using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace i1.ViewModel
{
    public class LocViewModel
    {
        public IEnumerable<SelectListItem> listcountries { get; set; }
        public IEnumerable<SelectListItem> liststates { get; set; }
    }
}