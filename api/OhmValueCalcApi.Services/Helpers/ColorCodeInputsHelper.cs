using OhmValueCalcApi.Services.Models;
using System.Collections.Generic;

namespace OhmValueCalcApi.Services.Helpers
{
    /// <summary>
    /// Color Code Inputs Helper - Provides color code and its matrix to calculate resister ohm value
    /// </summary>
    public static class ColorCodeInputsHelper
    {
        /// <summary>
        /// Get ringcolorcodes
        /// </summary>
        /// <returns>List of ringcolor codes</returns>
        public static IEnumerable<RingColorCode> GetRingColorCodes()
        {
            var ringColorCodes = new List<RingColorCode>();

            var blackColorCode = new RingColorCode
            {
                Name = "Black",
                SignficantFigure = 0,
                Multiplier = 1
            };
                ringColorCodes.Add(blackColorCode);

            var brownColorCode = new RingColorCode
            {
                Name = "Brown",
                SignficantFigure = 1,
                Multiplier = 10,
                Tolerance = 0.01
            };
            ringColorCodes.Add(brownColorCode);

            var redColorCode = new RingColorCode
            {
                Name = "Red",
                SignficantFigure = 2,
                Multiplier = 100,
                Tolerance = 0.02
            };
            ringColorCodes.Add(redColorCode);

            var orangeColorCode = new RingColorCode
            {
                Name = "Orange",
                SignficantFigure = 3,
                Multiplier = 1000
            };
            ringColorCodes.Add(orangeColorCode);

            var yellowColorCode = new RingColorCode
            {
                Name = "Yellow",
                SignficantFigure = 4,
                Multiplier = 10000
            };
            ringColorCodes.Add(yellowColorCode);

            var greenColorCode = new RingColorCode
            {
                Name = "Green",
                SignficantFigure = 5,
                Multiplier = 100000,
                Tolerance = 0.005
            };
            ringColorCodes.Add(greenColorCode);

            var blueColorCode = new RingColorCode
            {
                Name = "Blue",
                SignficantFigure = 6,
                Multiplier = 1000000,
                Tolerance = 0.0025
            };
            ringColorCodes.Add(blueColorCode);

            var violetColorCode = new RingColorCode
            {
                Name = "Violet",
                SignficantFigure = 7,
                Multiplier = 10000000,
                Tolerance = 0.0010
            };
            ringColorCodes.Add(violetColorCode);

            var greyColorCode = new RingColorCode
            {
                Name = "Gray",
                SignficantFigure = 8,
                Multiplier = 100000000,
                Tolerance = 0.0005
            };
            ringColorCodes.Add(greyColorCode);

            var whiteColorCode = new RingColorCode
            {
                Name = "White",
                SignficantFigure = 9,
                Multiplier = 1000000000
            };
            ringColorCodes.Add(whiteColorCode);

            var goldColorCode = new RingColorCode
            {
                Name = "Gold",
                Multiplier = 0.1,
                Tolerance = 0.05        
            };
            ringColorCodes.Add(goldColorCode);

            var silverColorCode = new RingColorCode
            {
                Name = "Silver",
                Multiplier = 0.01,
                Tolerance = 0.10
            };
            ringColorCodes.Add(silverColorCode);

            var pinkColorCode = new RingColorCode
            {
                Name = "Pink",
                Multiplier = 0.001
            };
            ringColorCodes.Add(pinkColorCode);

            var noneColorCode = new RingColorCode
            {
                Name = "None",
                Tolerance = 0.20
            };
            ringColorCodes.Add(noneColorCode);

            return ringColorCodes;
        }

    }
}
