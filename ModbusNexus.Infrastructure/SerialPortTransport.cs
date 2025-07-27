using ModbusNexus.Core.Interfaces;
using NModbus;
using NModbus.IO;
using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModbusNexus.Infrastructure
{
    public class SerialPortTransport : IModbusSerialTransport
    {
        private readonly ISerialPort _serialPort;

        public SerialPortTransport(ISerialPort serialPort)
        {
            _serialPort = serialPort;
            //Stream = new SerialPortStream(serialPort);
        }

        public Stream Stream => _serialPort.BaseStream;
        public int ReadTimeout { get => _serialPort.ReadTimeout; set => _serialPort.ReadTimeout = value; }
        public int WriteTimeout { get => _serialPort.WriteTimeout; set => _serialPort.WriteTimeout = value; }
        public bool CheckFrame { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public int Retries { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public uint RetryOnOldResponseThreshold { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public bool SlaveBusyUsesRetryCount { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public int WaitToRetryMilliseconds { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public IStreamResource StreamResource => throw new NotImplementedException();

        public byte[] BuildMessageFrame(IModbusMessage message)
        {
            throw new NotImplementedException();
        }

        public bool ChecksumsMatch(IModbusMessage message, byte[] messageFrame)
        {
            throw new NotImplementedException();
        }

        public void DiscardInBuffer()
        {
            _serialPort.DiscardInBuffer();
        }

        public Task DiscardInBufferAsync(CancellationToken cancellationToken = default)
        {
            _serialPort.DiscardInBuffer();
            return Task.CompletedTask;
        }

        public void Dispose()
        {
            _serialPort?.Dispose();
            Stream?.Dispose();
        }

        public void IgnoreResponse()
        {
            throw new NotImplementedException();
        }

        public byte[] ReadRequest()
        {
            throw new NotImplementedException();
        }

        public T UnicastMessage<T>(IModbusMessage message) where T : IModbusMessage, new()
        {
            throw new NotImplementedException();
        }

        public void Write(IModbusMessage message)
        {
            throw new NotImplementedException();
        }
    }
}