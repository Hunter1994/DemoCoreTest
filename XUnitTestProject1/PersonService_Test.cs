using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using Microsoft.EntityFrameworkCore;
using Demo.EntitFrameworkCore.Reposotory;
using Demo.Host;
using Demo.IService;
using Demo.Core.IReposotory;
using Demo.Core.Domain;
using Shouldly;
using System.Linq;
namespace XUnitTestProject1
{
    public class PersonService_Test
    {

        private IPersonService _personService;
        private IBaseRepository<Person> _baseRepository;
        public PersonService_Test()
        {
            var service = new ServiceCollection();
            service.AddDbContext<DemoContext>(options =>
            {
                options.UseInMemoryDatabase(databaseName: "default");
            }, ServiceLifetime.Transient);
            service.AddAssmbles(false, "Demo.Host.dll", "Demo.IService.dll", "Demo.Service.dll", "Demo.Core.dll", "Demo.EntitFrameworkCore.dll");

            var provider = service.BuildServiceProvider();

            _personService= provider.GetRequiredService<IPersonService>();
            _baseRepository = provider.GetRequiredService<IBaseRepository<Person>>();

            var context= provider.GetRequiredService<DemoContext>();
            context.People.Add(new Person()
            {
                Id = 1,
                Name = "张迪"
            });
            context.SaveChanges();

        }



        [Fact]
        public void Get_Not_Null()
        {
            var person = _baseRepository.Get(r => true);
            person.ShouldNotBeNull();
        }

        [Fact]
        public void GetList_Not_Noll()
        {
            var persons = _personService.GetList();
            persons.ShouldNotBeNull();
        }

        [Fact]
        public void GetList_Is1()
        {
            var persons = _personService.GetList();
            persons.Count().ShouldBe(1);
        }


    }
}
