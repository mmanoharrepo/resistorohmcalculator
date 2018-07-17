using Microsoft.AspNetCore.Mvc;
using OhmValueCalcApi.Services.Interfaces;
using OhmValueCalcApi.Services.Models;
using System;

namespace OhmValueCalcApi.Controllers
{
    /// <summary>
    /// Api Controller - Contains members to calculate ohmvalue and to serve band codes
    /// </summary>
    public class OhmValueController : Controller
    {
        #region Private Variables
        private IMasterDataService _masterDataService;
        private IOhmValueCalcService _ohmValueCalcService;
        #endregion

        public OhmValueController(IMasterDataService masterDataService, IOhmValueCalcService ohmValueCalcService)
        {
            _masterDataService = masterDataService;
            _ohmValueCalcService = ohmValueCalcService;
        }

        #region Public Methods
        /// <summary>
        /// HttpGetMethod to return BandCodes
        /// </summary>
        /// <returns></returns>
        [HttpGet("[controller]/GetBandCodes")]
        public IActionResult GetBandCodes()
        {
            return Json(_masterDataService.GetBandColors());
        }

        /// <summary>
        /// HttpPostMethod to CalculateOhmValue for given colors
        /// </summary>
        /// <param name="bandInputModel"></param>
        /// <returns></returns>
        [HttpPost("[controller]/Calculate")]
        public IActionResult CalculateOhmValue([FromBody]BandInputModel bandInputModel)
        {
            if (bandInputModel == null)
                throw new ArgumentNullException("Inputs are requried!!");

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(_ohmValueCalcService.CalculateOhmValue(bandInputModel));
        }

        #endregion
    }
}
