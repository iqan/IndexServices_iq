using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using i1.Models;
using i1_home.Models;

namespace i1.Service
{
    public class Loc
    {
        public List<country> GetCountryListFromDB()
        {
            using (idataEntities dataContext = new idataEntities())
            {
                return dataContext.countries.ToList();
            }
        }

        [HttpPost]
        public List<string> GetCityListFromDB(int stateId)
        {
            using (idataEntities dataContext = new idataEntities())
            {
                return dataContext.cities_new2.Where(query => query.state_id == stateId).Select(q => q.name).ToList();
            }
        }

        [HttpPost]
        public List<string> GetStateListFromDB(int countryid)
        {
            using (idataEntities dataContext = new idataEntities())
            {
                return dataContext.states.Where(query => query.country_id == countryid).Select(q => q.name).ToList();
            }
        }

        [HttpPost]
        public List<int> GetStateListIdFromDB(int countryId)
        {
            using (idataEntities dataContext = new idataEntities())
            {
                return dataContext.states.Where(query => query.country_id == countryId).Select(q => q.id).ToList();
            }
        }
    }
}