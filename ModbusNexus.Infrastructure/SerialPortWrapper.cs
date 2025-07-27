using ModbusNexus.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModbusNexus.Infrastructure
{
    public class SerialPortWrapper : ISerialPort
    {
        private readonly SerialPort _serialPort;

        public SerialPortWrapper(string portName, int baudRate)
        {
            _serialPort = new SerialPort(portName, baudRate);
        }

        public void Open() => _serialPort.Open();

        public void Close() => _serialPort.Close();

        public void DiscardInBuffer() => _serialPort.DiscardInBuffer();

        public void DiscardOutBuffer() => _serialPort.DiscardOutBuffer();

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public bool IsOpen => _serialPort.IsOpen;
        public Stream BaseStream => _serialPort.BaseStream;

        public int BaudRate
        {
            get => _serialPort.BaudRate;
            set => _serialPort.BaudRate = value;
        }

        public Parity Parity { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public StopBits StopBits { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public int ReadTimeout { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public int WriteTimeout { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public string PortName => throw new NotImplementedException();

        public int DataBits { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        // Остальные свойства аналогично
    }
}