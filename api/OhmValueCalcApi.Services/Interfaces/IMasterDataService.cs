using OhmValueCalcApi.Services.Models;

namespace OhmValueCalcApi.Services.Interfaces
{
    public interface IMasterDataService
    {
        /// <summary>
        /// Get bandcolorcodes - Colors that should be shown for each band
        /// </summary>
        /// <returns>BandColorCodes</returns>
        BandColorCodes GetBandColors();
    }
}
