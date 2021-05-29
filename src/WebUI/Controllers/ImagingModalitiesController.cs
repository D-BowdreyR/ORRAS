using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ORRAS.Application.Features.ImagingModalities;
using ORRAS.Domain.Entities;

namespace ORRAS.WebUI.Controllers
{
    public class ImagingModalitiesController : ApiControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<List<ImagingModality>>> List(CancellationToken ct)
        {
            return await Mediator.Send(new List.Query(), ct);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ImagingModality>> Details(Guid id)
        {
            return await Mediator.Send(new Details.Query { Id = id });
        }

    }
}