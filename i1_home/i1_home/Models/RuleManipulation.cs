
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using i1.Models;
    using System.Globalization;

namespace i1.Models
{
    class RuleManipulation
    {
        public int Manipulate(ref Rule1 Rules, ref List<Stocks1> Stocks, ref List<MonitorDisp> IndexMoniters)
        {

            //string Rule = "Minimum Threshold > 1 and Maximum Threshold < 8 and Fund Name = 2";
            //-----------------------------------------------------------------------------------//
            /* Aditya Jha - 514329
             * Code For Rule Validation
             * If Rule Is Valid, It Is Inserted In Database
             * Exchange Value 1 denotes fundid is top
             * Exchange Value 2 denotes Indexid is top
             * If Rule Is Being Applied, Rule Status Is "Active", Else Inactive In "DataBase"
             * //Console.WriteLine("{0} {1} {2} {3}", s[i], s[i + 1], s[i + 2], s[i + 3]);
             */
            List<Stocks1> Temp = Stocks;
            int Value;
            string Rule = Rules.RuleExpression;
            
            char[] c = new char[] { ' ' };


            string[] s = Rule.Split(c);
            string[] op = new string[] { "=", ">", "<", ">=", "<=", ">=", "<=" };
            int i = 0, Exchange = 0;

            for (i = 0; i < s.Length; i += 5)
            {
                if ((s[i] == "Fund" || s[i] == "FUND" || s[i] == "fund") && (s[i + 1] == "Id" || s[i + 1] == "id" || s[i + 1] == "ID"))
                {
                    string TempString = null;
                    TempString = s[0];
                    s[0] = s[i];
                    s[i] = TempString;
                    TempString = s[1];
                    s[1] = s[i + 1];
                    s[i + 1] = TempString;
                    TempString = s[2];
                    s[2] = s[i + 2];
                    s[i + 2] = TempString;
                    TempString = s[3];
                    s[3] = s[i + 3];
                    s[i + 3] = TempString;
                    Exchange = 1; //Console.WriteLine("*{0}*", Exchange);
                    break;
                }
            }
            if (Exchange == 0)
            {
                for (i = 0; i < s.Length; i += 5)
                {
                    if ((s[i] == "Index" || s[i] == "Index" || s[i] == "INDEX") && (s[i + 1] == "Id" || s[i + 1] == "id" || s[i + 1] == "ID"))
                    {
                        string TempStringIndex = null;
                        TempStringIndex = s[0];
                        s[0] = s[i];
                        s[i] = TempStringIndex;
                        TempStringIndex = s[1];
                        s[1] = s[i + 1];
                        s[i + 1] = TempStringIndex;
                        TempStringIndex = s[2];
                        s[2] = s[i + 2];
                        s[i + 2] = TempStringIndex;
                        TempStringIndex = s[3];
                        s[3] = s[i + 3];
                        s[i + 3] = TempStringIndex;
                        Exchange = 2; //Console.WriteLine("*{0}*", Exchange);
                        break;
                    }
                }
            }


            for (i = 0; i < s.Length; i += 5)
            {

                if ((s[i] == "Index" || s[i] == "Index" || s[i] == "INDEX") && (s[i + 1] == "Id" || s[i + 1] == "id" || s[i + 1] == "ID"))
                {
                    if (s[i + 2] == "=")
                    {
                        Temp = Temp.Where(x => x.IndexId == s[i + 3]).ToList(); //Console.WriteLine("II{0}", Temp.Count);
                    }
                    //Console.WriteLine("{0} {1} {2} {3}", s[i], s[i + 1], s[i + 2], s[i + 3]);

                }
                else if ((s[i] == "Fund" || s[i] == "FUND" || s[i] == "fund") && (s[i + 1] == "Id" || s[i + 1] == "id" || s[i + 1] == "ID"))
                {
                    if (s[i + 2] == "=")
                    {
                        Temp = Temp.Where(x => x.FundId == s[i + 3]).ToList(); //Console.WriteLine("FI{0}", Temp.Count);
                    }
                    //Console.WriteLine("{0} {1} {2} {3}", s[i], s[i + 1], s[i + 2], s[i + 3]);
                }
                else if ((s[i] == "Fund" || s[i] == "FUND" || s[i] == "fund") && (s[i + 1] == "Name" || s[i + 1] == "NAME" || s[i + 1] == "name"))
                {
                    if (s[i + 2] == "=")
                    {
                        Temp = Temp.Where(x => x.FundName == s[i + 3]).ToList(); //Console.WriteLine("FN{0}", Temp.Count);
                    }
                    //Console.WriteLine("{0} {1} {2} {3}", s[i], s[i + 1], s[i + 2], s[i + 3]);
                }
                else if ((s[i] == "Fund" || s[i] == "FUND" || s[i] == "fund") && (s[i + 1] == "Price" || s[i + 1] == "PRICE" || s[i + 1] == "price"))
                {
                    Value = Convert.ToInt32(s[i + 3]);
                    if (s[i + 2] == "=")
                    {
                        Temp = Temp.Where(x => x.FundPrice == Value).ToList(); //Console.WriteLine("FP{0}", Temp.Count);
                    }
                    if (s[i + 2] == ">")
                    {
                        Temp = Temp.Where(x => x.FundPrice > Value).ToList(); //Console.WriteLine("FP{0}", Temp.Count);
                    }
                    if (s[i + 2] == "<")
                    {
                        Temp = Temp.Where(x => x.FundPrice < Value).ToList(); //Console.WriteLine("FP{0}", Temp.Count);
                    }
                    if (s[i + 2] == ">=")
                    {
                        Temp = Temp.Where(x => x.FundPrice >= Value).ToList(); //Console.WriteLine("FP{0}", Temp.Count);
                    }
                    if (s[i + 2] == "=>")
                    {
                        Temp = Temp.Where(x => x.FundPrice >= Value).ToList(); //Console.WriteLine("FP{0}", Temp.Count);
                    }
                    if (s[i + 2] == "<=")
                    {
                        Temp = Temp.Where(x => x.FundPrice <= Value).ToList(); //Console.WriteLine("FP{0}", Temp.Count);
                    }
                    if (s[i + 2] == "=<")
                    {
                        Temp = Temp.Where(x => x.FundPrice <= Value).ToList(); //Console.WriteLine("FP{0}", Temp.Count);
                    }
                    //Console.WriteLine("{0} {1} {2} {3}", s[i], s[i + 1], s[i + 2], s[i + 3]);
                }
                else if ((s[i] == "Effective" || s[i] == "EFFECTIVE" || s[i] == "effective") && (s[i + 1] == "DATE" || s[i + 1] == "Date" || s[i + 1] == "date"))
                {
                    DateTime Date = new DateTime();
                    string[] formats = { "MM/dd/yyyy", "M/d/yyyy", "M/dd/yyyy", "MM/d/yyyy", "MM-dd-yyyy", "M-d-yyyy", "M-dd-yyyy", "MM-d-yyyy" };
                    Date = DateTime.ParseExact(s[i + 3], formats, new CultureInfo("en-US"), DateTimeStyles.None);
                    if (s[i + 2] == "=")
                    {
                        Temp = Temp.Where(x => x.EffectiveDate == Date).ToList(); //Console.WriteLine("ED{0}", Temp.Count);
                    }
                    if (s[i + 2] == ">")
                    {
                        Temp = Temp.Where(x => x.EffectiveDate > Date).ToList(); //Console.WriteLine("ED{0}", Temp.Count);
                    }
                    if (s[i + 2] == "<")
                    {
                        Temp = Temp.Where(x => x.EffectiveDate < Date).ToList(); //Console.WriteLine("ED{0}", Temp.Count);
                    }
                    if (s[i + 2] == ">=")
                    {
                        Temp = Temp.Where(x => x.EffectiveDate >= Date).ToList(); //Console.WriteLine("ED{0}", Temp.Count);
                    }
                    if (s[i + 2] == "=>")
                    {
                        Temp = Temp.Where(x => x.EffectiveDate >= Date).ToList(); //Console.WriteLine("ED{0}", Temp.Count);
                    }
                    if (s[i + 2] == "<=")
                    {
                        Temp = Temp.Where(x => x.EffectiveDate <= Date).ToList(); //Console.WriteLine("ED{0}", Temp.Count);
                    }
                    if (s[i + 2] == "=<")
                    {
                        Temp = Temp.Where(x => x.EffectiveDate <= Date).ToList(); //Console.WriteLine("ED{0}", Temp.Count);
                    }
                    //Console.WriteLine("{0} {1} {2} {3}", s[i], s[i + 1], s[i + 2], s[i + 3]);
                }
                else if ((s[i] == "MINIMUM" || s[i] == "Minimum" || s[i] == "minimum") && (s[i + 1] == "Threshold" || s[i + 1] == "THRESHOLD" || s[i + 1] == "threshold"))
                {
                    Value = Convert.ToInt32(s[i + 3]);
                    if (s[i + 2] == "=")
                    {
                        Temp = Temp.Where(x => x.MinimumThreshold == Value).ToList(); //Console.WriteLine("MI{0}", Temp.Count);
                    }
                    if (s[i + 2] == ">")
                    {
                        Temp = Temp.Where(x => x.MinimumThreshold > Value).ToList(); //Console.WriteLine("MI{0}", Temp.Count);
                    }
                    if (s[i + 2] == "<")
                    {
                        Temp = Temp.Where(x => x.MinimumThreshold < Value).ToList(); //Console.WriteLine("MI{0}", Temp.Count);
                    }
                    if (s[i + 2] == ">=")
                    {
                        Temp = Temp.Where(x => x.MinimumThreshold >= Value).ToList(); //Console.WriteLine("MI{0}", Temp.Count);
                    }
                    if (s[i + 2] == "=>")
                    {
                        Temp = Temp.Where(x => x.MinimumThreshold >= Value).ToList(); //Console.WriteLine("MI{0}", Temp.Count);
                    }
                    if (s[i + 2] == "<=")
                    {
                        Temp = Temp.Where(x => x.MinimumThreshold <= Value).ToList(); Console.WriteLine("MI{0}", Temp.Count);
                    }
                    if (s[i + 2] == "=<")
                    {
                        Temp = Temp.Where(x => x.MinimumThreshold <= Value).ToList(); //Console.WriteLine("MI{0}", Temp.Count);
                    }
                    //Console.WriteLine("{0} {1} {2} {3}", s[i], s[i + 1], s[i + 2], s[i + 3]);
                }
                else if ((s[i] == "Maximum" || s[i] == "MAXIMUM" || s[i] == "maximum") && (s[i + 1] == "Threshold" || s[i + 1] == "THRESHOLD" || s[i + 1] == "threshold"))
                {
                    Value = Convert.ToInt32(s[i + 3]);
                    if (s[i + 2] == "=")
                    {
                        Temp = Temp.Where(x => x.MaximumThreshold == Value).ToList(); //Console.WriteLine("MA{0}", Temp.Count);
                    }
                    if (s[i + 2] == ">")
                    {
                        Temp = Temp.Where(x => x.MaximumThreshold > Value).ToList(); //Console.WriteLine("MA{0}", Temp.Count);
                    }
                    if (s[i + 2] == "<")
                    {
                        Temp = Temp.Where(x => x.MaximumThreshold < Value).ToList(); //Console.WriteLine("MA{0}", Temp.Count);
                    }
                    if (s[i + 2] == ">=")
                    {
                        Temp = Temp.Where(x => x.MaximumThreshold >= Value).ToList(); //Console.WriteLine("MA{0}", Temp.Count);
                    }
                    if (s[i + 2] == "=>")
                    {
                        Temp = Temp.Where(x => x.MaximumThreshold >= Value).ToList(); //Console.WriteLine("MA{0}", Temp.Count);
                    }
                    if (s[i + 2] == "<=")
                    {
                        Temp = Temp.Where(x => x.MaximumThreshold <= Value).ToList(); //Console.WriteLine("MA{0}", Temp.Count);
                    }
                    if (s[i + 2] == "=<")
                    {
                        Temp = Temp.Where(x => x.MaximumThreshold <= Value).ToList(); //Console.WriteLine("MA{0}", Temp.Count);
                    }
                    //Console.WriteLine("{0} {1} {2} {3}", s[i], s[i + 1], s[i + 2], s[i + 3]);
                }

                //Console.WriteLine("{0}", Temp.Count);
                if (Temp.Count < 1)
                {
                    return 0;
                }
                Temp = Stocks;
            }

            return 1;
        }
    }
}

