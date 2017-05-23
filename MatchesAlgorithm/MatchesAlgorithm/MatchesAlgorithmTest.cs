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
       
        [TestMethod]
        public void FirstTwoLettersOfFirstNameTest()
        {
            var userNameList = new List<string> { "Razvan Tamas", "Ovidiu Jurje", "Razvan Hidan" };
            CollectionAssert.AreEqual(new[] { "Razvan Tamas", "Razvan Hidan" },UserNameMatches(userNameList,"Ra"));
        }

        List<string> UserNameMatches(List<string> userNameList, string searchLetters)
        {
            var nameResults = new List<string>();
            foreach (var userName in userNameList)
            {
                MatchLettersInName(searchLetters, nameResults, userName);
            }
            return nameResults;
        }

        private static void MatchLettersInName(string searchLetters, List<string> nameResults, string userName)
        {
            int i = 0;
            while (i < searchLetters.Length)
            {
                if (searchLetters[i] == userName[i])
                {
                    if (i == searchLetters.Length - 1) nameResults.Add(userName);
                    i++;
                }
                else break;
            }
        }
    }
}
