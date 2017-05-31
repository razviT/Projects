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
            Assert.AreEqual(EncryptText("Ceva text",3),"Caee xvtt");
        }
        [TestMethod]
        public void TestEncryptionTwo()
        {
            Assert.AreEqual(EncryptText("123456", 5), "162345");
        }
        [TestMethod]
        public void TestEncryptionThree()
        {
            Assert.AreEqual(EncryptText("encrypt this text for me", 4), "eyt trnpht  ctiefmr sxoe");
        }
        [TestMethod]
        public void TestDecryption()
        {
            Assert.AreEqual(EncryptText("Caee xvtt",3),"Ceva text");
        }

        string EncryptText(string text,int columns)
        {
            var encryptedText = string.Empty;           
            for (int i = 0; i < columns; i++)
            {
                encryptedText = EncryptForEachColumn(text, columns, encryptedText, i);
            }
            return encryptedText;
        }

        private static string EncryptForEachColumn(string text, int columns, string encryptedText, int i)
        {
            int j = i;
            encryptedText += text[i];
            while (j < text.Length - columns)
            {
                j += columns;
                encryptedText += text[j];                
            }
            return encryptedText;
        }
    }

}
