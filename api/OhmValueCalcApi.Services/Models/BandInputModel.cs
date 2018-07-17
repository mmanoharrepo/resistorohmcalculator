using System.ComponentModel.DataAnnotations;

namespace OhmValueCalcApi.Services.Models
{
    public class BandInputModel
    {
        /// <summary>
        /// The color of the first figure of component value band.
        /// </summary>
        [Required]
        public string BandAColor { get; set; }

        /// <summary>
        /// The color of the second significant figure band.
        /// </summary>
        [Required]
        public string BandBColor { get; set; }

        /// <summary>
        /// The color of the decimal multiplier band.
        /// </summary>
        [Required]
        public string BandCColor { get; set; }

        /// <summary>
        /// The color of the tolerance value band.
        /// </summary>
        [Required]
        public string BandDColor { get; set; }
    }
}
