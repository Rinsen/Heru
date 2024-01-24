using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rinsen.Heru.Modbus
{
    /// <summary>
    /// Input register - 16 bit integer register Read only
    /// </summary>
    internal enum InputRegister : ushort
    {
        /// <summary>
        /// Always 10
        /// </summary>
        ComponentId = 1,
        /// <summary>
        /// </summary>
        OutdoorTemperature = 2,
        SupplyAirTemperature = 3,
        ExtractAirTemperature = 4,
        ExhaustAirTemperature = 5,
        WaterTemperature = 6,
        HeatRecoveryTemperature = 7,
        RoomTemperature = 8,
        RFUReadable1 = 9,
        RFUReadable2 = 10,
        RFUReadable3 = 11,
        /// <summary>
        /// Should not be x0.1Pa, increase with x10
        /// </summary>
        SupplyPressureDuct = 12,
        /// <summary>
        /// Should not be x0.1Pa, increase with x10
        /// </summary>
        ExtractPressureDuct = 13,
        /// <summary>
        /// Bit mask. Bit is set if sensor is required and open circuit. See also Sensors shorted.
        /// </summary>
        SensorsOpen = 18,
        /// <summary>
        /// it mask. Bit is set if sensor is required and shorted. Bit0 = T1 … Bit6 = T7.
        /// </summary>
        SensorsShorted = 19,
        /// <summary>
        /// Number of days to filter change.
        /// </summary>
        FilterDaysLeft = 20,
        /// <summary>
        /// 0 = none, 1-5 = program 1-5
        /// </summary>
        CurrentWeektimerProgram = 21,
        /// <summary>
        /// 0 = Off, 1 = Min, 2 = Std, 3 = Max
        /// </summary>
        CurrentSupplyFanStep = 23,
        /// <summary>
        /// 0 = Off, 1 = Min, 2 = Std, 3 = Max
        /// </summary>
        CurrentExhaustFanStep = 24,
        CurrentSupplyFanPower = 25,
        CurrentExhaustFanPower = 26,
        CurrentSupplyFanSpeed = 27,
        CurrentExhaustFanSpeed = 28,
        /// <summary>
        /// 255 = 100%
        /// </summary>
        CurrentHeatingPower = 29,
        /// <summary>
        /// 255 = 100%
        /// </summary>
        CurrentHeatColdRecoveryPower = 30,
        /// <summary>
        /// 255 = 100%
        /// </summary>
        CurrentCoolingPower = 31,
        SupplyFanControlVoltage = 32,
        ExhaustFanControlVoltage = 33,
        /// <summary>
        /// 0 = Off, 1 = On
        /// </summary>
        ChangeoverActive = 34,
        /// <summary>
        /// 0 = None, 1 = RH, 2 = CO2, 3 = VOC
        /// </summary>
        QualitySensor1Type = 41,
        /// <summary>
        /// "RH: 0-10V=0-100 (%)
        /// CO2: 0-10V = 0 - 2000(PPM)
        /// VOC: 0-10V = 0 - 2000(PPM)"
        /// </summary>
        QualitySensor1Value = 42,
        QualitySensor2Type = 43,
        QualitySensor2Value = 44,
        QualitySensor3Type = 45,
        QualitySensor3Value = 46
    }
}
