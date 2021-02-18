using System.Runtime.Serialization;

namespace FormulaOne_Dll.DTO
{
    //[DataContract(Name = "driver")]
    public class DriverSimple
    {
        //[DataMember(Name = "driverNumber")]
        private readonly int driverNumber;
        //[DataMember(Name = "firstName")]
        private string firstName;
        //[DataMember(Name = "lastName")]
        private string lastName;
        //[DataMember(Name = "countryCode")]
        private string countryCode;
        //[DataMember(Name = "imgDriver")]
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