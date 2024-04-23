using Application2.Features.Language.Dtos;
using Application2.Features.Languages.Commnds.Created.CreatedLanguage;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LanguageController : BaseController
    {
        [HttpPost]
        public async Task<IActionResult> Add([FromBody] CreateLangugaCommand createLangugaCommand)
        {
            CreateLanguageDtos result = await Mediator.Send(createLangugaCommand);//mediater a git bu commandın handeelereini bul diyoruz 
            return Created("", result);
        }
    }
}
