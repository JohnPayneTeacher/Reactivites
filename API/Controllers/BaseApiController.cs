// FILE: BaseAPIController.cs
// NAME: John Payne
// COURSE: Udemy .NET Basics
// This is a base API controller to allow all other controllers to derive from

using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[ApiController]
[Route("api/{controller}")]

public class BaseApiController : ControllerBase
{
    
}