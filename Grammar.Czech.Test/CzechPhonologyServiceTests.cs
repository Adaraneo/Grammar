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
        public void Setup()
        {
            service = new CzechPhonologyService();
        }

        #region Softening
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
            Assert.AreEqual("hoš", service.ApplySoftening("hoch"));
        }

        [TestMethod]
        public void RevertSoftening_ShouldHandleShortWords()
        {
            Assert.AreEqual("hoch", service.RevertSoftening("hoš"));
        }

        [TestMethod]
        public void ApplySoftening_ShouldHandleWordsWithSoftenedEnding()
        {
            Assert.AreEqual("koč", service.ApplySoftening("koc"));
            Assert.AreEqual("koš", service.ApplySoftening("koch"));
        }
        #endregion
        #region MobileVowel
        [TestMethod]
        public void HasMobileVowel_ReturnsTrue_ForPes()
        {
            Assert.IsTrue(service.HasMobileVowel("pes"));
        }

        [TestMethod]
        public void HasMobileVowel_ReturnsTrue_ForOtec()
        {
            Assert.IsTrue(service.HasMobileVowel("otec"));
        }

        [TestMethod]
        public void HasMobileVowel_ReturnsTrue_ForDen()
        {
            Assert.IsTrue(service.HasMobileVowel("den"));
        }

        [TestMethod]
        public void HasMobileVowel_ReturnsFalse_ForHrad()
        {
            Assert.IsFalse(service.HasMobileVowel("hrad"));
        }

        [TestMethod]
        public void HasMobileVowel_ReturnsFalse_ForZena()
        {
            Assert.IsFalse(service.HasMobileVowel("žena"));
        }

        [TestMethod]
        public void RemoveMobileVowel_Pes_ReturnsPs()
        {
            Assert.AreEqual("ps", service.RemoveMobileVowel("pes"));
        }

        [TestMethod]
        public void RemoveMobileVowel_Otec_ReturnsOtc()
        {
            Assert.AreEqual("otc", service.RemoveMobileVowel("otec"));
        }

        [TestMethod]
        public void RemoveMobileVowel_Den_ReturnsDn()
        {
            Assert.AreEqual("dn", service.RemoveMobileVowel("den"));
        }

        [TestMethod]
        public void RemoveMobileVowel_NoMobileVowel_ReturnsOriginal()
        {
            Assert.AreEqual("hrad", service.RemoveMobileVowel("hrad"));
        }

        [TestMethod]
        public void InsertMobileVowel_Ps_ReturnsPes()
        {
            Assert.AreEqual("pes", service.InsertMobileVowel("ps", 1));
        }

        [TestMethod]
        public void InsertMobileVowel_Dn_ReturnsDen()
        {
            Assert.AreEqual("den", service.InsertMobileVowel("dn", 1));
        }
        #endregion
    }
}
