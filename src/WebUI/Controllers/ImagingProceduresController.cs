using System.Threading;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ORRAS.Domain.Entities;
using ORRAS.Application.Features.ImagingProcedures;

namespace ORRAS.WebUI.Controllers
{
    public class ImagingProceduresController : ApiControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<List<ImagingProcedure>>> List(CancellationToken ct)
        {
            return await Mediator.Send(new List.Query(), ct);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ImagingProcedure>> Details(Guid id)
        {
            return await Mediator.Send(new Details.Query { Id = id });
        }
    }
}