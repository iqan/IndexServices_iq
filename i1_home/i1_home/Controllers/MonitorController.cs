using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using i1.Models;

namespace i1.Controllers
{
    public class MonitorController : Controller
    {
        //
        // GET: /Monitor/

        public ActionResult Index()
        {
            MonitorBusinessLayer indexBusinessLayer =
            new MonitorBusinessLayer();

            List<MonitorDisp> indexex = indexBusinessLayer.Ind.ToList();
            return View(indexex);
            // return View();
        }

        //
        // GET: /Monitor/Details/5

        public ActionResult Details()
        {
            MonitorBusinessLayer indexBusinessLayer =
             new MonitorBusinessLayer();

            List<MonitorDisp> indexex = indexBusinessLayer.Ind.ToList();
            return View(indexex);
        }

        //
        // GET: /Monitor/Create

        public ActionResult Create()
        {
            return View();
        } 

        //
        // POST: /Monitor/Create

        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
        
        //
        // GET: /Monitor/Edit/5
 
        public ActionResult Edit(int id)
        {
            return View();
        }

        //
        // POST: /Monitor/Edit/5

        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here
 
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Monitor/Delete/5
 
        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /Monitor/Delete/5

        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
 
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
