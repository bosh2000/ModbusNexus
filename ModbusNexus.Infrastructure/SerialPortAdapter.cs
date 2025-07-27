using NModbus.IO;
using System.IO.Ports;

namespace ModbusNexus.Infrastructure
{
    public class SerialPortAdapter : IStreamResource
    {
        private readonly SerialPort _serialPort;

        public SerialPortAdapter(SerialPort serialPort)
        {
            _serialPort = serialPort;
        }

        public Stream Stream => _serialPort.BaseStream;
        public int ReadTimeout { get => _serialPort.ReadTimeout; set => _serialPort.ReadTimeout = value; }
        public int WriteTimeout { get => _serialPort.WriteTimeout; set => _serialPort.WriteTimeout = value; }

        public int InfiniteTimeout => throw new NotImplementedException();

        public void DiscardInBuffer()
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            _serialPort?.Dispose();
        }

        public int Read(byte[] buffer, int offset, int count)
        {
            throw new NotImplementedException();
        }

        public void Write(byte[] buffer, int offset, int count)
        {
            throw new NotImplementedException();
        }
    }
}