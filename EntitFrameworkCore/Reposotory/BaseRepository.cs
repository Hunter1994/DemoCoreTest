using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Linq.Expressions;
using Demo.Core.IReposotory;

namespace Demo.EntitFrameworkCore.Reposotory
{
    public class BaseRepository<T>: IBaseRepository<T> 
        where T : class
    {
        protected DemoContext _context;
        public BaseRepository(DemoContext context)
        {
            _context = context;
        }
        public T Get(Expression<Func<T, bool>> where)
        {
            return _context.Set<T>().Where(where).FirstOrDefault();
        }

    }
}
