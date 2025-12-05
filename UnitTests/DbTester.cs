using AutoEBookBuilder;
using NUnit.Framework;
using NUnit.Framework.Legacy;
using System.Data.SQLite;
using System.Linq;

namespace AutoEBookBuilder.UnitTests
{
    [TestFixture]
    internal class DbTester
    {
        private const string TEST = "test";
        [Test]
        public void DatabaseWriteTestMethod()
        {
            DbLoader.write(TEST, TEST);
        }
        [Test]
        public void DatabaseReadTestMethod()
        {
            DatabaseWriteTestMethod();
            var list = DbLoader.getAll(TEST);
            Assert.That(list.Count, Is.EqualTo(1));
            Assert.That(list.First(), Is.EqualTo(TEST));
        }
        [Test]
        public void DatabaseDeleteTestMethod()
        {
            DbLoader.write(TEST, TEST);
            DbLoader.delete(TEST);
            var list = DbLoader.getAll(TEST);
            Assert.That(list.Count, Is.EqualTo(0));
        }
    }
}
