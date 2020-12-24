using DecimalMath;
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
        public const decimal DELTA = 0.000001m;

        private Diem _diem1;
        private Diem _diem2;
        private Diem _diem3;

        private void SetNewValue(decimal x1, decimal x2, decimal y1, decimal y2, decimal z1, decimal z2)
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

        private decimal GetDistance(Diem x, Diem y) => DecimalEx.Sqrt(DecimalEx.Pow(x.GetX() - y.GetX(), 2m) + DecimalEx.Pow(x.GetY() - y.GetY(), 2m));

        private decimal GetSide12Length() => GetDistance(this._diem1, this._diem2);

        private decimal GetSide23Length() => GetDistance(this._diem2, this._diem3);

        private decimal GetSide31Length() => GetDistance(this._diem3, this._diem1);

        private bool IsValidTriangle()
        {
            var result = this._diem1.GetX() * (this._diem2.GetY() - this._diem3.GetY()) +
                        this._diem2.GetX() * (this._diem3.GetY() - this._diem1.GetY()) +
                        this._diem3.GetX() * (this._diem1.GetY() - this._diem2.GetY());
            return result != 0;
        }

        private bool IsEqualLength(decimal numA, decimal numB) => Decimal.Compare(numA, numB) == 0 || Math.Abs(numA - numB) < DELTA;

        private bool IsEquilateralTriangle() => IsEqualLength(GetSide12Length(), GetSide23Length()) && IsEqualLength(GetSide23Length(), GetSide31Length());

        private bool IsIsoscelesTriangle() => IsEqualLength(GetSide12Length(), GetSide23Length()) || 
                                            IsEqualLength(GetSide23Length(), GetSide31Length()) || 
                                            IsEqualLength(GetSide31Length(), GetSide12Length());
        
        private bool IsRightAngledTriangle() => IsEqualLength(DecimalEx.Pow(GetSide12Length(), 2m) + DecimalEx.Pow(GetSide23Length(), 2m), DecimalEx.Pow(GetSide31Length(), 2m)) ||
                                              IsEqualLength(DecimalEx.Pow(GetSide23Length(), 2m) + DecimalEx.Pow(GetSide31Length(), 2m), DecimalEx.Pow(GetSide12Length(), 2m)) ||
                                              IsEqualLength(DecimalEx.Pow(GetSide31Length(), 2m) + DecimalEx.Pow(GetSide12Length(), 2m), DecimalEx.Pow(GetSide23Length(), 2m));

        public decimal FindPerimeter(decimal x1, decimal x2, decimal y1, decimal y2, decimal z1, decimal z2)
        {
            SetNewValue(x1, x2, y1, y2, z1, z2);

            return IsValidTriangle() ?
                GetSide12Length() +
                GetSide23Length() +
                GetSide31Length()
                : -1.0m;
        }

        public string CheckTriangleType(decimal x1, decimal x2, decimal y1, decimal y2, decimal z1, decimal z2)
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
