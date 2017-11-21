using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using System.IO;
using Api.Database.Entity.Threats;
using Newtonsoft.Json;
using Api.Database;

namespace Api
{
    public static class DbContextExtension
    {

        public static bool AllMigrationsApplied(this DbContext context)
        {
            var applied = context.GetService<IHistoryRepository>()
                .GetAppliedMigrations()
                .Select(m => m.MigrationId);

            var total = context.GetService<IMigrationsAssembly>()
                .Migrations
                .Select(m => m.Key);

            return !total.Except(applied).Any();
        }

        public static void EnsureSeeded(this ApiContext context)
        {

            if (!context.Type.Any())
            {
                var types = JsonConvert.DeserializeObject<List<ThreatType>>(File.ReadAllText("seed" + Path.DirectorySeparatorChar + "types.json"));
                context.AddRange(types);
                context.SaveChanges();
            }

            //Ensure we have some status
            if (!context.Status.Any())
            {
                var stati = JsonConvert.DeserializeObject<List<Status>>(File.ReadAllText(@"seed" + Path.DirectorySeparatorChar + "status.json"));
                context.AddRange(stati);
                context.SaveChanges();

            }
            //Ensure we create initial Threat List
            if (!context.Threats.Any())
            {
                var threats = JsonConvert.DeserializeObject<List<Threat>>(File.ReadAllText(@"seed" + Path.DirectorySeparatorChar + "threats.json"));
                context.AddRange(threats);
                context.SaveChanges();
            }
        }
    }

}