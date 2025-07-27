using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Text;
using System.Threading.Tasks;

namespace ModbusNexus.Core.Interfaces
{
    public interface IModbusService
    {
        // Подключение/отключение
        Task<bool> ConnectRTUAsync(string portName, int baudRate, int dataBits = 8, Parity parity = Parity.None, StopBits stopBits = StopBits.One);

        Task<bool> ConnectTCPAsync(string ipAddress, int port);

        void Disconnect();

        // Чтение данных
        Task<ushort[]> ReadHoldingRegistersAsync(byte slaveId, ushort startAddress, ushort count);

        Task<ushort[]> ReadInputRegistersAsync(byte slaveId, ushort startAddress, ushort count);

        Task<bool[]> ReadCoilsAsync(byte slaveId, ushort startAddress, ushort count);

        Task<bool[]> ReadDiscreteInputsAsync(byte slaveId, ushort startAddress, ushort count);

        // Запись данных
        Task WriteSingleRegisterAsync(byte slaveId, ushort registerAddress, ushort value);

        Task WriteMultipleRegistersAsync(byte slaveId, ushort startAddress, ushort[] values);

        Task WriteSingleCoilAsync(byte slaveId, ushort coilAddress, bool value);

        Task WriteMultipleCoilsAsync(byte slaveId, ushort startAddress, bool[] values);

        // Утилиты
        bool IsConnected { get; }

        string LastErrorMessage { get; }

        event EventHandler<ModbusDataReceivedEventArgs> DataReceived;
    }

    public class ModbusDataReceivedEventArgs : EventArgs
    {
        public byte SlaveId { get; set; }
        public ModbusDataType DataType { get; set; }
        public ushort StartAddress { get; set; }
        public object Data { get; set; } // Может быть ushort[] или bool[]
    }

    public enum ModbusDataType
    {
        HoldingRegister,
        InputRegister,
        Coil,
        DiscreteInput
    }
}