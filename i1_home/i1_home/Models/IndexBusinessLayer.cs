using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace i1.Models
{
   public class IndexBusinessLayer
    {
       public String connectionString = null;
        
       public IEnumerable<Indice> Ind  
        {
             
            get
            {
                connectionString =
                    ConfigurationManager.ConnectionStrings["IndiceContext"].ConnectionString;

                List<Indice> Ind1 = new List<Indice>();

                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    SqlCommand cmd = new SqlCommand("spGetAllIndices", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    con.Open();
                    SqlDataReader rdr = cmd.ExecuteReader();
                    while (rdr.Read())
                    {
                        Indice indice = new Indice();
                        indice.IndexId = rdr["IndexId"].ToString();
                        indice.IndexName = rdr["IndexName"].ToString();
                        indice.IndexInsertionDate = Convert.ToDateTime(rdr["IndexInsertionDate"]);
                        indice.LoginId = rdr["LoginId"].ToString();
                       
                        Ind1.Add(indice);
                    }
                }

                return Ind1;
            }
        }
        public void AddIndice(Indice indices)
        {
            
                  connectionString=  ConfigurationManager.ConnectionStrings["IndiceContext"].ConnectionString;

            using (SqlConnection con1 = new SqlConnection(connectionString))
            {
                SqlCommand cmd1 = new SqlCommand("spAddIndices", con1);
                cmd1.CommandType = CommandType.StoredProcedure;

                SqlParameter indexid = new SqlParameter();
                indexid.ParameterName = "@IndexId";
                indexid.Value = indices.IndexId;
                cmd1.Parameters.Add(indexid);

                SqlParameter indexname = new SqlParameter();
                indexname.ParameterName = "@IndexName";
                indexname.Value = indices.IndexName;
                cmd1.Parameters.Add(indexname);

                SqlParameter indexinsertiondate = new SqlParameter();
                indexinsertiondate.ParameterName = "@IndexInsertionDate";
                indexinsertiondate.Value = indices.IndexInsertionDate;
                cmd1.Parameters.Add(indexinsertiondate);

                SqlParameter loginid = new SqlParameter();
                loginid.ParameterName = "@LoginId";
                loginid.Value = indices.LoginId;
                cmd1.Parameters.Add(loginid);

                con1.Open();
                cmd1.ExecuteNonQuery();
            }
        }

        public void SaveEmmployee(Indice indices)
        {
            string connectionString =
                    ConfigurationManager.ConnectionStrings["IndiceContext"].ConnectionString;

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd1 = new SqlCommand("spSaveIndice", con);
                cmd1.CommandType = CommandType.StoredProcedure;

                SqlParameter indexid = new SqlParameter();
                indexid.ParameterName = "@IndexId";
                indexid.Value = indices.IndexId;
                cmd1.Parameters.Add(indexid);

                SqlParameter indexname = new SqlParameter();
                indexname.ParameterName = "@IndexName";
                indexname.Value = indices.IndexName;
                cmd1.Parameters.Add(indexname);

                SqlParameter indexinsertiondate = new SqlParameter();
                indexinsertiondate.ParameterName = "@IndexInsertionDate";
                indexinsertiondate.Value = indices.IndexInsertionDate;
                cmd1.Parameters.Add(indexinsertiondate);

                //SqlParameter loginid = new SqlParameter();
                //loginid.ParameterName = "@LoginId";
                //loginid.Value = indices.LoginId;
                //cmd1.Parameters.Add(loginid);

                con.Open();
                cmd1.ExecuteNonQuery();
            }
        }

        public void DeleteEmployee(string indexID)
        {
            string connectionString =
                    ConfigurationManager.ConnectionStrings["IndiceContext"].ConnectionString;

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("spDeleteIndice", con);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter paramId = new SqlParameter();
                paramId.ParameterName = "@IndexId";
                paramId.Value = indexID;
                cmd.Parameters.Add(paramId);

                con.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public Indice GetIndiceToSelect(string indexId)
        {
            connectionString =
                    ConfigurationManager.ConnectionStrings["IndiceContext"].ConnectionString;

            List<Indice> Ind1 = new List<Indice>();

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("SELECT * FROM Indices WHERE IndexId='" + indexId + "'", con);

                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    Indice indice = new Indice();
                    indice.IndexId = rdr["IndexId"].ToString();
                    indice.IndexName = rdr["IndexName"].ToString();
                    indice.IndexInsertionDate = Convert.ToDateTime(rdr["IndexInsertionDate"]);
                    indice.LoginId = rdr["LoginId"].ToString();
                    Ind1.Add(indice);
                }
            }
            return Ind1[0];
        }

    }
}
