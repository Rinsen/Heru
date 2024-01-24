using Rinsen.Heru;

namespace HeruConsoleApp
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            Console.WriteLine("Heru statistics via modbus");

            await PrintStatus();
        }

        private static async Task PrintStatus()
        {
            using var fanUnit = new FanUnit(new ModbusOptions
            {
                IpAddressOrHostName = "192.168.1.220",
                PortNumber = 502
            });

            var status = await fanUnit.GetStatusAsync();
            var temperatures = await fanUnit.GetTemperaturesAsync();
            var fanSpeeds = await fanUnit.GetFanSpeedAsync();

            Console.WriteLine($"UnitOn: {status.UnitOn}");
            Console.WriteLine($"BoostActive: {status.BoostActive}");
            Console.WriteLine($"OverpressureActive: {status.OverpressureActive}");
            Console.WriteLine($"AwayActive: {status.AwayActive}");
            // print temperatures
            Console.WriteLine($"Exhaust: {temperatures.Exhaust}");
            Console.WriteLine($"Extract: {temperatures.Extract}");
            Console.WriteLine($"Outdoor: {temperatures.Outdoor}");
            Console.WriteLine($"Room: {temperatures.Room}");
            Console.WriteLine($"Supply: {temperatures.Supply}");
            Console.WriteLine($"Rotor: {temperatures.Rotor}");

            // print fan speeds
            Console.WriteLine($"SupplyFanSpeed: {fanSpeeds.CurrentSupplyFanSpeed} rpm");
            Console.WriteLine($"SupplyFanSpeedPower: {fanSpeeds.CurrentSupplyFanPower} %");
            Console.WriteLine($"ExtractFanSpeed: {fanSpeeds.CurrentExhaustFanSpeed} rpm");
            Console.WriteLine($"ExtractFanSpeedPower: {fanSpeeds.CurrentExhaustFanPower} %");

        }
    }
}

