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
        ComponentId = 0x00001,
        OutdoorTemperature = 0x00002,
        SupplyAirTemperature = 0x00003,
        ExtractAirTemperature = 0x00004,
        ExhaustAirTemperature = 0x00005,
        WaterTemperature = 0x00006,
        HeatRecoveryTemperature = 0x00007,
        RoomTemperature = 0x00008,
        RFUReadable1 = 0x00009,
        RFUReadable2 = 0x00010,
        RFUReadable3 = 0x00011,
        /// <summary>
        /// Should not be x0.1Pa, increase with x10
        /// </summary>
        SupplyPressureDuct = 0x00012,
        /// <summary>
        /// Should not be x0.1Pa, increase with x10
        /// </summary>
        ExtractPressureDuct = 0x00013,
        /// <summary>
        /// Bit mask. Bit is set if sensor is required and open circuit. See also Sensors shorted.
        /// </summary>
        SensorsOpen = 0x00018,
        /// <summary>
        /// it mask. Bit is set if sensor is required and shorted. Bit0 = T1 … Bit6 = T7.
        /// </summary>
        SensorsShorted = 0x00019,
        /// <summary>
        /// Number of days to filter change.
        /// </summary>
        FilterDaysLeft = 0x00020,
        /// <summary>
        /// 0 = none, 1-5 = program 1-5
        /// </summary>
        CurrentWeektimerProgram = 0x00021,
        /// <summary>
        /// 0 = Off, 1 = Min, 2 = Std, 3 = Max
        /// </summary>
        CurrentSupplyFanStep = 0x00023,
        /// <summary>
        /// 0 = Off, 1 = Min, 2 = Std, 3 = Max
        /// </summary>
        CurrentExhaustFanStep = 0x00024,
        CurrentSupplyFanPower = 0x00025,
        CurrentExhaustFanPower = 0x00026,
        CurrentSupplyFanSpeed = 0x00027,
        CurrentExhaustFanSpeed = 0x00028,
        /// <summary>
        /// 255 = 100%
        /// </summary>
        CurrentHeatingPower = 0x00029,
        /// <summary>
        /// 255 = 100%
        /// </summary>
        CurrentHeatColdRecoveryPower = 0x00030,
        /// <summary>
        /// 255 = 100%
        /// </summary>
        CurrentCoolingPower = 0x00031,
        SupplyFanControlVoltage = 0x00032,
        ExhaustFanControlVoltage = 0x00033,
        /// <summary>
        /// 0 = Off, 1 = On
        /// </summary>
        ChangeoverActive = 0x00034,
        /// <summary>
        /// 0 = None, 1 = RH, 2 = CO2, 3 = VOC
        /// </summary>
        QualitySensor1Type = 0x00041,
        /// <summary>
        /// "RH: 0-10V=0-100 (%)
        /// CO2: 0-10V = 0 - 2000(PPM)
        /// VOC: 0-10V = 0 - 2000(PPM)"
        /// </summary>
        QualitySensor1Value = 0x00042,
        QualitySensor2Type = 0x00043,
        QualitySensor2Value = 0x00044,
        QualitySensor3Type = 0x00045,
        QualitySensor3Value = 0x00046
    }
}
