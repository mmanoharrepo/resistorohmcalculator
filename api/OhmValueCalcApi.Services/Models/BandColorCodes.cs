using System.Collections.Generic;

namespace OhmValueCalcApi.Services.Models
{
    /// <summary>
    /// BandColorCodes
    /// </summary>
    public class BandColorCodes
    {
        public BandColorCodes()
        {
            FirstBandColorCodes = new List<string>();
            SecondBandColorCodes = new List<string>();
            ThirdBandColorCodes = new List<string>();
            FourthBandColorCodes = new List<string>();
        }

        /// <summary>
        /// Gets or Sets FirstBandColorCodes
        /// </summary>
        public List<string> FirstBandColorCodes { get; set; }

        /// <summary>
        /// Gets or Sets SecondBandColorCodes
        /// </summary>
        public List<string> SecondBandColorCodes { get; set; }

        /// <summary>
        /// Gets or Sets ThirdBandColorCodes
        /// </summary>
        public List<string> ThirdBandColorCodes { get; set; }

        /// <summary>
        /// Gets or sets FourthBandColorCodes
        /// </summary>
        public List<string> FourthBandColorCodes { get; set; }
    }
}
