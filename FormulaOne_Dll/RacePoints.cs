using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormulaOne_Dll
{
    public class RacePoints
    {
        int id,
            extDriver,
            extPos,
            extRace;
        string fastestLap;

        public RacePoints() { }

        public RacePoints(int id, int extDriver, int extPos, int extRace, string fastestLap)
        {
            this.Id = id;
            this.ExtDriver = extDriver;
            this.ExtPos = extPos;
            this.ExtRace = extRace;
            this.FastestLap = fastestLap;
        }

        public int Id { get => id; set => id = value; }
        public int ExtDriver { get => extDriver; set => extDriver = value; }
        public int ExtPos { get => extPos; set => extPos = value; }
        public int ExtRace { get => extRace; set => extRace = value; }
        public string FastestLap { get => fastestLap; set => fastestLap = value; }
    }
}
