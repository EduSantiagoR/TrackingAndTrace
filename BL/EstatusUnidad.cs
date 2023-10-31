using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class EstatusUnidad
    {
        public static List<object> GetAll()
        {
            var list = new List<object>();
            using(SqlConnection context = new SqlConnection(DL.Conexion.GetConnection()))
            {
                string query = "EstatusUnidadGetAll";
                SqlCommand cmd = new SqlCommand(query, context);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                SqlDataAdapter adapter = new SqlDataAdapter(cmd);

                DataTable tableUnidades = new DataTable();
                adapter.Fill(tableUnidades);
                if(tableUnidades.Rows.Count > 0)
                {
                    foreach(DataRow row in tableUnidades.Rows)
                    {
                        ML.EstatusUnidad estatus = new ML.EstatusUnidad();
                        estatus.IdEstatus = int.Parse(row["IdEstatus"].ToString());
                        estatus.Estatus = row["Estatus"].ToString();
                        list.Add(estatus);
                    }
                }
            }
            return list;
        }
    }
}
