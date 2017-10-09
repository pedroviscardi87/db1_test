using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Web;

namespace DB1.Models
{
    public class Candidate_DAO
    {
        public List<Candidate> GetAll()
        {
            try
            {
                SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["conn"].ToString());
                conn.Open();

                String sql = "" +
                    "select " +
                    "	c.[id], c.[name], v.[id] as id_vacancy, v.[name] as name_vacancy " +
                    "from [dbo].[candidates] c " +
                    "left join [dbo].[vacancies] v on (c.[id_vacancy]=v.[id]) " +
                    "order by c.[name]";

                SqlCommand cmd = new SqlCommand(sql, conn);
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                    using (DataTable dt = Utils.GetDataTable(dr))
                        return (from DataRow row in dt.Rows
                                select new Candidate
                                {
                                    id = Convert.ToInt32(row["id"]),
                                    name = Convert.ToString(row["name"]),
                                    vacancy = new Vacancy()
                                    {
                                        id = Convert.ToInt32(row["id_vacancy"]),
                                        name = Convert.ToString(row["name_vacancy"])
                                    },
                                    technologies = new Technology_DAO().GetByCandidate(Convert.ToInt32(row["id"]))
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

        public Boolean Insert(Candidate obj)
        {
            try
            {
                SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["conn"].ToString());
                conn.Open();
                SqlCommand cmd = new SqlCommand("insert into [dbo].[candidates]([id_vacancy],[name]) values (@id_vacancy,@name)", conn);
                cmd.Parameters.AddWithValue("@id_vacancy", obj.vacancy.id);
                cmd.Parameters.AddWithValue("@name", obj.name);
                cmd.ExecuteNonQuery();
                cmd.Dispose();
                cmd = new SqlCommand("select cast(@@identity as int)", conn);
                obj.id = (int)cmd.ExecuteScalar();
                cmd.Dispose();
                foreach (var tech in obj.technologies)
                {
                    cmd = new SqlCommand("insert into [dbo].[candidates_technologies]([id_candidate],[id_technology]) values (@id_candidate,@id_technology)", conn);
                    cmd.Parameters.AddWithValue("@id_candidate", obj.id);
                    cmd.Parameters.AddWithValue("@id_technology", tech.id);
                    cmd.ExecuteNonQuery();
                    cmd.Dispose();
                }
                return true;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public Boolean Delete(int id)
        {
            try
            {
                SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["conn"].ToString());
                conn.Open();

                String sql = "" +
                    "delete from [dbo].[candidates_technologies] where [id_candidate]=@id;" +
                    "delete from [dbo].[candidates] where [id]=@id;";

                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@id", id);
                cmd.ExecuteNonQuery();
                cmd.Dispose();
                return true;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public Boolean DeleteTechnologies(int id)
        {
            try
            {
                SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["conn"].ToString());
                conn.Open();
                SqlCommand cmd = new SqlCommand("delete from [dbo].[candidates_technologies] where [id_candidate]=@id", conn);
                cmd.Parameters.AddWithValue("@id", id);
                cmd.ExecuteNonQuery();
                cmd.Dispose();
                return true;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public Boolean Update(Candidate obj)
        {
            try
            {
                SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["conn"].ToString());
                conn.Open();
                SqlCommand cmd = new SqlCommand("update [dbo].[candidates] set [id_vacancy]=@id_vacancy, [name]=@name where [id]=@id", conn);
                cmd.Parameters.AddWithValue("@id", obj.id);
                cmd.Parameters.AddWithValue("@id_vacancy", obj.vacancy.id);
                cmd.Parameters.AddWithValue("@name", obj.name);
                cmd.ExecuteNonQuery();
                cmd.Dispose();
                return true;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}