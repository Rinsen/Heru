using NModbus;

namespace Rinsen.Heru.Modbus
{
    internal class InputRegisterHandler
    {

        internal async Task<Dictionary<InputRegister, ushort>> ReadInputRegistersToDictionaryAsync(IModbusMaster modbusMaster, InputRegister inputRegister, ushort numberOfPoints)
        {
            var inputRegisters = await modbusMaster.ReadInputRegistersAsync(0, (ushort)(inputRegister - 1), numberOfPoints);

            var result = new Dictionary<InputRegister, ushort>();

            for (int i = 0; i < numberOfPoints; i++)
            {
                result.Add((InputRegister)(i + (ushort)inputRegister), inputRegisters[i]);
            }

            return result;
        }
    }
}
