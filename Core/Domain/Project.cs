using System;
using System.Collections.Generic;
using System.Text;

namespace Demo.Core.Domain
{
    public class Project
    {
        public long Id { get; set; }
        public long PersonId { get; set; }
        public string Name { get; set; }
    }
}
