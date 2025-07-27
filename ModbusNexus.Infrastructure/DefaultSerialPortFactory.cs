using ModbusNexus.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModbusNexus.Infrastructure
{
    public class DefaultSerialPortFactory : ISerialPortFactory
    {
        public ISerialPort Create(string portName, int baudRate, Parity parity, int dataBits, StopBits stopBits)
        {
            return new SystemSerialPortWrapper(portName, baudRate, parity, dataBits, stopBits);
        }
    }
}