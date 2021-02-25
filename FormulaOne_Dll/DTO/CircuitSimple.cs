using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormulaOne_Dll.DTO
{
    public class CircuitSimple
    {
        int id;
        string name;
        int length;
        string extCountry;
        string imgCircuit;

        public CircuitSimple(Circuit c)
        {
            this.id = c.Id;
            this.name = c.Name;
            this.length = c.Length;
            this.extCountry = c.ExtCountry;
            this.imgCircuit = c.ImgCircuit;
        }
    }
}
