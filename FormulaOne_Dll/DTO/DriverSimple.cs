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

        public DriverSimple(Driver d)
        {
            this.driverNumber = d.DriverNumber;
            this.FirstName = d.FirstName;
            this.LastName= d.LastName;
            this.CountryCode = d.ExtCountry;
            this.ImgDriver = d.ImgDriver;
        }

        public int DriverNumber => driverNumber;

        public string FirstName { get => firstName; set => firstName = value; }
        public string LastName { get => lastName; set => lastName = value; }
        public string CountryCode { get => countryCode; set => countryCode = value; }
        public string ImgDriver { get => imgDriver; set => imgDriver = value; }
    }
}