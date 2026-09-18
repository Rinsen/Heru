namespace Rinsen.Heru.Modbus
{
    internal class ApplicationControlInputRegistersHandler
    {
        private readonly IModbusMasterFactory _modbusMasterFactory;

        public ApplicationControlInputRegistersHandler(IModbusMasterFactory modbusMasterFactory)
        {
            _modbusMasterFactory = modbusMasterFactory;
        }

        internal async Task<Dictionary<ApplicationControlInputRegisters, ushort>> ReadApplicationControlInputs(ApplicationControlInputRegisters inputRegister, ushort numberOfPoints)
        {
            var modbusMaster = _modbusMasterFactory.GetModbusMaster();

            var inputRegisters = await modbusMaster.ReadInputRegistersAsync(0, (ushort)(inputRegister - 1), numberOfPoints);

            var result = new Dictionary<ApplicationControlInputRegisters, ushort>();

            for (int i = 0; i < numberOfPoints; i++)
            {
                result.Add((ApplicationControlInputRegisters)(i + (ushort)inputRegister), inputRegisters[i]);
            }

            return result;
        }
    }
}
