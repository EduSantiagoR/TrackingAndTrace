using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class Paquete
    {
        public static bool Add(ML.Paquete paquete)
        {
            bool correct = false;
            try
            {
                using (SqlConnection context = new SqlConnection(DL.Conexion.GetConnection()))
                {
                    string query = "PaqueteAdd";
                    SqlCommand cmd = new SqlCommand(query, context);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    SqlParameter[] collection = new SqlParameter[6];
                    collection[0] = new SqlParameter("@Detalle", System.Data.SqlDbType.VarChar);
                    collection[0].Value = paquete.Detalle;
                    collection[1] = new SqlParameter("@Peso", System.Data.SqlDbType.Float);
                    collection[1].Value = paquete.Peso;
                    collection[2] = new SqlParameter("@DireccionOrigen", System.Data.SqlDbType.VarChar);
                    collection[2].Value = paquete.DireccionOrigen;
                    collection[3] = new SqlParameter("@DireccionEntrega", System.Data.SqlDbType.VarChar);
                    collection[3].Value = paquete.DireccionEntrega;
                    collection[4] = new SqlParameter("@FechaEstimadaEntrega", System.Data.SqlDbType.Date);
                    collection[4].Value = paquete.FechaEstimadaEntrega;
                    collection[5] = new SqlParameter("@CodigoRastreo", System.Data.SqlDbType.VarChar);
                    collection[5].Value = paquete.CodigoRastreo;

                    cmd.Parameters.AddRange(collection);
                    cmd.Connection.Open();
                    int rowsAffected = cmd.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        return true;
                    }
                }
            }
            catch
            {

            }
            return correct;
        }
        public static bool Update(ML.Paquete paquete)
        {
            bool correct = false;
            try
            {
                using (SqlConnection context = new SqlConnection(DL.Conexion.GetConnection()))
                {
                    string query = "PaqueteUpdate";
                    SqlCommand cmd = new SqlCommand(query, context);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    SqlParameter[] collection = new SqlParameter[7];
                    collection[0] = new SqlParameter("@IdPaquete", System.Data.SqlDbType.Int);
                    collection[0].Value = paquete.IdPaquete;
                    collection[1] = new SqlParameter("@Detalle", System.Data.SqlDbType.VarChar);
                    collection[1].Value = paquete.Detalle;
                    collection[2] = new SqlParameter("@Peso", System.Data.SqlDbType.Float);
                    collection[2].Value = paquete.Peso;
                    collection[3] = new SqlParameter("@DireccionOrigen", System.Data.SqlDbType.VarChar);
                    collection[3].Value = paquete.DireccionOrigen;
                    collection[4] = new SqlParameter("@DireccionEntrega", System.Data.SqlDbType.VarChar);
                    collection[4].Value = paquete.DireccionEntrega;
                    collection[5] = new SqlParameter("@FechaEstimadaEntrega", System.Data.SqlDbType.Date);
                    collection[5].Value = paquete.FechaEstimadaEntrega;
                    collection[6] = new SqlParameter("@CodigoRastreo", System.Data.SqlDbType.VarChar);
                    collection[6].Value = paquete.CodigoRastreo;

                    cmd.Parameters.AddRange(collection);
                    cmd.Connection.Open();
                    int rowsAffected = cmd.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        return true;
                    }
                }
            }
            catch
            {

            }
            return correct;
        }
        public static bool Delete(int idPaquete)
        {
            bool correct = false;
            try
            {
                using (SqlConnection context = new SqlConnection(DL.Conexion.GetConnection()))
                {
                    string query = "PaqueteDelete";
                    SqlCommand cmd = new SqlCommand(query, context);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    SqlParameter[] collection = new SqlParameter[1];
                    collection[0] = new SqlParameter("@IdPaquete", System.Data.SqlDbType.Int);
                    collection[0].Value = idPaquete;

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
    }
}
