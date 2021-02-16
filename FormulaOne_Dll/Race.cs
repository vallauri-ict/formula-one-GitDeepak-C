using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormulaOne_Dll
{
    public class Race
    {
        int idRace;
        string name;
        int extCircuit;
        DateTime data;

        public Race() { }

        public Race(int idRace, string name, int extCircuit, DateTime data)
        {
            this.IdRace = idRace;
            this.Name = name;
            this.ExtCircuit = extCircuit;
            this.Data = data;
        }

        public int IdRace { get => idRace; set => idRace = value; }
        public string Name { get => name; set => name = value; }        
        public int ExtCircuit { get => extCircuit; set => extCircuit = value; }
        public DateTime Data { get => data; set => data = value; }
    }
}
