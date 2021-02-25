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
        private int extFirstDriver;
        private int extSecondDriver;
        private string img;

        public TeamSimple(Team t)
        {
            this.id = t.Id;
            this.Name = t.Name;
            this.Logo = t.ImgLogo;
            this.ExtFirstDriver = t.ExtFirstDriver;
            this.ExtSecondDriver = t.ExtSecondDriver;
            this.Img = t.ImgCar;
        }

        public int Id => id;

        public string Name { get => name; set => name = value; }
        public string Logo { get => logo; set => logo = value; }
        public int ExtFirstDriver { get => extFirstDriver; set => extFirstDriver = value; }
        public int ExtSecondDriver { get => extSecondDriver; set => extSecondDriver = value; }
        public string Img { get => img; set => img = value; }
    }
}
