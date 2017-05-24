using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace MatchesAlgorithm
{
    public struct Index
    {
        public int start;
        public int end;
        public Index(int start, int end)
        {
            this.start = start;
            this.end = end;
        }
    }
    public struct NameAndIndex
    {
        public string name;
        public Index[] index;
        public NameAndIndex(string name,Index[] index)
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
            Assert.AreEqual(nameAndIndexTest[0].index[0].end, 3);
            
        }
        [TestMethod]
        public void TestForMatchingNames()
        {
            var userNameList = new List<string> { "Razvan Tamas", "Ovidiu Jurje", "Razvan Hidan" };
            var nameAndIndexTest = FindMatchingNamesAndIndexes(userNameList, "Hid");
            Assert.AreEqual(nameAndIndexTest[0].name, "Razvan Hidan");
        }
        [TestMethod]
        public void TestForMatchingIndexesTwo()
        {
            var userNameList = new List<string> { "Razvan Tamas", "Ovidiu Jurje", "Razvan Hidan" };
            var nameAndIndexTest = FindMatchingNamesAndIndexes(userNameList, "RazTa");
            Assert.AreEqual(nameAndIndexTest[0].index[1].start, 7);
        }
        [TestMethod]
        public void TestForMatchingIndexesThree()
        {
            var userNameList = new List<string> { "Razvan Tamas", "Ovidiu Jurje", "Razvan Hidan" };
            var nameAndIndexTest = FindMatchingNamesAndIndexes(userNameList, "RT");
            Assert.AreEqual(nameAndIndexTest[0].index[1].end, 7);
        }
        [TestMethod]
        public void TestForMatchingIndexesFour()
        {
            var userNameList = new List<string> { "Razvan Tamas", "Ovidiu Jurje", "Razvan Hidan" };
            var nameAndIndexTest = FindMatchingNamesAndIndexes(userNameList, "O");
            Assert.AreEqual(nameAndIndexTest[0].index[0].start, 0);
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
                    nameWithIndex[nameWithIndex.Length - 1].name = userName;
                    nameWithIndex[nameWithIndex.Length - 1].index = PutIndexesInSequences(matchingIndex);
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
                else if (partIndex + 1 < parts.Length && i <= searchLetters.Length-1)
                {
                    partIndex++;
                    differenceBetweenIndexes += parts[partIndex - 1].Length + partIndex; 
                    j = 0;                  
                }
                else break;
            }
            return false;
        }
        Index[] PutIndexesInSequences(int[] indexes)
        {
            var sequence = new Index[1];
            int j = 0;
            sequence[0].start = indexes[0];
            if (indexes.Length == 1)
                sequence[0].end = sequence[0].start;
            for (int i = 1; i < indexes.Length; i++)
            {
                if (indexes[i] - indexes[i - 1] == 1)
                {
                    sequence[j].end = indexes[i];
                }
                else
                {
                    j++;
                    Array.Resize(ref sequence, sequence.Length + 1);
                    sequence[j].start = indexes[i];
                    sequence[j].end = indexes[i];
                }
            }
            return sequence;
        }
        

       
    }
}
