using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace DB1.Models
{
    public class Technology_DAO
    {
        public List<Technology> GetByCandidate(int id_candidate)
        {
            try
            {
                SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["conn"].ToString());
                conn.Open();

                String sql = "" +
                    "select " +
                    "	t.[id], t.[name] " +
                    "from [dbo].[candidates_technologies] ct " +
                    "left join [dbo].[technologies] t on (t.[id]=ct.[id_technology]) " +
                    "left join [dbo].[candidates] c on (c.[id]=ct.[id_candidate]) " +
                    "where ct.[id_candidate]=@id_candidate " +
                    "order by [name]";

                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@id_candidate", id_candidate);
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                    using (DataTable dt = Utils.GetDataTable(dr))
                        return (from DataRow row in dt.Rows
                                select new Technology
                                {
                                    id = Convert.ToInt32(row["id"]),
                                    name = Convert.ToString(row["name"])
                                }).ToList();
                dr.Close();
                cmd.Dispose();
                conn.Close();
            }
            catch (Exception)
            {
                throw;
            }
            return null;
        }

        public List<Technology> GetAll()
        {
            try
            {
                SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["conn"].ToString());
                conn.Open();
                SqlCommand cmd = new SqlCommand("select [id], [name] from [dbo].[technologies] order by [name]", conn);
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                    using (DataTable dt = Utils.GetDataTable(dr))
                        return (from DataRow row in dt.Rows
                                select new Technology
                                {
                                    id = Convert.ToInt32(row["id"]),
                                    name = Convert.ToString(row["name"])
                                }).ToList();
                dr.Close();
                cmd.Dispose();
                conn.Close();
            }
            catch (Exception)
            {
                throw;
            }
            return null;
        }        
    }
}