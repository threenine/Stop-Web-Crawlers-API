using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Api.Database;
using Api.Database.Entity.Threats;
using AutoMapper.QueryableExtensions;
using Api.Domain.Bots;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;

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
           return _context.Threats.ProjectTo<Referer>().Where(x => x.Status == "Enabled").AsQueryable();
        }
       
        
        



    }

}
