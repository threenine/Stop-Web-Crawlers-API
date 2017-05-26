using System;
using Xunit;
using Api.Database;
using Microsoft.EntityFrameworkCore;
using Api.Controllers;
using Api.Database.Entity.Threats;
using AutoMapper;
using Threenine.AutoMapperConfig;
using PhilosophicalMonkey;

namespace Api.Tests
{
   public class RefererControllerTest   
    {
        public RefererControllerTest ()
        {
             //Set up code for automapper configuration 
            var seedTypes = new Type[] { typeof(Api.Domain.Marker) };
            var assemblies = Reflect.OnTypes.GetAssemblies(seedTypes);
            var typesInAssemblies = Reflect.OnTypes.GetAllExportedTypes(assemblies);
            MappingConfigurationFactory.LoadAllMappings(typesInAssemblies);
        }
       
        private ApiContext GetRefererData()
        {
             var options = new DbContextOptionsBuilder<ApiContext>()
            .UseInMemoryDatabase(Guid.NewGuid().ToString())
            .Options;

            var cxt = new ApiContext(options);

            cxt.Threats.Add(new Threat{ Id = 1, Name = "adsfasdf" , Referer = "dfasdfasdf"  });
            cxt.SaveChanges();
            return cxt;



        }

        [Fact]
        public void Get_List_Of_Referer()
        {
            using (var context = GetRefererData())
            {
                var controller = new RefererController(context);
                var list = controller.Get();
                Assert.NotNull(list);
            }
           
            

        }
    }
}
