using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data;

namespace Business
{
    public class SprinklerBusiness
    {
        SprinklerData sprinklerData = new SprinklerData();
        public string Create()
        {
            return sprinklerData.Insert();
        }
        public List<int> ReadAll()
        {

            return sprinklerData.ReadAll();
        }
    }
}
