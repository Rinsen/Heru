using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rinsen.Heru.Modbus;

/// <summary>
/// Input status - Discrete Input (1bit) Read only
/// </summary>
internal enum InputStatus
{
    // Switch input registers
    /// <summary>
    /// Switch input D1
    /// </summary>
    FireAlarmInput = 0x00001,
    /// <summary>
    /// Switch input D2
    /// </summary>
    BoostInput = 0x00002,
    /// <summary>
    /// Switch input D3
    /// </summary>
    OverpressureInput = 0x00003,
    /// <summary>
    /// Switch input D4
    /// </summary>
    ExtendedOperationInput = 0x00004,
    /// <summary>
    /// Switch input D5
    /// </summary>
    AwayInput = 0x00005,
    /// <summary>
    /// Switch input D6
    /// </summary>
    FilterInput = 0x00006,
    /// <summary>
    /// Switch input D7
    /// </summary>
    HeaterInterlock = 0x00007,
    /// <summary>
    /// Switch input D8
    /// </summary>
    ExternalSummerWinterChangeover = 0x00008,
    /// <summary>
    /// Switch input D9
    /// </summary>
    EmergencyServiceStop = 0x00009,
    
    // Alarm registers
    FireAlarm = 0x00010,
    RotorAlarm = 0x00011,
    FreezeAlarm = 0x00013,
    LowSupplyAlarm = 0x00014,
    LowRotorTemperatureAlarm = 0x00015,
    TempSensorOpenCircuitAlarm = 0x00018,
    TempSensorShortCircuitAlarm = 0x00019,
    PulserAlarm = 0x00020,
    SupplyFanAlarm = 0x00021,
    ExhaustFanAlarm = 0x00022,
    SupplyFilterAlarm = 0x00023,
    ExhaustFilterAlarm = 0x00024,
    FilterTimerAlarm = 0x00025,
    FreezeProtectionBLevel = 0x00026,
    FreezeProtectionALevel = 0x00027,
    Startup1stPhaseDamperOpen = 0x00028,
    Startup2stPhaseSupplyFanRunning = 0x00029,
    Heating = 0x00030,
    RecoveryHeatCold = 0x00031,
    Cooling = 0x00032,
    CO2Boost = 0x00033,
    RHBoost = 0x00034,
    PumpAlarmHeating = 0x00035,
    PumpAlarmCooling = 0x00036,
    SNCActive = 0x00037,
    VOCBoost = 0x00038,
    PressureDeviationAlarmSupply = 0x00046,
    PressureDeviationAlarmExtract = 0x00047,
    LostComMiniExpansion = 0x00053

}
