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
        public void TestForMatchingIndexes()
        {
            var userNameList = new List<string> { "Razvan Tamas", "Ovidiu Jurje", "Razvan Hidan" };
            var nameAndIndexTest = FindMatchingNamesAndIndexesUsingCommonPrefixes(userNameList, "RazvTa");
            Assert.AreEqual(nameAndIndexTest[0].index[0].end, 3);

        }
        [TestMethod]
        public void TestForMatchigLettersUsingPrefixesThree()
        {
            var userNameList = new List<string> { "Razvan Tamas", "Ovidiu Jurje", "Razvan Hidan" };
            var nameAndIndexTest = FindMatchingNamesAndIndexesUsingCommonPrefixes(userNameList, "Hid");
            Assert.AreEqual(nameAndIndexTest[0].name, "Razvan Hidan");
        }
        [TestMethod]
        public void TestForMatchingIndexesTwo()
        {
            var userNameList = new List<string> { "Razvan Tamas", "Ovidiu Jurje", "Razvan Hidan" };
            var nameAndIndexTest = FindMatchingNamesAndIndexesUsingCommonPrefixes(userNameList, "RazTa");
            Assert.AreEqual(nameAndIndexTest[0].index[1].start, 7);
        }
        [TestMethod]
        public void TestForMatchingIndexesThree()
        {
            var userNameList = new List<string> { "Razvan Tamas", "Ovidiu Jurje", "Razvan Hidan" };
            var nameAndIndexTest = FindMatchingNamesAndIndexesUsingCommonPrefixes(userNameList, "RT");
            Assert.AreEqual(nameAndIndexTest[0].index[1].end, 7);
        }
        [TestMethod]
        public void TestForMatchingIndexesFour()
        {
            var userNameList = new List<string> { "Razvan Tamas", "Ovidiu Jurje", "Razvan Hidan" };
            var nameAndIndexTest = FindMatchingNamesAndIndexesUsingCommonPrefixes(userNameList, "O");
            Assert.AreEqual(nameAndIndexTest[0].index[0].start, 0);
        }
        [TestMethod]
        public void TestForMatchingIndexesFive()
        {
            var userNameList = new List<string> { "Razvan Tamas", "Ovidiu Jurje", "Razvan Hidan" };
            var nameAndIndexTest = FindMatchingNamesAndIndexesUsingCommonPrefixes(userNameList, "RT");
            CollectionAssert.AreEqual(nameAndIndexTest[0].index, new Index[] { new Index(0, 0), new Index(7, 7) });
        }
        [TestMethod]
        public void TestForMatchingIndexesSix()
        {
            var userNameList = new List<string> { "Razvan Tamas", "Ovidiu Jurje", "Razvan Hidan" };
            var nameAndIndexTest = FindMatchingNamesAndIndexesUsingCommonPrefixes(userNameList, "OviJu");
            CollectionAssert.AreEqual(nameAndIndexTest[0].index, new Index[] { new Index(0, 2), new Index(7, 8) });
        }
        [TestMethod]
        public void TestForMatchingIndexesSeven()
        {
            var userNameList = new List<string> { "Razvan Tamas", "Ovidiu Jurje", "Razvan Hidan" };
            var nameAndIndexTest = FindMatchingNamesAndIndexesUsingCommonPrefixes(userNameList, "J");
            CollectionAssert.AreEqual(nameAndIndexTest[0].index, new Index[] { new Index(-1, -1), new Index(7, 7) });
        }
        [TestMethod]
        public void TestForMatchingIndexesEight()
        {
            var userNameList = new List<string> { "Razvan Tamas", "Ovidiu Jurje", "Razvan Hidan" };
            var nameAndIndexTest = FindMatchingNamesAndIndexesUsingCommonPrefixes(userNameList, "R");
            CollectionAssert.AreEqual(nameAndIndexTest[1].index, new Index[] { new Index(0, 0) });
        }
        [TestMethod]
        public void TestForMatchingIndexesNine()
        {
            var userNameList = new List<string> { "Razvan Tamas", "Ovidiu Jurje", "Razvan Hidan" };
            var nameAndIndexTest = FindMatchingNamesAndIndexesUsingCommonPrefixes(userNameList, "Razvan");
            CollectionAssert.AreEqual(nameAndIndexTest[0].index, new Index[] { new Index(0, 5) });
        }

        [TestMethod]
        public void TestForMatchingLettersUsingPrefixes()
        {
            var userNameList = new List<string> { "Razvan Tamas", "Ovidiu Jurje", "Razvan Hidan" };
            var nameAndIndexTest = FindMatchingNamesAndIndexesUsingCommonPrefixes(userNameList, "RazHi");
            Assert.AreEqual(nameAndIndexTest[0].name, "Razvan Hidan");
        }
        [TestMethod]
        public void TestForMatchingLettersUsingPrefixesTwo()
        {
            var userNameList = new List<string> { "Razvan Tamas", "Ovidiu Jurje", "Razvan Hidan Bogdan" };
            var nameAndIndexTest = FindMatchingNamesAndIndexesUsingCommonPrefixes(userNameList, "RaBog");
            Assert.AreEqual(nameAndIndexTest[0].name, "Razvan Hidan Bogdan");
        }
        [TestMethod]
        public void TestForMatchingIndexesTen()
        {
            var userNameList = new List<string> { "Razvan Tamas", "Ovidiu Jurje", "Razvan Hidan Bogdan" };
            var nameAndIndexTest = FindMatchingNamesAndIndexesUsingCommonPrefixes(userNameList, "RaBog");
            CollectionAssert.AreEqual(nameAndIndexTest[0].index, new Index[] { new Index(0, 1),new Index(-1,-1), new Index(13,15)});
        }
        [TestMethod]
        public void TestForBiggestCommonPrefix()
        {
            Assert.AreEqual(BiggestCommonPrefix("Rad", "Razvana"), "Ra");
        }

        string BiggestCommonPrefix(string searchLetters, string text)
        {
            if (string.IsNullOrEmpty(searchLetters) || string.IsNullOrEmpty(text) || searchLetters[0] != text[0])
                return "";
            return (searchLetters[0] + BiggestCommonPrefix(searchLetters.Substring(1), text.Substring(1)));
        }

        NameAndIndex[] FindMatchingNamesAndIndexesUsingCommonPrefixes(List<string> userNameList, string searchLetters)
        {
            var nameWithIndex = new NameAndIndex[] { };
            string orderedSequence = string.Empty;
            foreach (var userName in userNameList)
            {
                CheckEachUserForMatchingLetters(searchLetters, userName, ref nameWithIndex);
            }
            return nameWithIndex;
        }

        private void CheckEachUserForMatchingLetters(string searchLetters, string userName, ref NameAndIndex[] nameWithIndex)
        {           
            var parts = userName.Split(' ');
            var matchingIndex = new Index[]{ };
            int differenceInIndex = 0;
            var searchLettersTwo = searchLetters;
            for (int partIndex = 0; partIndex < parts.Length; partIndex++)
            {
                if (partIndex > 0 && partIndex < parts.Length)
                {
                    differenceInIndex += parts[partIndex - 1].Length + 1;
                }

                Array.Resize(ref matchingIndex, matchingIndex.Length + 1);
                matchingIndex[matchingIndex.Length-1] = FindmatchingIndexes(ref searchLettersTwo, parts[partIndex],differenceInIndex); 
                
                if (IsMatchingLetters(ref searchLetters, parts[partIndex]))
                {                   
                    Array.Resize(ref nameWithIndex, nameWithIndex.Length + 1);
                    nameWithIndex[nameWithIndex.Length - 1].name = userName;
                    nameWithIndex[nameWithIndex.Length - 1].index = matchingIndex;
                }
            }
        }

        public bool IsMatchingLetters(ref string searchLetters, string text)
        {          
            var largestCommonPrefix = BiggestCommonPrefix(searchLetters, text);
            if (searchLetters == largestCommonPrefix)
            {                
                return true;
            }
            if (largestCommonPrefix.Length > 0)
            {               
                searchLetters = searchLetters.Substring(largestCommonPrefix.Length);              
            }
            return false;
        }   
        public Index FindmatchingIndexes(ref string searchLetters,string text, int differenceInIndex)
        {
            var largestCommonPrefix = BiggestCommonPrefix(searchLetters, text);
            var matchingIndex = new Index  (-1,-1);
            if (largestCommonPrefix.Length > 0)
            {
                matchingIndex = new Index(differenceInIndex, differenceInIndex + largestCommonPrefix.Length - 1);
                searchLetters = searchLetters.Substring(largestCommonPrefix.Length);
            }
            return matchingIndex;
                
        }
        
    }
    
}
