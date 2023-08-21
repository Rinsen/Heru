namespace Rinsen.Heru
{
    public class FanSpeed
    {
        /// <summary>
        /// Supply fan power in percentage of max power
        /// </summary>
        public ushort CurrentSupplyFanPower { get; internal set; }

        /// <summary>
        /// Exhaust fan power in percentage of max power
        /// </summary>
        public ushort CurrentExhaustFanPower { get; internal set; }

        /// <summary>
        /// Supply fan speed in RPM.
        /// </summary>
        public ushort CurrentSupplyFanSpeed { get; internal set; }

        /// <summary>
        /// Exhaust fan speed in RPM.
        /// </summary>
        public ushort CurrentExhaustFanSpeed { get; internal set; }
    }
}
