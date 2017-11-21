using Api.Database;
using Api.Domain.Bots;
using AutoMapper.QueryableExtensions;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace Api.Controllers
{

    [Route("api/[controller]")]
    public class RefererController : Controller
    {
        private readonly ApiContext _context;


        public RefererController (ApiContext context)
        {
            _context = context;
        }

        /// <summary>
        ///       Returns a complete list of Known Referer Spammmers
        /// </summary>
        ///<remarks>
        /// Returns a JSON array including all known Referer Spam bots
        ///  GET /get
        /// {
        ///    {
        ///      "name": "Name of Referer ",
        ///      "url":  "Url to block",
        ///      "type": "Type of Bot",
        ///      "status": "Enabled"
        ///     }
        /// }
        ///</remarks>
        [HttpGet("[action]")]
       
        public IQueryable<Referer> Get()
        {
           return _context.Threats.Where(x => x.Status.Name == $"Enabled").AsQueryable().ProjectTo<Referer>();
        }
       
        
        



    }

}
