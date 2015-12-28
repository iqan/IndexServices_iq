//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Web;
//using System.Web.Mvc;
//using i1.Models;

//namespace i1.Controllers
//{
//    public class ValidateController : Controller
//    {


//        public ActionResult Index()
//        {
//            List<Stocks1> Stocks = new List<Stocks1>();
//            List<Stocks1> Update = new List<Stocks1>();
//            List<MonitorDisp> IndexMoniters = new List<MonitorDisp>();
//            List<Indice> Indexs = new List<Indice>();
//            List<Rule1> Rules = new List<Rule1>();

//            IndexBusinessLayer Index = new IndexBusinessLayer();
//            StockBusinessLayer Stock = new StockBusinessLayer();
//            RuleBusinessLayer Rule = new RuleBusinessLayer();

//            Indexs = Index.Ind.ToList();
//            Stocks = Stock.Ind.ToList();
//            Rules = Rule.rule.ToList();


//            RuleManipulation Obj = new RuleManipulation();
//            int i;
//            i = Obj.Manipulate(ref Rules, ref Stocks, ref IndexMoniters);

//            if (i==0)
//            {
//                return View(Update);
//            }
//            else
//            return View(Stocks);
//        }


//        public ActionResult Ru()
//        {

//            List<Stocks1> Stocks = new List<Stocks1>();
//            List<Stocks1> Update = new List<Stocks1>();
//            List<MonitorDisp> IndexMoniters = new List<MonitorDisp>();
//            List<Indice> Indexs = new List<Indice>();
//            List<Rule1> Rules = new List<Rule1>();

//            IndexBusinessLayer Index = new IndexBusinessLayer();
//            StockBusinessLayer Stock = new StockBusinessLayer();
//            RuleBusinessLayer Rule = new RuleBusinessLayer();

//            Indexs = Index.Ind.ToList();
//            Stocks = Stock.Ind.ToList();
//            Rules = Rule.rule.ToList();

//            return View(Rules);
//        }








//        public ActionResult St()
//        {

//            List<Stocks1> Stocks = new List<Stocks1>();
//            List<Stocks1> Update = new List<Stocks1>();
//            List<MonitorDisp> IndexMoniters = new List<MonitorDisp>();
//            List<Indice> Indexs = new List<Indice>();
//            List<Rule1> Rules = new List<Rule1>();

//            IndexBusinessLayer Index = new IndexBusinessLayer();
//            StockBusinessLayer Stock = new StockBusinessLayer();
//            RuleBusinessLayer Rule = new RuleBusinessLayer();

//            Indexs = Index.Ind.ToList();
//            Stocks = Stock.Ind.ToList();
//            Rules = Rule.rule.ToList();

//            return View(Stocks);
//        }







//        public ActionResult In()
//        {

//            List<Stocks1> Stocks = new List<Stocks1>();
//            List<Stocks1> Update = new List<Stocks1>();
//            List<MonitorDisp> IndexMoniters = new List<MonitorDisp>();
//            List<Indice> Indexs = new List<Indice>();
//            List<Rule1> Rules = new List<Rule1>();

//            IndexBusinessLayer Index = new IndexBusinessLayer();
//            StockBusinessLayer Stock = new StockBusinessLayer();
//            RuleBusinessLayer Rule = new RuleBusinessLayer();

//            Indexs = Index.Ind.ToList();
//            Stocks = Stock.Ind.ToList();
//            Rules = Rule.rule.ToList();

//            return View(Indexs);
//        }







//        public ActionResult Im()
//        {

//            List<Stocks1> Stocks = new List<Stocks1>();
//            List<Stocks1> Update = new List<Stocks1>();
//            List<MonitorDisp> IndexMoniters = new List<MonitorDisp>();
//            List<Indice> Indexs = new List<Indice>();
//            List<Rule1> Rules = new List<Rule1>();

//            IndexBusinessLayer Index = new IndexBusinessLayer();
//            StockBusinessLayer Stock = new StockBusinessLayer();
//            RuleBusinessLayer Rule = new RuleBusinessLayer();

//            Indexs = Index.Ind.ToList();
//            Stocks = Stock.Ind.ToList();
//            Rules = Rule.rule.ToList();
//            return View(IndexMoniters);
//        }




//    }
//}
