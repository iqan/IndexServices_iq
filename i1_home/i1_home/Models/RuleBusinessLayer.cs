using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using i1.Models;

namespace i1.Models
{
    public class RuleBusinessLayer
    {
        public String connectionString = null;

        public IEnumerable<Rule1> rule
        {

            get
            {
                connectionString =
                    ConfigurationManager.ConnectionStrings["RuleContext"].ConnectionString;

                List<Rule1> Ind1 = new List<Rule1>();

                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    SqlCommand cmd = new SqlCommand("spGetAllRules", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    con.Open();
                    SqlDataReader rdr = cmd.ExecuteReader();
                    while (rdr.Read())
                    {
                        Rule1 indice = new Rule1();
                        indice.RuleId = rdr["RuleId"].ToString();
                        indice.RuleName = rdr["RuleName"].ToString();
                        indice.RuleExpression = rdr["RuleExpression"].ToString();
                        indice.RuleStatus = rdr["RuleStatus"].ToString();
                        indice.RuleCreationDate = Convert.ToDateTime(rdr["RuleCreationDate"]);
                        indice.FundId = rdr["FundId"].ToString();
                        indice.LoginId = rdr["LoginId"].ToString();

                        Ind1.Add(indice);
                    }
                }

                return Ind1;
            }
        }

        public void AddRule(Rule1 rule123)
        {

            connectionString = ConfigurationManager.ConnectionStrings["RuleContext"].ConnectionString;

            using (SqlConnection con1 = new SqlConnection(connectionString))
            {
                SqlCommand cmd1 = new SqlCommand("spAddRules", con1);
                cmd1.CommandType = CommandType.StoredProcedure;

                SqlParameter ruleid = new SqlParameter();
                ruleid.ParameterName = "@RuleId";
                ruleid.Value = rule123.RuleId;
                cmd1.Parameters.Add(ruleid);

                SqlParameter rulename = new SqlParameter();
                rulename.ParameterName = "@RuleName";
                rulename.Value = rule123.RuleName;
                cmd1.Parameters.Add(rulename);

                SqlParameter ruleexpr = new SqlParameter();
                //ruleexpr.ParameterName = "@RuleExpression";
                ruleexpr.ParameterName = "@RuleExpression";
                ruleexpr.Value = rule123.RuleExpression;
                cmd1.Parameters.Add(ruleexpr);

                SqlParameter rulestatus = new SqlParameter();
                rulestatus.ParameterName = "@RuleStatus";
                rulestatus.Value = "Unknown";
                cmd1.Parameters.Add(rulestatus);

                SqlParameter ruledate = new SqlParameter();
                ruledate.ParameterName = "@RuleCreationDate";
                ruledate.Value = rule123.RuleCreationDate;
                cmd1.Parameters.Add(ruledate);

                SqlParameter fundid = new SqlParameter();
                fundid.ParameterName = "@FundId";
                fundid.Value = rule123.FundId;
                cmd1.Parameters.Add(fundid);

                SqlParameter loginid = new SqlParameter();
                loginid.ParameterName = "@LoginId";
                loginid.Value = rule123.LoginId;
                cmd1.Parameters.Add(loginid);

                con1.Open();
                cmd1.ExecuteNonQuery();
            }
        }

        public void ValidateRule(Rule1 rule123)
        {

            connectionString = ConfigurationManager.ConnectionStrings["RuleContext"].ConnectionString;
      
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd1 = new SqlCommand("spSaveRules", con);
                cmd1.CommandType = CommandType.StoredProcedure;

                SqlParameter ruleid = new SqlParameter();
                ruleid.ParameterName = "@RuleId";
                ruleid.Value = rule123.RuleId;
                cmd1.Parameters.Add(ruleid);

                SqlParameter rulename = new SqlParameter();
                rulename.ParameterName = "@RuleName";
                rulename.Value = rule123.RuleName;
                cmd1.Parameters.Add(rulename);

                SqlParameter ruleexpr = new SqlParameter();
                ruleexpr.ParameterName = "@RuleExpression";
                ruleexpr.Value = rule123.RuleExpression;
                cmd1.Parameters.Add(ruleexpr);

                SqlParameter rulestatus = new SqlParameter();
                rulestatus.ParameterName = "@RuleStatus";
                rulestatus.Value = "Accepted";
                //  rulestatus.Value = "Index id = "+
                cmd1.Parameters.Add(rulestatus);

                SqlParameter ruledate = new SqlParameter();
                ruledate.ParameterName = "@RuleCreationDate";
                ruledate.Value = rule123.RuleCreationDate;
                cmd1.Parameters.Add(ruledate);

                SqlParameter fundid = new SqlParameter();
                fundid.ParameterName = "@FundId";
                fundid.Value = rule123.FundId;
                cmd1.Parameters.Add(fundid);

                //SqlParameter loginid = new SqlParameter();
                //loginid.ParameterName = "@LoginId";
                //loginid.Value = rule123.LoginId;
                //cmd1.Parameters.Add(loginid);


                con.Open();
                cmd1.ExecuteNonQuery();
            }
        }

        public void SaveRule(Rule1 rule123)
        {
            string connectionString =
                    ConfigurationManager.ConnectionStrings["RuleContext"].ConnectionString;

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd1 = new SqlCommand("spSaveRules", con);
                cmd1.CommandType = CommandType.StoredProcedure;

                SqlParameter ruleid = new SqlParameter();
                ruleid.ParameterName = "@RuleId";
                ruleid.Value = rule123.RuleId;
                cmd1.Parameters.Add(ruleid);

                SqlParameter rulename = new SqlParameter();
                rulename.ParameterName = "@RuleName";
                rulename.Value = rule123.RuleName;
                cmd1.Parameters.Add(rulename);

                SqlParameter ruleexpr = new SqlParameter();
                ruleexpr.ParameterName = "@RuleExpression";
                ruleexpr.Value = rule123.RuleExpression;
                cmd1.Parameters.Add(ruleexpr);

                SqlParameter rulestatus = new SqlParameter();
                rulestatus.ParameterName = "@RuleStatus";
                rulestatus.Value = rule123.RuleStatus;
              //  rulestatus.Value = "Index id = "+
                cmd1.Parameters.Add(rulestatus);

                SqlParameter ruledate = new SqlParameter();
                ruledate.ParameterName = "@RuleCreationDate";
                ruledate.Value = rule123.RuleCreationDate;
                cmd1.Parameters.Add(ruledate);

                SqlParameter fundid = new SqlParameter();
                fundid.ParameterName = "@FundId";
                fundid.Value = rule123.FundId;
                cmd1.Parameters.Add(fundid);

                //SqlParameter loginid = new SqlParameter();
                //loginid.ParameterName = "@LoginId";
                //loginid.Value = rule123.LoginId;
                //cmd1.Parameters.Add(loginid);


                con.Open();
                cmd1.ExecuteNonQuery();
            }
        }

        public void DeleteRule(string ruleid)
        {
            string connectionString =
                    ConfigurationManager.ConnectionStrings["RuleContext"].ConnectionString;

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("spDeleteRules", con);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter paramId = new SqlParameter();
                paramId.ParameterName = "@RuleId";
                paramId.Value = ruleid;
                cmd.Parameters.Add(paramId);

                con.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public Rule1 GetRuleToSelect(string ruleid)
        {
            connectionString =
                    ConfigurationManager.ConnectionStrings["RuleContext"].ConnectionString;

            List<Rule1> rule1 = new List<Rule1>();

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("SELECT * FROM Rules WHERE RuleId='" + ruleid + "'", con);

                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    Rule1 rule = new Rule1();

                    rule.RuleId = rdr["RuleId"].ToString();
                    rule.RuleName = rdr["RuleName"].ToString();
                    rule.RuleExpression = rdr["RuleExpression"].ToString();
                    rule.RuleStatus = rdr["RuleStatus"].ToString();
                    rule.RuleCreationDate= Convert.ToDateTime(rdr["RuleCreationDate"]);
                    rule.FundId = rdr["FundId"].ToString();
                    rule.LoginId = rdr["LoginId"].ToString();
                    rule1.Add(rule);
                }
            }
            return rule1[0];
        }

        
    }
}