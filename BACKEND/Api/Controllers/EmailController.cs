using Api.ViewModels.ContactEmail;
using Api.ViewModels.Interview;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Service.Services;

namespace Api.Controllers;

[Authorize]
public class EmailController : BaseAPIController
{
    private readonly IEmailService _emailService;
    private readonly IMapper _mapper;

    public EmailController(IEmailService emailService, IMapper mapper)
    {
        _emailService = emailService;
        _mapper = mapper;
    }

    [HttpPost]
    [Authorize(Roles = "Recruiter, Admin")]
    public async Task<IActionResult> SendEmail(ContactEmailViewModel contactEmailViewModel)
    {

        return Ok();
    }
}