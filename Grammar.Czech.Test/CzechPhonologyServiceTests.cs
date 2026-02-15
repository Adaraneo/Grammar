using Grammar.Czech.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grammar.Czech.Test
{
    [TestClass]
    public class CzechPhonologyServiceTests
    {
        private CzechPhonologyService service;
        [TestInitialize]
        public void Init()
        {
            service = new CzechPhonologyService();
        }

        [TestMethod]
        public void ApplySoftening_ShouldSoftened()
        {
            Assert.AreEqual("č", service.ApplySoftening("c"));
            Assert.AreEqual("š", service.ApplySoftening("ch"));
            Assert.AreEqual("z", service.ApplySoftening("h"));
            Assert.AreEqual("ď", service.ApplySoftening("d"));
            Assert.AreEqual("ť", service.ApplySoftening("t"));
            Assert.AreEqual("ň", service.ApplySoftening("n"));
        }

        [TestMethod]
        public void RevertSoftening_ShouldRevert()
        {
            Assert.AreEqual("c", service.RevertSoftening("č"));
            Assert.AreEqual("ch", service.RevertSoftening("š"));
            Assert.AreEqual("h", service.RevertSoftening("z"));
            Assert.AreEqual("d", service.RevertSoftening("ď"));
            Assert.AreEqual("t", service.RevertSoftening("ť"));
            Assert.AreEqual("n", service.RevertSoftening("ň"));
        }

        [TestMethod]
        public void ApplySoftening_ShouldNotChange()
        {
            Assert.AreEqual("a", service.ApplySoftening("a"));
            Assert.AreEqual("b", service.ApplySoftening("b"));
            Assert.AreEqual("e", service.ApplySoftening("e"));
        }

        [TestMethod]
        public void RevertSoftening_ShouldNotChange()
        {
            Assert.AreEqual("a", service.RevertSoftening("a"));
            Assert.AreEqual("b", service.RevertSoftening("b"));
            Assert.AreEqual("e", service.RevertSoftening("e"));
        }

        [TestMethod]
        public void ApplySoftening_ShouldHandleShortWords()
        {
            Assert.AreEqual("č", service.ApplySoftening("c"));
            Assert.AreEqual("š", service.ApplySoftening("ch"));
        }

        [TestMethod]
        public void RevertSoftening_ShouldHandleShortWords()
        {
            Assert.AreEqual("c", service.RevertSoftening("č"));
            Assert.AreEqual("ch", service.RevertSoftening("š"));
        }

        [TestMethod]
        public void ApplySoftening_ShouldHandleWordsWithSoftenedEnding()
        {
            Assert.AreEqual("koč", service.ApplySoftening("koc"));
            Assert.AreEqual("koš", service.ApplySoftening("koch"));
        }
    }
}
