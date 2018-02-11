using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.Domain.Bots;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swc.Service;

namespace swcApi.Controllers
{
    [Produces("application/json")]
    [Route("api/Referrer")]
    public class ReferrerController : Controller
    {
        private readonly IReferrerService _referrerService;

        public ReferrerController(IReferrerService referrerService)
        {
            _referrerService = referrerService;
        }
        public IEnumerable<Referer> Get()
        {
            return _referrerService.GetAllActive();
        }
        [HttpPost]
        public IActionResult Create([FromBody] Referer referer)
        {
            if (referer == null)
            {
                return BadRequest();
            }
           
           var identifier =  _referrerService.Insert(referer);
            

            return CreatedAtRoute("Detail", new {  referer = identifier }, referer);
        }

        [HttpGet]
        public Referer Detail(string identifier)
        {
            return _referrerService.GetReferer(identifier);
        }
    }
}