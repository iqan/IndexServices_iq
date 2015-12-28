using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;

namespace i1.Models
{
    public class MonitorBusinessLayer
    {
        public String connectionString = null;

        public IEnumerable<MonitorDisp> Ind
        {

            get
            {
                connectionString =
                    ConfigurationManager.ConnectionStrings["MonitorContext"].ConnectionString;

                List<MonitorDisp> Ind1 = new List<MonitorDisp>();

                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    SqlCommand cmd = new SqlCommand("spGetAllMonitor", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    con.Open();
                    SqlDataReader rdr = cmd.ExecuteReader();
                    while (rdr.Read())
                    {
                        MonitorDisp indice = new MonitorDisp();
                        indice.IndexId = rdr["IndexId"].ToString();
                        indice.ProcessingStatus = rdr["ProcessingStatus"].ToString();
                        indice.RecordInsertionDate = Convert.ToDateTime(rdr["RecordInsertionDate"]);

                        Ind1.Add(indice);
                    }
                }

                return Ind1;
            }
        }
    }
}