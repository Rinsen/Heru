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

    }
}
