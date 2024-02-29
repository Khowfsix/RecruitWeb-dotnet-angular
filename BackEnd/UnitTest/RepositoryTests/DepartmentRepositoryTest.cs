//using Api.ViewModels.Company;
//using AutoMapper;
//using Data;
//using Data.Entities;
//using Data.Interfaces;
//using Data.Mapping;
//using Data.Repositories;
//using FakeItEasy;
//using Service;

//namespace UnitTest.RepositoryTests
//{
//    public class CompanyRepository_UnitTest
//    {
//        private readonly CompanyRepository _CompanyRepository;
//        private readonly CompanyService _CompanyService;

//        private readonly RecruitmentWebContext _fakeDbContext = A.Fake<RecruitmentWebContext>();
//        private readonly ICompanyRepository _fakeCompanyRepository = A.Fake<ICompanyRepository>();
//        private readonly IUnitOfWork _fakeUow = A.Fake<IUnitOfWork>();
//        private readonly IMapper _mapper;
//        public CompanyRepository_UnitTest()
//        {
//            _mapper = new MapperConfiguration(cfg =>
//                        {
//                            cfg.AddProfile(new AutoMapperConfiguration());
//                        }).CreateMapper();

//            _CompanyRepository = new CompanyRepository(_fakeDbContext, _fakeUow, _mapper);
//            _CompanyService = new CompanyService(_fakeCompanyRepository, _mapper);
//        }

//        [Fact]
//        public async Task Add_Company_In_Repository_Returns_Correctly()
//        {
//            //Code để check repo trả về model với id tạo ở model, tên giống tên truyền vào từ add model
//            //Arrange
//            var fakeCompanyId = Guid.NewGuid();

//            var fakeCreatedCompany = new CompanyAddModel
//            {
//                CompanyName = "string",
//            };

//            var mappedCreatedCompany = _mapper.Map<CompanyModel>(fakeCreatedCompany);
//            mappedCreatedCompany.CompanyId = fakeCompanyId;
//            //Act
//            var response = await _CompanyRepository.SaveCompany(mappedCreatedCompany);

//            //Assert
//            Assert.NotEqual(mappedCreatedCompany.CompanyId, response.CompanyId);
//        }

//        [Fact]
//        public async Task Get_Company_Returns_Correctly()
//        {
//            //Arrange
//            List<CompanyModel> companyList = new();
//            var expectedCreatedCompany1 = new CompanyModel
//            {
//                CompanyId = Guid.NewGuid(),
//                CompanyName = "string",
//                IsDeleted = false
//            };
//            var expectedCreatedCompany2 = new CompanyModel
//            {
//                CompanyId = Guid.NewGuid(),
//                CompanyName = "string",
//                IsDeleted = false
//            };
//            var expectedCreatedCompany3 = new CompanyModel
//            {
//                CompanyId = Guid.NewGuid(),
//                CompanyName = "string",
//                IsDeleted = false
//            };
//            companyList.Add(expectedCreatedCompany1);
//            companyList.Add(expectedCreatedCompany2);
//            companyList.Add(expectedCreatedCompany3);
//            //Act
//            A.CallTo(() => _fakeCompanyRepository.GetAllCompany(null)).Returns(companyList);
//            var response = await _CompanyService.GetAllCompany(null);

//            //Assert
//            Assert.IsAssignableFrom<IEnumerable<CompanyViewModel>>(response);
//        }
//    }
//}