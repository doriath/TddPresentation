using System.Text.RegularExpressions;
using MbUnit.Framework;

namespace TemplateProject.Tests
{
    [TestFixture]
    public class RegexLearningTests
    {
        [Test]
        public void TestReplace()
        {
            Regex regex = new Regex(@"test");
            string template = "asdf test fdsa test";
            Match match = regex.Match(template);
            Assert.AreEqual(5, match.Index);
            match = match.NextMatch();
            Assert.AreEqual(15, match.Index);
        }
    }
}