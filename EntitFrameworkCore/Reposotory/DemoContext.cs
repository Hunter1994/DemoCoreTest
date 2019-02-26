using System;
using System.Collections.Generic;
using System.Text;
using Demo.Core.Domain;
using Microsoft.EntityFrameworkCore;

namespace Demo.EntitFrameworkCore.Reposotory
{
    public class DemoContext:DbContext
    {
        public DbSet<Person> People { get; set; }

        public DemoContext()
        {

        }

        public DemoContext(DbContextOptions<DemoContext> options) : base(options) { }
    }
}
