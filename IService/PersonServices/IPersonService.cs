using Demo.Core.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Demo.IService
{
    public interface IPersonService
    {
        Person Get();
        IEnumerable<Person> GetList();

        IEnumerable<Person> GetContainProject();

    }
}
