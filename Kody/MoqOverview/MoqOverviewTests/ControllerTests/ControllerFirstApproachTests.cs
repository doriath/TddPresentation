using MoqOverview;
using MoqOverviewTests.FakeClasses;
using NUnit.Framework;
using System.Linq;

namespace MoqOverviewTests
{
    [TestFixture]
    public class ControllerFirstApproachTests
    {
        private Controller m_controller;

        [SetUp]
        public void SetUp()
        {
            //initializing controller....
            //m_controller = new Controller (...what the heck should be here...?)

            //approach 1. create "fake" class implementing IEmployeeRepository
            this.m_controller = new Controller(new FakeEmployeeRepository());
            // a gdzie tu czytelnoœæ? Osoba, która potem ogl¹da takie testy, nie wie co siê dzieje!
        }

        [Test]
        public void WritingUsersTest()
        {
            string[] result = this.m_controller.ShowUsers().ToArray();

            Assert.AreEqual("Mój: 2000,00z³", result[0]);
            Assert.AreEqual(1, result.Length);
        }
    }
}