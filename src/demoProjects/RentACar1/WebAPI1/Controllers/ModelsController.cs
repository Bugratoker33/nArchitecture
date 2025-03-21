﻿using Application1.Features.Models.Models;
using Application1.Features.Models.Quaries.GetListModel;
using Application1.Features.Models.Quaries.GetListModelByDynamic;
using Core.Application.Requests;
using Core.Persistence.Dynamic;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ModelsController : BaseController
    {
        [HttpGet]
        public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
        {
            GetListModelQuery getListModelQuery = new GetListModelQuery{PageRequest = pageRequest };
            ModelListModel result = await Mediator.Send(getListModelQuery);
            return Ok(result);

          

        }

        [HttpPost("GetList/ByDynamic")]
        public async Task<IActionResult> GetListByDynamic([FromQuery] PageRequest pageRequest, [FromBody] Dynamic dynamic )
        {
            GetListModelByDynamicQuery getListModelByDynamicQuery = new GetListModelByDynamicQuery { PageRequest = pageRequest ,Dynamic = dynamic };
            ModelListModel result = await Mediator.Send(getListModelByDynamicQuery);
            return Ok(result);



        }
    }
}
