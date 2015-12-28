using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using i1.Models;

namespace i1.Controllers
{
    public class IndiceController : Controller
    {
        //
        // GET: /Indice/

        public ActionResult Index()
        {
            IndexBusinessLayer indexBusinessLayer =
           new IndexBusinessLayer();

            List<Indice> indexex = indexBusinessLayer.Ind.ToList();
            return View(indexex);
           // return View();
        }

        //
        // GET: /Indice/Details/5

        public ActionResult Details(Indice i)
        {
            return View(i);
        }

        //
        // GET: /Indice/Create

        public ActionResult Create()
        {
            return View();
        } 

        //
        // POST: /Indice/Create

        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            //if (ModelState.IsValid)
            //{
            //    foreach (string key in collection.AllKeys)
            //    {
            //        Response.Write("Key = " + key + "  ");
            //        Response.Write("Value = " + collection[key]);
            //        Response.Write("<br/>");
            //    }
            //}
            //return View();
            Indice indice = new Indice();
            // Retrieve form data using form collection
            indice.IndexId = collection["IndexId"];
            indice.IndexName = collection["IndexName"];
            indice.IndexInsertionDate = DateTime.Today;
            indice.LoginId = collection["LoginId"];

            IndexBusinessLayer indexBusinessLayer =
                new IndexBusinessLayer();

            indexBusinessLayer.AddIndice(indice);
            return RedirectToAction("Index");
        }
        
        //
        // GET: /Indice/Edit/5

        public ActionResult Edit(Indice i,string indexId)
        {
            string temp = TempData["userid"].ToString();
            TempData.Keep();                 //Data will not be lost for all Keys
            TempData.Keep("userid");
            if (temp == i.LoginId)
            {
                IndexBusinessLayer indiceBusinessLayer =
                       new IndexBusinessLayer();
                Indice indice1 =
                       indiceBusinessLayer.Ind.SingleOrDefault(e => e.IndexId == indexId);
                ViewBag.error = null;
                return View(indice1);
            }
            else
            {
                ViewBag.error = "Sorry, You cant edit this.";
                return View();
            }
        }


        //
        // POST: /Indice/Edit/5

        [HttpPost]
        public ActionResult Edit(Indice indice)
        {
            if (ModelState.IsValid)
            {
                IndexBusinessLayer indiceBusinessLayer =
                    new IndexBusinessLayer();
                indiceBusinessLayer.SaveEmmployee(indice);

                return RedirectToAction("Index");
            }
            return View(indice);
        }

        //
        // GET: /Indice/Delete/5

        //public ActionResult Delete()
        //{
        //    return View();
        //}

        //
        // POST: /Indice/Delete/5

        public ActionResult Delete(Indice i,string indexId)
        {
            string temp = TempData["userid"].ToString();
            TempData.Keep();                 //Data will not be lost for all Keys
            TempData.Keep("userid");
            if (temp == i.LoginId)
            {
                IndexBusinessLayer indiceBusinessLayer =
          new IndexBusinessLayer();
                Indice indiceTemp = new Indice();
                indiceTemp = indiceBusinessLayer.GetIndiceToSelect(indexId);
                ViewBag.error = null;
                return View(indiceTemp);   
            }
            else
            {
                ViewBag.error = "Sorry, You cant delete this.";
                return View();
            }
        }

        [HttpPost]
        public ActionResult Delete(Indice indice)
        {
            IndexBusinessLayer indiceBusinessLayer =
                   new IndexBusinessLayer();
            indiceBusinessLayer.DeleteEmployee(indice.IndexId);
            List<Indice> indexex = indiceBusinessLayer.Ind.ToList();

            return View("Index", indexex);
        }
        //[HttpPost]
        //public ActionResult Delete(int id, FormCollection collection)
        //{
        //    try
        //    {
        //        // TODO: Add delete logic here

        //        return RedirectToAction("Index");
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}
    }
}
