using DL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class Repartidor
    {
        public static List<object> GetAll()
        {
            ML.Repartidor repartidor = new ML.Repartidor();
            try
            {
                using(DL.ESantiagoPaqueteriaEntities context = new DL.ESantiagoPaqueteriaEntities())
                {
                    var query = (from Repartidores in context.Repartidors
                                 join UnidadEntrega in context.UnidadEntregas on Repartidores.IdUnidadAsignada equals UnidadEntrega.IdUnidad
                                 join EstatusUnidad in context.EstatusUnidads on UnidadEntrega.IdEstatusUnidad equals EstatusUnidad.IdEstatus
                                 select new
                                 { 
                                     IdRepartidor = Repartidores.IdRepartidor,
                                     Nombre = Repartidores.Nombre,
                                     ApellidoPaterno = Repartidores.ApellidoPaterno,
                                     ApellidoMaterno = Repartidores.ApellidoMaterno,
                                     IdUnidadAsignada = UnidadEntrega.IdUnidad,
                                     NumeroPlaca = UnidadEntrega.NumeroPlaca,
                                     Modelo = UnidadEntrega.Modelo,
                                     Marca = UnidadEntrega.Marca,
                                     YearFabricacion = UnidadEntrega.YearFabricacion,
                                     IdEstatus = EstatusUnidad.IdEstatus,
                                     Estatus = EstatusUnidad.Estatus,
                                     Telefono = Repartidores.Telefono,
                                     FechaIngreso = Repartidores.FechaIngreso,
                                     Fotografia = Repartidores.Fotografia
                                 });
                    if(query != null)
                    {
                        repartidor.Repartidores = new List<object>();
                        foreach (var item in query)
                        {
                            ML.Repartidor repartidorResult = new ML.Repartidor();
                            repartidorResult.UnidadAsignada = new ML.UnidadEntrega();
                            repartidorResult.UnidadAsignada.Estatus = new ML.EstatusUnidad();
                            repartidorResult.IdRepartidor = item.IdRepartidor;
                            repartidorResult.Nombre = item.Nombre;
                            repartidorResult.ApellidoPaterno = item.ApellidoPaterno;
                            repartidorResult.ApellidoMaterno = item.ApellidoMaterno;
                            repartidorResult.Telefono = item.Telefono;
                            repartidorResult.FechaIngreso = item.FechaIngreso;
                            repartidorResult.Fotografia = item.Fotografia;
                            repartidorResult.UnidadAsignada.IdUnidad = item.IdUnidadAsignada;
                            repartidorResult.UnidadAsignada.NumeroPlaca = item.NumeroPlaca;
                            repartidorResult.UnidadAsignada.Modelo = item.Modelo;
                            repartidorResult.UnidadAsignada.Marca = item.Marca;
                            repartidorResult.UnidadAsignada.YearFabricacion = item.YearFabricacion;
                            repartidorResult.UnidadAsignada.Estatus.IdEstatus = item.IdEstatus;
                            repartidorResult.UnidadAsignada.Estatus.Estatus = item.Estatus;
                            repartidor.Repartidores.Add(repartidorResult);
                        }
                    }
                }
            }
            catch
            {

            }
            return repartidor.Repartidores;
        }
        public static ML.Repartidor GetById(int idRepartidor)
        {
            ML.Repartidor repartidor = new ML.Repartidor();
            try
            {
                using (DL.ESantiagoPaqueteriaEntities context = new ESantiagoPaqueteriaEntities())
                {
                    var query = (from Repartidores in context.Repartidors
                                 join UnidadEntrega in context.UnidadEntregas on Repartidores.IdUnidadAsignada equals UnidadEntrega.IdUnidad
                                 join EstatusUnidad in context.EstatusUnidads on UnidadEntrega.IdEstatusUnidad equals EstatusUnidad.IdEstatus
                                 where Repartidores.IdRepartidor == idRepartidor
                                 select new
                                 {
                                     IdRepartidor = Repartidores.IdRepartidor,
                                     Nombre = Repartidores.Nombre,
                                     ApellidoPaterno = Repartidores.ApellidoPaterno,
                                     ApellidoMaterno = Repartidores.ApellidoMaterno,
                                     IdUnidadAsignada = UnidadEntrega.IdUnidad,
                                     NumeroPlaca = UnidadEntrega.NumeroPlaca,
                                     Modelo = UnidadEntrega.Modelo,
                                     Marca = UnidadEntrega.Marca,
                                     YearFabricacion = UnidadEntrega.YearFabricacion,
                                     IdEstatus = EstatusUnidad.IdEstatus,
                                     Estatus = EstatusUnidad.Estatus,
                                     Telefono = Repartidores.Telefono,
                                     FechaIngreso = Repartidores.FechaIngreso,
                                     Fotografia = Repartidores.Fotografia
                                 }).FirstOrDefault();
                    if(query != null)
                    {
                        repartidor.UnidadAsignada = new ML.UnidadEntrega();
                        repartidor.UnidadAsignada.Estatus = new ML.EstatusUnidad();
                        repartidor.IdRepartidor = query.IdRepartidor;
                        repartidor.Nombre = query.Nombre;
                        repartidor.ApellidoPaterno = query.ApellidoPaterno;
                        repartidor.ApellidoMaterno = query.ApellidoMaterno;
                        repartidor.Telefono = query.Telefono;
                        repartidor.FechaIngreso = query.FechaIngreso;
                        repartidor.Fotografia = query.Fotografia;
                        repartidor.UnidadAsignada.IdUnidad = query.IdUnidadAsignada;
                        repartidor.UnidadAsignada.NumeroPlaca = query.NumeroPlaca;
                        repartidor.UnidadAsignada.Modelo = query.Modelo;
                        repartidor.UnidadAsignada.Marca = query.Marca;
                        repartidor.UnidadAsignada.YearFabricacion = query.YearFabricacion;
                        repartidor.UnidadAsignada.Estatus.IdEstatus = query.IdEstatus;
                        repartidor.UnidadAsignada.Estatus.Estatus = query.Estatus;
                    }
                }
            }
            catch { }
            return repartidor;
        }
        public static bool Add(ML.Repartidor repartidor)
        {
            bool correct = false;
            try
            {
                using(DL.ESantiagoPaqueteriaEntities context = new ESantiagoPaqueteriaEntities())
                {
                    DL.Repartidor nuevoRepartidor = new DL.Repartidor();
                    nuevoRepartidor.Nombre = repartidor.Nombre;
                    nuevoRepartidor.ApellidoPaterno = repartidor.ApellidoPaterno;
                    nuevoRepartidor.ApellidoMaterno = repartidor.ApellidoMaterno;
                    nuevoRepartidor.Telefono = repartidor.Telefono;
                    nuevoRepartidor.FechaIngreso = repartidor.FechaIngreso;
                    nuevoRepartidor.IdUnidadAsignada = repartidor.UnidadAsignada.IdUnidad;

                    var query = (from a in context.UnidadEntregas where a.IdUnidad == nuevoRepartidor.IdUnidadAsignada select a).SingleOrDefault();
                    if (query != null)
                    {
                        query.IdEstatusUnidad = 4;
                    }

                    context.Repartidors.Add(nuevoRepartidor);
                    context.SaveChanges();
                    correct = true;
                }
            }
            catch
            {

            }
            return correct;
        }
        public static bool Update(ML.Repartidor repartidor)
        {
            bool correct = false;
            try
            {
                using(DL.ESantiagoPaqueteriaEntities context = new ESantiagoPaqueteriaEntities())
                {
                    var query = (from r in context.Repartidors where r.IdRepartidor == repartidor.IdRepartidor select r).SingleOrDefault();
                    if (query != null)
                    {
                        query.Nombre = repartidor.Nombre;
                        query.ApellidoPaterno = repartidor.ApellidoPaterno;
                        query.ApellidoMaterno = repartidor.ApellidoMaterno;
                        query.Telefono = repartidor.Telefono;
                        query.FechaIngreso = repartidor.FechaIngreso;
                        query.IdUnidadAsignada = repartidor.UnidadAsignada.IdUnidad;
                        context.SaveChanges();
                        correct = true;
                    }
                }
            }
            catch
            {

            }
            return correct;
        }
        public static bool Delete(int idRepartidor)
        {
            bool correct = false;
            try
            {
                using(DL.ESantiagoPaqueteriaEntities context = new ESantiagoPaqueteriaEntities())
                {
                    var query = (from r in context.Repartidors where r.IdRepartidor == idRepartidor select r).First();
                    context.Repartidors.Remove(query);
                    context.SaveChanges();
                    correct = true;
                }
            }
            catch
            {

            }
            return correct;
        }
    }
}
