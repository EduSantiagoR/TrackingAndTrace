using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class Rol
    {
        public static List<object> GetAll()
        {
            ML.Rol rol = new ML.Rol();
            try
            {
                using(DL.ESantiagoPaqueteriaEntities context = new DL.ESantiagoPaqueteriaEntities())
                {
                    var query = context.RolGetAll();
                    if(query != null)
                    {
                        rol.Roles = new List<object>();
                        foreach(var registro in query)
                        {
                            ML.Rol rol1 = new ML.Rol();
                            rol1.IdRol = registro.IdRol;
                            rol1.Tipo = registro.Tipo;
                            rol.Roles.Add(registro);
                        }
                    }
                }
            }
            catch
            {

            }
            return rol.Roles;
        }
    }
}
