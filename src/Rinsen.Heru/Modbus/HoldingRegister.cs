using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rinsen.Heru.Modbus
{
    internal enum HoldingRegister : ushort
    {
        TemperatureSetpointEconomy = 0x00001,
        TemperatureSetpointComfort = 0x00002,
        SupplyFanSpeed = 0x00003,
        ExhaustFanSpeed = 0x00004,
        MinExhaustFanSpeed = 0x00005,
        MaxExhaustFanSpeed = 0x00006,
        BoostDuration = 0x00027,
    }
}
