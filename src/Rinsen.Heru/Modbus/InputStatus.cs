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
    FireAlarmInput = 1,
    /// <summary>
    /// Switch input D2
    /// </summary>
    BoostInput = 2,
    /// <summary>
    /// Switch input D3
    /// </summary>
    OverpressureInput = 3,
    /// <summary>
    /// Switch input D4
    /// </summary>
    ExtendedOperationInput = 4,
    /// <summary>
    /// Switch input D5
    /// </summary>
    AwayInput = 5,
    /// <summary>
    /// Switch input D6
    /// </summary>
    FilterInput = 6,
    /// <summary>
    /// Switch input D7
    /// </summary>
    HeaterInterlock = 7,
    /// <summary>
    /// Switch input D8
    /// </summary>
    ExternalSummerWinterChangeover = 8,
    /// <summary>
    /// Switch input D9
    /// </summary>
    EmergencyServiceStop = 9,
    
    // Alarm registers
    FireAlarm = 10,
    RotorAlarm = 11,
    FreezeAlarm = 13,
    LowSupplyAlarm = 14,
    LowRotorTemperatureAlarm = 15,
    TempSensorOpenCircuitAlarm = 18,
    TempSensorShortCircuitAlarm = 19,
    PulserAlarm = 20,
    SupplyFanAlarm = 21,
    ExhaustFanAlarm = 22,
    SupplyFilterAlarm = 23,
    ExhaustFilterAlarm = 24,
    FilterTimerAlarm = 25,
    FreezeProtectionBLevel = 26,
    FreezeProtectionALevel = 27,
    Startup1stPhaseDamperOpen = 28,
    Startup2stPhaseSupplyFanRunning = 29,
    Heating = 30,
    RecoveryHeatCold = 31,
    Cooling = 32,
    CO2Boost = 33,
    RHBoost = 34,
    PumpAlarmHeating = 35,
    PumpAlarmCooling = 36,
    SNCActive = 37,
    VOCBoost = 38,
    PreDefrost = 40,
    Defrost = 41,
    Error = 42,
    GasAlarm = 43,
    PressureDeviationAlarmSupply = 46,
    PressureDeviationAlarmExtract = 47,
    FlowDeviationAlarmSupply = 48,
    FlowDeviationAlarmExtract = 49,
    LostComDuctPressureSensor = 50,
    LostComDuctFlowPressureSensor = 51,
    LostComDuctFilterPressureSensor = 52,
    LostComMiniExpansion = 53,
    LostCom = 54,
}
