namespace Rinsen.Heru
{
    /// <summary>
    /// Current operating state of the ventilation unit.
    /// </summary>
    public class Status
    {
        /// <summary>
        /// Indicates whether the unit is currently running.
        /// </summary>
        public bool UnitOn { get; set; }

        /// <summary>
        /// Indicates whether boost ventilation is currently active.
        /// </summary>
        public bool BoostActive { get; set; }

        /// <summary>
        /// Indicates whether overpressure mode is currently active.
        /// </summary>
        public bool OverpressureActive { get; set; }

        /// <summary>
        /// Indicates whether away mode is currently active.
        /// </summary>
        public bool AwayActive { get; set; }

    }
}
