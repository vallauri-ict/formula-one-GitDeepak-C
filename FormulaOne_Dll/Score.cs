using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormulaOne_Dll
{
    public class Score
    {
        int pos,
            points,
            extDriver,
            extTeam;

        public Score() { }

        public Score(int pos, int points, int extDriver, int extTeam)
        {
            this.Pos = pos;
            this.Points = points;
            this.ExtDriver = extDriver;
            this.ExtTeam = extTeam;
        }

        public int Pos { get => pos; set => pos = value; }
        public int Points { get => points; set => points = value; }
        public int ExtDriver { get => extDriver; set => extDriver = value; }
        public int ExtTeam { get => extTeam; set => extTeam = value; }
    }
}
