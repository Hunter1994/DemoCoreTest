using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Demo.Core.IReposotory
{
    public interface IBaseRepository<T> where T : class
    {
        T Get(Expression<Func<T, bool>> where);
        IQueryable<T> GetList(Expression<Func<T, bool>> where);
    }
}
