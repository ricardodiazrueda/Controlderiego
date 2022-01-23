using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlRiego
{
    public class Solenoide
    {
        public int SolenoideID { get; set; }
        public string Campo { get; set; }
        public int RadioID { get; set; }
        public int NumeroSolenoide { get; set; }
        public bool Estado { get; set; }
        public override string ToString()
        {
            return Campo + (char)('@' + RadioID) + (char)('@' + NumeroSolenoide);
        }
        public override bool Equals(object obj)
        {
            Solenoide data = obj as Solenoide;
            return this.Campo == data.Campo && this.RadioID == data.RadioID && this.NumeroSolenoide == data.NumeroSolenoide;
        }
    }
}
