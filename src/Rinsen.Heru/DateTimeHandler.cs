using Rinsen.Heru.Modbus;

namespace Rinsen.Heru
{
    internal class DateTimeHandler
    {
        private readonly ApplicationControlHoldingRegisterHandler _applicationControlHoldingRegisterHandler;

        public DateTimeHandler(ApplicationControlHoldingRegisterHandler applicationControlHoldingRegisterHandler)
        {
            _applicationControlHoldingRegisterHandler = applicationControlHoldingRegisterHandler;
        }

        /// <summary>
        /// Sets the current time in the application's control holding registers if it differs from the local time by more than 2 seconds.
        /// </summary>
        public async Task SetDateTimeNowAsync()
        {
            var configuredTime = await GetTimeAsync();
            var now = DateTime.Now;
            if (Math.Abs((now - configuredTime).TotalSeconds) <= 2)
            {
                return;
            }

            var values = new ushort[]
            {
                (ushort)now.Year,
                (ushort)now.Month,
                (ushort)now.Day,
                (ushort)now.Hour,
                (ushort)now.Minute,
                (ushort)now.Second
            };

            await _applicationControlHoldingRegisterHandler.WriteApplicationControlHoldingRegisters(ApplicationControlHoldingRegister.TimeYear,  values);
        }

        private async Task<DateTime> GetTimeAsync()
        {
            var holdingRegisters = await _applicationControlHoldingRegisterHandler.ReadApplicationControlHoldingRegisters(ApplicationControlHoldingRegister.TimeYear, 6);

            return new DateTime(
                holdingRegisters[ApplicationControlHoldingRegister.TimeYear],
                holdingRegisters[ApplicationControlHoldingRegister.TimeMonth],
                holdingRegisters[ApplicationControlHoldingRegister.TimeDay],
                holdingRegisters[ApplicationControlHoldingRegister.TimeHour],
                holdingRegisters[ApplicationControlHoldingRegister.TimeMinute],
                holdingRegisters[ApplicationControlHoldingRegister.TimeSecond]
            );
        }
    }
}
