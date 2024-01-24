using NModbus;

namespace Rinsen.Heru.Modbus
{
    internal class CoilStatusHandler
    {

        public async Task<bool[]> ReadCoilsAsync(IModbusMaster modbusMaster, CoilStatus startCoilStatus, ushort numberOfPoints)
        {
            var coilStatus = await modbusMaster.ReadCoilsAsync(0, (ushort)(startCoilStatus - 1), numberOfPoints);

            return coilStatus;
        }

        internal async Task WriteSingleCoilAsync(IModbusMaster modbusMaster, CoilStatus coilStatus, bool newStatus)
        {
            await modbusMaster.WriteSingleCoilAsync(0, (ushort)(coilStatus - 1), newStatus);

            var result = await modbusMaster.ReadCoilsAsync(0, (ushort)(coilStatus - 1), 1);

            if (result[0] != newStatus)
            {
                throw new Exception("Write failed");
            }
        }
    }
}
