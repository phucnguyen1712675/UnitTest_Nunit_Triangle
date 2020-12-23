using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTest_Nunit_Triangle
{
    public class Diem
    {
        public double _x;
        public double _y;

        public void SetX(double value) => this._x = value;
        public double GetX() => this._x;
        public void SetY(double value) => this._y = value;
        public double GetY() => this._y;
    }
}
