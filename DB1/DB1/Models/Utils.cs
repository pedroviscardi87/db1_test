using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;

namespace DB1.Models
{
    public class Utils
    {
        public static DataTable GetDataTable(SqlDataReader reader)
        {
            DataTable tbEsquema = reader.GetSchemaTable();
            DataTable tbRetorno = new DataTable();

            foreach (DataRow r in tbEsquema.Rows)
                if (!tbRetorno.Columns.Contains(r["ColumnName"].ToString()))
                {
                    DataColumn col = new DataColumn()
                    {
                        ColumnName = r["ColumnName"].ToString(),
                        Unique = Convert.ToBoolean(r["IsUnique"]),
                        AllowDBNull = Convert.ToBoolean(r["AllowDBNull"]),
                        ReadOnly = Convert.ToBoolean(r["IsReadOnly"])
                    };
                    tbRetorno.Columns.Add(col);
                }

            while (reader.Read())
            {
                DataRow novaLinha = tbRetorno.NewRow();
                for (int i = 0; i < tbRetorno.Columns.Count; i++)
                    novaLinha[i] = reader.GetValue(i);
                tbRetorno.Rows.Add(novaLinha);
            }

            return tbRetorno;
        }

        public static String Get(String url)
        {
            try
            {
                HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(url);
                httpWebRequest.Method = WebRequestMethods.Http.Get;
                httpWebRequest.Accept = "application/json";
                using (WebResponse response = (WebResponse)httpWebRequest.GetResponse())
                using (StreamReader sr = new StreamReader(response.GetResponseStream(), Encoding.UTF8))
                    return sr.ReadToEnd();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}