namespace Rinsen.Heru.Modbus
{
    internal class ApplicationControlCoilStatusRegistersHandler
    {
        private readonly IModbusMasterFactory _modbusMasterFactory;

        public ApplicationControlCoilStatusRegistersHandler(IModbusMasterFactory modbusMasterFactory)
        {
            _modbusMasterFactory = modbusMasterFactory;
        }

        public async Task<bool[]> ReadApplicationControlStatisRegisters(ApplicationControlCoilStatusRegisters startCoilStatus, ushort numberOfPoints)
        {
            var modbusMaster = _modbusMasterFactory.GetModbusMaster();

            var coilStatus = await modbusMaster.ReadCoilsAsync(0, (ushort)(startCoilStatus - 1), numberOfPoints);

            return coilStatus;
        }

        internal async Task WriteSingleCoilAsync(ApplicationControlCoilStatusRegisters coilStatus, bool newStatus)
        {
            var modbusMaster = _modbusMasterFactory.GetModbusMaster();

            await modbusMaster.WriteSingleCoilAsync(0, (ushort)(coilStatus - 1), newStatus);

            var result = await modbusMaster.ReadCoilsAsync(0, (ushort)(coilStatus - 1), 1);

            if (result[0] != newStatus)
            {
                throw new Exception("Write failed");
            }
        }
    }
}
