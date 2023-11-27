using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class Usuario
    {
        public static bool Add(ML.Usuario usuario)
        {
            bool resultado = new bool();

            try
            {
                using (DL.JAlarconPruebaTecnicaNoviembreEntities context = new DL.JAlarconPruebaTecnicaNoviembreEntities())
                {
                    int filasAfectadas = context.AddUsuario(usuario.Nombre, usuario.ApellidoPaterno, usuario.ApellidoMaterno, usuario.Nacionalidad, usuario.Edad);

                    if (filasAfectadas > 0)
                    {
                        resultado = true;
                    }
                    else
                    {
                        resultado = false;
                    }
                }

            }
            catch (Exception ex)
            {
                resultado = false;
                Console.WriteLine(ex.Message);
            }
            return resultado;
        }

        public static bool Update(ML.Usuario usuario)
        {
            bool resultado = new bool();
            try
            {
                using (DL.JAlarconPruebaTecnicaNoviembreEntities context = new DL.JAlarconPruebaTecnicaNoviembreEntities())
                {
                    int filasAfectadas = context.UpdateUsuario(usuario.IdUsuario, usuario.Nombre, usuario.ApellidoPaterno, usuario.ApellidoMaterno, usuario.Nacionalidad, usuario.Edad);

                    if (filasAfectadas > 0)
                    {
                        resultado = true;
                    }
                    else
                    {
                        resultado = false;
                    }
                }

            }
            catch (Exception ex)
            {
                resultado = false;
                Console.WriteLine(ex.Message);
            }
            return resultado;
        }

        public static bool Delete(int IdUsuario)
        {
            bool resultado = new bool();
            try
            {
                using (DL.JAlarconPruebaTecnicaNoviembreEntities context = new DL.JAlarconPruebaTecnicaNoviembreEntities())
                {
                    int filasAfectadas = context.DeleteUsuario(IdUsuario);

                    if (filasAfectadas > 0)
                    {
                        resultado = true;
                    }
                    else
                    {
                        resultado = false;
                    }
                }
            }
            catch (Exception ex)
            {
                resultado = false;
                Console.WriteLine(ex.Message);
            }
            return resultado;
        }
        public static List<object> GetAll()
        {

            List<object> list = new List<object>();
            try
            {
                using (DL.JAlarconPruebaTecnicaNoviembreEntities context = new DL.JAlarconPruebaTecnicaNoviembreEntities())
                {
                    var objeto = context.GetAllUsuario();
                    if (objeto != null)
                    {
                        foreach (var item in objeto)
                        {
                            ML.Usuario usuario = new ML.Usuario();
                            usuario.Objetos = new List<object>();
                            usuario.IdUsuario = item.IdUsuario;
                            usuario.Nombre = item.Nombre;
                            usuario.ApellidoPaterno = item.ApellidoPaterno;
                            usuario.ApellidoMaterno = item.ApellidoMaterno;
                            usuario.Nacionalidad = item.Nacionalidad;
                            usuario.Edad = item.Edad.Value;
                            list.Add(usuario);

                        }
                    }

                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return list;

        }

        public static ML.Usuario GetById(int IdUsuario)
        {
            ML.Usuario usuario = new ML.Usuario();
            try
            {
                using (DL.JAlarconPruebaTecnicaNoviembreEntities context = new DL.JAlarconPruebaTecnicaNoviembreEntities())
                {
                    var objeto = context.GetByIdUsuario(IdUsuario).SingleOrDefault();

                    if (objeto != null)
                    {

                        usuario.IdUsuario = objeto.IdUsuario;
                        usuario.Nombre = objeto.Nombre;
                        usuario.ApellidoPaterno = objeto.ApellidoPaterno;
                        usuario.ApellidoMaterno = objeto.ApellidoMaterno;
                        usuario.Nacionalidad = objeto.Nacionalidad;
                        usuario.Edad = objeto.Edad.Value;

                    }

                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return usuario;

        }
    }
}
