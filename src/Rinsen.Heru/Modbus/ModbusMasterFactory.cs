using System.Net.Sockets;
using NModbus;
using NModbus.Logging;

namespace Rinsen.Heru.Modbus
{

    internal interface IModbusMasterFactory
    {
        IModbusMaster GetModbusMaster();
    }

    internal class ModbusMasterFactory : IModbusMasterFactory, IDisposable
    {
        private readonly ModbusOptions _modbusOptions;
        private TcpClient? _tcpClient = null;
        private IModbusMaster? _modbusMaster = null;
        private bool disposedValue;

        public ModbusMasterFactory(ModbusOptions modbusOptions)
        {
            _modbusOptions = modbusOptions;
        }

        public IModbusMaster GetModbusMaster()
        {
            if (_modbusMaster != null)
            {
                return _modbusMaster;
            }

            _tcpClient = new TcpClient(_modbusOptions.IpAddressOrHostName, _modbusOptions.PortNumber);

            var factory = new ModbusFactory(logger: new DebugModbusLogger(LoggingLevel.Trace));
            _modbusMaster = factory.CreateMaster(_tcpClient);

            return _modbusMaster;
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    // TODO: dispose managed state (managed objects)
                    _tcpClient?.Dispose();
                    _tcpClient = null;
                    _modbusMaster?.Dispose();
                    _modbusMaster = null;
                }

                // TODO: free unmanaged resources (unmanaged objects) and override finalizer
                // TODO: set large fields to null
                disposedValue = true;
            }
        }

        // // TODO: override finalizer only if 'Dispose(bool disposing)' has code to free unmanaged resources
        // ~ModbusMasterFactory()
        // {
        //     // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
        //     Dispose(disposing: false);
        // }

        public void Dispose()
        {
            // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }
    }
}
