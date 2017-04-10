using System;
using Microsoft.EntityFrameworkCore;

namespace Api.Database
{
    public class ApiContext : DbContext
    {
        public ApiContext (DbContextOptions<ApiContext> options) : base(options){ }
    }
}
