using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

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
            //_logger = logger;
        }

        [Route("{id}")]
        [HttpGet]
        public ActionResult<Models.Application.Application> Get([FromRoute]int id)
        {
            try
            {
                return Ok(_applicationBusiness.Get(id));
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpGet]
        public ActionResult<List<Models.Application.Application>> List()
        {
            try
            {
                return Ok(_applicationBusiness.List());
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpPatch]
        public ActionResult<Models.Application.Application> Update([FromBody] Models.Application.Application application)
        {
            try
            {
                return Ok(_applicationBusiness.Update(application));
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpPost]
        public ActionResult<Models.Application.Application> Add([FromBody] Models.Application.Application application)
        {
            try
            {
                return Ok(_applicationBusiness.Add(application));
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpDelete]
        public ActionResult<bool> Delete([FromQuery] int id)
        {
            try
            {
                return Ok(_applicationBusiness.Delete(id));
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
    }
}
