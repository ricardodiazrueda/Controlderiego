using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlRiego
{
    public class Log
    {
        public int LogID { get; set; }
        public DateTime Fecha { get; set; }
        public string Tipo { get; set; }
        public string Info { get; set; }
        public override string ToString()
        {
            return Info;
        }
    }
}
