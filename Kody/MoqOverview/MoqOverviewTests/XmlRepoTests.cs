using System.Linq;
using MoqOverview.Repo;
using NUnit.Framework;


namespace MoqOverviewTests
{
    [TestFixture]
    public class XmlRepoTests
    {
        private XmlEmployeeRepository m_repo;


        [SetUp]
        public void SetUp()
        {
            m_repo = new XmlEmployeeRepository ();
        }

        [Test]
        public void AllResultsTest()
        {
            var result = m_repo.GetEmployees ();
            Assert.AreEqual (2, result.Count());
        }


    }
}