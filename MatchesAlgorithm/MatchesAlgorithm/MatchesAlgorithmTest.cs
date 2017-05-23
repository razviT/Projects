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
            CollectionAssert.AreEqual(new[] { "Ovidiu Jurje" }, FindUsersNamesWithMatchingLetters(userNameList, "O"));
        }
       
        [TestMethod]
        public void FirstTwoLettersOfFirstNameTest()
        {
            var userNameList = new List<string> { "Razvan Tamas", "Ovidiu Jurje", "Razvan Hidan" };
            CollectionAssert.AreEqual(new[] { "Razvan Tamas","Razvan Hidan" },FindUsersNamesWithMatchingLetters(userNameList,"Ra"));
        }
        [TestMethod]
        public void LettersFromBothNamesTest()
        {
            var userNameList = new List<string> { "Razvan Tamas", "Ovidiu Jurje", "Razvan Hidan" };
            CollectionAssert.AreEqual(new[] { "Razvan Hidan" }, FindUsersNamesWithMatchingLetters(userNameList, "RaHid"));
        }
        [TestMethod]
        public void TestIfNoLettersMatch()
        {
            var userNameList = new List<string> { "Razvan Tamas", "Ovidiu Jurje", "Razvan Hidan" };           
            CollectionAssert.AreEqual(new List<string>(), FindUsersNamesWithMatchingLetters(userNameList, "PoTo"));
        }
        [TestMethod]
        public void TestIfOnlyFewLettersMatch()
        {
            var userNameList = new List<string> { "Razvan Tamas", "Ovidiu Jurje", "Razvan Hidan" };
            CollectionAssert.AreEqual(new List<string>(), FindUsersNamesWithMatchingLetters(userNameList, "RaJu"));
        }
        [TestMethod]
        public void TestIfAllLettersAreMatchedInTheSecondName()
        {
            var userNameList = new List<string> { "Razvan Tamas", "Ovidiu Jurje", "Razvan Hidan" };
            CollectionAssert.AreEqual(new[] { "Ovidiu Jurje" }, FindUsersNamesWithMatchingLetters(userNameList, "Ju"));
        }
        [TestMethod]
        public void TestFor()
        {

        }
       
        List<string> FindUsersNamesWithMatchingLetters(List<string> userNameList, string searchLetters)
        {
            var nameResults = new List<string>();
            foreach (var userName in userNameList)
            {
                if (IsMatching(searchLetters, userName))
                    nameResults.Add(userName);
            }
            return nameResults;
        }

        public bool IsMatching(string searchLetters, string text)
        {
            var parts = text.Split(' ');           
            int i = 0;
            int j = 0;
            int partIndex = 0;
            while (i < searchLetters.Length)
            {
                if (searchLetters[i] == parts[partIndex][j])
                {
                    if (i == searchLetters.Length - 1)
                    {
                        return true;
                    }                    
                    i++;
                    j++;
                }
                else if (partIndex + 1 < parts.Length)
                {
                    partIndex++;
                    j = 0;                  
                }
                else break;
            }
            return false;
        }

       
    }
}
