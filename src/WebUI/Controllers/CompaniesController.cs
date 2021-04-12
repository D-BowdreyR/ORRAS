using System.Threading;
using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ORRA.Application.Companies.Queries;
using System.Collections.Generic;
using ORRA.Domain.Entities;
using ORRA.Infrastructure.Persistence;

namespace ORRA.WebUI.Controllers
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
        public async Task<ActionResult<List<Company>>> List(CancellationToken ct)
        {
            return await Mediator.Send(new ListCompanies.Query(), ct);
        }
    }
}