using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormulaOne_Dll
{
    public class Country
    {

        private string countryCode;
        private string countryName;

        public Country() { }

        public Country(string countryCode, string countryName)
        {
            this.CountryCode = countryCode;
            this.CountryName = countryName;
        }

        public string CountryCode { get => countryCode; set => countryCode = value; }
        public string CountryName { get => countryName; set => countryName = value; }

        public override string ToString()
        {
            return countryCode + " - " + countryName;
        }
    }
}
