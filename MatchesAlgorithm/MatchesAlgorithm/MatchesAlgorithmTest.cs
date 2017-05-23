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
            CollectionAssert.AreEqual(new[] { "Ovidiu Jurje" }, FindUserNamesWithMatchingLetters(userNameList, "O"));
        }
       
        [TestMethod]
        public void FirstTwoLettersOfFirstNameTest()
        {
            var userNameList = new List<string> { "Razvan Tamas", "Ovidiu Jurje", "Razvan Hidan" };
            CollectionAssert.AreEqual(new[] { "Razvan Tamas","Razvan Hidan" },FindUserNamesWithMatchingLetters(userNameList,"Ra"));
        }
        [TestMethod]
        public void LettersFromBothNamesTest()
        {
            var userNameList = new List<string> { "Razvan Tamas", "Ovidiu Jurje", "Razvan Hidan" };
            CollectionAssert.AreEqual(new[] { "Razvan Hidan" }, FindUserNamesWithMatchingLetters(userNameList, "RaHid"));
        }
        [TestMethod]
        public void TestIfNoLettersMatch()
        {
            var userNameList = new List<string> { "Razvan Tamas", "Ovidiu Jurje", "Razvan Hidan" };           
            CollectionAssert.AreEqual(new List<string>(), FindUserNamesWithMatchingLetters(userNameList, "PoTo"));
        }
        [TestMethod]
        public void TestIfOnlyFewLettersMatch()
        {
            var userNameList = new List<string> { "Razvan Tamas", "Ovidiu Jurje", "Razvan Hidan" };
            CollectionAssert.AreEqual(new List<string>(), FindUserNamesWithMatchingLetters(userNameList, "RaJu"));
        }
        [TestMethod]
        public void TestIfAllLettersAreMatchedInTheSecondName()
        {
            var userNameList = new List<string> { "Razvan Tamas", "Ovidiu Jurje", "Razvan Hidan" };
            CollectionAssert.AreEqual(new[] { "Ovidiu Jurje" }, FindUserNamesWithMatchingLetters(userNameList, "Ju"));
        }
       
        List<string> FindUserNamesWithMatchingLetters(List<string> userNameList, string searchLetters)
        {
            var nameResults = new List<string>();
            foreach (var userName in userNameList)
            {

                GoThroughUsers(searchLetters, nameResults, userName);
            }
            return nameResults;
        }

        public void GoThroughUsers(string searchLetters, List<string> results, string userName)
        {
            var userNamesInArray=userName.Split(' ');
            
            int i = 0;
            int j = 0;
            int nameNumber = 0;
            while (i < searchLetters.Length)
            {
                if (searchLetters[i] == userNamesInArray[nameNumber][j])
                {
                    if (i == searchLetters.Length - 1) results.Add(userName);
                    i++;
                    j++;
                }
                else if (nameNumber + 1 < userNamesInArray.Length)
                {
                    nameNumber++;
                    j = 0;
                }
                else break;
            }
        }

       
    }
}
