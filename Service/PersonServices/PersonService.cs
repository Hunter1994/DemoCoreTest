using Demo.Core.Domain;
using Demo.Core.IReposotory;
using Demo.IService;
using System;
using System.Collections.Generic;
using System.Text;

namespace Demo.Service
{
    public class PersonService : IPersonService
    {
        private IBaseRepository<Person> _baseRepository;
        private IPersonRepository _personRepository;
        public PersonService(IBaseRepository<Person> baseRepository, IPersonRepository personRepository)
        {
            _baseRepository = baseRepository;
            _personRepository = personRepository;
        }
        public Person Get()
        {
            //return new Person() { Name = "asd" };
            return _baseRepository.Get(r => true);
        }

        public IEnumerable<Person> GetList()
        {
            return _personRepository.GetList();
        }
    }
}
