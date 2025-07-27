using ModbusNexus.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModbusNexus.Infrastructure
{
    public class SystemSerialPortWrapper : ISerialPort
    {
        private readonly SerialPort _serialPort;

        public SystemSerialPortWrapper(string portName, int baudRate, Parity parity, int dataBits, StopBits stopBits)
        {
            _serialPort = new SerialPort(portName, baudRate, parity, dataBits, stopBits)
            {
                ReadTimeout = 1000,
                WriteTimeout = 1000
            };
        }

        public void DiscardInBuffer() => _serialPort.DiscardInBuffer();

        public void DiscardOutBuffer() => _serialPort.DiscardOutBuffer();

        public void Open() => _serialPort.Open();

        public void Close() => _serialPort.Close();

        public bool IsOpen => _serialPort.IsOpen;
        public Stream BaseStream => _serialPort.BaseStream;
        public string PortName => _serialPort.PortName;
        public int BaudRate { get => _serialPort.BaudRate; set => _serialPort.BaudRate = value; }
        public Parity Parity { get => _serialPort.Parity; set => _serialPort.Parity = value; }
        public int DataBits { get => _serialPort.DataBits; set => _serialPort.DataBits = value; }
        public StopBits StopBits { get => _serialPort.StopBits; set => _serialPort.StopBits = value; }
        public int ReadTimeout { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public int WriteTimeout { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public void Dispose() => _serialPort.Dispose();
    }
}