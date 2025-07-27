using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.IO;
using System.Text;

namespace ModbusNexus.Core.Interfaces
{
    public interface ISerialPort : IDisposable
    {
        void Open();

        void Close();

        bool IsOpen { get; }
        Stream BaseStream { get; }

        void DiscardInBuffer();

        void DiscardOutBuffer();

        // Таймауты
        int ReadTimeout { get; set; }

        int WriteTimeout { get; set; }

        // Параметры соединения
        string PortName { get; }

        int BaudRate { get; set; }
        Parity Parity { get; set; }
        int DataBits { get; set; }
        StopBits StopBits { get; set; }
    }
}