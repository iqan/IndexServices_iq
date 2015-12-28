using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using i1.Models;

namespace i1.Controllers
{
    public class StocksController : Controller
    {
        //
        // GET: /stock/

        public ActionResult Index()
        {
            StockBusinessLayer indexBusinessLayer =
              new StockBusinessLayer();

            List<Stocks1> indexex = indexBusinessLayer.Ind.ToList();
            return View(indexex);
        }

        //
        // GET: /stock/Details/5

        public ActionResult Details(Stocks1 stck)
        {
            return View(stck);
        }

        //
        // GET: /stock/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /stock/Create

        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            Stocks1 indice = new Stocks1();
            indice.IndexId = collection["IndexId"];
            indice.FundId = collection["FundId"];
            indice.FundName = collection["FundName"];
            indice.FundPrice = Convert.ToDouble(collection["FundPrice"]);
            indice.EffectiveDate = Convert.ToDateTime(collection["EffectiveDate"]);
            indice.MinimumThreshold = Convert.ToDouble(collection["MinimumThreshold"]);
            indice.MaximumThreshold = Convert.ToDouble(collection["MaximumThreshold"]);
            indice.LoginId = collection["LoginId"];


            StockBusinessLayer indexBusinessLayer =
                new StockBusinessLayer();

            indexBusinessLayer.AddStock(indice);
            return RedirectToAction("Index");
        }

        //
        // GET: /stock/Edit/5

        [HttpGet]
        public ActionResult Edit(string fundId)
        {
            StockBusinessLayer indiceBusinessLayer =
                  new StockBusinessLayer();
            Stocks1 stock123 =
                   indiceBusinessLayer.Ind.SingleOrDefault(e => e.FundId == fundId);

            return View(stock123);
        }

        //
        // POST: /stock/Edit/5

        [HttpPost]
        public ActionResult Edit(Stocks1 stock123)
        {
            if (ModelState.IsValid)
            {
                StockBusinessLayer indiceBusinessLayer =
                    new StockBusinessLayer();
                indiceBusinessLayer.SaveStock(stock123);

                return RedirectToAction("Index");
            }
            return View(stock123);
        }

        //
        // GET: /stock/Delete/5

        public ActionResult Delete(string fundId)
        {
            StockBusinessLayer indiceBusinessLayer =
                   new StockBusinessLayer();
            Stocks1 indiceTemp = new Stocks1();
            indiceTemp = indiceBusinessLayer.GetStocksToSelect(fundId);
            return View(indiceTemp);
        }

        //
        // POST: /stock/Delete/5

        [HttpPost]
        public ActionResult Delete(Stocks1 stock123)
        {
            StockBusinessLayer stockBusinessLayer =
                  new StockBusinessLayer();
            stockBusinessLayer.DeleteStock(stock123.FundId);
            List<Stocks1> indexex = stockBusinessLayer.Ind.ToList();

            return View("Index", indexex);
        }

        public ActionResult rulex()
        {
            return View();
        }

        //
        // POST: /stock/Create

        [HttpPost]
        public ActionResult rulex(FormCollection collection)
        {
            Stocks1 indice = new Stocks1();
            indice.IndexId = collection["IndexId"];
            indice.FundId = collection["FundId"];
            indice.FundName = collection["FundName"];
            indice.FundPrice = Convert.ToDouble(collection["FundPrice"]);
            indice.EffectiveDate = Convert.ToDateTime(collection["EffectiveDate"]);
            indice.MinimumThreshold = Convert.ToDouble(collection["MinimumThreshold"]);
            indice.MaximumThreshold = Convert.ToDouble(collection["MaximumThreshold"]);
            indice.LoginId = collection["LoginId"];


            StockBusinessLayer indexBusinessLayer =
                new StockBusinessLayer();

            indexBusinessLayer.AddStock(indice);
            return RedirectToAction("Index");
        }

        public ActionResult rulexs(FormCollection coll)
        {
            return View(coll);
        }
    }
}
