using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.Domain.Bots;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swc.Service;
using Swashbuckle.AspNetCore;

namespace swcApi.Controllers
{
    /// <inheritdoc />
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class ReferrerController : Controller
    {
        private readonly IReferrerService _referrerService;

        /// <inheritdoc />
        public ReferrerController(IReferrerService referrerService)
        {
            _referrerService = referrerService;
        }

        /// <summary>
        ///  Returns a list of all active referrer spammers
        /// </summary>
        ///<remarks>
        /// This is a remark to add additional information about this method
        ///  GET /get
        /// {
        ///    "value1", 
        ///    "value2"
        /// }
        ///</remarks>
        [HttpGet]
        public IEnumerable<Referrer> Get()
        {
            return _referrerService.GetAllActive();
        }


        /// <summary>
        ///  Returns a collection of values
        /// </summary>
        ///<remarks>
        /// This is a remark to add additional information about this method
        ///  GET /get
        /// {
        ///    "value1", 
        ///    "value2"
        /// }
        ///</remarks>
        [HttpPost]
        public IActionResult Post([FromBody] Referrer referrer)
        {
            if (referrer == null)
            {
                return BadRequest();
            }
           
           var identifier =  _referrerService.Insert(referrer);
            

            return CreatedAtRoute("Detail", new {  referer = identifier }, referrer);
        }

        /// <summary>
        ///  Returns a collection of values
        /// </summary>
        ///<remarks>
        /// This is a remark to add additional information about this method
        ///  GET /get
        /// {
        ///    "value1", 
        ///    "value2"
        /// }
        ///</remarks>
        [HttpGet("{identifier}")]
        public Referrer Detail(string identifier)
        {
            return _referrerService.GetReferer(identifier);
        }
    }
}