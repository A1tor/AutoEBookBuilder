using Microsoft.Office.Interop.Word;
using NUnit.Framework;
using NUnit.Framework.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoEBookBuilder.UnitTests
{
    [TestFixture]
    internal class ApiTester
    {
        [Test]
        public void ApiReadTestMethod()
        {
            var list = DbLoader.getAll("apis");
            var set = new HashSet<string>(list);
            var map = ApiLoader.Load(list);
            Assert.That(map.Keys.Contains("fb2"), Is.EqualTo(true));
            Assert.That(map.Keys.Count, Is.EqualTo(list.Count));
        }
        [Test]
        public void ApiParseTestMethod()
        {
            var list = DbLoader.getAll("apis");
            var map = ApiLoader.Load(list);
            foreach (var api in map.Values)
                api.GetMethod("parseToType").Invoke(null, new string[] { "test", "test"});
            Assert.That(map.Keys.Contains("fb2"), Is.EqualTo(true));
            Assert.That(map.Keys.Count, Is.EqualTo(list.Count));
        }
    }
}
