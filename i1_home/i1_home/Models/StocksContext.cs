using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace i1.Models
{
    public class StocksContext
    {
        public class StockContext : DbContext
        {
            public DbSet<Stocks1> stock { get; set; }
        }
    }
}