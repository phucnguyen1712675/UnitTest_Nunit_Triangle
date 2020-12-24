using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTest_Nunit_Triangle
{
    public class Diem
    {
        public decimal _x;
        public decimal _y;

        public void SetX(decimal value) => this._x = value;
        public decimal GetX() => this._x;
        public void SetY(decimal value) => this._y = value;
        public decimal GetY() => this._y;
    }
}
