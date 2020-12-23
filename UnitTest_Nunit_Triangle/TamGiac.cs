using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTest_Nunit_Triangle
{
    public class TamGiac
    {
        private const double DELTA = 0.00001;

        private Diem _diem1;
        private Diem _diem2;
        private Diem _diem3;

        private void SetNewValue(double x1, double x2, double y1, double y2, double z1, double z2)
        {
            this._diem1 = new Diem
            {
                _x = x1,
                _y = x2
            };
            this._diem2 = new Diem
            {
                _x = y1,
                _y = y2
            };
            this._diem3 = new Diem
            {
                _x = z1,
                _y = z2
            };
        }

        private double GetDistance(Diem x, Diem y) => Math.Sqrt((Math.Pow(x.GetX() - y.GetX(), 2) + Math.Pow(x.GetY() - y.GetY(), 2)));

        private double GetSide12Length() => GetDistance(this._diem1, this._diem2);

        private double GetSide23Length() => GetDistance(this._diem2, this._diem3);

        private double GetSide31Length() => GetDistance(this._diem3, this._diem1);

        private bool IsValidTriangle()
        {
            var result = this._diem1.GetX() * (this._diem2.GetY() - this._diem3.GetY()) +
                        this._diem2.GetX() * (this._diem3.GetY() - this._diem1.GetY()) +
                        this._diem3.GetX() * (this._diem1.GetY() - this._diem2.GetY());
            return result != 0;
        }

        private bool IsEqualLength(double numA, double numB) => Math.Abs(numA - numB) < DELTA;

        private bool IsEquilateralTriangle() => IsEqualLength(GetSide12Length(), GetSide23Length()) && IsEqualLength(GetSide23Length(), GetSide31Length());

        private bool IsIsoscelesTriangle() => IsEqualLength(GetSide12Length(), GetSide23Length()) || 
                                            IsEqualLength(GetSide23Length(), GetSide31Length()) || 
                                            IsEqualLength(GetSide31Length(), GetSide12Length());
        
        private bool IsRightAngledTriangle() => IsEqualLength(Math.Pow(GetSide12Length(), 2) + Math.Pow(GetSide23Length(), 2), Math.Pow(GetSide31Length(), 2)) ||
                                              IsEqualLength(Math.Pow(GetSide23Length(), 2) + Math.Pow(GetSide31Length(), 2), Math.Pow(GetSide12Length(), 2)) ||
                                              IsEqualLength(Math.Pow(GetSide31Length(), 2) + Math.Pow(GetSide12Length(), 2), Math.Pow(GetSide23Length(), 2));

        public double FindPerimeter(double x1, double x2, double y1, double y2, double z1, double z2)
        {
            SetNewValue(x1, x2, y1, y2, z1, z2);

            return IsValidTriangle() ?
                GetSide12Length() +
                GetSide23Length() +
                GetSide31Length()
                : -1.0;
        }

        public string CheckTriangleType(double x1, double x2, double y1, double y2, double z1, double z2)
        {
            SetNewValue(x1, x2, y1, y2, z1, z2);

            string result;

            if (IsValidTriangle())
            {
                result = "Tam giác";
                var temp = result;
                
                if (IsEquilateralTriangle())
                {
                    result += " đều";
                }
                else
                {
                    if (IsRightAngledTriangle())
                    {
                        result += " vuông";
                    }
                    if (IsIsoscelesTriangle())
                    {
                        result += " cân";
                    }
                }
                if (result.Equals(temp))
                {
                    result += " thường";
                }
            }
            else
            {
                result = "Không phải tam giác";
            }
            return result;
        }
    }
}
