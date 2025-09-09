using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MultiShop.Images.Controller;

[AllowAnonymous]
[Route("api/[controller]")]
[ApiController]
public class GoogleDriveImageUploadController : ControllerBase
{
}