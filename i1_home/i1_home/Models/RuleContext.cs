using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace i1.Models
{
    public class RuleContext: DbContext
    {
       
            public DbSet<Rule1> rule { get; set; }
    }
}