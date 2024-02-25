//using Api.ViewModels.Room;
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
//    public class RoomRepository_UnitTest
//    {
//        private readonly RoomRepository _RoomRepository;
//        private readonly RoomService _roomService;

//        private readonly RecruitmentWebContext _fakeDbContext = A.Fake<RecruitmentWebContext>();
//        private readonly IRoomRepository _fakeRoomRepository = A.Fake<IRoomRepository>();
//        private readonly IUnitOfWork _fakeUow = A.Fake<IUnitOfWork>();
//        private readonly IMapper _mapper;

//        public RoomRepository_UnitTest()
//        {
//            _mapper = new MapperConfiguration(cfg =>
//                        {
//                            cfg.AddProfile(new AutoMapperConfiguration());
//                        }).CreateMapper();

//            _RoomRepository = new RoomRepository(_fakeDbContext, _fakeUow, _mapper);
//            _roomService = new RoomService(_fakeRoomRepository, _mapper);
//        }

//        [Fact]
//        public async Task Add_Room_In_Repository_Returns_Correctly()
//        {
//            //Code để check repo trả về model với id tạo ở model, tên giống tên truyền vào từ add model
//            //Arrange
//            var fakeRoomId = Guid.NewGuid();

//            var fakeCreatedRoom = new RoomAddModel
//            {
//                RoomName = "string",
//            };

//            var mappedCreatedRoom = _mapper.Map<RoomModel>(fakeCreatedRoom);
//            mappedCreatedRoom.RoomId = fakeRoomId;
//            //Act
//            var response = await _RoomRepository.SaveRoom(mappedCreatedRoom);

//            //Assert
//            Assert.NotEqual(mappedCreatedRoom.RoomId, response.RoomId);
//        }

//        [Fact]
//        public async Task Get_Room_Returns_Correctly()
//        {
//            //Arrange
//            List<RoomModel> list = new();
//            var expectedCreatedRoom1 = new RoomModel
//            {
//                RoomId = Guid.NewGuid(),
//                RoomName = "string",
//                IsDeleted = false
//            };
//            var expectedCreatedRoom2 = new RoomModel
//            {
//                RoomId = Guid.NewGuid(),
//                RoomName = "string",
//                IsDeleted = false
//            };
//            var expectedCreatedRoom3 = new RoomModel
//            {
//                RoomId = Guid.NewGuid(),
//                RoomName = "string",
//                IsDeleted = false
//            };

//            //Act
//            A.CallTo(() => _fakeRoomRepository.GetAllRoom()).Returns(list);
//            var response = await _roomService.GetAllRoom();

//            //Assert
//            Assert.IsAssignableFrom<IEnumerable<RoomViewModel>>(response);
//        }
//    }
//}