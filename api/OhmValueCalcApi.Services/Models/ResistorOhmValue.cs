namespace OhmValueCalcApi.Services.Models
{
    public class ResistorOhmValue
    {
        /// <summary>
        /// Gets or Sets OhmValue (Without Tolerance)
        /// </summary>
        public double OhmValue { get; set; }

        /// <summary>
        /// Gets or Sets MinValue
        /// </summary>
        public double MinValue { get; set; }

        /// <summary>
        /// Gets or Sets Maxvalue
        /// </summary>
        public double MaxValue { get; set; }
    }
}
