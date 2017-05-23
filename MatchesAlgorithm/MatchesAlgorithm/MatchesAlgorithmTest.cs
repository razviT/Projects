using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace MatchesAlgorithm
{
    [TestClass]
    public class MatchesAlgorithmTest
    {
        [TestMethod]
        public void FirstLetterTest()
        {
            List<string> UserNameList = new List<string>();
            UserNameList.Add("Razvan Tamas");
            UserNameList.Add("Jurje Ovidiu");
            UserNameList.Add("Razvan Hidan");
            Assert.AreEqual("Ovidiu Jurje", UserNameMatches(UserNameList, "O"));
        }

        List<string> UserNameMatches(List<string> userNameList, string searchLetters)
        {
            return new List<string>();
        }
    }
}
