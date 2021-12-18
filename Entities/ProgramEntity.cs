using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class ProgramEntity
    {
        public int ProgramID { get; set; }
        public int SprinklerID { get; set; }
        public string ActionTime { get; set; }
        public int Action { get; set; }
        public bool Finish { get; set; }
        public ProgramEntity previus { get; set; }  
        public override string ToString()
        {

            return SprinklerID + " - " + ActionTime + " - " + (Action == 1 ? "Encender" : "Apagar");
        }
    }
}
