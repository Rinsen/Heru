namespace Rinsen.Heru.Modbus
{
    /// <summary>
    /// Application control coil status registers - Discrete Output (1bit) Read/Write
    /// </summary>
    internal enum ApplicationControlCoilStatusRegisters : ushort
    {
        /// <summary>
        /// Unit operation enable: set to 1 to run the ventilation unit, set to 0 to stop it.
        /// </summary>
        UnitOn = 1,

        /// <summary>
        /// Overpressure mode command: set to 1 to activate overpressure operation.
        /// </summary>
        OverpressureMode = 2,

        /// <summary>
        /// Boost mode command: set to 1 to activate temporary high-ventilation operation.
        /// </summary>
        BoostMode = 3,

        /// <summary>
        /// Away mode command: set to 1 to run reduced ventilation for unoccupied periods.
        /// </summary>
        AwayMode = 4,

        /// <summary>
        /// Alarm acknowledge command: write 1 to clear active alarms; reads always return 0.
        /// </summary>
        ClearAlarms = 5,

        /// <summary>
        /// Filter service timer reset command: write 1 to reset the filter timer; reads always return 0.
        /// </summary>
        ResetFilterTimer = 6,

        /// <summary>
        /// Scheduled standby override command: write 1 to wake the unit and extend operation.
        /// </summary>
        ExtendOperation = 7,
    }
}
