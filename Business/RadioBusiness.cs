using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data;
using Entities;

namespace Business
{
    public class RadioBusiness
    {
        RadioData radioData = new RadioData();
        public string Create(int sprinklers)
        {
            return radioData.Insert(sprinklers);
        }
        public int Quantity()
        {
            return radioData.ReadQuantity();
        }
        public int GetSprinklers(int radio)
        {
            return radioData.ReadSprinklers(radio);
        }
        public int PrevQuantity(int radio)
        {
            return radioData.ReadQuantity(radio);
        }
    }
}
