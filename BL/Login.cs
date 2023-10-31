using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class Login
    {
        public static ML.Usuario CheckLogin(string username, string password)
        {
            ML.Usuario usuario = new ML.Usuario();
            usuario.Rol = new ML.Rol();
            bool correct = false;
            try
            {
                using(DL.ESantiagoPaqueteriaEntities context = new DL.ESantiagoPaqueteriaEntities())
                {
                    byte[] passwordBytes = Encriptar(Encoding.UTF8.GetBytes(password));
                    var query = context.UsuarioLogin(username, passwordBytes);
                    if(query != null)
                    {
                        foreach(var item in query)
                        {
                            usuario.UserName = item.Username;
                            usuario.Password = item.Password;
                            usuario.Rol.IdRol = item.IdRol;
                            usuario.Rol.Tipo = item.Tipo;
                        }
                        correct = true;
                    }
                }
            }
            catch
            {
                correct = false;
            }
            return usuario;
        }
        public static byte[] Encriptar(byte[] data)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] datosEncriptados = sha256.ComputeHash(data);
                return datosEncriptados;
            }
        }
    }
}
