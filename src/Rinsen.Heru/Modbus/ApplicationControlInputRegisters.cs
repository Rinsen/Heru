namespace Rinsen.Heru.Modbus
{
    /// <summary>
    /// Input registers that expose read-only operating values from the ventilation unit.
    /// </summary>
    internal enum ApplicationControlInputRegisters : ushort
    {
        /// <summary>
        /// Unit/component identifier reported by the controller.
        /// </summary>
        ComponentId = 1,
        /// <summary>
        /// Outdoor air temperature entering the unit.
        /// </summary>
        OutdoorTemperature = 2,
        /// <summary>
        /// Supply air temperature leaving the unit after conditioning.
        /// </summary>
        SupplyAirTemperature = 3,
        /// <summary>
        /// Extract air temperature entering the unit from the building.
        /// </summary>
        ExtractAirTemperature = 4,
        /// <summary>
        /// Exhaust air temperature leaving the unit to the outdoors.
        /// </summary>
        ExhaustAirTemperature = 5,
        /// <summary>
        /// Water temperature used by the unit, if a water-connected accessory is installed.
        /// </summary>
        WaterTemperature = 6,
        /// <summary>
        /// Heat recovery temperature measured across the heat exchanger.
        /// </summary>
        HeatRecoveryTemperature = 7,
        /// <summary>
        /// Room temperature from the installed room sensor, when available.
        /// </summary>
        RoomTemperature = 8,
        /// <summary>
        /// Reserved for future use; readable placeholder register 1.
        /// </summary>
        RFUReadable1 = 9,
        /// <summary>
        /// Reserved for future use; readable placeholder register 2.
        /// </summary>
        RFUReadable2 = 10,
        /// <summary>
        /// Reserved for future use; readable placeholder register 3.
        /// </summary>
        RFUReadable3 = 11,
        /// <summary>
        /// Supply duct pressure measurement. The raw value should be multiplied by 10 to convert to the expected Pa scale.
        /// </summary>
        SupplyPressureDuct = 12,
        /// <summary>
        /// Extract duct pressure measurement. The raw value should be multiplied by 10 to convert to the expected Pa scale.
        /// </summary>
        ExtractPressureDuct = 13,
        /// <summary>
        /// Bit mask indicating which sensors are required but currently report an open circuit.
        /// </summary>
        SensorsOpen = 18,
        /// <summary>
        /// Bit mask indicating which sensors are required but currently report a short circuit. Bit 0 represents T1 and bit 6 represents T7.
        /// </summary>
        SensorsShorted = 19,
        /// <summary>
        /// Number of days remaining before the filter should be changed.
        /// </summary>
        FilterDaysLeft = 20,
        /// <summary>
        /// Currently active week timer program, where 0 means no program and 1-5 select programs 1-5.
        /// </summary>
        CurrentWeektimerProgram = 21,
        /// <summary>
        /// Current supply fan step, where 0 = Off, 1 = Min, 2 = Std, and 3 = Max.
        /// </summary>
        CurrentSupplyFanStep = 23,
        /// <summary>
        /// Current exhaust fan step, where 0 = Off, 1 = Min, 2 = Std, and 3 = Max.
        /// </summary>
        CurrentExhaustFanStep = 24,
        /// <summary>
        /// Current supply fan power as a raw percentage-like value reported by the controller.
        /// </summary>
        CurrentSupplyFanPower = 25,
        /// <summary>
        /// Current exhaust fan power as a raw percentage-like value reported by the controller.
        /// </summary>
        CurrentExhaustFanPower = 26,
        /// <summary>
        /// Current supply fan speed in revolutions per minute.
        /// </summary>
        CurrentSupplyFanSpeed = 27,
        /// <summary>
        /// Current exhaust fan speed in revolutions per minute.
        /// </summary>
        CurrentExhaustFanSpeed = 28,
        /// <summary>
        /// Current heating output level, where 255 corresponds to 100%.
        /// </summary>
        CurrentHeatingPower = 29,
        /// <summary>
        /// Current heat/cold recovery output level, where 255 corresponds to 100%.
        /// </summary>
        CurrentHeatColdRecoveryPower = 30,
        /// <summary>
        /// Current cooling output level, where 255 corresponds to 100%.
        /// </summary>
        CurrentCoolingPower = 31,
        /// <summary>
        /// Analog control voltage for the supply fan.
        /// </summary>
        SupplyFanControlVoltage = 32,
        /// <summary>
        /// Analog control voltage for the exhaust fan.
        /// </summary>
        ExhaustFanControlVoltage = 33,
        /// <summary>
        /// Changeover state, where 0 = Off and 1 = On.
        /// </summary>
        ChangeoverActive = 34,
        /// <summary>
        /// Type configured for quality sensor 1, where 0 = None, 1 = RH, 2 = CO2, and 3 = VOC.
        /// </summary>
        QualitySensor1Type = 41,
        /// <summary>
        /// Raw input value for quality sensor 1; interpretation depends on the configured sensor type.
        /// RH: 0-10V maps to 0-100%.
        /// CO2: 0-10V maps to 0-2000 ppm.
        /// VOC: 0-10V maps to 0-2000 ppm.
        /// </summary>
        QualitySensor1Value = 42,
        /// <summary>
        /// Type configured for quality sensor 2, where 0 = None, 1 = RH, 2 = CO2, and 3 = VOC.
        /// </summary>
        QualitySensor2Type = 43,
        /// <summary>
        /// Raw input value for quality sensor 2; interpretation depends on the configured sensor type.
        /// </summary>
        QualitySensor2Value = 44,
        /// <summary>
        /// Type configured for quality sensor 3, where 0 = None, 1 = RH, 2 = CO2, and 3 = VOC.
        /// </summary>
        QualitySensor3Type = 45,
        /// <summary>
        /// Raw input value for quality sensor 3; interpretation depends on the configured sensor type.
        /// </summary>
        QualitySensor3Value = 46,
    }
}
