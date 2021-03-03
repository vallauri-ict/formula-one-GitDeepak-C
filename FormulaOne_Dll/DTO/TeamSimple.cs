using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormulaOne_Dll.DTO
{
    public class TeamSimple
    {
        private readonly int id;
        private string name;
        private string logo;
        private string img;
        private string firstDriverName;
        private string firstDriverSurname;
        private string secondDriverName;
        private string secondDriversurname;

        public TeamSimple(Team t, Driver d1, Driver d2)
        {
            this.id = t.Id;
            this.Name = t.Name;
            this.Logo = t.ImgLogo;
            this.FirstDriverName = d1.FirstName;
            this.FirstDriverSurname = d1.LastName;
            this.SecondDriverName = d2.FirstName;
            this.SecondDriversurname = d2.LastName;
            this.Img = t.ImgCar;
        }

        public int Id => id;

        public string Name { get => name; set => name = value; }
        public string Logo { get => logo; set => logo = value; }
        public string Img { get => img; set => img = value; }

        public string FirstDriverName { get => firstDriverName; set => firstDriverName = value; }
        public string FirstDriverSurname { get => firstDriverSurname; set => firstDriverSurname = value; }
        public string SecondDriverName { get => secondDriverName; set => secondDriverName = value; }
        public string SecondDriversurname { get => secondDriversurname; set => secondDriversurname = value; }
    }
}
