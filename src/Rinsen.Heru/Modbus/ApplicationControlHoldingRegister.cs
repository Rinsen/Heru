namespace Rinsen.Heru.Modbus
{
    /// <summary>
    /// Holding registers that store writable setpoints, configuration, and the unit clock.
    /// </summary>
    internal enum ApplicationControlHoldingRegister : ushort
    {
        #region Temperature and Fan Control

        /// <summary>
        /// Economy temperature setpoint used when the unit is in reduced operation (15-39°C).
        /// </summary>
        TemperatureSetpointEconomy = 1,
        /// <summary>
        /// Comfort temperature setpoint used during normal occupied operation (15-40°C).
        /// </summary>
        TemperatureSetpointComfort = 2,
        /// <summary>
        /// Requested supply fan speed setpoint (0-100%).
        /// </summary>
        SupplyFanSpeed = 3,
        /// <summary>
        /// Requested exhaust fan speed setpoint (0-100%).
        /// </summary>
        ExhaustFanSpeed = 4,
        /// <summary>
        /// Lower limit used when calculating the exhaust fan speed (0-100%).
        /// </summary>
        MinExhaustFanSpeed = 5,
        /// <summary>
        /// Upper limit used when calculating the exhaust fan speed (0-100%).
        /// </summary>
        MaxExhaustFanSpeed = 6,
        /// <summary>
        /// Standard supply fan airflow setpoint (0-9999 l/s). Only for regulation type CAV.
        /// </summary>
        StdSupplyFanAirflowSetpoint = 7,
        /// <summary>
        /// Standard exhaust fan airflow setpoint (0-9999 l/s). Only for regulation type CAV.
        /// </summary>
        StdExhaustFanAirflowSetpoint = 8,
        /// <summary>
        /// Minimum exhaust fan airflow setpoint (0-9999 l/s). Only for regulation type CAV.
        /// </summary>
        MinExhaustFanAirflowSetpoint = 9,
        /// <summary>
        /// Maximum exhaust fan airflow setpoint (0-9999 l/s). Only for regulation type CAV.
        /// </summary>
        MaxExhaustFanAirflowSetpoint = 10,
        /// <summary>
        /// Reserved. Readable, value has no meaning.
        /// </summary>
        Reserved11 = 11,
        /// <summary>
        /// Temperature regulation mode (0: Supply, 1: Extract, 2: Room, 3: Extract S/W, 4: Room S/W).
        /// </summary>
        TemperatureRegulationMode = 12,
        /// <summary>
        /// Minimum supply temperature (15-19°C).
        /// </summary>
        MinSupplyTemperature = 13,
        /// <summary>
        /// Maximum supply temperature (20-40°C).
        /// </summary>
        MaxSupplyTemperature = 14,
        /// <summary>
        /// Supply cold limit A (2-10°C).
        /// </summary>
        SupplyColdLimitA = 15,
        /// <summary>
        /// Supply cold limit B (5-12°C). Must be greater than limit A.
        /// </summary>
        SupplyColdLimitB = 16,
        /// <summary>
        /// Freeze protection limit (5-10°C).
        /// </summary>
        FreezeProtectionLimit = 17,
        /// <summary>
        /// Reserved. Readable, value has no meaning.
        /// </summary>
        Reserved18 = 18,

        #endregion

        #region SNC (Thermal Comfort) Settings

        /// <summary>
        /// SNC (Summer Night Cooling) enabled (0=no, 1=yes).
        /// </summary>
        SncEnabled = 19,
        /// <summary>
        /// SNC indoor-outdoor difference limit (10-1000, 0.1°C steps).
        /// </summary>
        SncIndoorOutdoorDiffLimit = 20,
        /// <summary>
        /// SNC exhaust high limit (18-24°C).
        /// </summary>
        SncExhaustHighLimit = 21,
        /// <summary>
        /// SNC exhaust low limit (19-26°C).
        /// </summary>
        SncExhaustLowLimit = 22,

        #endregion

        #region Standby and Boost Control

        /// <summary>
        /// Standby temperature evaluation enabled (0=no, 1=yes).
        /// </summary>
        StandbyTempEvaluationEnabled = 23,
        /// <summary>
        /// Evaluation interval (1-4 hours).
        /// </summary>
        Interval = 24,
        /// <summary>
        /// Evaluation time (5-15 minutes).
        /// </summary>
        EvaluationTime = 25,
        /// <summary>
        /// Minimum operating time (30-120 minutes).
        /// </summary>
        MinOperatingTime = 26,
        /// <summary>
        /// Boost duration (10-240 minutes).
        /// </summary>
        BoostDuration = 27,
        /// <summary>
        /// Overpressure duration (10-60 minutes).
        /// </summary>
        OverpressureDuration = 28,
        /// <summary>
        /// Overpressure offset (5-100%). Maximum value of difference between EC Min and EC Max.
        /// </summary>
        OverpressureOffset = 29,

        #endregion

        #region Fire Safety

        /// <summary>
        /// Fire sensor type (0: None, 1: Normally open (NO), 2: Normally closed (NC)).
        /// </summary>
        FireSensorType = 30,
        /// <summary>
        /// Fire mode (0: Fans off, 1: Exhaust fan only, 2: Supply fan only, 3: Both fans).
        /// </summary>
        FireMode = 31,

        #endregion

        #region Forced Fan Speed

        /// <summary>
        /// Forced fanspeed for supply (20-100%).
        /// </summary>
        ForcedFanspeedSupply = 32,
        /// <summary>
        /// Forced fanspeed for exhaust (20-100%).
        /// </summary>
        ForcedFanspeedExhaust = 33,
        /// <summary>
        /// Reserved. Readable, value has no meaning.
        /// </summary>
        Reserved34 = 34,
        /// <summary>
        /// Reserved. Readable, value has no meaning.
        /// </summary>
        Reserved35 = 35,
        /// <summary>
        /// Reserved. Readable, value has no meaning.
        /// </summary>
        Reserved36 = 36,

        #endregion

        #region Filter Measurement

        /// <summary>
        /// Filter measurement weekday (0=Monday, 1=Tuesday, ..., 6=Sunday).
        /// </summary>
        FilterMeasurementWeekday = 37,
        /// <summary>
        /// Filter measurement hour (0-23).
        /// </summary>
        FilterMeasurementHour = 38,
        /// <summary>
        /// Filter measurement minute (0-59).
        /// </summary>
        FilterMeasurementMinute = 39,
        /// <summary>
        /// Filter speed increase (5-50% points).
        /// </summary>
        FilterSpeedIncrease = 40,
        /// <summary>
        /// Filter measurement mode (0: Off, 1: Switch, 2: Speed inc., 3: Differential).
        /// </summary>
        FilterMeasurementMode = 41,
        /// <summary>
        /// Supply filter final pressure difference (20-500 Pa).
        /// </summary>
        SupplyFilterFinalPressureDiff = 42,
        /// <summary>
        /// Extract filter final pressure difference (20-500 Pa).
        /// </summary>
        ExtractFilterFinalPressureDiff = 43,
        /// <summary>
        /// Filter change period in months (0: off, 6-12: time in months, 30 days each).
        /// </summary>
        FilterChangePeriod = 44,

        #endregion

        #region Alarm Configuration

        /// <summary>
        /// Alarm classes (0-65535). Bit mask defining which alarms are classified as A or B.
        /// </summary>
        AlarmClasses = 45,
        /// <summary>
        /// Alarm relay output (0-65535). Bit mask for which alarms trigger the relay.
        /// </summary>
        AlarmRelayOutput = 46,
        /// <summary>
        /// Alarm relay state, contact function at normal operation (0-7). Bit mask: 0=NO, 1=NC.
        /// </summary>
        AlarmRelayStateContactFunction = 47,

        #endregion

        #region Temperature Control Extension

        /// <summary>
        /// Setpoint maximum limit for comfort mode (15-40°C). Maximum selectable temperature setpoint.
        /// </summary>
        SetpointMaxLimitComfort = 48,
        /// <summary>
        /// Economy setpoint enabled (0=no, 1=yes).
        /// </summary>
        EcoSetpointEnabled = 49,
        /// <summary>
        /// Reserved. Readable, value has no meaning.
        /// </summary>
        Reserved50 = 50,
        /// <summary>
        /// Reserved. Readable, value has no meaning.
        /// </summary>
        Reserved51 = 51,

        #endregion

        #region Seasonal Control

        /// <summary>
        /// Changeover type (0: Temperature, 1: Date, 2: External input).
        /// </summary>
        ChangeoverType = 52,
        /// <summary>
        /// Supply temperature offset (-10 to 10 K).
        /// </summary>
        SupplyTemperatureOffset = 53,
        /// <summary>
        /// Winter start temperature (-40 to 40°C).
        /// </summary>
        WinterStart = 54,
        /// <summary>
        /// Summer start temperature (-40 to 40°C).
        /// </summary>
        SummerStart = 55,
        /// <summary>
        /// Time constant (0-1000 hours).
        /// </summary>
        TimeConstant = 56,
        /// <summary>
        /// Winter start date (MMDD format, e.g., 1102 = November 2).
        /// </summary>
        WinterStartDate = 57,
        /// <summary>
        /// Summer start date (MMDD format, e.g., 0930 = September 30).
        /// </summary>
        SummerStartDate = 58,
        /// <summary>
        /// Reserved. Readable, value has no meaning.
        /// </summary>
        Reserved59 = 59,
        /// <summary>
        /// Reserved. Readable, value has no meaning.
        /// </summary>
        Reserved60 = 60,

        #endregion

        #region Damper and Heat Recovery

        /// <summary>
        /// Flow direction (0: standard, 1: opposite).
        /// </summary>
        FlowDirection = 61,
        /// <summary>
        /// Damper opening time (30-120 seconds).
        /// </summary>
        DamperOpeningTime = 62,

        #endregion

        #region Heater and Cooler Configuration

        /// <summary>
        /// Preheater type (0: None, 1: Electric).
        /// </summary>
        PreheaterType = 63,
        /// <summary>
        /// Preheater enabled (0=no, 1=yes).
        /// </summary>
        PreheaterEnabled = 64,
        /// <summary>
        /// Preheater temperature setpoint (-40 to 40°C).
        /// </summary>
        PreheaterTemperatureSetpoint = 65,
        /// <summary>
        /// Heater type (0: None, 1: Water, 2: Electric).
        /// </summary>
        HeaterType = 66,
        /// <summary>
        /// Heater enabled (0=no, 1=yes).
        /// </summary>
        HeaterEnabled = 67,
        /// <summary>
        /// Cooler type (0: None, 1: Water).
        /// </summary>
        CoolerType = 68,
        /// <summary>
        /// Cooler enabled (0=no, 1=yes).
        /// </summary>
        CoolerEnabled = 69,

        #endregion

        #region DX and Gas Detection

        /// <summary>
        /// DX Defrost supply fan reduction (10-50%).
        /// </summary>
        DXDefrostSupplyFanReduction = 70,
        /// <summary>
        /// Gas Detection Input enable (0=no, 1=yes).
        /// </summary>
        GasDetectionInputEnable = 71,
        /// <summary>
        /// Gas Detect forced fan speed (10-50%).
        /// </summary>
        GasDetectForcedFanSpeed = 72,
        /// <summary>
        /// Reserved. Readable, value has no meaning.
        /// </summary>
        Reserved73 = 73,
        /// <summary>
        /// Reserved. Readable, value has no meaning.
        /// </summary>
        Reserved74 = 74,
        /// <summary>
        /// Reserved. Readable, value has no meaning.
        /// </summary>
        Reserved75 = 75,
        /// <summary>
        /// Reserved. Readable, value has no meaning.
        /// </summary>
        Reserved76 = 76,
        /// <summary>
        /// Reserved. Readable, value has no meaning.
        /// </summary>
        Reserved77 = 77,
        /// <summary>
        /// Reserved. Readable, value has no meaning.
        /// </summary>
        Reserved78 = 78,
        /// <summary>
        /// Reserved. Readable, value has no meaning.
        /// </summary>
        Reserved79 = 79,
        /// <summary>
        /// Reserved. Readable, value has no meaning.
        /// </summary>
        Reserved80 = 80,

        #endregion

        #region Sensor Calibration

        /// <summary>
        /// Temperature sensor 1 calibration offset (-50 to 50 × 0.1°C).
        /// </summary>
        TempSensor1Calibration = 81,
        /// <summary>
        /// Temperature sensor 2 calibration offset (-50 to 50 × 0.1°C).
        /// </summary>
        TempSensor2Calibration = 82,
        /// <summary>
        /// Temperature sensor 3 calibration offset (-50 to 50 × 0.1°C).
        /// </summary>
        TempSensor3Calibration = 83,
        /// <summary>
        /// Temperature sensor 4 calibration offset (-50 to 50 × 0.1°C).
        /// </summary>
        TempSensor4Calibration = 84,
        /// <summary>
        /// Temperature sensor 5 calibration offset (-50 to 50 × 0.1°C).
        /// </summary>
        TempSensor5Calibration = 85,
        /// <summary>
        /// Temperature sensor 6 calibration offset (-50 to 50 × 0.1°C).
        /// </summary>
        TempSensor6Calibration = 86,
        /// <summary>
        /// Temperature sensor 7 calibration offset (-50 to 50 × 0.1°C).
        /// </summary>
        TempSensor7Calibration = 87,
        /// <summary>
        /// Reserved. Readable, value has no meaning.
        /// </summary>
        Reserved88 = 88,
        /// <summary>
        /// Reserved. Readable, value has no meaning.
        /// </summary>
        Reserved89 = 89,
        /// <summary>
        /// Reserved. Readable, value has no meaning.
        /// </summary>
        Reserved90 = 90,

        #endregion

        #region Quality Sensor Configuration

        /// <summary>
        /// Quality sensor 1 limit (RH: 0-100%, CO2: 0-2000 PPM, VOC: 0-2000 PPM).
        /// </summary>
        QualitySensor1Limit = 91,
        /// <summary>
        /// Quality sensor 2 limit (RH: 0-100%, CO2: 0-2000 PPM, VOC: 0-2000 PPM).
        /// </summary>
        QualitySensor2Limit = 92,
        /// <summary>
        /// Quality sensor 3 limit (RH: 0-100%, CO2: 0-2000 PPM, VOC: 0-2000 PPM).
        /// </summary>
        QualitySensor3Limit = 93,
        /// <summary>
        /// Reserved. Readable, value has no meaning.
        /// </summary>
        Reserved94 = 94,

        #endregion

        #region Duct Sensor Configuration

        /// <summary>
        /// Duct sensor type (0: None, 1: 0-10V, 2: Modbus).
        /// </summary>
        DuctSensorType = 95,
        /// <summary>
        /// Duct sensor function (0: Individual).
        /// </summary>
        DuctSensorFunction = 96,
        /// <summary>
        /// Duct sensor pressure range for 0-10V (1-10: 0..100Pa to 0..2500Pa).
        /// </summary>
        DuctSensorPressureRange = 97,
        /// <summary>
        /// Duct sensor model (0: QBM 68.2525).
        /// </summary>
        DuctSensorModel = 98,

        #endregion

        #region Flow Sensor Configuration

        /// <summary>
        /// Flow sensor type (0: None, 1: 0-10V, 2: Modbus).
        /// </summary>
        FlowSensorType = 99,
        /// <summary>
        /// Flow sensor function (0: Individual, 1: Combined).
        /// </summary>
        FlowSensorFunction = 100,
        /// <summary>
        /// Flow sensor pressure range for 0-10V (1-10: 0..100Pa to 0..2500Pa).
        /// </summary>
        FlowSensorPressureRange = 101,
        /// <summary>
        /// Flow sensor model (0: QBM 68.2525, 1: Other, 2: Another model).
        /// </summary>
        FlowSensorModel = 102,

        #endregion

        #region K-Factor Settings

        /// <summary>
        /// K-factor Supply (multiplied by 100).
        /// </summary>
        KFactorSupply = 103,
        /// <summary>
        /// K-factor Exhaust (multiplied by 100).
        /// </summary>
        KFactorExhaust = 104,

        #endregion

        #region Filter Sensor Configuration

        /// <summary>
        /// Filter sensor type (0: None, 1: 0-10V, 2: Modbus).
        /// </summary>
        FilterSensorType = 105,
        /// <summary>
        /// Filter sensor function (0: Individual, 1: Combined).
        /// </summary>
        FilterSensorFunction = 106,
        /// <summary>
        /// Filter sensor pressure range for 0-10V (1-10: 0..100Pa to 0..2500Pa).
        /// </summary>
        FilterSensorPressureRange = 107,
        /// <summary>
        /// Filter sensor model (0: QBM 68.2525).
        /// </summary>
        FilterSensorModel = 108,
        /// <summary>
        /// Reserved. Readable, value has no meaning.
        /// </summary>
        Reserved109 = 109,

        #endregion

        #region Fan Regulation Setpoints - Standard Fan Speed

        /// <summary>
        /// Supply setpoint percentage for standard fan speed (10-100%).
        /// </summary>
        StandardFanSpeedSupplySetpointPercent = 110,
        /// <summary>
        /// Exhaust setpoint percentage for standard fan speed (10-100%).
        /// </summary>
        StandardFanSpeedExhaustSetpointPercent = 111,
        /// <summary>
        /// Supply setpoint pressure for standard fan speed (0-999 Pa). For regulation type VAV.
        /// </summary>
        StandardFanSpeedSupplySetpointPa = 112,
        /// <summary>
        /// Exhaust setpoint pressure for standard fan speed (0-999 Pa). For regulation type VAV.
        /// </summary>
        StandardFanSpeedExhaustSetpointPa = 113,
        /// <summary>
        /// Supply setpoint airflow for standard fan speed (0-9999 l/s). For regulation type CAV, VAV.
        /// </summary>
        StandardFanSpeedSupplySetpointLs = 114,
        /// <summary>
        /// Exhaust setpoint airflow for standard fan speed (0-9999 l/s). For regulation type CAV, VAV.
        /// </summary>
        StandardFanSpeedExhaustSetpointLs = 115,
        /// <summary>
        /// Supply offset for standard fan speed (-999 to 999 l/s).
        /// </summary>
        StandardFanSpeedSupplyOffset = 116,
        /// <summary>
        /// Exhaust offset for standard fan speed (-999 to 999 l/s).
        /// </summary>
        StandardFanSpeedExhaustOffset = 117,
        /// <summary>
        /// Exhaust startup setpoint (0-9999 l/s). For fan regulation type VAV (Exhaust Fan Slave).
        /// </summary>
        ExhaustStartupSetpoint = 118,
        /// <summary>
        /// Reserved. Readable, value has no meaning.
        /// </summary>
        Reserved119 = 119,

        #endregion

        #region Fan Regulation Setpoints - Min Fan Speed

        /// <summary>
        /// Supply setpoint percentage for minimum fan speed (0-100%).
        /// </summary>
        MinFanSpeedSupplySetpointPercent = 120,
        /// <summary>
        /// Exhaust setpoint percentage for minimum fan speed (0-100%).
        /// </summary>
        MinFanSpeedExhaustSetpointPercent = 121,
        /// <summary>
        /// Supply setpoint pressure for minimum fan speed (0-999 Pa). For regulation type VAV.
        /// </summary>
        MinFanSpeedSupplySetpointPa = 122,
        /// <summary>
        /// Exhaust setpoint pressure for minimum fan speed (0-999 Pa). For regulation type VAV.
        /// </summary>
        MinFanSpeedExhaustSetpointPa = 123,
        /// <summary>
        /// Supply setpoint airflow for minimum fan speed (0-9999 l/s). For regulation type CAV, VAV.
        /// </summary>
        MinFanSpeedSupplySetpointLs = 124,
        /// <summary>
        /// Exhaust setpoint airflow for minimum fan speed (0-9999 l/s). For regulation type CAV, VAV.
        /// </summary>
        MinFanSpeedExhaustSetpointLs = 125,
        /// <summary>
        /// Supply offset for minimum fan speed (-999 to 999 l/s).
        /// </summary>
        MinFanSpeedSupplyOffset = 126,
        /// <summary>
        /// Exhaust offset for minimum fan speed (-999 to 999 l/s).
        /// </summary>
        MinFanSpeedExhaustOffset = 127,
        /// <summary>
        /// Reserved. Readable, value has no meaning.
        /// </summary>
        Reserved128 = 128,
        /// <summary>
        /// Reserved. Readable, value has no meaning.
        /// </summary>
        Reserved129 = 129,

        #endregion

        #region Fan Regulation Setpoints - Max Fan Speed

        /// <summary>
        /// Supply setpoint percentage for maximum fan speed (0-100%).
        /// </summary>
        MaxFanSpeedSupplySetpointPercent = 130,
        /// <summary>
        /// Exhaust setpoint percentage for maximum fan speed (0-100%).
        /// </summary>
        MaxFanSpeedExhaustSetpointPercent = 131,
        /// <summary>
        /// Supply setpoint pressure for maximum fan speed (0-999 Pa). For regulation type VAV.
        /// </summary>
        MaxFanSpeedSupplySetpointPa = 132,
        /// <summary>
        /// Exhaust setpoint pressure for maximum fan speed (0-999 Pa). For regulation type VAV.
        /// </summary>
        MaxFanSpeedExhaustSetpointPa = 133,
        /// <summary>
        /// Supply setpoint airflow for maximum fan speed (0-9999 l/s). For regulation type CAV, VAV.
        /// </summary>
        MaxFanSpeedSupplySetpointLs = 134,
        /// <summary>
        /// Exhaust setpoint airflow for maximum fan speed (0-9999 l/s). For regulation type CAV, VAV.
        /// </summary>
        MaxFanSpeedExhaustSetpointLs = 135,
        /// <summary>
        /// Supply offset for maximum fan speed (-999 to 999 l/s).
        /// </summary>
        MaxFanSpeedSupplyOffset = 136,
        /// <summary>
        /// Exhaust offset for maximum fan speed (-999 to 999 l/s).
        /// </summary>
        MaxFanSpeedExhaustOffset = 137,

        #endregion

        #region Weekly Schedule

        /// <summary>
        /// Week schedule enabled (0: No, 1: Yes). Master switch for all programs.
        /// </summary>
        WeekScheduleEnabled = 140,
        /// <summary>
        /// WS1 on hour (0-23).
        /// </summary>
        WS1OnHour = 141,
        /// <summary>
        /// WS1 on minute (0-59).
        /// </summary>
        WS1OnMinute = 142,
        /// <summary>
        /// WS1 off hour (0-23).
        /// </summary>
        WS1OffHour = 143,
        /// <summary>
        /// WS1 off minute (0-59).
        /// </summary>
        WS1OffMinute = 144,
        /// <summary>
        /// WS1 weekdays (0-127). Bit mask: bit 0=Monday, bit 6=Sunday.
        /// </summary>
        WS1Weekdays = 145,
        /// <summary>
        /// WS1 temperature mode (0: Comfort, 1: Economy).
        /// </summary>
        WS1TempMode = 146,
        /// <summary>
        /// WS1 fan speed (0: Standby, 1: Min, 2: Std, 3: Max).
        /// </summary>
        WS1FanSpeed = 147,
        /// <summary>
        /// WS1 program enabled (0: Disabled, 1: Enabled).
        /// </summary>
        WS1ProgramEnabled = 148,

        /// <summary>
        /// WS2 on hour (0-23).
        /// </summary>
        WS2OnHour = 151,
        /// <summary>
        /// WS2 on minute (0-59).
        /// </summary>
        WS2OnMinute = 152,
        /// <summary>
        /// WS2 off hour (0-23).
        /// </summary>
        WS2OffHour = 153,
        /// <summary>
        /// WS2 off minute (0-59).
        /// </summary>
        WS2OffMinute = 154,
        /// <summary>
        /// WS2 weekdays (0-127). Bit mask: bit 0=Monday, bit 6=Sunday.
        /// </summary>
        WS2Weekdays = 155,
        /// <summary>
        /// WS2 temperature mode (0: Comfort, 1: Economy).
        /// </summary>
        WS2TempMode = 156,
        /// <summary>
        /// WS2 fan speed (0: Standby, 1: Min, 2: Std, 3: Max).
        /// </summary>
        WS2FanSpeed = 157,
        /// <summary>
        /// WS2 program enabled (0: Disabled, 1: Enabled).
        /// </summary>
        WS2ProgramEnabled = 158,

        /// <summary>
        /// WS3 on hour (0-23).
        /// </summary>
        WS3OnHour = 161,
        /// <summary>
        /// WS3 on minute (0-59).
        /// </summary>
        WS3OnMinute = 162,
        /// <summary>
        /// WS3 off hour (0-23).
        /// </summary>
        WS3OffHour = 163,
        /// <summary>
        /// WS3 off minute (0-59).
        /// </summary>
        WS3OffMinute = 164,
        /// <summary>
        /// WS3 weekdays (0-127). Bit mask: bit 0=Monday, bit 6=Sunday.
        /// </summary>
        WS3Weekdays = 165,
        /// <summary>
        /// WS3 temperature mode (0: Comfort, 1: Economy).
        /// </summary>
        WS3TempMode = 166,
        /// <summary>
        /// WS3 fan speed (0: Standby, 1: Min, 2: Std, 3: Max).
        /// </summary>
        WS3FanSpeed = 167,
        /// <summary>
        /// WS3 program enabled (0: Disabled, 1: Enabled).
        /// </summary>
        WS3ProgramEnabled = 168,

        /// <summary>
        /// WS4 on hour (0-23).
        /// </summary>
        WS4OnHour = 171,
        /// <summary>
        /// WS4 on minute (0-59).
        /// </summary>
        WS4OnMinute = 172,
        /// <summary>
        /// WS4 off hour (0-23).
        /// </summary>
        WS4OffHour = 173,
        /// <summary>
        /// WS4 off minute (0-59).
        /// </summary>
        WS4OffMinute = 174,
        /// <summary>
        /// WS4 weekdays (0-127). Bit mask: bit 0=Monday, bit 6=Sunday.
        /// </summary>
        WS4Weekdays = 175,
        /// <summary>
        /// WS4 temperature mode (0: Comfort, 1: Economy).
        /// </summary>
        WS4TempMode = 176,
        /// <summary>
        /// WS4 fan speed (0: Standby, 1: Min, 2: Std, 3: Max).
        /// </summary>
        WS4FanSpeed = 177,
        /// <summary>
        /// WS4 program enabled (0: Disabled, 1: Enabled).
        /// </summary>
        WS4ProgramEnabled = 178,

        /// <summary>
        /// WS5 on hour (0-23).
        /// </summary>
        WS5OnHour = 181,
        /// <summary>
        /// WS5 on minute (0-59).
        /// </summary>
        WS5OnMinute = 182,
        /// <summary>
        /// WS5 off hour (0-23).
        /// </summary>
        WS5OffHour = 183,
        /// <summary>
        /// WS5 off minute (0-59).
        /// </summary>
        WS5OffMinute = 184,
        /// <summary>
        /// WS5 weekdays (0-127). Bit mask: bit 0=Monday, bit 6=Sunday.
        /// </summary>
        WS5Weekdays = 185,
        /// <summary>
        /// WS5 temperature mode (0: Comfort, 1: Economy).
        /// </summary>
        WS5TempMode = 186,
        /// <summary>
        /// WS5 fan speed (0: Standby, 1: Min, 2: Std, 3: Max).
        /// </summary>
        WS5FanSpeed = 187,
        /// <summary>
        /// WS5 program enabled (0: Disabled, 1: Enabled).
        /// </summary>
        WS5ProgramEnabled = 188,

        #endregion

        #region Holiday Schedule

        /// <summary>
        /// Holiday schedule enabled (0: No, 1: Yes). Master switch for all programs.
        /// </summary>
        HolidayScheduleEnabled = 200,

        /// <summary>
        /// HS1 start year (e.g., 2019).
        /// </summary>
        HS1StartYear = 201,
        /// <summary>
        /// HS1 start date (MMDD format, e.g., 1102=Nov 2, 0930=Sep 30).
        /// </summary>
        HS1StartDate = 202,
        /// <summary>
        /// HS1 start hour (0-23).
        /// </summary>
        HS1StartHour = 203,
        /// <summary>
        /// HS1 start minute (0-59).
        /// </summary>
        HS1StartMinute = 204,
        /// <summary>
        /// HS1 end year.
        /// </summary>
        HS1EndYear = 205,
        /// <summary>
        /// HS1 end date (MMDD format).
        /// </summary>
        HS1EndDate = 206,
        /// <summary>
        /// HS1 end hour (0-23).
        /// </summary>
        HS1EndHour = 207,
        /// <summary>
        /// HS1 end minute (0-59).
        /// </summary>
        HS1EndMinute = 208,
        /// <summary>
        /// HS1 temperature mode (0: Comfort, 1: Economy).
        /// </summary>
        HS1TempMode = 209,
        /// <summary>
        /// HS1 fan speed (0: Standby, 1: Min, 2: Std, 3: Max).
        /// </summary>
        HS1FanSpeed = 210,
        /// <summary>
        /// HS1 program enabled. Bit mask: B0 (1=On).
        /// </summary>
        HS1ProgramEnabled = 211,

        /// <summary>
        /// HS2 start year (e.g., 2019).
        /// </summary>
        HS2StartYear = 221,
        /// <summary>
        /// HS2 start date (MMDD format).
        /// </summary>
        HS2StartDate = 222,
        /// <summary>
        /// HS2 start hour (0-23).
        /// </summary>
        HS2StartHour = 223,
        /// <summary>
        /// HS2 start minute (0-59).
        /// </summary>
        HS2StartMinute = 224,
        /// <summary>
        /// HS2 end year.
        /// </summary>
        HS2EndYear = 225,
        /// <summary>
        /// HS2 end date (MMDD format).
        /// </summary>
        HS2EndDate = 226,
        /// <summary>
        /// HS2 end hour (0-23).
        /// </summary>
        HS2EndHour = 227,
        /// <summary>
        /// HS2 end minute (0-59).
        /// </summary>
        HS2EndMinute = 228,
        /// <summary>
        /// HS2 temperature mode (0: Comfort, 1: Economy).
        /// </summary>
        HS2TempMode = 229,
        /// <summary>
        /// HS2 fan speed (0: Standby, 1: Min, 2: Std, 3: Max).
        /// </summary>
        HS2FanSpeed = 230,
        /// <summary>
        /// HS2 program enabled. Bit mask: B0 (1=On).
        /// </summary>
        HS2ProgramEnabled = 231,

        /// <summary>
        /// HS3 start year (e.g., 2019).
        /// </summary>
        HS3StartYear = 241,
        /// <summary>
        /// HS3 start date (MMDD format).
        /// </summary>
        HS3StartDate = 242,
        /// <summary>
        /// HS3 start hour (0-23).
        /// </summary>
        HS3StartHour = 243,
        /// <summary>
        /// HS3 start minute (0-59).
        /// </summary>
        HS3StartMinute = 244,
        /// <summary>
        /// HS3 end year.
        /// </summary>
        HS3EndYear = 245,
        /// <summary>
        /// HS3 end date (MMDD format).
        /// </summary>
        HS3EndDate = 246,
        /// <summary>
        /// HS3 end hour (0-23).
        /// </summary>
        HS3EndHour = 247,
        /// <summary>
        /// HS3 end minute (0-59).
        /// </summary>
        HS3EndMinute = 248,
        /// <summary>
        /// HS3 temperature mode (0: Comfort, 1: Economy).
        /// </summary>
        HS3TempMode = 249,
        /// <summary>
        /// HS3 fan speed (0: Standby, 1: Min, 2: Std, 3: Max).
        /// </summary>
        HS3FanSpeed = 250,
        /// <summary>
        /// HS3 program enabled. Bit mask: B0 (1=On).
        /// </summary>
        HS3ProgramEnabled = 251,

        /// <summary>
        /// HS4 start year (e.g., 2019).
        /// </summary>
        HS4StartYear = 261,
        /// <summary>
        /// HS4 start date (MMDD format).
        /// </summary>
        HS4StartDate = 262,
        /// <summary>
        /// HS4 start hour (0-23).
        /// </summary>
        HS4StartHour = 263,
        /// <summary>
        /// HS4 start minute (0-59).
        /// </summary>
        HS4StartMinute = 264,
        /// <summary>
        /// HS4 end year.
        /// </summary>
        HS4EndYear = 265,
        /// <summary>
        /// HS4 end date (MMDD format).
        /// </summary>
        HS4EndDate = 266,
        /// <summary>
        /// HS4 end hour (0-23).
        /// </summary>
        HS4EndHour = 267,
        /// <summary>
        /// HS4 end minute (0-59).
        /// </summary>
        HS4EndMinute = 268,
        /// <summary>
        /// HS4 temperature mode (0: Comfort, 1: Economy).
        /// </summary>
        HS4TempMode = 269,
        /// <summary>
        /// HS4 fan speed (0: Standby, 1: Min, 2: Std, 3: Max).
        /// </summary>
        HS4FanSpeed = 270,
        /// <summary>
        /// HS4 program enabled. Bit mask: B0 (1=On).
        /// </summary>
        HS4ProgramEnabled = 271,

        /// <summary>
        /// HS5 start year (e.g., 2019).
        /// </summary>
        HS5StartYear = 281,
        /// <summary>
        /// HS5 start date (MMDD format).
        /// </summary>
        HS5StartDate = 282,
        /// <summary>
        /// HS5 start hour (0-23).
        /// </summary>
        HS5StartHour = 283,
        /// <summary>
        /// HS5 start minute (0-59).
        /// </summary>
        HS5StartMinute = 284,
        /// <summary>
        /// HS5 end year.
        /// </summary>
        HS5EndYear = 285,
        /// <summary>
        /// HS5 end date (MMDD format).
        /// </summary>
        HS5EndDate = 286,
        /// <summary>
        /// HS5 end hour (0-23).
        /// </summary>
        HS5EndHour = 287,
        /// <summary>
        /// HS5 end minute (0-59).
        /// </summary>
        HS5EndMinute = 288,
        /// <summary>
        /// HS5 temperature mode (0: Comfort, 1: Economy).
        /// </summary>
        HS5TempMode = 289,
        /// <summary>
        /// HS5 fan speed (0: Standby, 1: Min, 2: Std, 3: Max).
        /// </summary>
        HS5FanSpeed = 290,
        /// <summary>
        /// HS5 program enabled. Bit mask: B0 (1=On).
        /// </summary>
        HS5ProgramEnabled = 291,

        /// <summary>
        /// HS6 start year (e.g., 2019).
        /// </summary>
        HS6StartYear = 301,
        /// <summary>
        /// HS6 start date (MMDD format).
        /// </summary>
        HS6StartDate = 302,
        /// <summary>
        /// HS6 start hour (0-23).
        /// </summary>
        HS6StartHour = 303,
        /// <summary>
        /// HS6 start minute (0-59).
        /// </summary>
        HS6StartMinute = 304,
        /// <summary>
        /// HS6 end year.
        /// </summary>
        HS6EndYear = 305,
        /// <summary>
        /// HS6 end date (MMDD format).
        /// </summary>
        HS6EndDate = 306,
        /// <summary>
        /// HS6 end hour (0-23).
        /// </summary>
        HS6EndHour = 307,
        /// <summary>
        /// HS6 end minute (0-59).
        /// </summary>
        HS6EndMinute = 308,
        /// <summary>
        /// HS6 temperature mode (0: Comfort, 1: Economy).
        /// </summary>
        HS6TempMode = 309,
        /// <summary>
        /// HS6 fan speed (0: Standby, 1: Min, 2: Std, 3: Max).
        /// </summary>
        HS6FanSpeed = 310,
        /// <summary>
        /// HS6 program enabled. Bit mask: B0 (1=On).
        /// </summary>
        HS6ProgramEnabled = 311,

        /// <summary>
        /// HS7 start year (e.g., 2019).
        /// </summary>
        HS7StartYear = 321,
        /// <summary>
        /// HS7 start date (MMDD format).
        /// </summary>
        HS7StartDate = 322,
        /// <summary>
        /// HS7 start hour (0-23).
        /// </summary>
        HS7StartHour = 323,
        /// <summary>
        /// HS7 start minute (0-59).
        /// </summary>
        HS7StartMinute = 324,
        /// <summary>
        /// HS7 end year.
        /// </summary>
        HS7EndYear = 325,
        /// <summary>
        /// HS7 end date (MMDD format).
        /// </summary>
        HS7EndDate = 326,
        /// <summary>
        /// HS7 end hour (0-23).
        /// </summary>
        HS7EndHour = 327,
        /// <summary>
        /// HS7 end minute (0-59).
        /// </summary>
        HS7EndMinute = 328,
        /// <summary>
        /// HS7 temperature mode (0: Comfort, 1: Economy).
        /// </summary>
        HS7TempMode = 329,
        /// <summary>
        /// HS7 fan speed (0: Standby, 1: Min, 2: Std, 3: Max).
        /// </summary>
        HS7FanSpeed = 330,
        /// <summary>
        /// HS7 program enabled. Bit mask: B0 (1=On).
        /// </summary>
        HS7ProgramEnabled = 331,

        /// <summary>
        /// HS8 start year (e.g., 2019).
        /// </summary>
        HS8StartYear = 341,
        /// <summary>
        /// HS8 start date (MMDD format).
        /// </summary>
        HS8StartDate = 342,
        /// <summary>
        /// HS8 start hour (0-23).
        /// </summary>
        HS8StartHour = 343,
        /// <summary>
        /// HS8 start minute (0-59).
        /// </summary>
        HS8StartMinute = 344,
        /// <summary>
        /// HS8 end year.
        /// </summary>
        HS8EndYear = 345,
        /// <summary>
        /// HS8 end date (MMDD format).
        /// </summary>
        HS8EndDate = 346,
        /// <summary>
        /// HS8 end hour (0-23).
        /// </summary>
        HS8EndHour = 347,
        /// <summary>
        /// HS8 end minute (0-59).
        /// </summary>
        HS8EndMinute = 348,
        /// <summary>
        /// HS8 temperature mode (0: Comfort, 1: Economy).
        /// </summary>
        HS8TempMode = 349,
        /// <summary>
        /// HS8 fan speed (0: Standby, 1: Min, 2: Std, 3: Max).
        /// </summary>
        HS8FanSpeed = 350,
        /// <summary>
        /// HS8 program enabled. Bit mask: B0 (1=On).
        /// </summary>
        HS8ProgramEnabled = 351,

        /// <summary>
        /// HS9 start year (e.g., 2019).
        /// </summary>
        HS9StartYear = 361,
        /// <summary>
        /// HS9 start date (MMDD format).
        /// </summary>
        HS9StartDate = 362,
        /// <summary>
        /// HS9 start hour (0-23).
        /// </summary>
        HS9StartHour = 363,
        /// <summary>
        /// HS9 start minute (0-59).
        /// </summary>
        HS9StartMinute = 364,
        /// <summary>
        /// HS9 end year.
        /// </summary>
        HS9EndYear = 365,
        /// <summary>
        /// HS9 end date (MMDD format).
        /// </summary>
        HS9EndDate = 366,
        /// <summary>
        /// HS9 end hour (0-23).
        /// </summary>
        HS9EndHour = 367,
        /// <summary>
        /// HS9 end minute (0-59).
        /// </summary>
        HS9EndMinute = 368,
        /// <summary>
        /// HS9 temperature mode (0: Comfort, 1: Economy).
        /// </summary>
        HS9TempMode = 369,
        /// <summary>
        /// HS9 fan speed (0: Standby, 1: Min, 2: Std, 3: Max).
        /// </summary>
        HS9FanSpeed = 370,
        /// <summary>
        /// HS9 program enabled. Bit mask: B0 (1=On).
        /// </summary>
        HS9ProgramEnabled = 371,

        /// <summary>
        /// HS10 start year (e.g., 2019).
        /// </summary>
        HS10StartYear = 381,
        /// <summary>
        /// HS10 start date (MMDD format).
        /// </summary>
        HS10StartDate = 382,
        /// <summary>
        /// HS10 start hour (0-23).
        /// </summary>
        HS10StartHour = 383,
        /// <summary>
        /// HS10 start minute (0-59).
        /// </summary>
        HS10StartMinute = 384,
        /// <summary>
        /// HS10 end year.
        /// </summary>
        HS10EndYear = 385,
        /// <summary>
        /// HS10 end date (MMDD format).
        /// </summary>
        HS10EndDate = 386,
        /// <summary>
        /// HS10 end hour (0-23).
        /// </summary>
        HS10EndHour = 387,
        /// <summary>
        /// HS10 end minute (0-59).
        /// </summary>
        HS10EndMinute = 388,
        /// <summary>
        /// HS10 temperature mode (0: Comfort, 1: Economy).
        /// </summary>
        HS10TempMode = 389,
        /// <summary>
        /// HS10 fan speed (0: Standby, 1: Min, 2: Std, 3: Max).
        /// </summary>
        HS10FanSpeed = 390,
        /// <summary>
        /// HS10 program enabled. Bit mask: B0 (1=On).
        /// </summary>
        HS10ProgramEnabled = 391,

        #endregion

        #region Clock/Time

        /// <summary>
        /// Current calendar year stored in the unit clock.
        /// </summary>
        TimeYear = 400,
        /// <summary>
        /// Current calendar month stored in the unit clock. (1-12)
        /// </summary>
        TimeMonth = 401,
        /// <summary>
        /// Current day of the month stored in the unit clock. (1-31)
        /// Reading this copies time to read/write buffer.
        /// </summary>
        TimeDay = 402,
        /// <summary>
        /// Current hour of the day stored in the unit clock. (0-23)
        /// </summary>
        TimeHour = 403,
        /// <summary>
        /// Current minute stored in the unit clock. (0-59)
        /// </summary>
        TimeMinute = 404,
        /// <summary>
        /// Current second stored in the unit clock. (0-59)
        /// Writing this writes time from read/write buffer.
        /// </summary>
        TimeSecond = 405,

        #endregion

        #region Modbus Communication

        /// <summary>
        /// Modbus address / ID (1-255).
        /// </summary>
        ModbusAddress = 901,
        /// <summary>
        /// Baudrate (0-7: 9600, 14400, 19200, 28800, 38400, 57600, 115200, 230400 bps).
        /// </summary>
        Baudrate = 902,
        /// <summary>
        /// Stop bits (0: Auto, 1: 1 bit, 2: 2 bits).
        /// </summary>
        StopBit = 903,
        /// <summary>
        /// Parity (0: None, 1: Odd, 2: Even).
        /// </summary>
        Parity = 904,

        #endregion

        #region Menu Access Control

        /// <summary>
        /// Service menu access (0: Allowed, 1: Prohibited).
        /// </summary>
        ServiceMenuAccess = 911,
        /// <summary>
        /// Installation menu access (0: Allowed, 1: Prohibited).
        /// </summary>
        InstallationMenuAccess = 912,
        /// <summary>
        /// Special settings menu access (0: Allowed, 1: Prohibited).
        /// </summary>
        SpecialSettingsMenuAccess = 913,

        #endregion

        #region PID Control Parameters

        /// <summary>
        /// Exhaust fan PID control, proportional coefficient (0-1000).
        /// </summary>
        ExhaustFanPIDProportional = 920,
        /// <summary>
        /// Exhaust fan PID control, integral coefficient (0-1000).
        /// </summary>
        ExhaustFanPIDIntegral = 921,
        /// <summary>
        /// Exhaust fan PID control, derivative coefficient (0-1000).
        /// </summary>
        ExhaustFanPIDDerivative = 922,
        /// <summary>
        /// Supply fan PID control, proportional coefficient (0-1000).
        /// </summary>
        SupplyFanPIDProportional = 923,
        /// <summary>
        /// Supply fan PID control, integral coefficient (0-1000).
        /// </summary>
        SupplyFanPIDIntegral = 924,
        /// <summary>
        /// Supply fan PID control, derivative coefficient (0-1000).
        /// </summary>
        SupplyFanPIDDerivative = 925,
        /// <summary>
        /// Heating PID control, proportional coefficient (0-1000).
        /// </summary>
        HeatingPIDProportional = 926,
        /// <summary>
        /// Heating PID control, integral coefficient (0-1000).
        /// </summary>
        HeatingPIDIntegral = 927,
        /// <summary>
        /// Heating PID control, derivative coefficient (0-1000).
        /// </summary>
        HeatingPIDDerivative = 928,
        /// <summary>
        /// Recovery (heat exchanger) PID control, proportional coefficient (0-1000).
        /// </summary>
        RecoveryPIDProportional = 929,
        /// <summary>
        /// Recovery (heat exchanger) PID control, integral coefficient (0-1000).
        /// </summary>
        RecoveryPIDIntegral = 930,
        /// <summary>
        /// Recovery (heat exchanger) PID control, derivative coefficient (0-1000).
        /// </summary>
        RecoveryPIDDerivative = 931,
        /// <summary>
        /// Cooling PID control, proportional coefficient (0-1000).
        /// </summary>
        CoolingPIDProportional = 932,
        /// <summary>
        /// Cooling PID control, integral coefficient (0-1000).
        /// </summary>
        CoolingPIDIntegral = 933,
        /// <summary>
        /// Cooling PID control, derivative coefficient (0-1000).
        /// </summary>
        CoolingPIDDerivative = 934,
        /// <summary>
        /// Room temperature PID control, proportional coefficient (0-1000).
        /// </summary>
        RoomPIDProportional = 935,
        /// <summary>
        /// Room temperature PID control, integral coefficient (0-1000).
        /// </summary>
        RoomPIDIntegral = 936,
        /// <summary>
        /// Room temperature PID control, derivative coefficient (0-1000).
        /// </summary>
        RoomPIDDerivative = 937,
        /// <summary>
        /// Humidity (RH) PID control, proportional coefficient (0-1000).
        /// </summary>
        RhPIDProportional = 938,
        /// <summary>
        /// Humidity (RH) PID control, integral coefficient (0-1000).
        /// </summary>
        RhPIDIntegral = 939,
        /// <summary>
        /// Humidity (RH) PID control, derivative coefficient (0-1000).
        /// </summary>
        RhPIDDerivative = 940,
        /// <summary>
        /// CO2 level PID control, proportional coefficient (0-1000).
        /// </summary>
        CO2PIDProportional = 941,
        /// <summary>
        /// CO2 level PID control, integral coefficient (0-1000).
        /// </summary>
        CO2PIDIntegral = 942,
        /// <summary>
        /// CO2 level PID control, derivative coefficient (0-1000).
        /// </summary>
        CO2PIDDerivative = 943,
        /// <summary>
        /// VOC (Volatile Organic Compound) PID control, proportional coefficient (0-1000).
        /// </summary>
        VOCPIDProportional = 944,
        /// <summary>
        /// VOC (Volatile Organic Compound) PID control, integral coefficient (0-1000).
        /// </summary>
        VOCPIDIntegral = 945,
        /// <summary>
        /// VOC (Volatile Organic Compound) PID control, derivative coefficient (0-1000).
        /// </summary>
        VOCPIDDerivative = 946,

        #endregion
    }
}
