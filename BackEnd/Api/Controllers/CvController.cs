//using Api.ViewModels.Cv;
//using Api.ViewModels.UploadFileFromForm;
//using AutoMapper;
//using Castle.Core.Internal;
//using Data.Entities;
//using Microsoft.AspNetCore.Authorization;
//using Microsoft.AspNetCore.Identity;
//using Microsoft.AspNetCore.Mvc;
//using Service.Interfaces;

//namespace Api.Controllers
//{
//    [Authorize]
//    public class CvController : BaseAPIController
//    {
//        private readonly ICvService _cvService;
//        private readonly UserManager<WebUser> _userManager;
//        private readonly IApplicationSuggestionService _applicationSuggestionService;
//        private readonly IFileService _fileService;
//        private readonly IHttpClientFactory _httpClientFactory;
//        private readonly IMapper _mapper;

//        public CvController(ICvService cvService,
//            UserManager<WebUser> userManager,
//            IApplicationSuggestionService applicationSuggestionService,
//            IFileService uploadFileService,
//            IHttpClientFactory httpClientFactory,
//            IMapper mapper)
//        {
//            _cvService = cvService;
//            _userManager = userManager;
//            _applicationSuggestionService = applicationSuggestionService;
//            _fileService = uploadFileService;
//            _httpClientFactory = httpClientFactory;

//            _mapper = mapper;
//        }

//        [HttpGet]
//        public async Task<IActionResult> GetAllCv(string? request)
//        {
//            var cvList = await _cvService.GetAllCv(request);
//            if (cvList.IsNullOrEmpty())
//            {
//                return Ok("Not found");
//            }
//            var response = _mapper.Map<List<CvViewModel>>(cvList); //List<CV>>
//            return Ok(response);
//        }

//        [HttpPost]
//        public async Task<IActionResult> SaveCv([FromBody] CvAddModel request)
//        {
//            if (request == null)
//                return BadRequest();

//            if (ModelState.IsValid)
//            {
//                var cvList = await _cvService.SaveCv(request);
//                if (cvList is null)
//                {
//                    return Ok("Not found");
//                }
//                return Ok(cvList);
//            }
//            ModelState.AddModelError("", "Could not create new CV!");
//            return NotFound(request);
//        }

//        [HttpPost("[action]/{Cvid:guid}")]
//        public async Task<IActionResult> UploadCvPdf([FromForm] UploadFileFromForm request, Guid Cvid)
//        {
//            //var fileExtension = Path.GetExtension(request.CvPDF.FileName);
//            //// Các đuôi file cho phép
//            //var allowedExtensions = new[] { ".pdf" };
//            //if (!allowedExtensions.Contains(fileExtension.ToLower()))
//            //{
//            //    // Xử lý khi tệp tải lên không phải là pdf
//            //    ModelState.AddModelError("", "Uploaded file is not pdf!");
//            //    return BadRequest();
//            //}

//            var resp = await _cvService.UploadCvPdf(request.File, Cvid);

//            if (resp is false)
//                return BadRequest(resp);

//            return Ok(resp);
//        }

//        [HttpPut("{requestId:guid}")]
//        public async Task<IActionResult> UpdateCv([FromBody] CvUpdateModel request, Guid requestId)
//        {
//            if (ModelState.IsValid)
//            {
//                //var cvpdf = await _fileService.AddFileAsync(request.CvPDF);
//                var cvList = await _cvService.UpdateCv(request, requestId);
//                if (cvList == false)
//                {
//                    return Ok("Not found");
//                }
//                return Ok(cvList);
//            }
//            ModelState.AddModelError("", "Could not Update CV!");
//            return NotFound(request);
//        }

//        [HttpDelete("{requestId:guid}")]
//        public async Task<IActionResult> DeleteCv(Guid requestId)
//        {
//            if (ModelState.IsValid)
//            {
//                var resp = await _cvService.DeleteCv(requestId);
//                if (resp == false)
//                {
//                    return Ok("Not found");
//                }
//                return Ok(resp);
//            }
//            ModelState.AddModelError("", "Could not Delete CV!"); ;
//            return NotFound();
//        }

//        [HttpGet("[action]/{candidateId:guid}")]
//        public async Task<IActionResult> GetCandidateCvs(Guid candidateId)
//        {
//            var cvList = await _cvService.GetCvsOfCandidate(candidateId);
//            if (cvList == null)
//            {
//                return Ok("Not found");
//            }
//            return Ok(cvList);
//        }

//        [HttpGet("[action]/{Cvid:guid}")]
//        public async Task<IActionResult> GetCv(Guid Cvid)
//        {
//            var cv = await _cvService.GetCvById(Cvid);
//            if (cv == null)
//            {
//                return Ok("Not found");
//            }
//            // await DownloadImageFromCloudinary(cv.CvPdf);
//            return Ok(cv);
//        }

//        [HttpGet("{positionId:guid}")]
//        public async Task<IActionResult> GetCvSuggestions(Guid positionId)
//        {
//            var response = await _applicationSuggestionService.GetSuggestion(positionId);
//            return Ok(response);
//        }

//        [HttpGet("UserCv")]
//        public async Task<IActionResult> GetUserCv()
//        {
//            string role = "Candidate";
//            var curUser = await GetIdCurrent();
//            if (curUser.Id != null && curUser.Role.Contains(role))
//            {
//                var response = await _cvService.GetAllUserCv(curUser.Id);
//                if (response == null)
//                {
//                    return BadRequest("Cv has not been created");
//                }
//                return Ok(response);
//            }
//            return BadRequest();
//        }

//        private async Task<IdAndRoleModel> GetIdCurrent()
//        {
//            var userName = HttpContext.User.Identity!.Name;
//            var user = await _userManager.FindByNameAsync(userName);
//            var userRole = await _userManager.GetRolesAsync(user);
//            if (user != null && userRole != null)
//            {
//                var CurUser = new IdAndRoleModel()
//                {
//                    Id = user.Id,
//                    Role = userRole.ToList(),
//                };
//                return (CurUser);
//            }
//            return (null!);
//        }
//        [HttpDelete("DeleteFile")]
//        public async Task<IActionResult> DeleteFile(string path)
//        {
//            var data = await _fileService.DeleteFileAsync(path);
//            return Ok(data);
//        }

//        [HttpGet("download")]
//        public async Task<IActionResult> DownloadImageFromCloudinary(string imageUrl)
//        {
//            if (string.IsNullOrEmpty(imageUrl))
//            {
//                return BadRequest("Image URL is required.");
//            }

//            using var httpClient = _httpClientFactory.CreateClient();
//            try
//            {
//                // Gửi yêu cầu GET để download tấm hình từ Cloudinary
//                var response = await httpClient.GetAsync(imageUrl);

//                // Kiểm tra xem yêu cầu có thành công không
//                if (response.IsSuccessStatusCode)
//                {
//                    // Lấy nội dung của tấm hình từ response
//                    var imageStream = await response.Content.ReadAsStreamAsync();

//                    // Chuyển Stream thành mảng byte
//                    using var memoryStream = new MemoryStream();
//                    await imageStream.CopyToAsync(memoryStream);
//                    var imageBytes = memoryStream.ToArray();

//                    // Trả về FileContentResult để download tấm hình
//                    return new FileContentResult(imageBytes, "image/jpeg")
//                    {
//                        FileDownloadName = "downloaded_image.jpg"
//                    };
//                }
//                else
//                {
//                    // Xử lý lỗi nếu yêu cầu không thành công
//                    return BadRequest("Error while downloading image from Cloudinary.");
//                }
//            }
//            catch (HttpRequestException)
//            {
//                // Xử lý lỗi nếu URL không hợp lệ hoặc không thể kết nối đến Cloudinary
//                return BadRequest("Invalid image URL or failed to connect to Cloudinary.");
//            }
//        }
//    }

//    public class IdAndRoleModel
//    {
//        public string Id { get; set; } = string.Empty;
//        public List<string> Role { get; set; } = new();
//    }
//}