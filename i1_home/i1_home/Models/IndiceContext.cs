using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace i1.Models
{
    public class IndiceContext:DbContext
    {
        public DbSet<Indice> Ind { get; set; }
    }
}