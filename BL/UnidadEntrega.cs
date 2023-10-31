using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class UnidadEntrega
    {
        public static List<object> GetAll()
        {
            ML.UnidadEntrega unidadEntrega = new ML.UnidadEntrega();
            unidadEntrega.Estatus = new ML.EstatusUnidad();
            try
            {
                using(DL.ESantiagoPaqueteriaEntities context = new DL.ESantiagoPaqueteriaEntities())
                {
                    var query = from unidad in context.UnidadEntregas
                                join estado in context.EstatusUnidads on unidad.IdEstatusUnidad equals estado.IdEstatus
                                select new
                                {
                                    IdUnidad = unidad.IdUnidad,
                                    NumeroPlaca = unidad.NumeroPlaca,
                                    Modelo = unidad.Modelo,
                                    Marca = unidad.Marca,
                                    YearFabricacion = unidad.YearFabricacion,
                                    IdEstatus = estado.IdEstatus,
                                    Estado = estado.Estatus
                                };
                    if(query != null)
                    {
                        unidadEntrega.Unidades = new List<object>();
                        foreach(var item in query)
                        {
                            ML.UnidadEntrega unidad = new ML.UnidadEntrega();
                            unidad.Estatus = new ML.EstatusUnidad();
                            unidad.IdUnidad = item.IdUnidad;
                            unidad.NumeroPlaca = item.NumeroPlaca;
                            unidad.Modelo = item.Modelo;
                            unidad.Marca = item.Marca;
                            unidad.YearFabricacion = item.YearFabricacion;
                            unidad.Estatus.IdEstatus = item.IdEstatus;
                            unidad.Estatus.Estatus = item.Estado;
                            unidadEntrega.Unidades.Add(unidad);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return unidadEntrega.Unidades;
        }
        public static List<object> GetAllDisponibles()
        {
            ML.UnidadEntrega unidadEntrega = new ML.UnidadEntrega();
            unidadEntrega.Estatus = new ML.EstatusUnidad();
            try
            {
                using (DL.ESantiagoPaqueteriaEntities context = new DL.ESantiagoPaqueteriaEntities())
                {
                    var query = from unidad in context.UnidadEntregas
                                join estado in context.EstatusUnidads on unidad.IdEstatusUnidad equals estado.IdEstatus
                                where estado.IdEstatus == 1
                                select new
                                {
                                    IdUnidad = unidad.IdUnidad,
                                    NumeroPlaca = unidad.NumeroPlaca,
                                    Modelo = unidad.Modelo,
                                    Marca = unidad.Marca,
                                    YearFabricacion = unidad.YearFabricacion,
                                    IdEstatus = estado.IdEstatus,
                                    Estado = estado.Estatus
                                };
                    if (query != null)
                    {
                        unidadEntrega.Unidades = new List<object>();
                        foreach (var item in query)
                        {
                            ML.UnidadEntrega unidad = new ML.UnidadEntrega();
                            unidad.Estatus = new ML.EstatusUnidad();
                            unidad.IdUnidad = item.IdUnidad;
                            unidad.NumeroPlaca = item.NumeroPlaca;
                            unidad.Modelo = item.Modelo;
                            unidad.YearFabricacion = item.YearFabricacion;
                            unidad.Estatus.IdEstatus = item.IdEstatus;
                            unidad.Estatus.Estatus = item.Estado;
                            unidadEntrega.Unidades.Add(unidad);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return unidadEntrega.Unidades;
        }
        public static ML.UnidadEntrega GetById(int idUnidadEntrega)
        {
            ML.UnidadEntrega unidad = new ML.UnidadEntrega();
            unidad.Estatus = new ML.EstatusUnidad();
            try
            {
                using(SqlConnection context = new SqlConnection(DL.Conexion.GetConnection()))
                {
                    string query = "UnidadEntregaGetById";
                    SqlCommand cmd = new SqlCommand(query, context);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    SqlParameter sqlParameter = new SqlParameter("@IdUnidad", System.Data.SqlDbType.Int);
                    sqlParameter.Value = idUnidadEntrega;
                    cmd.Parameters.Add(sqlParameter);

                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);

                    DataTable tableUnidad = new DataTable();
                    adapter.Fill(tableUnidad);
                    if(tableUnidad.Rows.Count > 0)
                    {
                        DataRow row = tableUnidad.Rows[0];
                        unidad.IdUnidad = int.Parse(row["IdUnidad"].ToString());
                        unidad.NumeroPlaca = row["NumeroPlaca"].ToString();
                        unidad.Modelo = row["Modelo"].ToString();
                        unidad.Marca = row["Marca"].ToString();
                        unidad.YearFabricacion = int.Parse(row["YearFabricacion"].ToString());
                        unidad.Estatus.IdEstatus = int.Parse(row["IdEstatus"].ToString());
                        unidad.Estatus.Estatus = row["Estatus"].ToString();
                    }
                }
            }
            catch
            {

            }
            return unidad;
        }
        public static bool Add(ML.UnidadEntrega unidadEntrega)
        {
            bool correct = false;
            try
            {
                using(SqlConnection context = new SqlConnection(DL.Conexion.GetConnection()))
                {
                    string query = "UnidadEntregaAdd";
                    SqlCommand cmd = new SqlCommand(query, context);
                    cmd.CommandType = CommandType.StoredProcedure;

                    SqlParameter[] collection = new SqlParameter[5];
                    collection[0] = new SqlParameter("@NumeroPlaca", System.Data.SqlDbType.VarChar);
                    collection[0].Value = unidadEntrega.NumeroPlaca;
                    collection[1] = new SqlParameter("@Modelo", System.Data.SqlDbType.VarChar);
                    collection[1].Value = unidadEntrega.Modelo;
                    collection[2] = new SqlParameter("@Marca", System.Data.SqlDbType.VarChar);
                    collection[2].Value = unidadEntrega.Marca;
                    collection[3] = new SqlParameter("@YearFabricacion", System.Data.SqlDbType.Int);
                    collection[3].Value = unidadEntrega.YearFabricacion;
                    collection[4] = new SqlParameter("@IdEstatusUnidad", System.Data.SqlDbType.Int);
                    collection[4].Value = unidadEntrega.Estatus.IdEstatus;

                    cmd.Parameters.AddRange(collection);
                    cmd.Connection.Open();
                    int rowsAffected = cmd.ExecuteNonQuery();
                    if (rowsAffected > 0)
                    {
                        correct = true;
                    }
                }
            }
            catch
            {

            }
            return correct;
        }
        public static bool Update(ML.UnidadEntrega unidadEntrega)
        {
            bool correct = false;
            try
            {
                using (SqlConnection context = new SqlConnection(DL.Conexion.GetConnection()))
                {
                    string query = "UnidadEntregaUpdate";
                    SqlCommand cmd = new SqlCommand(query, context);
                    cmd.CommandType = CommandType.StoredProcedure;

                    SqlParameter[] collection = new SqlParameter[6];
                    collection[0] = new SqlParameter("@IdUnidad", System.Data.SqlDbType.Int);
                    collection[0].Value = unidadEntrega.IdUnidad;
                    collection[1] = new SqlParameter("@NumeroPlaca", System.Data.SqlDbType.VarChar);
                    collection[1].Value = unidadEntrega.NumeroPlaca;
                    collection[2] = new SqlParameter("@Modelo", System.Data.SqlDbType.VarChar);
                    collection[2].Value = unidadEntrega.Modelo;
                    collection[3] = new SqlParameter("@Marca", System.Data.SqlDbType.VarChar);
                    collection[3].Value = unidadEntrega.Marca;
                    collection[4] = new SqlParameter("@YearFabricacion", System.Data.SqlDbType.Int);
                    collection[4].Value = unidadEntrega.YearFabricacion;
                    collection[5] = new SqlParameter("@IdEstatusUnidad", System.Data.SqlDbType.Int);
                    collection[5].Value = unidadEntrega.Estatus.IdEstatus;

                    cmd.Parameters.AddRange(collection);
                    cmd.Connection.Open();
                    int rowsAffected = cmd.ExecuteNonQuery();
                    if (rowsAffected > 0)
                    {
                        correct = true;
                    }
                }
            }
            catch
            {

            }
            return correct;
        }
        public static bool Delete(int idUnidadEntrega)
        {
            bool correct = false;
            try
            {
                using(SqlConnection context = new SqlConnection(DL.Conexion.GetConnection()))
                {
                    string query = "UnidadEntregaDelete";
                    SqlCommand cmd = new SqlCommand(query, context);
                    cmd.CommandType = CommandType.StoredProcedure;

                    SqlParameter[] collection = new SqlParameter[1];
                    collection[0] = new SqlParameter("@IdUnidad", SqlDbType.Int);
                    collection[0].Value = idUnidadEntrega;

                    cmd.Parameters.AddRange(collection);
                    cmd.Connection.Open();

                    int rowsAffected = cmd.ExecuteNonQuery();
                    if(rowsAffected > 0)
                    {
                        correct = true;
                    }
                }
            }
            catch
            {

            }
            return correct;
        }
    }
}
