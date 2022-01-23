using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlRiego
{
    public class Usuario
    {
        public int UsuarioID { get; set; }
        public string Nombre { get; set; }
        public string NombreUsuario { get; set; }
        public string Clave { get; set; }
        public bool Tipo { get; set; }
        public override string ToString()
        {
            return Nombre;
        }
    }
}
