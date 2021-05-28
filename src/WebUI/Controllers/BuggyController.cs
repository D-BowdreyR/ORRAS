using System;
using Microsoft.AspNetCore.Mvc;
using ORRAS.Application.Common.Exceptions;

namespace ORRAS.WebUI.Controllers
{
    public class BuggyController : ApiControllerBase
    {
         [HttpGet("not-found")]
        public ActionResult GetNotFound()
        {
            throw new NotFoundException("The resource was not found");
        }

        [HttpGet("bad-request")]
        public ActionResult GetBadRequest()
        {
            return BadRequest("This is a bad request");
        }

        [HttpGet("server-error")]
        public ActionResult GetServerError()
        {
            throw new Exception("This is a server error");
        }

        [HttpGet("unauthorised")]
        public ActionResult GetUnauthorised()
        {
            return Unauthorized();
        }
    }
}