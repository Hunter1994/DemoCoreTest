using Demo.Core.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Demo.Core.IReposotory
{
    public interface IPersonRepository
    {
        IEnumerable<Person> GetList();
    }
}
