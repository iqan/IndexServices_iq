using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using System.Data.Common;
using System.Data.SqlClient;
using i1.Models;
using i1.Service;
using System.Web.Mvc;
using i1_home.Models;

namespace i1.DbMethods
{
    public class UserMethods
    {
        public string LogOnCon(LogOnModel model)
        {
            string dp = "System.Data.SqlClient";
            string cnStr = ConfigurationManager.ConnectionStrings["myConnectionString"].ConnectionString;
            DbProviderFactory df = DbProviderFactories.GetFactory(dp);

            try
            {
                using (DbConnection cn = df.CreateConnection())
                {
                    cn.ConnectionString = cnStr;
                    cn.Open();
                    DbCommand cmd = df.CreateCommand();

                    cmd.Connection = cn;
                    cmd.CommandText = "SELECT * FROM Users where LoginId=@u AND Password=@p";
                    cmd.Parameters.Add(new SqlParameter("@u", model.UserName));
                    cmd.Parameters.Add(new SqlParameter("@p", model.Password));
                    using (DbDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            if (dr["LoginId"].ToString().StartsWith("IM") || dr["LoginId"].ToString() == "admin")
                            {
                                cn.Close();
                                return "Indice";
                            }
                            else
                            {
                                cn.Close();
                                return "Rule";
                            }
                        }
                        cn.Close();
                        return "LogOn";
                    }
                }
            }
            catch
            { 
                return "LogOn";
            }
        }

        public string CheckDuplicate(string fname)
        {
            string dp = "System.Data.SqlClient";
            string cnStr = ConfigurationManager.ConnectionStrings["myConnectionString"].ConnectionString;
            DbProviderFactory df = DbProviderFactories.GetFactory(dp);

            try
            {
                using (DbConnection cn = df.CreateConnection())
                {
                    cn.ConnectionString = cnStr;
                    cn.Open();
                    DbCommand cmd = df.CreateCommand();

                    cmd.Connection = cn;
                    cmd.CommandText = "SELECT * FROM Users where LoginId=@u";
                    cmd.Parameters.Add(new SqlParameter("@u", fname));

                    using (DbDataReader dr = cmd.ExecuteReader())
                    {
                        if(dr.Read())
                        {
                            int i =0 ;
                            string fname1 = fname + i.ToString();
                            fname = CheckDuplicate(fname1);
                        }
                        cn.Close();
                        return fname;
                    }
                }
            }
            catch
            {
                return "LogOn";
            }
        }

        public string GetLoginId(string fname)
        {
            string dp = "System.Data.SqlClient";
            string cnStr = ConfigurationManager.ConnectionStrings["myConnectionString"].ConnectionString;
            DbProviderFactory df = DbProviderFactories.GetFactory(dp);

            try
            {
                using (DbConnection cn = df.CreateConnection())
                {
                    cn.ConnectionString = cnStr;
                    cn.Open();
                    DbCommand cmd = df.CreateCommand();

                    cmd.Connection = cn;
                    cmd.CommandText = "SELECT * FROM Users where FirstName=@u";
                    cmd.Parameters.Add(new SqlParameter("@u", fname));

                    using (DbDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr.Read())
                        {
                            cn.Close();
                            return fname;
                        }
                        cn.Close();
                        return fname;
                    }
                }
            }
            catch
            {
                return "LogOn";
            }
        }

        public List<string> Register(RegisterModel model)
        {
            string cnStr = ConfigurationManager.ConnectionStrings["myConnectionString"].ConnectionString;
            SqlConnection con = new SqlConnection(cnStr);
            SqlCommand cmd = null;
            SqlCommand cmd2 = null;
            List<string> ls = new List<string>();

            try
            {
                con.Open();
                string sql = "INSERT INTO Users (LoginId,Password,FirstName,LastName,Role,Age,Gender,PhoneNumber,Email,Address,ZipCode,City,State,Country)" +
                    "VALUES (@l,@p,@f,@ln,@r,@a,@g,@c,@e,@ad,@z,@city,@state,@country)";
                //string sql2 = "INSERT INTO Login (LoginId,Password)" +
                //        "VALUES (@l,@p)";

                cmd = new SqlCommand(sql, con);
                //cmd2 = new SqlCommand(sql2, con);
                string pre = string.Empty;
                if (model.Role == "IM")
                {
                    pre = "IM_";
                }
                else
                {
                    pre = "US_";
                }

                string UserName1 = pre + model.FirstName;

                string UserName = CheckDuplicate(UserName1);

                
                ls.Add(UserName);
                

                cmd.Parameters.AddWithValue("@l", UserName);
                cmd.Parameters.AddWithValue("@p", model.Password);
                cmd.Parameters.AddWithValue("@f", model.FirstName);
                cmd.Parameters.AddWithValue("@ln", model.LastName);
                cmd.Parameters.AddWithValue("@r", model.Role);
                cmd.Parameters.AddWithValue("@a", model.Age);
                cmd.Parameters.AddWithValue("@g", model.Gender);
                cmd.Parameters.AddWithValue("@c", model.ContactNumber);
                cmd.Parameters.AddWithValue("@e", model.Email);
                cmd.Parameters.AddWithValue("@ad", model.Address);
                cmd.Parameters.AddWithValue("@z", model.ZipCode);
                cmd.Parameters.AddWithValue("@city", model.City);
                cmd.Parameters.AddWithValue("@state", model.State);
                cmd.Parameters.AddWithValue("@country", model.Country);
                cmd2.Parameters.AddWithValue("@l", UserName);
                cmd2.Parameters.AddWithValue("@p", model.Password);

                using (cmd)
                {
                    cmd.ExecuteNonQuery();
                }
                cmd = null;
                //using (cmd2)
                //{
                //    cmd2.ExecuteNonQuery();
                //}
                cmd = null;
                con.Close();
                ls.Add("RegisterSuccess");
                return ls;
            }
            catch
            {
                ls.Add("");
                ls.Add("Register");
                return ls;
            }
        }

        public string GetUserNameByFirstName(string uname)
        {
            string dp = "System.Data.SqlClient";
            string cnStr = ConfigurationManager.ConnectionStrings["myConnectionString"].ConnectionString;
            DbProviderFactory df = DbProviderFactories.GetFactory(dp);

            try
            {
                using (DbConnection cn = df.CreateConnection())
                {
                    cn.ConnectionString = cnStr;
                    cn.Open();
                    DbCommand cmd = df.CreateCommand();

                    cmd.Connection = cn;
                    cmd.CommandText = "SELECT * FROM Users where LoginId=@u";
                    cmd.Parameters.Add(new SqlParameter("@u", uname));
                    using (DbDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            return dr["FirstName"].ToString();
                        }
                        return string.Empty;
                    }
                }
            }
            catch
            {
                return string.Empty;
            }
        }

        public RegisterModel GetUserDetails(string uname)
        {
            string dp = "System.Data.SqlClient";
            string cnStr = ConfigurationManager.ConnectionStrings["myConnectionString"].ConnectionString;
            DbProviderFactory df = DbProviderFactories.GetFactory(dp);
            RegisterModel r = new RegisterModel();
            try
            {
                using (DbConnection cn = df.CreateConnection())
                {
                    cn.ConnectionString = cnStr;
                    cn.Open();
                    DbCommand cmd = df.CreateCommand();

                    cmd.Connection = cn;
                    cmd.CommandText = "SELECT * FROM Users where LoginId=@u";
                    cmd.Parameters.Add(new SqlParameter("@u", uname));
                    using (DbDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            r.FirstName = dr["FirstName"].ToString();
                            r.LastName = dr["LastName"].ToString();
                            r.Password = dr["Password"].ToString();
                            r.ConfirmPassword = dr["ConfirmPassword"].ToString();
                            r.Email = dr["Email"].ToString();
                            r.ContactNumber = int.Parse(dr["ContactNumber"].ToString());
                            r.Address = dr["Address"].ToString();
                            r.ZipCode = int.Parse(dr["ZipCode"].ToString());
                            Loc locService = new Loc();
                            List<SelectListItem> listcountries = new List<SelectListItem>();
                            List<country> countries = new List<country>();
                            countries = locService.GetCountryListFromDB();
                            listcountries.Add(new SelectListItem { Text = "Select", Value = "Select", Selected = true });
                            foreach (country item in countries)
                            {
                                listcountries.Add(new SelectListItem { Text = item.name, Value = item.id.ToString() });
                            }

                            r.listcountries = listcountries;
                            return r;
                        }
                        return r;
                    }
                }
            }
            catch
            {
                return r;
            }
        }
    }
}