using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TextEncription
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestEncryptionOne()
        {
            Assert.AreEqual(EncryptText("Ceva text", 3), "Caee xvtt");
        }
        [TestMethod]
        public void TestEncryptionTwo()
        {
            Assert.AreEqual(EncryptText("1234567", 4), "1526374");
        }
        [TestMethod]
        public void TestEncryptionThree()
        {
            Assert.AreEqual(EncryptText("encrypt this text for me", 4), "eyt trnpht  ctiefmr sxoe");
        }
        [TestMethod]
        public void TestDecryption()
        {
            Assert.AreEqual(DecryptText("Caee xvtt", 3), "Ceva text");
        }
        [TestMethod]
        public void TestDecryptionTwo()
        {
            Assert.AreEqual(DecryptText("eyt trnpht  ctiefmr sxoe", 4), "encrypt this text for me");
        }
        [TestMethod]
        public void TestDectryptionThree()
        {
            Assert.AreEqual(DecryptText("1526374", 4), "1234567");
        }
        string EncryptText(string text, int columns)
        {
            var encryptedText = string.Empty;
            for (int i = 0; i < columns; i++)
            {
                encryptedText += EncryptForColumn(text, columns, i);
            }
            return encryptedText;
        }

        private static string EncryptForColumn(string text, int columns, int currentColumn)
        {
            var encryptedText = "";
            for (int j = currentColumn; j < text.Length; j += columns)
            {
                encryptedText += text[j];
            }
            return encryptedText;
        }
        string DecryptText(string text, int columns)
        {
            columns = (int)Math.Ceiling((double)text.Length / columns);
            return EncryptText(text, columns);
        }
    }

}
