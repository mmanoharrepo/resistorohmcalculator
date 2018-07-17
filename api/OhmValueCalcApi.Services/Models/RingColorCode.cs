namespace OhmValueCalcApi.Services.Models
{
    public class RingColorCode
    {
        /// <summary>
        /// Gets or Sets Name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or Sets Significant Figure
        /// </summary>
        public int? SignficantFigure { get; set; }

        /// <summary>
        /// Gets or Sets Multiplier
        /// </summary>
        public double? Multiplier { get; set; }

        /// <summary>
        /// Gets or Sets Tolerance
        /// </summary>
        public double? Tolerance { get; set; }
    }
}
