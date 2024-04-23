using Application2.Features.Language.Dtos;
using Application2.Features.Languages.Commnds.Created.CreatedLanguage;
using Application2.Features.Languages.Models;
using Application2.Features.Languages.Queries.GetListLanguage;
using Core.Application.Requests;
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
        [HttpGet]
        public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
        {
            GetListLanguageQuery getListBrandQuery = new() { PageRequest = pageRequest };
            LanguageListModel result = await Mediator.Send(getListBrandQuery);//mediater a git bu commandın handeelereini bul diyoruz 
            return Ok(result);

        }
    }
}
