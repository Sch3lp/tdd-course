using bugfix_livedemo_impl;
using NUnit.Framework;
using System;

namespace bugfix_livedemo
{
    [TestFixture]
    public class PeriodTests
    {
        [Test]
        public void IsInPeriod_InPeriode_True()
        {
            var period = new Period(new DateTime(2016, 10, 10), new DateTime(2016, 10, 20));
            Assert.That(period.IsInPeriod(new DateTime(2016, 10, 15)), Is.True);
        }

        [Test]
        public void IsInPeriod_LaterDanPeriod_False()
        {
            var period = new Period(new DateTime(2016, 10, 10), new DateTime(2016, 10, 20));
            Assert.That(period.IsInPeriod(new DateTime(2016, 10, 30)), Is.False);
        }

        [Test]
        public void IsInPeriod_VroegerDanPeriode_False()
        {
            var period = new Period(new DateTime(2016, 10, 10), new DateTime(2016, 10, 20));
            Assert.That(period.IsInPeriod(new DateTime(2016, 10, 1)), Is.False);
        }
    }
}