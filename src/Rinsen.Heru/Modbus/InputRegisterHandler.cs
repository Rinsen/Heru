using NModbus;
using System.Net.Sockets;

namespace Rinsen.Heru.Modbus
{
    internal class InputRegisterHandler
    {

        internal async Task<Dictionary<InputRegister, ushort>> ReadInputRegistersToDictionaryAsync(ModbusOptions options, InputRegister inputRegister, ushort numberOfPoints)
        {
            var inputRegisters = await ReadInputRegistersAsync(options, inputRegister, numberOfPoints);

            var result = new Dictionary<InputRegister, ushort>();

            for (int i = 0; i < numberOfPoints; i++)
            {
                result.Add((InputRegister)(i + (int)inputRegister), inputRegisters[i]);
            }

            return result;
        }

        internal async Task<ushort[]> ReadInputRegistersAsync(ModbusOptions options, InputRegister inputRegister, ushort numberOfPoints)
        {
            using var client = new TcpClient(options.IpAddressOrHostName, options.PortNumber);

            var factory = new ModbusFactory();
            IModbusMaster master = factory.CreateMaster(client);

            return await master.ReadInputRegistersAsync(0, (ushort)(inputRegister - 1), numberOfPoints);
        }
    }
}
