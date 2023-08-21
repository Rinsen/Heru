using Rinsen.Heru;

namespace HeruConsoleApp
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            Console.WriteLine("Hello, World!");

            var fanUnit = new FanUnit(new ModbusOptions
            {
                IpAddressOrHostName = "192.168.1.194",
                PortNumber = 502
            });

            var result = await fanUnit.GetStatusAsync();
            var temperatures = await fanUnit.GetTemperaturesAsync();
            var fanSpeeds = await fanUnit.GetFanSpeedAsync();

            await fanUnit.ActivateSetting(Setting.BoostMode);
        }
    }
}