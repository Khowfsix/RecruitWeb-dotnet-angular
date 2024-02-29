//using Api.Controllers;
//using Api.ViewModels.Company;
//using Microsoft.AspNetCore.Mvc;
//using Moq;
//using Service.Interfaces;

//namespace UnitTest.Company
//{
//    public class CompanyControllerTests
//    {
//        private readonly Mock<ICompanyService> _mockCompanyService;
//        private readonly CompanyController _CompanyController;

//        public CompanyControllerTests()
//        {
//            _mockCompanyService = new Mock<ICompanyService>();
//            _CompanyController = new CompanyController(_mockCompanyService.Object);
//        }

//        [Fact]
//        public async Task Company_Controller_Get_All_Test()
//        {
//            // Arrange
//            var expecteds = new List<CompanyViewModel>
//            {
//                new CompanyViewModel(),
//                new CompanyViewModel()
//            };

//            _mockCompanyService.Setup(service => service.GetAllCompany(null)).ReturnsAsync(expecteds);

//            // Act
//            var result = await _CompanyController.GetAllCompany(null) as OkObjectResult;

//            // Assert
//            Assert.NotNull(result);
//            Assert.Equal(200, result.StatusCode);
//            var CompanyList = Assert.IsType<List<CompanyViewModel>>(result.Value);
//            Assert.Equal(2, CompanyList.Count);
//        }

//        [Fact]
//        public async Task Company_Controller_Save_Company_Test()
//        {
//            // Arrange
//            var input = new CompanyAddModel();

//            var expected = new CompanyViewModel();

//            _mockCompanyService.Setup(service => service.SaveCompany(input)).ReturnsAsync(expected);

//            // Act
//            var result = await _CompanyController.SaveCompany(input) as OkObjectResult;

//            // Assert
//            Assert.NotNull(result);
//            Assert.Equal(200, result.StatusCode);
//            var created = Assert.IsType<CompanyViewModel>(result.Value);
//        }

//        [Fact]
//        public async Task Company_Controller_Update_Company_Test()
//        {
//            // Arrange
//            Guid CompanyId = Guid.NewGuid();
//            var input = new CompanyUpdateModel();

//            var expected = true;

//            _mockCompanyService.Setup(service => service.UpdateCompany(input, CompanyId)).ReturnsAsync(true);

//            // Act
//            var result = await _CompanyController.UpdateCompany(input, CompanyId) as OkObjectResult;

//            // Assert
//            Assert.NotNull(result);
//            Assert.Equal(200, result.StatusCode);
//            var updated = Assert.IsType<bool>(result.Value);
//            Assert.Equal(expected, updated);
//        }

//        [Fact]
//        public async Task Company_Controller_Delete_Company_Test()
//        {
//            // Arrange
//            Guid CompanyId = Guid.NewGuid();
//            var expected = true;

//            _mockCompanyService.Setup(service => service.DeleteCompany(CompanyId)).ReturnsAsync(true);

//            // Act
//            var result = await _CompanyController.DeleteCompany(CompanyId) as OkObjectResult;

//            // Assert
//            Assert.NotNull(result);
//            Assert.Equal(200, result.StatusCode);
//            var deleted = Assert.IsType<bool>(result.Value);
//            Assert.Equal(expected, deleted);
//        }
//    }
//}