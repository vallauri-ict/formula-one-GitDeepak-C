using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormulaOne_Dll
{
    public class Team
    {
        private int id;
        private string name;
        private string fullTeamName;
        private string teamBase;
        private string extCountry;
        private string teamChief;
        private string technicalChief;
        private string powerUnit;
        private string chassis;
        private string firstTeamEntry;
        private int worldChampionships;
        private int extFirstDriver;
        private int extSecondDriver;
        private string imgLogo;
        private string imgCar;

        public Team() { }

        public Team(
            int id, 
            string name, 
            string fullTeamName, 
            string teambase, 
            string extCountry, 
            string teamChief,
            string technicalChief,
            string powerUnit,
            string chassis, 
            string firstTimeEntry,
            int worldChampionships,
            int extFirstDruver,
            int extSecondDriver,
            string imgLogo,
            string imgCar
        ) 
        {
            this.Id = id;
            this.Name = name;
            this.FullTeamName = fullTeamName;
            this.TeamBase = teamBase;
            this.ExtCountry = extCountry;
            this.TeamChief = teamChief;
            this.TechnicalChief = technicalChief;
            this.PowerUnit = powerUnit;
            this.Chassis = chassis;
            this.FirstTeamEntry = firstTimeEntry;
            this.WorldChampionships = worldChampionships;
            this.ExtFirstDriver = extFirstDriver;
            this.ExtSecondDriver = extSecondDriver;
            this.ImgLogo = imgLogo;
            this.ImgCar = imgCar;
        }

        public int Id { get => id; set => id = value; }
        public string Name { get => name; set => name = value; }
        public string FullTeamName { get => fullTeamName; set => fullTeamName = value; }
        public string TeamBase { get => teamBase; set => teamBase = value; }
        public string ExtCountry { get => extCountry; set => extCountry = value; }
        public string TeamChief { get => teamChief; set => teamChief = value; }
        public string TechnicalChief { get => technicalChief; set => technicalChief = value; }
        public string PowerUnit { get => powerUnit; set => powerUnit = value; }
        public string Chassis { get => chassis; set => chassis = value; }
        public string FirstTeamEntry { get => firstTeamEntry; set => firstTeamEntry = value; }
        public int WorldChampionships { get => worldChampionships; set => worldChampionships = value; }
        public int ExtFirstDriver { get => extFirstDriver; set => extFirstDriver = value; }
        public int ExtSecondDriver { get => extSecondDriver; set => extSecondDriver = value; }
        public string ImgLogo { get => imgLogo; set => imgLogo = value; }
        public string ImgCar { get => imgCar; set => imgCar = value; }
    }
}
