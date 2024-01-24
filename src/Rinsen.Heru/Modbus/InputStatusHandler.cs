using NModbus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rinsen.Heru.Modbus
{
    internal class InputStatusHandler
    {
        internal async Task<Dictionary<InputStatus, bool>> ReadInputRegistersToDictionaryAsync(IModbusMaster modbusMaster, InputStatus inputStatus, ushort numberOfPoints)
        {
            var inputStatuses = await modbusMaster.ReadInputsAsync(0, (ushort)(inputStatus - 1), numberOfPoints);

            var result = new Dictionary<InputStatus, bool>();

            for (int i = 0; i < numberOfPoints; i++)
            {
                result.Add((InputStatus)(i + (ushort)inputStatus), inputStatuses[i]);
            }

            return result;
        }


    }
}
