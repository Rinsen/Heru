namespace Rinsen.Heru.Modbus
{
    /// <summary>
    /// Coil status - Discrete Output (1bit) R/W
    /// </summary>
    internal enum CoilStatus : ushort
    {
        UnitOn = 1,
        OverpressureMode = 2,
        BoostMode = 3,
        AwayMode = 4,
        /// <summary>
        /// Write 1 to clear alarm, reads always 0
        /// </summary>
        ClearAlarms = 5,
        /// <summary>
        /// Write 1 to reset filter timer, reads always 0
        /// </summary>
        ResetFilterTimer = 6,
        /// <summary>
        /// To wake up from scheduled standby
        /// </summary>
        ExtendOperation = 7,


    }
}
