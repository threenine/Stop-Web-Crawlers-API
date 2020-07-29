using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using Api.Domain.Bots;
using Microsoft.AspNetCore.Mvc;
using NSwag.Annotations;
using Swc.Service;

namespace swcApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ReferrerController : ControllerBase
    {
        private readonly IReferrerService _referrerService;
        public ReferrerController(IReferrerService referrerService)
        {
            _referrerService = referrerService;
        }
        
        [HttpGet]
        public IEnumerable<Referrer> Get()
        {
            return _referrerService.GetAllActive();
        }
        
        [HttpGet("{identifier}")]
        [SwaggerResponse(HttpStatusCode.OK, typeof(Referrer), Description = "A single Referrer object containing information regarding the referrer ")]
       
        public async Task<ActionResult<Referrer>> Get(string identifier)
        {
            var referrer = await _referrerService.Details(identifier);
            return new ActionResult<Referrer>(referrer);
        }
        [HttpPost]
        public async Task<ActionResult<Referrer>> Create([FromBody] AddRefererer referrer)
        {
            if (!ModelState.IsValid) return new BadRequestObjectResult(ModelState);
            
                var threat = await _referrerService.Insert(referrer);
                return new CreatedResult($"/{threat.Identifier}", threat);
        }

    }
}