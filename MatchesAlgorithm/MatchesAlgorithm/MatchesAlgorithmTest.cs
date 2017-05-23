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
            var userNameList = new List<string> { "Razvan Tamas", "Ovidiu Jurje", "Razvan Hidan" };
            CollectionAssert.AreEqual(new[] { "Ovidiu Jurje" }, UserNameMatches(userNameList, "O"));
        }

        List<string> UserNameMatches(List<string> userNameList, string searchLetters)
        {
            var nameResults = new List<string>();
            foreach (var userName in userNameList)
            {
                if (userName[0] == searchLetters[0]) nameResults.Add(userName);
            }
            return nameResults;
        }
    }
}
