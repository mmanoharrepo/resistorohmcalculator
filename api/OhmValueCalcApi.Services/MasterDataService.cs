using System.Linq;
using OhmValueCalcApi.Services.Helpers;
using OhmValueCalcApi.Services.Interfaces;
using OhmValueCalcApi.Services.Models;

namespace OhmValueCalcApi.Services
{
    public class MasterDataService : IMasterDataService
    {
        /// <summary>
        /// Get bandcolorcodes - Colors that should be shown for each band
        /// </summary>
        /// <returns></returns>
        public BandColorCodes GetBandColors()
        {
            var ringColorCodes = ColorCodeInputsHelper.GetRingColorCodes();

            var colorCodes = new BandColorCodes();

            var colorsWithSignificantFigure = ringColorCodes.Where(r => r.SignficantFigure.HasValue).Select(r => r.Name);
            colorCodes.FirstBandColorCodes.AddRange(colorsWithSignificantFigure);
            colorCodes.SecondBandColorCodes.AddRange(colorsWithSignificantFigure);

            var colorsWithMultiplier = ringColorCodes.Where(r => r.Multiplier.HasValue).Select(r => r.Name);
            colorCodes.ThirdBandColorCodes.AddRange(colorsWithMultiplier);

            var colorsWithTolerance = ringColorCodes.Where(r => r.Tolerance.HasValue).Select(r => r.Name);
            colorCodes.FourthBandColorCodes.AddRange(colorsWithTolerance);

            return colorCodes;
        }
    }
}
