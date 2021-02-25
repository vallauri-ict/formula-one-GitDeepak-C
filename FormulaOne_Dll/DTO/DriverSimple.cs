using System.Runtime.Serialization;

namespace FormulaOne_Dll.DTO
{
    public class DriverSimple
    {
        private readonly int driverNumber;
        private string firstName;
        private string lastName;
        private string countryCode;
        private string imgDriver;
        private string fullTeamName;

        public DriverSimple(Driver d, string fullTeamName)
        {
            this.driverNumber = d.DriverNumber;
            this.FirstName = d.FirstName;
            this.LastName= d.LastName;
            this.CountryCode = d.ExtCountry;
            this.ImgDriver = d.ImgDriver;
            this.FullTeamName = fullTeamName;
        }

        public int DriverNumber => driverNumber;

        public string FirstName { get => firstName; set => firstName = value; }
        public string LastName { get => lastName; set => lastName = value; }
        public string CountryCode { get => countryCode; set => countryCode = value; }
        public string ImgDriver { get => imgDriver; set => imgDriver = value; }
        public string CountryFlag 
        { 
            get 
            {
                return string.Format("https://www.countryflags.io/{0}/flat/64.png", CountryCode);
            } 
        }

        public string FullTeamName { get => fullTeamName; set => fullTeamName = value; }
    }
}