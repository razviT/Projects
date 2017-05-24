using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace MatchesAlgorithm
{   
     public struct NameAndIndex
    {
        public string name;
        public string index;
        public NameAndIndex(string name,string index)
        {
            this.name = name;
            this.index = index;
        }
    }
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
        public void TestForMatchingIndexes()
        {
            var userNameList = new List<string> { "Razvan Tamas", "Ovidiu Jurje", "Razvan Hidan" };
            var nameAndIndexTest = FindMatchingNamesAndIndexes(userNameList, "RazvTa");
            Assert.AreEqual(nameAndIndexTest[0].index, "0-3,7-8");
            
        }
        [TestMethod]
        public void TestForMatchingNames()
        {
            var userNameList = new List<string> { "Razvan Tamas", "Ovidiu Jurje", "Razvan Hidan" };
            var nameAndIndexTest = FindMatchingNamesAndIndexes(userNameList, "Hid");
            Assert.AreEqual(nameAndIndexTest[0].name, "Razvan Hidan");
        }
       
        List<string> FindUsersNamesWithMatchingLetters(List<string> userNameList, string searchLetters)
        {
            var nameResults = new List<string>();          
            foreach (var userName in userNameList)
            {
                var matchingIndex=new int[searchLetters.Length];
                if (IsMatching(searchLetters, userName,ref matchingIndex))
                    nameResults.Add(userName);
            }
            return nameResults;
        }

        NameAndIndex[] FindMatchingNamesAndIndexes(List<string> userNameList, string searchLetters)
        {
            var nameWithIndex = new NameAndIndex[] { };
            string orderedSequence = string.Empty;
            foreach (var userName in userNameList)
            {
                var matchingIndex = new int[searchLetters.Length];
                if (IsMatching(searchLetters, userName, ref matchingIndex))
                {
                    Array.Resize(ref nameWithIndex, nameWithIndex.Length + 1);
                    nameWithIndex[nameWithIndex.Length-1].name = userName;
                    orderedSequence = OrderSequenceOfIndexes(matchingIndex);
                    nameWithIndex[nameWithIndex.Length-1].index = orderedSequence;
                }
                   
            }
            return nameWithIndex;
        }

        public bool IsMatching(string searchLetters, string text, ref int[] matchingIndex)
        {
            var parts = text.Split(' ');           
            int i = 0;
            int j = 0;
            int differenceBetweenIndexes = 0;
            int partIndex = 0;           
            while (i < searchLetters.Length)
            {
                
                if (searchLetters[i] == parts[partIndex][j])
                {
                    matchingIndex[i] =j + differenceBetweenIndexes;
                    if (i == searchLetters.Length - 1)
                    {                       
                        return true;
                    }                  
                    i++;
                    j++;                  
                }
                else if (partIndex + 1 < parts.Length && i < searchLetters.Length-1)
                {
                    partIndex++;
                    differenceBetweenIndexes += parts[partIndex - 1].Length + partIndex; 
                    j = 0;                  
                }
                else break;
            }
            return false;
        }
        public string OrderSequenceOfIndexes(int[] numbers)
        {
            string orderedSequence = string.Empty;
            int start, end;
            start = end = numbers[0];          
            for(int i = 1; i < numbers.Length; i++)
            {
                if (numbers[i] == numbers[i - 1] + 1) end = numbers[i];
                else
                {
                    if (start == end) orderedSequence += start + ",";
                    else
                    {
                        orderedSequence += start + "-" + end + ",";
                        start = end = numbers[i];
                    }
                }                               
            }
            if (start == end) orderedSequence += start;
            else orderedSequence += start + "-" + end;
            return orderedSequence;
        }

       
    }
}
