using System;

namespace FormulaOne_Dll.DTO
{
    public class ScoreSimple
    {
        private string grandPrix;
        private DateTime date;
        private string winner;
        private string car;
        private int nLaps;
        private DateTime time;

        public ScoreSimple(Score s, Race r, Driver d, Team t, RacePoints rp)
        {
            this.GrandPrix = r.Name;
            this.Date = r.Data;
            this.Winner = d.FirstName + " " + d.LastName;
            this.Car = t.Name;
            this.NLaps = 0;
            this.Time = new DateTime().Date; //Convert.ToDateTime(rp.FastestLap);
        }

        public string GrandPrix { get => grandPrix; set => grandPrix = value; }
        public DateTime Date { get => date; set => date = value; }
        public string Winner { get => winner; set => winner = value; }
        public string Car { get => car; set => car = value; }
        public int NLaps { get => nLaps; set => nLaps = value; }
        public DateTime Time { get => time; set => time = value; }
    }
}
