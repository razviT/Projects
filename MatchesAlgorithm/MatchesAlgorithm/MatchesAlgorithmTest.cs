using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace MatchesAlgorithm
{
    public struct Range
    {
        public int start;
        public int end;
        public Range(int index)
            : this(index, index)
        {
        }

        public Range(int start, int end)
        {
            this.start = start;
            this.end = end;
        }
    }
    public struct NameAndIndex
    {
        public string name;
        public Range[] index;
        public NameAndIndex(string name,Range[] index)
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
            CollectionAssert.AreEqual(nameAndIndexTest[0].index,new Range[] { new Range(0, 3), new Range(7, 8)});

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
            CollectionAssert.AreEqual(nameAndIndexTest[0].index, new Range[] { new Range(0, 0), new Range(7, 7) });
        }
        [TestMethod]
        public void TestForMatchingIndexesSix()
        {
            var userNameList = new List<string> { "Razvan Tamas", "Ovidiu Jurje", "Razvan Hidan" };
            var nameAndIndexTest = FindMatchingNamesAndIndexesUsingCommonPrefixes(userNameList, "OviJu");
            CollectionAssert.AreEqual(nameAndIndexTest[0].index, new Range[] { new Range(0, 2), new Range(7, 8) });
        }
        [TestMethod]
        public void TestForMatchingIndexesSeven()
        {
            var userNameList = new List<string> { "Razvan Tamas", "Ovidiu Jurje", "Razvan Hidan" };
            var nameAndIndexTest = FindMatchingNamesAndIndexesUsingCommonPrefixes(userNameList, "J");
            CollectionAssert.AreEqual(nameAndIndexTest[0].index, new Range[] {new Range(7, 7) });
        }
        [TestMethod]
        public void TestForMatchingIndexesEight()
        {
            var userNameList = new List<string> { "Razvan Tamas", "Ovidiu Jurje", "Razvan Hidan" };
            var nameAndIndexTest = FindMatchingNamesAndIndexesUsingCommonPrefixes(userNameList, "R");
            CollectionAssert.AreEqual(nameAndIndexTest[1].index, new Range[] { new Range(0, 0) });
        }
        [TestMethod]
        public void TestForMatchingIndexesNine()
        {
            var userNameList = new List<string> { "Razvan Tamas", "Ovidiu Jurje", "Razvan Hidan" };
            var nameAndIndexTest = FindMatchingNamesAndIndexesUsingCommonPrefixes(userNameList, "Razvan");
            CollectionAssert.AreEqual(nameAndIndexTest[1].index, new Range[] { new Range(0, 5) });
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
            CollectionAssert.AreEqual(nameAndIndexTest[0].index, new Range[] { new Range(0, 1), new Range(13,15)});
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
            var result = new NameAndIndex[] { };
            foreach (var userName in userNameList)
            {
                var match = CheckEachUserForMatchingLetters(searchLetters, userName);
                if (match.HasValue)
                {
                    result = AddNewMatch(result, match.Value);
                }
            }
            return result;
        }

        private NameAndIndex[] AddNewMatch(NameAndIndex[] nameWithIndex, NameAndIndex value)
        {            
            Array.Resize(ref nameWithIndex, nameWithIndex.Length + 1);
            nameWithIndex[nameWithIndex.Length - 1].name = value.name;
            nameWithIndex[nameWithIndex.Length - 1].index = value.index;
            return nameWithIndex;
        }

        private NameAndIndex? CheckEachUserForMatchingLetters(string searchLetters, string userName)
        {           
            var parts = userName.Split(' ');
            var matchingIndex = new Range[]{ };
            int differenceInIndex = 0;
            var rangeNeeded = searchLetters;
            var searchLettersTwo = searchLetters;
            for (int partIndex = 0; partIndex < parts.Length; partIndex++)
            {
                var indexMatch= FindmatchingIndexes(ref searchLettersTwo, parts[partIndex], differenceInIndex);
                if (indexMatch.HasValue)
                {
                    matchingIndex = AddNewIndexMatch(matchingIndex, indexMatch.Value);
                    if (IsAMatch(matchingIndex, rangeNeeded))
                    {
                        return new NameAndIndex(userName, matchingIndex);
                    }
                }                                      
                differenceInIndex += parts[partIndex].Length + 1;
            }
            return null;
        }

        private static Range[] AddNewIndexMatch(Range[] matchingIndex, Range indexMatch)
        {
            Array.Resize(ref matchingIndex, matchingIndex.Length + 1);
            matchingIndex[matchingIndex.Length - 1] = indexMatch;
            return matchingIndex;
        }

        
        public Range? FindmatchingIndexes(ref string searchLetters,string text, int differenceInIndex)
        {
            var largestCommonPrefix = BiggestCommonPrefix(searchLetters, text);          
            if (largestCommonPrefix.Length > 0)
            {
                searchLetters = searchLetters.Substring(largestCommonPrefix.Length);
                return new Range(differenceInIndex, differenceInIndex + largestCommonPrefix.Length - 1);
                
            }
            return null;              
        }
        public bool IsAMatch(Range[]matchingIndex,string searchLetters)
        {
            int range = CountLettersInRanges(matchingIndex);
            if (range == searchLetters.Length)
            {
                return true;
            }
            return false;
        }

        private static int CountLettersInRanges(Range[] matchingIndex)
        {
            int count = 0;
            for (int i = 0; i < matchingIndex.Length; i++)
            {
                count += (matchingIndex[i].end - matchingIndex[i].start + 1);
            }

            return count;
        }
    }
    
}
