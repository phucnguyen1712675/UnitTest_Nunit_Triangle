using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace UnitTest_Nunit_Triangle.Test
{
    [TestFixture]
    public class DiemTest
    {
        private Diem _diem;

        [SetUp]
        public void SetUp()
        {
            _diem = new Diem();
        }

        [Test]
        public void IsInstance()
        {
            Assert.IsInstanceOf(typeof(Diem), _diem);
        }
    }
}
