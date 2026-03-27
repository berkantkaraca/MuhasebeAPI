using Microsoft.AspNetCore.Mvc;
using MuhasebeAPI.Presentation.Abstraction;

namespace MuhasebeAPI.Presentation.Controllers;

public sealed class TestController : ApiController
{
    [HttpGet]
    public IActionResult Get()
    {
        return Ok("İşlem başarılı");
    }
}
