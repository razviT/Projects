using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace MatchesAlgorithm
{
    public struct Index
    {
        public int start;
        public int end;
        public Index(int index)
            : this(index, index)
        {
        }

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
        [TestMethod]
        public void TestForMatchingIndexesFive()
        {
            var userNameList = new List<string> { "Razvan Tamas", "Ovidiu Jurje", "Razvan Hidan" };
            var nameAndIndexTest = FindMatchingNamesAndIndexes(userNameList, "RT");
            CollectionAssert.AreEqual(nameAndIndexTest[0].index, new Index[] { new Index(0, 0), new Index(7, 7) });
        }
        [TestMethod]
        public void TestForMatchingIndexesSix()
        {
            var userNameList = new List<string> { "Razvan Tamas", "Ovidiu Jurje", "Razvan Hidan" };
            var nameAndIndexTest = FindMatchingNamesAndIndexes(userNameList, "OviJu");
            CollectionAssert.AreEqual(nameAndIndexTest[0].index, new Index[] { new Index(0, 2), new Index(7, 8) });
        }      
        [TestMethod]
        public void TestForMatchingIndexesSeven()
        {
            var userNameList = new List<string> { "Razvan Tamas", "Ovidiu Jurje", "Razvan Hidan" };
            var nameAndIndexTest = FindMatchingNamesAndIndexes(userNameList, "J");
            Assert.AreEqual(nameAndIndexTest[0].index[0].start, 7);
        }
        [TestMethod]
        public void TestForMatchingIndexesEight()
        {
            var userNameList = new List<string> { "Razvan Tamas", "Ovidiu Jurje", "Razvan Hidan" };
            var nameAndIndexTest = FindMatchingNamesAndIndexes(userNameList, "R");
            CollectionAssert.AreEqual(nameAndIndexTest[1].index, new Index[] { new Index(0, 0) });
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
                    nameWithIndex[nameWithIndex.Length - 1].index = PutNumbersInSequences(matchingIndex);
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
        Index[] PutNumbersInSequences(int[] numbers)
        {
            var sequence = new Index[1];
            int j = 0;
            sequence[0].start = numbers[0];
            if (numbers.Length == 1)
                sequence[0].end = sequence[0].start;
            for (int i = 1; i < numbers.Length; i++)
            {
                if (numbers[i] - numbers[i - 1] == 1)
                {
                    sequence[j].end = numbers[i];
                }
                else
                {
                    j++;
                    Array.Resize(ref sequence, sequence.Length + 1);                   
                    sequence[j] = new Index(numbers[i]);
                }
            }
            return sequence;
        }
              
    }
}
