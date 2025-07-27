using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Text;

namespace ModbusNexus.Core.Interfaces
{
    public interface ISerialPortFactory
    {
        ISerialPort Create(string portName, int baudRate, Parity parity, int dataBits, StopBits stopBits);
    }
}