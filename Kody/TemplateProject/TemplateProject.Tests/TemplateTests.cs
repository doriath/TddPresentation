using MbUnit.Framework;

namespace TemplateProject.Tests
{
    [TestFixture]
    public class TemplateTests
    {
        [Test]
        [Row("Reader", "Hello, Reader")]
        [Row("Me", "Hello, Me")]
        public void TestOneVariable(string name, string evaluated)
        {
            Template template = new Template("Hello, ${name}");
            template.Set("name", name);
            Assert.AreEqual(evaluated, template.Evaluate());
        }

        [Test]
        public void TestDifferentTemplate()
        {
            Template template = new Template("Hi, ${name}");
            template.Set("name", "Tom");
            Assert.AreEqual("Hi, Tom", template.Evaluate());
        }

        [Test]
        public void TestMultipleVariables()
        {
            Template template = new Template("${one}, ${two}, ${three}");
            template.Set("one", "1");
            template.Set("two", "2");
            template.Set("three", "3");
            Assert.AreEqual("1, 2, 3", template.Evaluate());
        }

        [Test]
        public void TestUnknownVariablesAreIgnored()
        {
            Template template = new Template("Hello, ${name}");
            template.Set("unknown", "Hi");
            template.Set("name", "Tom");
            Assert.AreEqual("Hello, Tom", template.Evaluate());
        }

        [Test]
        [Row("Hello, ${name}", "No value for ${name}")]
        [Row("Hello, ${one}, ${second}", "No value for ${one}")]
        public void MissingValueRaisesException(string templateText, string expectedMessage)
        {
            Template template = new Template(templateText);
            var e = Assert.Throws<MissingValueException>(() => template.Evaluate());
            Assert.AreEqual(expectedMessage, e.Message);
        }

        [Test]
        public void VariablesAreProcessedOnce()
        {
            Template template = new Template("${one}, ${two}, ${three}");
            template.Set("one", "${one}");
            template.Set("two", "${two}");
            template.Set("three", "${three}");
            Assert.AreEqual("${one}, ${two}, ${three}", template.Evaluate());
        }
    }
}