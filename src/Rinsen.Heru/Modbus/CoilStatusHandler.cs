using NModbus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Rinsen.Heru.Modbus
{
    internal class CoilStatusHandler
    {

        public async Task<bool[]> ReadCoilsAsync(ModbusOptions options, CoilStatus startCoilStatus, ushort numberOfPoints)
        {
            using TcpClient client = new TcpClient(options.IpAddressOrHostName, options.PortNumber);

            var factory = new ModbusFactory();
            IModbusMaster master = factory.CreateMaster(client);

            var coilStatus = await master.ReadCoilsAsync(0, (ushort)(startCoilStatus - 1), numberOfPoints);

            return coilStatus;
        }

        internal async Task WriteSingleCoilAsync(ModbusOptions options, CoilStatus coilStatus, bool newStatus)
        {
            using TcpClient client = new TcpClient(options.IpAddressOrHostName, options.PortNumber);

            var factory = new ModbusFactory();
            IModbusMaster master = factory.CreateMaster(client);

            await master.WriteSingleCoilAsync(0, (ushort)(coilStatus - 1), newStatus);

            var result = await master.ReadCoilsAsync(0, (ushort)(coilStatus - 1), 1);

            if (result[0] != newStatus)
            {
                throw new Exception("Write failed");
            }
        }
    }
}
