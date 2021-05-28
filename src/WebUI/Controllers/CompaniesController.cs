using System.Threading;
using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ORRAS.Application.Companies.Queries;
using System.Collections.Generic;
using ORRAS.Domain.Entities;
using ORRAS.Infrastructure.Persistence;

namespace ORRAS.WebUI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompaniesController : ApiControllerBase
    {

        [HttpGet("{id}")]
        public async Task<ActionResult<Company>> Details(Guid id)
        {
            return await Mediator.Send(new Details.Query { Id = id });
        }

        [HttpGet]
        public async Task<ActionResult<CompaniesVm>> List(CancellationToken ct)
        {
            return await Mediator.Send(new ListCompanies.Query(), ct);
        }

        // TODO: add Create, Update and Delete endpoints for companies
    }
}