using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data;
using Entities;

namespace Business
{
    public class ProgramBusiness
    {
        ProgramData programData = new ProgramData();
        public string Create(int SprinklerID, string ActionTime, int Action)
        {
            return programData.Insert(SprinklerID, ActionTime, Action);
        }
        public List<ProgramEntity> GetPrograms(int SprinklerID)
        {
            return programData.ReadPrograms(SprinklerID);
        }
        public List<ProgramEntity> GetAll()
        {
            return programData.ReadAll();
        }
        public string Delete(int ProgramID)
        {
            return programData.Delete(ProgramID);
        }
    }
}
