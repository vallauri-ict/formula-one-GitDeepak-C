using System;

namespace FormulaOne_Dll
{
    public class Driver
    {
        private int driverNumber;
        private string firstName;
        private string lastName;
        private DateTime dob;
        private string placeOfBirth;
        private string extCountry;
        private string biography;
        private string imgDriver;
        private int podiums;
        private int totalPoints;
        private int grandPrix;
        private int worldChampionships;
        private string highestRaceFinish;
        private int highestGridFinish;

        public Driver() { }

        public Driver(
            int driverNumber, 
            string firstName,
            string lastName,
            DateTime dob,
            string place,
            string country,
            string biography,
            string imgDriver,
            int podiums,
            int totalPoints,
            int grandPrix,
            int worldChampionships,
            string highestRaceFinish,
            int highestGridFinish
        )
        {
            this.DriverNumber = driverNumber;
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Dob = dob;
            this.PlaceOfBirth = placeOfBirth;
            this.ExtCountry = country;
            this.Biography = biography;
            this.ImgDriver = imgDriver;
            this.Podiums = podiums;
            this.TotalPoints = totalPoints;
            this.GrandPrix = grandPrix;
            this.WorldChampionships = worldChampionships;
            this.HighestRaceFinish = highestRaceFinish;
            this.HighestGridFinish = highestGridFinish;
        }

        public int DriverNumber { get => driverNumber; set => driverNumber = value; }
        public string FirstName { get => firstName; set => firstName = value; }
        public string LastName { get => lastName; set => lastName = value; }
        public DateTime Dob { get => dob; set => dob = value; }
        public string PlaceOfBirth { get => placeOfBirth; set => placeOfBirth = value; }
        public string ExtCountry { get => extCountry; set => extCountry = value; }
        public string Biography { get => biography; set => biography = value; }
        public string ImgDriver { get => imgDriver; set => imgDriver = value; }
        public int Podiums { get => podiums; set => podiums = value; }
        public int TotalPoints { get => totalPoints; set => totalPoints = value; }
        public int GrandPrix { get => grandPrix; set => grandPrix = value; }
        public int WorldChampionships { get => worldChampionships; set => worldChampionships = value; }
        public string HighestRaceFinish { get => highestRaceFinish; set => highestRaceFinish = value; }
        public int HighestGridFinish { get => highestGridFinish; set => highestGridFinish = value; }
    }
}
