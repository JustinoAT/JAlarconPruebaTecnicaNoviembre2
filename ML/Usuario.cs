using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ML
{
    public class Usuario
    {
        public int IdUsuario { get; set; }
        public string Nombre { get; set; }
        public string ApellidoPaterno { get; set; }
        public string ApellidoMaterno { get; set; }
        public string Nacionalidad { get; set; }
        public int Edad { get; set; }
        public List<object> Objetos { get; set; }
        public object Objeto { get; set; }
    }
}
