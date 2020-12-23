using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace UnitTest_Nunit_Triangle.Test
{
    [TestFixture]
    public class TamGiacTest
    {
        private const double DELTA = 0.00001;
        private TamGiac _tamgiac;

        [SetUp]
        public void SetUp()
        {
            _tamgiac = new TamGiac();
        }

        //__________Test for Expected Results__________  

        // Test Case #1:
        [Test]
        public void IsInstance()
            => Assert.IsInstanceOf(typeof(TamGiac), _tamgiac);

        // Test Case #2 - #7:
        [TestCase("Không phải tam giác", 0, 0, 0, 2, 0, 4)]
        [TestCase("Tam giác thường", 0, 6, 0, 10, 4, 0)]
        [TestCase("Tam giác cân", 0, 0, 2, 3, 4, 0)]
        [TestCase("Tam giác vuông", 0, 0, 0, 3, 2, 0)]
        [TestCase("Tam giác vuông cân", 0, 0, 0, 2, 2, 0)]
        [TestCase("Tam giác đều", 0, 0, 0.5, 0, 0.25, 0.43301270189)]
        public void CheckTriangleType_ReturnsExpectedResult(string expectedResult, double x1, double y1, double x2, double y2, double x3, double y3)
            => Assert.AreEqual(expectedResult, _tamgiac.CheckTriangleType(x1, y1, x2, y2, x3, y3));

        // Test Case #8 - #10:
        [TestCase(6.82842712475, 0, 0, 0, 2, 2, 0)]
        [TestCase(-1.0, 0, 0, 0, 0, 0, 0)]
        [TestCase(-1.0, 0, 0, 0, 2, 0, 3)]
        public void CheckPerimeter_ReturnExpectedResult(double expectedResult, double x1, double y1, double x2, double y2, double x3, double y3)
            => Assert.IsTrue(Math.Abs(_tamgiac.FindPerimeter(x1, y1, x2, y2, x3, y3) - expectedResult) < DELTA);

        //__________Test for Actual Results__________  

        // Test Case #11 - #16:
        [TestCase("Không phải tam giác", 0, 0, 2, 2, 0, 4)]
        [TestCase("Tam giác thường", 0, 0, 0, 0, 0, 0)]
        [TestCase("Tam giác cân", 0, 0, 0.5, 0, 0.25, 0.43301270189)]
        [TestCase("Tam giác vuông", 5, 5, 0, 3, 2, 0)]
        [TestCase("Tam giác vuông cân", 0, 0, 0, 3, 2, 1)]
        [TestCase("Tam giác đều", 0, 0, 2, 3, 4, 0)]
        public void CheckTriangleType_ReturnsActualResult(string expectedResult, double x1, double y1, double x2, double y2, double x3, double y3)
            => Assert.AreNotEqual(expectedResult, _tamgiac.CheckTriangleType(x1, y1, x2, y2, x3, y3));

        // Test Case #17 - #18:
        [TestCase(8, 0, 0, 0, 3, 3, 1)]
        [TestCase(0, 0, 0, 0, 0, 0, 0)]
        public void CheckPerimeter_ReturnActualResult(double expectedResult, double x1, double y1, double x2, double y2, double x3, double y3)
            => Assert.IsFalse(Math.Abs(_tamgiac.FindPerimeter(x1, y1, x2, y2, x3, y3) - expectedResult) < DELTA);
    }
}
