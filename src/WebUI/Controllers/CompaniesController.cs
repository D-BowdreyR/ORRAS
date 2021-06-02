using System.Threading;
using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using ORRAS.Domain.Entities;
using ORRAS.Infrastructure.Persistence;
using ORRAS.Application.Features.Companies.Queries;
using ORRAS.Application.Features.Companies.Commands;
using MediatR;
using Microsoft.AspNetCore.Authorization;

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
        
        [Authorize]
        [HttpGet]
        public async Task<ActionResult<CompaniesVm>> List(CancellationToken ct)
        {
            return await Mediator.Send(new ListCompanies.Query(), ct);
        }
        
        // TODO: add Create, Update and Delete endpoints for companies
        [HttpPost]
        public async Task<ActionResult<Unit>> CreateCompany(NewCompanyDto company, CancellationToken ct)
        {
            return await Mediator.Send(new CreateCompany.Command{Company = company}, ct);
        }
        [HttpPut("{id}")]
        public async Task<ActionResult> EditCompany()
        {
            return NoContent();
        }

        [HttpDelete("{id}")]

         public async Task<ActionResult> DeleteCompany()
        {
            return NoContent();
        }
    }
}