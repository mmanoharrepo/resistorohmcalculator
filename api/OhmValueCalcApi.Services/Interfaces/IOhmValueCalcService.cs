using OhmValueCalcApi.Services.Models;

namespace OhmValueCalcApi.Services.Interfaces
{
    public interface IOhmValueCalcService
    {
        /// <summary>
        /// Calculates the ohmvalue of a resistor based on the given band colors.
        /// </summary>
        /// <param name="bandInputModel">Band Inputs Model</param>
        /// <returns>Resistor Ohm Value</returns>
        ResistorOhmValue CalculateOhmValue(BandInputModel bandInputModel);
    }
}