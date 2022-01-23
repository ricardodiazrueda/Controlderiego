using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlRiego
{
    public class Programa
    {
        public int ProgramaID { get; set; }
        public int SolenoideID { get; set; }
        public string Hora { get; set; }
        public bool Accion { get; set; }

        public Programa Original { get; set; }
        public int Intento { get; set; } = 0;
        public override string ToString()
        {
            string[] dias = new string[] { "domingo", "lunes", "martes", "miércoles", "jueves", "viernes", "sábado" };
            
            return SolenoideID + " - " + dias[Hora[0] - '0'] + Hora.Substring(1, Hora.Length - 1);
        }
    }
}
