using System.Collections.Generic;
using Application.Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Application.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ApplicationController : ControllerBase
    {
        private readonly IApplicationBusiness _applicationBusiness;
        public ApplicationController(IApplicationBusiness applicationBusiness)
        {
            _applicationBusiness = applicationBusiness;
        }

        [Route("{id}")]
        [HttpGet]
        public ActionResult<Models.Application.Application> Get([FromRoute]int id)
        {
            return Ok(_applicationBusiness.Get(id));
        }

        [HttpGet]
        public ActionResult<List<Models.Application.Application>> List()
        {
            return Ok(_applicationBusiness.List());
        }

        [HttpPatch]
        public ActionResult<Models.Application.Application> Update([FromBody] Models.Application.Application application)
        {
            return Ok(_applicationBusiness.Update(application));
        }

        [HttpPost]
        public ActionResult<Models.Application.Application> Add([FromBody] Models.Application.Application application)
        {
            return Ok(_applicationBusiness.Add(application));
        }

        [HttpDelete]
        public ActionResult<bool> Delete([FromQuery] int id)
        {
            return Ok(_applicationBusiness.Delete(id));
        }
    }
}
