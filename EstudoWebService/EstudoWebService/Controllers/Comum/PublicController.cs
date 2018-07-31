using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace EstudoWebService.Controllers.Comum
{
    [RoutePrefix("api/public")]
    public class PublicController : ApiControllerBase
    {
        [HttpGet]
        [Route("is-alive")]
        public IHttpActionResult IsAlive()
        {
            return Ok(true);
        }
    }
}
