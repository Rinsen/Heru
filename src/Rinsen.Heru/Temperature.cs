namespace Rinsen.Heru
{
    public class Temperature
    {
        /// <summary>
        /// Outdoor temperature entering fan unit
        /// </summary>
        public double Outdoor { get; set; }

        /// <summary>
        /// Intake temperature in heat exchanger
        /// </summary>        
        public double Rotor { get; set; }

        /// <summary>
        /// Supply temperature leaving fan unit
        /// </summary>
        public double Supply { get; set; }

        /// <summary>
        /// Optional: Room temperature if sensor is installed
        /// </summary>
        public double? Room { get; set; } = null;

        /// <summary>
        /// Temperature of air entering heat exchanger from extract air
        /// </summary>
        public double Extract { get; set; }

        /// <summary>
        /// Temperature of air leaving heat exchanger to outdoor
        /// </summary>
        public double Exhaust { get; set; }



    }
}