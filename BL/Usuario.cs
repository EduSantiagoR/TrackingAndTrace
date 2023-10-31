using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure.Annotations;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace BL
{
    public class Usuario
    {
        public static ML.Usuario GetAll()
        {
            ML.Usuario usuario = new ML.Usuario();
            try
            {
                using (DL.ESantiagoPaqueteriaEntities context = new DL.ESantiagoPaqueteriaEntities())
                {
                    var query = context.UsuarioGetAll();
                    if(query != null)
                    {
                        usuario.Usuarios = new List<object>();
                        foreach(var item in query)
                        {
                            ML.Usuario user = new ML.Usuario();
                            user.Rol = new ML.Rol();
                            user.IdUsuario = item.IdUsuario;
                            user.UserName = item.Username;
                            user.Password = item.Password;
                            user.Rol.IdRol = item.IdRol;
                            user.Rol.Tipo = item.RolAsignado;
                            user.Email = item.Email;
                            user.Nombre = item.Nombre;
                            user.ApellidoPaterno = item.ApellidoPaterno;
                            user.ApellidoMaterno = item.ApellidoMaterno;
                            usuario.Usuarios.Add(user);
                        }
                    }
                }
            }
            catch
            {

            }
            return usuario;
        }
        public static ML.Usuario GetById(int idUsuario)
        {
            ML.Usuario usuario = new ML.Usuario();
            try
            {
                using(DL.ESantiagoPaqueteriaEntities context = new DL.ESantiagoPaqueteriaEntities())
                {
                    var query = context.UsuarioGetById(idUsuario);
                    if(query != null)
                    {
                        foreach(var item in query)
                        {
                            usuario.Rol = new ML.Rol();
                            usuario.IdUsuario = item.IdUsuario;
                            usuario.UserName = item.Username;
                            usuario.Password = item.Password;
                            usuario.Rol.IdRol = item.IdRol;
                            usuario.Rol.Tipo = item.RolAsignado;
                            usuario.Email = item.Email;
                            usuario.Nombre = item.Nombre;
                            usuario.ApellidoPaterno = item.ApellidoPaterno;
                            usuario.ApellidoMaterno = item.ApellidoMaterno;
                        }
                    }
                }
            }
            catch
            {

            }
            return usuario;
        }
        public static bool Add(ML.Usuario usuario)
        {
            bool correct = false;
            byte[] paswordSha = Encriptar(Encoding.UTF8.GetBytes(usuario.PasswordString));

            try
            {
                using(DL.ESantiagoPaqueteriaEntities context = new DL.ESantiagoPaqueteriaEntities())
                {
                    int rowsAffected = context.UsuarioAdd(usuario.UserName,
                        paswordSha,
                        usuario.Rol.IdRol,
                        usuario.Email,
                        usuario.Nombre,
                        usuario.ApellidoPaterno,
                        usuario.ApellidoMaterno);
                    if(rowsAffected > 0)
                    {
                        correct = true;
                    }
                }
            }
            catch
            {
                correct = false;
            }
            return correct;
        }
        public static bool Update(ML.Usuario usuario)
        {
            bool correct = false;
            byte[] paswordSha = Encriptar(usuario.Password);
            try
            {
                using (DL.ESantiagoPaqueteriaEntities context = new DL.ESantiagoPaqueteriaEntities())
                {
                    int rowsAffected = context.UsuarioUpdate(usuario.IdUsuario,
                        usuario.UserName,
                        paswordSha,
                        usuario.Rol.IdRol,
                        usuario.Email,
                        usuario.Nombre,
                        usuario.ApellidoPaterno,
                        usuario.ApellidoMaterno);
                    if(rowsAffected > 0)
                    {
                        correct = true;
                    }
                }
            }
            catch
            {
                correct = false;
            }
            return correct;
        }
        public static bool Delete(int idUsuario)
        {
            bool correct = false;
            try
            {
                using(DL.ESantiagoPaqueteriaEntities context = new DL.ESantiagoPaqueteriaEntities())
                {
                    int rowsAffected = context.UsuarioDelete(idUsuario);
                    if(rowsAffected > 0)
                    {
                        correct = true;
                    }
                }
            }
            catch
            {
                correct = false;
            }
            return correct;
        }
        public static byte[] Encriptar(byte[] data)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] datosEncriptados = sha256.ComputeHash(data);
                return datosEncriptados;
            }
        }
        public static string Desencriptar(byte[] data)
        {
            StringBuilder stringBuilder = new StringBuilder();

            foreach (byte b in data)
                stringBuilder.AppendFormat("{0:X2}", b);
            string hashString = stringBuilder.ToString();

            return hashString;
        }
    }
}
