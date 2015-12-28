using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;

namespace i1.Models
{
    public class StockBusinessLayer
    {
        public String connectionString = null;

        public IEnumerable<Stocks1> Ind
        {

            get
            {
                connectionString =
                    ConfigurationManager.ConnectionStrings["StockContext"].ConnectionString;

                List<Stocks1> Ind1 = new List<Stocks1>();

                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    SqlCommand cmd = new SqlCommand("spGetAllStocks", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    con.Open();
                    SqlDataReader rdr = cmd.ExecuteReader();
                    while (rdr.Read())
                    {
                        Stocks1 stock1 = new Stocks1();
                        stock1.IndexId = rdr["IndexId"].ToString();
                        stock1.FundId = rdr["FundId"].ToString();
                        stock1.FundName = rdr["FundName"].ToString();
                        stock1.FundPrice = Convert.ToDouble(rdr["FundPrice"].ToString());
                        stock1.EffectiveDate = Convert.ToDateTime(rdr["EffectiveDate"]);
                        stock1.MinimumThreshold = Convert.ToDouble(rdr["MinimumThreshold"].ToString());
                        stock1.MaximumThreshold = Convert.ToDouble(rdr["MaximumThreshold"].ToString());
                        stock1.LoginId = rdr["LoginId"].ToString();

                        Ind1.Add(stock1);

                    }
                }

                return Ind1;
            }
        }
        public void AddStock(Stocks1 stock123)
        {

            connectionString = ConfigurationManager.ConnectionStrings["StockContext"].ConnectionString;

            using (SqlConnection con1 = new SqlConnection(connectionString))
            {
                SqlCommand cmd1 = new SqlCommand("spAddStocks", con1);
                cmd1.CommandType = CommandType.StoredProcedure;

                SqlParameter indexid = new SqlParameter();
                indexid.ParameterName = "@IndexId";
                indexid.Value = stock123.IndexId;
                cmd1.Parameters.Add(indexid);

                SqlParameter FundId = new SqlParameter();
                FundId.ParameterName = "@FundId";
                FundId.Value = stock123.FundId;
                cmd1.Parameters.Add(FundId);

                SqlParameter FundName = new SqlParameter();
                FundName.ParameterName = "@FundName";
                FundName.Value = stock123.FundName;
                cmd1.Parameters.Add(FundName);

                SqlParameter FundPrice = new SqlParameter();
                FundPrice.ParameterName = "@FundPrice";
                FundPrice.Value = stock123.FundPrice;
                cmd1.Parameters.Add(FundPrice);

                

                SqlParameter EffectiveDate = new SqlParameter();
                EffectiveDate.ParameterName = "@EffectiveDate";
                EffectiveDate.Value = stock123.EffectiveDate;
                cmd1.Parameters.Add(EffectiveDate);

                SqlParameter MinimumThreshold = new SqlParameter();
                MinimumThreshold.ParameterName = "@MinimumThreshold";
                MinimumThreshold.Value = stock123.MinimumThreshold;
                cmd1.Parameters.Add(MinimumThreshold);

                SqlParameter MaximumThreshold = new SqlParameter();
                MaximumThreshold.ParameterName = "@MaximumThreshold";
                MaximumThreshold.Value = stock123.MaximumThreshold;
                cmd1.Parameters.Add(MaximumThreshold);


                SqlParameter loginid = new SqlParameter();
                loginid.ParameterName = "@LoginId";
                loginid.Value = stock123.LoginId;
                cmd1.Parameters.Add(loginid);

                con1.Open();
                cmd1.ExecuteNonQuery();
            }
        }
        public void SaveStock(Stocks1 stock123)
        {
            string connectionString =
                    ConfigurationManager.ConnectionStrings["StockContext"].ConnectionString;

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd1 = new SqlCommand("spSaveStock", con);
                cmd1.CommandType = CommandType.StoredProcedure;

                SqlParameter indexid = new SqlParameter();
                indexid.ParameterName = "@IndexId";
                indexid.Value = stock123.IndexId;
                cmd1.Parameters.Add(indexid);

                SqlParameter FundId = new SqlParameter();
                FundId.ParameterName = "@FundId";
                FundId.Value = stock123.FundId;
                cmd1.Parameters.Add(FundId);

                SqlParameter FundName = new SqlParameter();
                FundName.ParameterName = "@FundName";
                FundName.Value = stock123.FundName;
                cmd1.Parameters.Add(FundName);

                SqlParameter FundPrice = new SqlParameter();
                FundPrice.ParameterName = "@FundPrice";
                FundPrice.Value = stock123.FundPrice;
                cmd1.Parameters.Add(FundPrice);



                SqlParameter EffectiveDate = new SqlParameter();
                EffectiveDate.ParameterName = "@EffectiveDate";
                EffectiveDate.Value = stock123.EffectiveDate;
                cmd1.Parameters.Add(EffectiveDate);

                SqlParameter MinimumThreshold = new SqlParameter();
                MinimumThreshold.ParameterName = "@MinimumThreshold";
                MinimumThreshold.Value = stock123.MinimumThreshold;
                cmd1.Parameters.Add(MinimumThreshold);

                SqlParameter MaximumThreshold = new SqlParameter();
                MaximumThreshold.ParameterName = "@MaximumThreshold";
                MaximumThreshold.Value = stock123.MaximumThreshold;
                cmd1.Parameters.Add(MaximumThreshold);


                SqlParameter loginid = new SqlParameter();
                loginid.ParameterName = "@LoginId";
                loginid.Value = stock123.LoginId;
                cmd1.Parameters.Add(loginid);

                con.Open();
                cmd1.ExecuteNonQuery();
            }
        }


        public void DeleteStock(string FundId)
        {
            string connectionString =
                    ConfigurationManager.ConnectionStrings["StockContext"].ConnectionString;

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("spDeleteIndice", con);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter paramId = new SqlParameter();
                paramId.ParameterName = "@FundId";
                paramId.Value = FundId;
                cmd.Parameters.Add(paramId);

                con.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public Stocks1 GetStocksToSelect(string FundId)
        {
            connectionString =
                    ConfigurationManager.ConnectionStrings["StockContext"].ConnectionString;

            List<Stocks1> Ind1 = new List<Stocks1>();

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("SELECT * FROM Stocks WHERE FundId='" + FundId + "'", con);

                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    Stocks1 stock1 = new Stocks1();
                    stock1.IndexId = rdr["IndexId"].ToString();
                    stock1.FundId = rdr["FundId"].ToString();
                    stock1.FundName = rdr["FundName"].ToString();
                    stock1.FundPrice = Convert.ToDouble(rdr["FundPrice"].ToString());
                    stock1.EffectiveDate = Convert.ToDateTime(rdr["EffectiveDate"]);
                    stock1.MinimumThreshold = Convert.ToDouble(rdr["MinimumThreshold"].ToString());
                    stock1.MaximumThreshold = Convert.ToDouble(rdr["MaximumThreshold"].ToString());
                    stock1.LoginId = rdr["LoginId"].ToString();

                    Ind1.Add(stock1);
                }
            }
            return Ind1[0];
        }

        public void Expression(Stocks1 stock123)
        {
        }
    
    }
}