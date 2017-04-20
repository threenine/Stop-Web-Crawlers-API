using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Api.Database;
using Api.Database.Entity.Threats;
using AutoMapper.QueryableExtensions;
using Api.Domain.Bots;

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

          [HttpGet("[action]")]
        public IEnumerable<Referer> Get()
        {
           return _context.Threats.ProjectTo<Referer>().AsEnumerable();
        }
    }

}
