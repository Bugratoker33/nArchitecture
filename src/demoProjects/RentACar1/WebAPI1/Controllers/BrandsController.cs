using Application.Features.someFeature.Commands.CreateSomeFeature;
using Application.Features.someFeature.Dtos;
using Application1.Features.Brands.Commands.CreateBrand;
using Application1.Features.Brands.Dtos;
using Application1.Features.Brands.Models;
using Application1.Features.Brands.Queries.GetListBrand;
using Core.Application.Requests;
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
            CreatedBrandDto result = await Mediator.Send(createBrandCommand);//mediater a git bu commandın handeelereini bul diyoruz 
            return Created("", result);
        }
        [HttpGet]
        public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
        {
           GetListBrandQuery getListBrandQuery = new () { PageRequest =pageRequest};
           BrandListModel result= await Mediator.Send(getListBrandQuery);//mediater a git bu commandın handeelereini bul diyoruz 
            return Ok(result);

        }
    }
}
