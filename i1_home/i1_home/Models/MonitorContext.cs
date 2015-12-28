using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Data.Entity;

namespace i1.Models
{
    public class MonitorContext:DbContext
    {   
            public DbSet<MonitorDisp> Ind { get; set; }   
    }
}