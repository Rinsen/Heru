namespace Rinsen.Heru
{
    /// <summary>
    /// High-level control actions that can be applied to the ventilation unit.
    /// </summary>
    public enum Setting
    {
        /// <summary>
        /// Start or stop the ventilation unit.
        /// </summary>
        UnitOn,
        /// <summary>
        /// Enable or disable overpressure operation.
        /// </summary>
        OverpressureMode,
        /// <summary>
        /// Enable or disable temporary boost ventilation.
        /// </summary>
        BoostMode,
        /// <summary>
        /// Enable or disable reduced ventilation for away periods.
        /// </summary>
        AwayMode,
        /// <summary>
        /// Clear active alarms and acknowledge the current alarm state.
        /// </summary>
        ClearAlarms,
        /// <summary>
        /// Reset the filter service timer after the filter has been changed.
        /// </summary>
        ResetFilterTimer,
        /// <summary>
        /// Extend the current operation period or wake the unit from scheduled standby.
        /// </summary>
        ExtendOperation,
    }
}
