using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class LogEntity
    {
        public int LogID { get; set; }
        public int? EntityID { get; set; }
        public string Type { get; set; }
        public string Data { get; set; }
    }
}
