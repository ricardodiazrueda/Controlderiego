using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data;

namespace Business
{
    public class DataBusiness
    {
        DataData dataData = new DataData();
        public string Write(string key, string value)
        {
            return dataData.Set(key, value);
        }
        public string Read(string key)
        {
            return dataData.Get(key);
        }
    }
}
