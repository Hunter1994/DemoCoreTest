using Demo.Core.Domain;
using Demo.Core.IReposotory;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Demo.EntitFrameworkCore.Reposotory
{
    public class PersonRepository :BaseRepository<Person>, IPersonRepository
    {
        public PersonRepository(DemoContext context) : base(context)
        {
        }

        public IEnumerable<Person> GetList()
        {
            return _context.People.ToList();
        }

        public int? SumAge()
        {
            return _context.People.Sum(r => r.Age);
        }
        public int SumNum()
        {
            return _context.People.Sum(r => r.Num);
        }
    }
}
