using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using i1.Models;

namespace i1.Controllers
{
    public class RuleController : Controller
    {
        //
        // GET: /Rule/

        public ActionResult Index()
        {
            RuleBusinessLayer indexBusinessLayer =
           new RuleBusinessLayer();

            List<Rule1> indexex = indexBusinessLayer.rule.ToList();
            return View(indexex);
        }

        //
        // GET: /Rule/Details/5

        public ActionResult Expression()
        {
            StockBusinessLayer s = new StockBusinessLayer();
           

            return View();
        }


        public ActionResult Details(Rule1 r)
        {
            
            return View(r);
        }

        //
        // GET: /Rule/Create

        [HttpPost]
        public ActionResult Create1(FormCollection coll)
        {
            string temp = " Index id = " + coll["IndexId"] + " Fund id = " + coll["FundId"] + " Fund Name = " + coll[" FundName"] + " Fund Price = " + coll["FundPrice"] + " Effective Date = " + coll["EffectiveDate"] + " Minimum Threshold >= " + coll["MinimumThreshold"] + " Maximum Threshold < " + coll["MaximumThreshold"];
            Rule1 r = new Rule1();
            r.RuleExpression = temp;
            r.RuleCreationDate = System.DateTime.Now;
            return RedirectToAction("Create",r);
        }

        public ActionResult Create(Rule1 r)
        {
            return View(r);
        } 

        //
        // POST: /Rule/Create

        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            Rule1 rule1 = new Rule1();
            // Retrieve form data using form collection
            rule1.RuleId = collection["RuleId"];
            rule1.RuleName = collection["RuleName"];
            rule1.RuleExpression = collection["RuleExpression"];
            rule1.RuleCreationDate = Convert.ToDateTime(collection["RuleCreationDate"]);
            rule1.FundId = collection["FundId"];
            rule1.LoginId = TempData["userid"].ToString();
            //string temp = TempData["userid"].ToString();
            TempData.Keep();                 //Data will not be lost for all Keys
            TempData.Keep("userid");

            RuleBusinessLayer ruleBusinessLayer =
                new RuleBusinessLayer();

            ruleBusinessLayer.AddRule(rule1);
            return RedirectToAction("Index");
        }
        
        //
        // GET: /Rule/Edit/5
        [HttpGet]
        public ActionResult Edit(Rule1 rule1, FormCollection form)
        {
            RuleBusinessLayer ruleBusinessLayer =
                   new RuleBusinessLayer();
            Rule1 rule2 =
                   ruleBusinessLayer.rule.SingleOrDefault(e => e.RuleId == rule1.RuleId);

            return View(rule1);
        }

        //
        // POST: /Rule/Edit/5

        [HttpPost]
        public ActionResult Edit(Rule1 rule1)
        {

            if (ModelState.IsValid)
            {
                RuleBusinessLayer ruleBusinessLayer =
                    new RuleBusinessLayer();
                ruleBusinessLayer.SaveRule(rule1);

                return RedirectToAction("Index");
            }
            return View(rule1);
        }

        //
        // GET: /Rule/Delete/5
 
        public ActionResult Delete(string ruleid)
        {
            RuleBusinessLayer ruleBusinessLayer =
                   new RuleBusinessLayer();
            Rule1 ruleTemp = new Rule1();
            ruleTemp = ruleBusinessLayer.GetRuleToSelect(ruleid);
            return View(ruleTemp);
        }

        //
        // POST: /Rule/Delete/5

        [HttpPost]
        public ActionResult Delete(Rule1 rule123)
        {
            RuleBusinessLayer ruleBusinessLayer =
                    new RuleBusinessLayer();
            ruleBusinessLayer.DeleteRule(rule123.RuleId);
            List<Rule1> indexex = ruleBusinessLayer.rule.ToList();

            return View("Index", indexex);
        }

        public ActionResult ValidateRule(Rule1 rule)
        {
            List<Stocks1> Stocks = new List<Stocks1>();
            List<MonitorDisp> IndexMoniters = new List<MonitorDisp>();
            List<Indice> Indexs = new List<Indice>();
            List<Rule1> Rules = new List<Rule1>();

            IndexBusinessLayer Index = new IndexBusinessLayer();
            StockBusinessLayer Stock = new StockBusinessLayer();
            RuleBusinessLayer Rule = new RuleBusinessLayer();

            Indexs = Index.Ind.ToList();
            Stocks = Stock.Ind.ToList();
            Rules = Rule.rule.ToList();

            RuleManipulation Obj = new RuleManipulation();
            int i;
            i = Obj.Manipulate(ref rule, ref Stocks, ref IndexMoniters);

            if (i == 0)
            {
                Rule.ValidateRule(rule);
                TempData["message"] = "Validation Successful.";
                return View("Details", rule);
            }
            else
            {
                TempData["message"] = "Validation Unsuccessful.";
                return View("Index", Rules);
            }
        }
    }
}
