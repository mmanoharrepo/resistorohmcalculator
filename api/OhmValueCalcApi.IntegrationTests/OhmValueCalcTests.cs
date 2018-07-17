using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using OhmValueCalcApi.Services;
using OhmValueCalcApi.Services.Interfaces;
using OhmValueCalcApi.Services.Models;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace OhmValueCalcApi.IntegrationTests
{
    [TestClass]
    public class OhmValueCalcTests
    {
        private readonly TestServer _testServer;
        private readonly HttpClient _client;

        #region Private Variables
        private IMasterDataService _masterDataService;
        #endregion

        public OhmValueCalcTests()
        {
            _testServer = new TestServer(WebHost.CreateDefaultBuilder()
             .UseStartup<Startup>()
             .UseEnvironment("Development"));
            _client = _testServer.CreateClient();
            _masterDataService = new MasterDataService();
        }

        [TestMethod]
        public async Task GetBandCodes_ExpectBandCodes()
        {
            //Act
            var result = await _client.GetAsync("OhmValue/GetBandCodes");

            //Assert
            Assert.IsNotNull(result);
            var responseString = await result.Content.ReadAsStringAsync();
            var bandColorCodes = JsonConvert.DeserializeObject<BandColorCodes>(responseString);
            Assert.IsNotNull(bandColorCodes);
            var bandColorCodesFromService = _masterDataService.GetBandColors();
            Assert.AreEqual(bandColorCodes.FirstBandColorCodes.Count, bandColorCodesFromService.FirstBandColorCodes.Count);
            Assert.AreEqual(bandColorCodes.SecondBandColorCodes.Count, bandColorCodesFromService.SecondBandColorCodes.Count);
            Assert.AreEqual(bandColorCodes.ThirdBandColorCodes.Count, bandColorCodesFromService.ThirdBandColorCodes.Count);
            Assert.AreEqual(bandColorCodes.FourthBandColorCodes.Count, bandColorCodesFromService.FourthBandColorCodes.Count);
        }

        [TestMethod]
        public async Task CalculateOhmValue_NullInput_ExpectsBadRequest()
        {
            //Arrange
            var content = new StringContent("", Encoding.UTF8, "application/json");

            //Act
            var result = await _client.PostAsync("OhmValue/Calculate", content);

            //Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(result.StatusCode, System.Net.HttpStatusCode.BadRequest);
        }

        [TestMethod]
        public async Task CalculateOhmValue_InputWithEmptyBands_ExpectsBadRequest()
        {
            //Arrange
            var inputModel = new BandInputModel();
            var content = new StringContent(JsonConvert.SerializeObject(inputModel), Encoding.UTF8, "application/json");

            //Act
            var result = await _client.PostAsync("OhmValue/Calculate", content);

            //Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(result.StatusCode, System.Net.HttpStatusCode.BadRequest);
        }

        [TestMethod]
        public async Task CalculateOhmValue_InputWithNonExistingBands_ExpectsBadRequest()
        {
            //Arrange
            var inputModel = new BandInputModel() { BandAColor = "Test" , BandBColor = "Black", BandCColor = "White", BandDColor = "None" };
            var content = new StringContent(JsonConvert.SerializeObject(inputModel), Encoding.UTF8, "application/json");

            //Act
            var result = await _client.PostAsync("OhmValue/Calculate", content);

            //Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(result.StatusCode, System.Net.HttpStatusCode.BadRequest);
        }

        [TestMethod]
        public async Task CalculateOhmValue_ValidInput_ReturnsCalculatedDataSuccessfully()
        {
            //Arrange
            var inputModel = new BandInputModel()
            {
                BandAColor = "Yellow",
                BandBColor = "Violet",
                BandCColor = "Orange",
                BandDColor = "Gold"
            };
            var content = new StringContent(JsonConvert.SerializeObject(inputModel), Encoding.UTF8, "application/json");

            //Act
            var result = await _client.PostAsync("OhmValue/Calculate", content);

            //Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(result.StatusCode, System.Net.HttpStatusCode.OK);
            var responseString = await result.Content.ReadAsStringAsync();
            var resistorOhmValue = JsonConvert.DeserializeObject<ResistorOhmValue>(responseString);
            Assert.IsNotNull(resistorOhmValue);
            Assert.AreEqual(resistorOhmValue.OhmValue, 47000);
            Assert.AreEqual(resistorOhmValue.MaxValue, 49350);
            Assert.AreEqual(resistorOhmValue.MinValue, 44650);
        }
    }
}
