using NModbus;

namespace Rinsen.Heru.Modbus
{
    internal class AlarmRegisterHandler
    {
        private readonly IModbusMasterFactory _modbusMasterFactory;

        public AlarmRegisterHandler(IModbusMasterFactory modbusMasterFactory)
        {
            _modbusMasterFactory = modbusMasterFactory;
        }

        /// <summary>
        /// Asynchronously reads alarm registers from the Modbus server.
        /// </summary>
        /// <param name="modbusMaster">The Modbus master instance.</param>
        /// <param name="inputStatus">The starting alarm register.</param>
        /// <param name="numberOfPoints">The number of points to read.</param>
        /// <returns>A dictionary of alarm registers and their status.</returns>
        internal async Task<Dictionary<AlarmRegister, bool>> ReadAlarmRegistersAsync(AlarmRegister inputStatus, ushort numberOfPoints)
        {
            var modbusMaster = _modbusMasterFactory.GetModbusMaster();

            var inputStatuses = await modbusMaster.ReadInputsAsync(0, (ushort)(inputStatus - 1), numberOfPoints);

            var result = new Dictionary<AlarmRegister, bool>();

            for (int i = 0; i < numberOfPoints; i++)
            {
                result.Add((AlarmRegister)(i + (ushort)inputStatus), inputStatuses[i]);
            }

            return result;
        }
    }
}
