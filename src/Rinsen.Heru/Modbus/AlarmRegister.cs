namespace Rinsen.Heru.Modbus;

/// <summary>
/// Alarm registers - Discrete Input (1bit) Read only
/// </summary>
internal enum AlarmRegister : ushort
{
    /// <summary>
    /// Fire alarm input is active.
    /// </summary>
    FireAlarm = 10,

    /// <summary>
    /// Rotor (heat exchanger wheel) alarm is active.
    /// </summary>
    RotorAlarm = 11,

    /// <summary>
    /// Freeze alarm is active.
    /// </summary>
    FreezeAlarm = 13,

    /// <summary>
    /// Low supply air temperature alarm is active.
    /// </summary>
    LowSupplyAlarm = 14,

    /// <summary>
    /// Low rotor temperature alarm is active.
    /// </summary>
    LowRotorTemperatureAlarm = 15,

    /// <summary>
    /// Temperature sensor open-circuit alarm is active.
    /// </summary>
    TempSensorOpenCircuitAlarm = 18,

    /// <summary>
    /// Temperature sensor short-circuit alarm is active.
    /// </summary>
    TempSensorShortCircuitAlarm = 19,

    /// <summary>
    /// Pulser alarm is active.
    /// </summary>
    PulserAlarm = 20,

    /// <summary>
    /// Supply fan alarm is active.
    /// </summary>
    SupplyFanAlarm = 21,

    /// <summary>
    /// Exhaust fan alarm is active.
    /// </summary>
    ExhaustFanAlarm = 22,

    /// <summary>
    /// Supply air filter alarm is active.
    /// </summary>
    SupplyFilterAlarm = 23,

    /// <summary>
    /// Exhaust air filter alarm is active.
    /// </summary>
    ExhaustFilterAlarm = 24,

    /// <summary>
    /// Filter timer alarm is active (scheduled filter service interval elapsed).
    /// </summary>
    FilterTimerAlarm = 25,

    /// <summary>
    /// Freeze protection level B is active.
    /// </summary>
    FreezeProtectionBLevel = 26,

    /// <summary>
    /// Freeze protection level A is active.
    /// </summary>
    FreezeProtectionALevel = 27,

    /// <summary>
    /// Startup phase 1 is active: damper open.
    /// </summary>
    Startup1stPhaseDamperOpen = 28,

    /// <summary>
    /// Startup phase 2 is active: supply fan running.
    /// </summary>
    Startup2stPhaseSupplyFanRunning = 29,

    /// <summary>
    /// Heating output is active.
    /// </summary>
    Heating = 30,

    /// <summary>
    /// Heat/cold recovery function is active.
    /// </summary>
    RecoveryHeatCold = 31,

    /// <summary>
    /// Cooling output is active.
    /// </summary>
    Cooling = 32,

    /// <summary>
    /// CO₂ boost mode is active.
    /// </summary>
    CO2Boost = 33,

    /// <summary>
    /// Relative humidity (RH) boost mode is active.
    /// </summary>
    RHBoost = 34,

    /// <summary>
    /// Heating circulation pump alarm is active.
    /// </summary>
    PumpAlarmHeating = 35,

    /// <summary>
    /// Cooling circulation pump alarm is active.
    /// </summary>
    PumpAlarmCooling = 36,

    /// <summary>
    /// SNC function is active.
    /// </summary>
    SNCActive = 37,

    /// <summary>
    /// VOC boost mode is active.
    /// </summary>
    VOCBoost = 38,

    /// <summary>
    /// Pre-defrost mode is active.
    /// </summary>
    PreDefrost = 40,

    /// <summary>
    /// Defrost mode is active.
    /// </summary>
    Defrost = 41,

    /// <summary>
    /// Generic unit error state is active.
    /// </summary>
    Error = 42,

    /// <summary>
    /// Gas alarm is active.
    /// </summary>
    GasAlarm = 43,

    /// <summary>
    /// Supply air pressure deviation alarm is active.
    /// </summary>
    PressureDeviationAlarmSupply = 46,

    /// <summary>
    /// Extract air pressure deviation alarm is active.
    /// </summary>
    PressureDeviationAlarmExtract = 47,

    /// <summary>
    /// Supply air flow deviation alarm is active.
    /// </summary>
    FlowDeviationAlarmSupply = 48,

    /// <summary>
    /// Extract air flow deviation alarm is active.
    /// </summary>
    FlowDeviationAlarmExtract = 49,

    /// <summary>
    /// Communication with duct pressure sensor is lost.
    /// </summary>
    LostComDuctPressureSensor = 50,

    /// <summary>
    /// Communication with duct flow pressure sensor is lost.
    /// </summary>
    LostComDuctFlowPressureSensor = 51,

    /// <summary>
    /// Communication with duct filter pressure sensor is lost.
    /// </summary>
    LostComDuctFilterPressureSensor = 52,

    /// <summary>
    /// Communication with mini expansion module is lost.
    /// </summary>
    LostComMiniExpansion = 53,

    /// <summary>
    /// General communication loss alarm is active.
    /// </summary>
    LostCom = 54,
}
