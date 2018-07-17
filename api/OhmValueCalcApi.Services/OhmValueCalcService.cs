using System;
using System.Collections.Generic;
using System.Linq;
using OhmValueCalcApi.Services.Helpers;
using OhmValueCalcApi.Services.Interfaces;
using OhmValueCalcApi.Services.Models;

namespace OhmValueCalcApi.Services
{
    public class OhmValueCalcService : IOhmValueCalcService
    {
        #region Private Variables
        private IEnumerable<RingColorCode> _ringColorCodes;
        #endregion

        #region Constructor
        public OhmValueCalcService()
        {
            _ringColorCodes = ColorCodeInputsHelper.GetRingColorCodes();
        }
        #endregion

        #region Public Methods

        /// <summary>
        /// Calculates the ohmvalue of a resistor based on the given band colors.
        /// </summary>
        /// <param name="bandInputModel">Band Inputs Model</param>
        /// <returns>Resistor Ohm Value</returns>
        public ResistorOhmValue CalculateOhmValue(BandInputModel bandInputModel)
        {
            if (bandInputModel == null || string.IsNullOrWhiteSpace(bandInputModel.BandAColor) ||
                string.IsNullOrWhiteSpace(bandInputModel.BandBColor) || string.IsNullOrWhiteSpace(bandInputModel.BandCColor) ||
                string.IsNullOrWhiteSpace(bandInputModel.BandDColor))
                throw new ArgumentNullException("BandInputs cannot be null or empty!!");

            var firstBandColorCode = _ringColorCodes.FirstOrDefault(r => r.Name.ToLower() == bandInputModel.BandAColor.ToLower() && r.SignficantFigure.HasValue);
            var secondBandColorCode = _ringColorCodes.FirstOrDefault(r => r.Name.ToLower() == bandInputModel.BandBColor.ToLower() && r.SignficantFigure.HasValue);
            var thirdBandColorCode = _ringColorCodes.FirstOrDefault(r => r.Name.ToLower() == bandInputModel.BandCColor.ToLower() && r.Multiplier.HasValue);
            var fourthBandColorCode = _ringColorCodes.FirstOrDefault(r => r.Name.ToLower() == bandInputModel.BandDColor.ToLower() && r.Tolerance.HasValue);

            if (firstBandColorCode == null || secondBandColorCode == null || thirdBandColorCode == null || fourthBandColorCode == null)
                throw new ArgumentException("Invalid Parameters, One or more input colors are invalid!!");

            var resistorOhmValue = new ResistorOhmValue();

            var firstDigit = firstBandColorCode.SignficantFigure.Value;
            var secondDigit = secondBandColorCode.SignficantFigure.Value;
            var multiplier = thirdBandColorCode.Multiplier.Value;
            var tolerance = fourthBandColorCode.Tolerance.Value;

            resistorOhmValue.OhmValue = (firstDigit * 10 + secondDigit) * multiplier;
            resistorOhmValue.MinValue = Math.Round(resistorOhmValue.OhmValue * (1 - tolerance));
            resistorOhmValue.MaxValue = Math.Round(resistorOhmValue.OhmValue * (1 + tolerance));

            return resistorOhmValue;
        }
        #endregion
    }
}
