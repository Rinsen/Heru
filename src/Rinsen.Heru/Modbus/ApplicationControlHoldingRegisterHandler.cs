namespace Rinsen.Heru.Modbus
{
    internal class ApplicationControlHoldingRegisterHandler
    {
        private readonly IModbusMasterFactory _modbusMasterFactory;

        public ApplicationControlHoldingRegisterHandler(IModbusMasterFactory modbusMasterFactory)
        {
            _modbusMasterFactory = modbusMasterFactory;
        }

        public async Task<Dictionary<ApplicationControlHoldingRegister, ushort>> ReadApplicationControlHoldingRegisters(ApplicationControlHoldingRegister startRegister, ushort count)
        {
            var modbusMaster = _modbusMasterFactory.GetModbusMaster();

            var registers = await modbusMaster.ReadHoldingRegistersAsync(0, (ushort)(startRegister - 1), count);
            var result = new Dictionary<ApplicationControlHoldingRegister, ushort>();

            for (int i = 0; i < count; i++)
            {
                result.Add((ApplicationControlHoldingRegister)(i + (ushort)startRegister), (ushort)registers[i]);

            }
            return result;
        }

        public async Task WriteApplicationControlHoldingRegisters(ApplicationControlHoldingRegister startRegister, ushort[] values)
        {
            var modbusMaster = _modbusMasterFactory.GetModbusMaster();

            await modbusMaster.WriteMultipleRegistersAsync(0, (ushort)(startRegister - 1), values);
        }
    }
}
