using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ORRAS.Application.Features.ResearchStudies.Queries;

namespace ORRAS.WebUI.Controllers
{
    public class StudiesController : ApiControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<StudiesVm>> GetStudies(CancellationToken ct)
        {
            return await Mediator.Send(new ListStudies.Query(), ct);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ResearchStudyDto>> GetStudy(Guid id, CancellationToken ct)
        {

            return await Mediator.Send(new GetStudy.Query { Id = id }, ct);
        }
    }
}