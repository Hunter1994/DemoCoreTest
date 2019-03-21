using Demo.Core.Domain;
using Demo.Core.IReposotory;
using Demo.IService;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Demo.Host.Controllers
{
    
    public class PersonController: BaseController
    {
        private IPersonService _personService;
        private IBaseRepository<Person> _baseRepository;
        public PersonController(IPersonService personService, IBaseRepository<Person> baseRepository)
        {
            _personService = personService;
            _baseRepository = baseRepository;
        }

        public IEnumerable<Person> GetList()
        {
            return _personService.GetList();
        }

        public Person Get()
        {
           var a= _personService.SumAge();
           var b= _personService.SumNum();

            return _baseRepository.Get(r => true);
        }

        public IEnumerable<Person> GetContainProject()
        {
            return _personService.GetContainProject();
        }

    }
}
