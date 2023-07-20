namespace Rinsen.Heru.Modbus
{
    /// <summary>
    /// Coil status - Discrete Output (1bit) R/W
    /// </summary>
    internal enum CoilStatus : ushort
    {
        UnitOn = 0x00001,
        OverpressureMode = 0x00002,
        BoostMode = 0x00003,
        AwayMode = 0x00004,
        /// <summary>
        /// Write 1 to clear alarm, reads always 0
        /// </summary>
        ClearAlarms = 0x00005,
        /// <summary>
        /// Write 1 to reset filter timer, reads always 0
        /// </summary>
        ResetFilterTimer = 0x00006,
        /// <summary>
        /// To wake up from scheduled standby
        /// </summary>
        ExtendOperation = 0x00007,


    }
}
