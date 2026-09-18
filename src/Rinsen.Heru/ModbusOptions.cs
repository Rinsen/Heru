namespace Rinsen.Heru
{
    /// <summary>
    /// Connection settings used when opening a Modbus TCP session to the unit.
    /// </summary>
    public class ModbusOptions
    {
        /// <summary>
        /// IP address or host name of the Heru unit or gateway.
        /// </summary>
        public required string IpAddressOrHostName { get; set; }

        /// <summary>
        /// TCP port used by the Modbus server.
        /// </summary>
        public int PortNumber { get; set; }

    }
}
