using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EncryptWordTester
{
    [TestClass]
    public class getEncryptWordTester
    {
        [TestMethod]
        public void TestSetWord()
        {
            EncryptWord ew = new EncryptWord(5);
            ew.setEncryptedWord("Tester");
            Assert.AreEqual("Yjxyjw", ew.getEncryptedWord());
        }

        [TestMethod]
        public void testConstructorString()
        {
            EncryptWord ew = new EncryptWord("Tester", 5);
            Assert.AreEqual("Yjxyjw", ew.getEncryptedWord());
        }

        [TestMethod]
        public void testConstructorInt()
        {
            EncryptWord ew = new EncryptWord(2);
            ew.setEncryptedWord("Oliver");
            Assert.AreEqual("Qnkxgt", ew.getEncryptedWord());
        }

        [TestMethod]
        public void testGuess()
        {
            EncryptWord ew = new EncryptWord(9);
            Assert.AreEqual(true, ew.guessCipherValue(9));
        }

        [TestMethod]
        public void testGuess2()
        {
            EncryptWord ew = new EncryptWord(8);
            Assert.AreEqual(false, ew.guessCipherValue(9));
        }

        [TestMethod]
        public void testGuessTotal()
        {
            EncryptWord ew = new EncryptWord(10);
            ew.guessCipherValue(1);
            ew.guessCipherValue(2);
            ew.guessCipherValue(3);
            ew.guessCipherValue(4);
            ew.guessCipherValue(5);
            ew.guessCipherValue(6);
            ew.guessCipherValue(7);
            ew.guessCipherValue(8);
            ew.guessCipherValue(9);
            ew.guessCipherValue(10);
            Assert.AreEqual(10, ew.getTotalGuesses());
        }

    }
}
