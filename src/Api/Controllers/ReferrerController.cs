using System.Collections.Generic;
using Api.Domain.Bots;
using Microsoft.AspNetCore.Mvc;
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
       
    }
}