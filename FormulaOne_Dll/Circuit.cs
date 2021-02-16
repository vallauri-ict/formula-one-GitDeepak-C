using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormulaOne_Dll
{
    public class Circuit
    {
        int id;
        string name;
        int length;
        int nLaps;
        string extCountry;
        string recordLap;
        string imgCircuit;

        public Circuit() { }

        public Circuit(int id, string name, int length, int nLaps, string extCountry, string recordLap, string imgCircuit)
        {
            this.Id = id;
            this.Name = name;
            this.Length = length;
            this.NLaps = nLaps;
            this.ExtCountry = extCountry;
            this.RecordLap = recordLap;
            this.ImgCircuit = imgCircuit;
        }

        public int Id { get => id; set => id = value; }
        public string Name { get => name; set => name = value; }
        public int Length { get => length; set => length = value; }
        public int NLaps { get => nLaps; set => nLaps = value; }
        public string ExtCountry { get => extCountry; set => extCountry = value; }
        public string RecordLap { get => recordLap; set => recordLap = value; }
        public string ImgCircuit { get => imgCircuit; set => imgCircuit = value; }
    }
}
