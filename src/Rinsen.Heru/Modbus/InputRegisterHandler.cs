using NModbus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Rinsen.Heru.Modbus
{
    internal class InputRegisterHandler
    {

        internal async Task<Dictionary<InputRegister, ushort>> ReadInputRegistersAsync(ModbusOptions options, InputRegister inputRegister, ushort numberOfPoints)
        {
            using TcpClient client = new TcpClient(options.IpAddressOrHostName, options.PortNumber);

            var factory = new ModbusFactory();
            IModbusMaster master = factory.CreateMaster(client);

            var inputRegisters = await master.ReadInputRegistersAsync(0, (ushort)(inputRegister - 1), numberOfPoints);

            var result = new Dictionary<InputRegister, ushort>();

            for (int i = 0; i < numberOfPoints; i++)
            {
                result.Add((InputRegister)(i + (int)inputRegister), inputRegisters[i]);
            }

            return result;
        }
    }
}
