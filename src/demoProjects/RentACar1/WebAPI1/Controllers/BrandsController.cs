using Application.Features.someFeature.Commands.CreateSomeFeature;
using Application.Features.someFeature.Dtos;
using Application1.Features.Brands.Commands.CreateBrand;
using Application1.Features.Brands.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BrandsController : BaseController
    {
        [HttpPost]
        public async Task<IActionResult> Add([FromBody] CreateBrandCommand createBrandCommand)
        {
            CreatedBrandDto result = await Mediator.Send(createBrandCommand);
            return Created("", result);
        }
    }
}
