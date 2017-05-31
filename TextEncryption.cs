using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TextEncription
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            Assert.AreEqual(EncryptText("Ceva text",3),"Caee xvtt");
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
                encryptedText += text[j + columns];
                j += columns;
            }
            return encryptedText;
        }
    }

}
