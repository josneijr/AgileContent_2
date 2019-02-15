using NUnit.Framework;
using System;
using AgileContent1;

namespace AgileContent1_Test
{
    [TestFixture()]
    public class Test
    {
        [Test()]
        public void TestCase_321()
        {
            Solution solution = new Solution();

            Assert.AreEqual(321, solution.solution(123));
        }

        [Test()]
        public void TestCase_56998123()
        {
            Solution solution = new Solution();

            Assert.AreEqual(99865321, solution.solution(56998123));
        }

        [Test()]
        public void TestCase_9999999999()
        {
            Solution solution = new Solution();

            Assert.AreEqual(-1, solution.solution(999999999));
        }
    }
}
