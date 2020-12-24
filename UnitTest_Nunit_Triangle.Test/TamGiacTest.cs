using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DecimalMath;
using NUnit.Framework;

namespace UnitTest_Nunit_Triangle.Test
{
    [TestFixture]
    public class TamGiacTest
    {
        private TamGiac _tamgiac;

        [SetUp]
        public void SetUp()
        {
            _tamgiac = new TamGiac();
        }

        public static IEnumerable<object[]> Data1 =>
            new List<object[]>
            {
                new object[] { "Không phải tam giác", 0m, 0m, 0m, 0m, 0m, 0m },
                new object[] { "Tam giác thường", 0m, 6m, 0m, 10m, 4m, 0m },
                new object[] { "Tam giác cân", 0m, 0m, 2m, 3m, 4m, 0m },
                new object[] { "Tam giác vuông", 0m, 0m, 0m, 3m, 2m, 0m },
                new object[] { "Tam giác vuông cân", 0m, 0m, 0m, 2m, 2m, 0m },
                new object[] { "Tam giác vuông cân", 0m, 0m, 0m, 9999999999m, 9999999999m, 0m },
                new object[] { "Tam giác vuông cân", 0m, 0m, 0m, -9999999999m, -9999999999m, 0m },
                new object[] { "Tam giác đều", 0m, 0m, 0.5m, 0m, 0.25m, 0.25m * DecimalEx.Sqrt(3m) }
            };

        public static IEnumerable<object[]> Data2 =>
            new List<object[]>
            {
                new object[] { 4m + 2m * DecimalEx.Sqrt(2m), 0m, 0m, 0m, 2m, 2m, 0m },
                new object[] { -1.0m, 0m, 0m, 0m, 0m, 0m, 0m },
                new object[] { -1.0m, 0m, 0m, 0m, 2m, 0m, 3m }
            };

        public static IEnumerable<object[]> Data3 =>
            new List<object[]>
            {
                new object[] { "Không phải tam giác", 0m, 0m, 2m, 2m, 0m, 4m },
                new object[] { "Tam giác thường", 0m, 0m, 0m, 0m, 0m, 0m },
                new object[] { "Tam giác cân", 0m, 0m, 0.5m, 0m, 0.25m, 0.25m * DecimalEx.Sqrt(3m) },
                new object[] { "Tam giác vuông", 5m, 5m, 0m, 3m, 2m, 0m },
                new object[] { "Tam giác vuông cân", 0m, 0m, 0m, 3m, 2m, 1m },
                new object[] { "Tam giác đều", 0m, 0m, 2m, 3m, 4m, 0m }
            };

        public static IEnumerable<object[]> Data4 =>
            new List<object[]>
            {
                new object[] { 8m, 0m, 0m, 0m, 3m, 3m, 1m },
                new object[] { 0m, 0m, 0m, 0m, 0m, 0m, 0m }
            };

        //__________Test for Expected Results__________  

        // Test Case #1:
        [Test]
        public void IsInstance()
            => Assert.IsInstanceOf(typeof(TamGiac), _tamgiac);

        // Test Case #2 - #7:
        [Test]
        [TestCaseSource(nameof(Data1))]
        public void CheckTriangleType_ReturnsExpectedResult(string expectedResult, decimal x1, decimal y1, decimal x2, decimal y2, decimal x3, decimal y3)
            => Assert.AreEqual(expectedResult, _tamgiac.CheckTriangleType(x1, y1, x2, y2, x3, y3));

        // Test Case #8 - #10:
        [Test]
        [TestCaseSource(nameof(Data2))]
        public void CheckPerimeter_ReturnExpectedResult(decimal expectedResult, decimal x1, decimal y1, decimal x2, decimal y2, decimal x3, decimal y3)
            => Assert.IsTrue(Decimal.Compare(_tamgiac.FindPerimeter(x1, y1, x2, y2, x3, y3), expectedResult) == 0);

        //__________Test for Actual Results__________  

        // Test Case #11 - #16:
        [Test]
        [TestCaseSource(nameof(Data3))]
        public void CheckTriangleType_ReturnsActualResult(string expectedResult, decimal x1, decimal y1, decimal x2, decimal y2, decimal x3, decimal y3)
            => Assert.AreNotEqual(expectedResult, _tamgiac.CheckTriangleType(x1, y1, x2, y2, x3, y3));

        // Test Case #17 - #18:
        [Test]
        [TestCaseSource(nameof(Data4))]
        public void CheckPerimeter_ReturnActualResult(decimal expectedResult, decimal x1, decimal y1, decimal x2, decimal y2, decimal x3, decimal y3)
            => Assert.IsFalse(Decimal.Compare(_tamgiac.FindPerimeter(x1, y1, x2, y2, x3, y3), expectedResult) == 0);
    }
}
