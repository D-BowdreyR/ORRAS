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
    }
}