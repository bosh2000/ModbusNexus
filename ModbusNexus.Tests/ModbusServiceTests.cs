using FluentAssertions;
using Microsoft.Extensions.Logging;
using ModbusNexus.Core.Interfaces;
using ModbusNexus.Infrastructure;
using Moq;
using System.IO.Ports;

namespace ModbusNexus.Tests
{
    public class ModbusServiceTests
    {
        private readonly Mock<ISerialPort> _serialPortMock;
        private readonly Mock<ILogger<ModbusService>> _loggerMock;
        private readonly Mock<ISerialPortFactory> _portFactoryMock;
        private readonly ModbusService _service;

        public ModbusServiceTests()
        {
            _serialPortMock = new Mock<ISerialPort>();
            _loggerMock = new Mock<ILogger<ModbusService>>();
            _portFactoryMock = new Mock<ISerialPortFactory>();

            _portFactoryMock
                .Setup(f => f.Create(It.IsAny<string>(), It.IsAny<int>(), It.IsAny<Parity>(),
                       It.IsAny<int>(), It.IsAny<StopBits>()))
                .Returns(_serialPortMock.Object);

            _service = new ModbusService(_loggerMock.Object, _portFactoryMock.Object);
        }

        [Fact]
        public async Task ConnectRTUAsync_ShouldReturnTrue_WhenPortOpensSuccessfully()
        {
            // Arrange
            _serialPortMock.Setup(p => p.Open());
            _serialPortMock.SetupGet(p => p.IsOpen).Returns(true);

            // Act
            var result = await _service.ConnectRTUAsync("COM3", 9600);

            // Assert
            result.Should().BeTrue();
            _serialPortMock.Verify(p => p.Open(), Times.Once);
            _loggerMock.Verify(
                    x => x.Log(
                        LogLevel.Information,
                        It.IsAny<EventId>(),
                        It.Is<It.IsAnyType>((v, t) => v.ToString().Contains("Connected to COM3 at 9600 bps")),
                        It.IsAny<Exception>(),
                        It.IsAny<Func<It.IsAnyType, Exception, string>>()
                    ),
                    Times.Once);
        }

        [Fact]
        public async Task ConnectRTUAsync_ShouldReturnFalse_WhenPortFailsToOpen()
        {
            // Arrange
            _serialPortMock.Setup(p => p.Open())
                .Throws(new IOException("Port unavailable"));

            // Act
            var result = await _service.ConnectRTUAsync("COM3", 9600);

            // Assert
            result.Should().BeFalse();
            _loggerMock.Verify(
                    x => x.Log(
                        LogLevel.Error,
                        It.IsAny<EventId>(),
                        It.Is<It.IsAnyType>((v, t) => v.ToString().Contains("Modbus RTU error")),
                        It.IsAny<Exception>(),
                        It.IsAny<Func<It.IsAnyType, Exception, string>>()
                    ),
                    Times.Once);
        }
    }
}