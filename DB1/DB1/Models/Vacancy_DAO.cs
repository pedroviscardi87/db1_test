using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace DB1.Models
{
    public class Vacancy_DAO
    {
        public List<Vacancy> GetAll()
        {
            try
            {
                SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["conn"].ToString());
                conn.Open();
                SqlCommand cmd = new SqlCommand("select [id], [name] from [dbo].[vacancies] order by [name]", conn);
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                    using (DataTable dt = Utils.GetDataTable(dr))
                        return (from DataRow row in dt.Rows
                                select new Vacancy
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