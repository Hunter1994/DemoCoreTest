using Demo.Core.Domain;
using Demo.Core.IReposotory;
using Demo.IService;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Demo.Service
{
    public class PersonService : IPersonService
    {
        private IBaseRepository<Person> _baseRepository;
        private IPersonRepository _personRepository;
        private IBaseRepository<Project> _projectRepository;

        public PersonService(IBaseRepository<Person> baseRepository
             ,IPersonRepository personRepository
            ,IBaseRepository<Project> projectRepository)
        {
            _baseRepository = baseRepository;
            _personRepository = personRepository;
            _projectRepository = projectRepository;
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

        public IEnumerable<Person> GetContainProject()
        {
            var persons = (from person in _baseRepository.GetList(x => true)
                           join project in _projectRepository.GetList(x => true) on person.Id equals project.PersonId
                           select person).ToList();
            return persons;
        }
    }
}
