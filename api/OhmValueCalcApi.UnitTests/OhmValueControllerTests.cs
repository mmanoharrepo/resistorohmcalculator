using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using OhmValueCalcApi.Controllers;
using OhmValueCalcApi.Services.Interfaces;
using OhmValueCalcApi.Services.Models;
using System;
using System.Collections.Generic;

namespace OhmValueCalcApi.UnitTests
{
    [TestClass]
    public class OhmValueControllerTests
    {
        #region Private Variables
        private OhmValueController _ohmValueController;
        private Mock<IMasterDataService> _masterDataService;
        private Mock<IOhmValueCalcService> _ohmValueCalcService;
        #endregion

        [TestInitialize]
        public void InitializeTests()
        {
            _masterDataService = new Mock<IMasterDataService>();
            _ohmValueCalcService = new Mock<IOhmValueCalcService>();
            _ohmValueController = new OhmValueController(_masterDataService.Object, _ohmValueCalcService.Object);
        }

        [TestMethod]
        public void GetBandCodes_ExpectBandCodesJson()
        {
            //Arrange
            SetMockBandColorCodeData();

            //Act
            var result = _ohmValueController.GetBandCodes();

            //Assert
            Assert.IsNotNull(result);
            Assert.IsTrue(result is JsonResult);
            var jsonData = ((JsonResult)result).Value;
            Assert.IsNotNull(jsonData);
        }


        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException), "Inputs are requried!!")]
        public void CalculateOhmValue_NullInput_ExpectArgumentNullException()
        {
            var result = _ohmValueController.CalculateOhmValue(null);
        }

        [TestMethod]
        public void CalculateOhmValue_MissingBandCodes_ReturnsBadRequestObjectResult()
        {
            //Arrange
            var inputModel = new Services.Models.BandInputModel();
            _ohmValueController.ModelState.AddModelError("BandAColor", "Input is invalid");
            _ohmValueController.ModelState.AddModelError("BandBColor", "Input is invalid");
            _ohmValueController.ModelState.AddModelError("BandCColor", "Input is invalid");
            _ohmValueController.ModelState.AddModelError("BandDColor", "Input is invalid");

            //Act
            var result = _ohmValueController.CalculateOhmValue(inputModel);

            //Assert
            Assert.IsTrue(result is BadRequestObjectResult);
            var actionResult = (BadRequestObjectResult)result;
            Assert.IsNotNull(actionResult.Value);
        }

        [TestMethod]
        public void CalculateOhmValue_ValidInput_ReturnsCalculatedDataSuccessfully()
        {
            //Arrange
            var inputModel = new BandInputModel()
            {
                BandAColor = "Black",
                BandBColor = "Yellow",
                BandCColor = "Green",
                BandDColor = "White"
            };
            SetMockCalculateResult();

            //Act
            var result = _ohmValueController.CalculateOhmValue(inputModel);

            //Assert
            Assert.IsTrue(result is BadRequestObjectResult);
            var actionResult = (BadRequestObjectResult)result;
            Assert.IsNotNull(actionResult.Value);
        }

        private void SetMockBandColorCodeData()
        {
            _masterDataService.Setup(m => m.GetBandColors()).Returns(new Services.Models.BandColorCodes()
            {
                FirstBandColorCodes = new List<string>() { "Black" },
                SecondBandColorCodes = new List<string>() { "Yellow" },
                ThirdBandColorCodes = new List<string>() { "White" },
                FourthBandColorCodes = new List<string>() { "None" }
            });
        }

        private void SetMockCalculateResult()
        {
            _ohmValueCalcService.Setup(m => m.CalculateOhmValue(It.IsAny<BandInputModel>())).Returns(new ResistorOhmValue()
            {
                OhmValue = 40,
                MaxValue = 45,
                MinValue = 35
            });
        }
    }
}
