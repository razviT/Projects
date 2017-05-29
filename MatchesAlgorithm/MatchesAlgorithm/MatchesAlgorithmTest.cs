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
        public void TestForMatchingNames()
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
            Assert.AreEqual(nameAndIndexTest[0].index[0].start, 7);
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
            Assert.AreEqual(nameAndIndexTest[0].name,"Razvan Hidan");
        }
        [TestMethod]
        public void TestForMatchingLettersUsingPrefixesTwo()
        {
            var userNameList = new List<string> { "Razvan Tamas", "Ovidiu Jurje", "Razvan Hidan Bogdan" };
            var nameAndIndexTest = FindMatchingNamesAndIndexesUsingCommonPrefixes(userNameList, "RaBog");
            Assert.AreEqual(nameAndIndexTest[0].name, "Razvan Hidan Bogdan");
        }
        [TestMethod]
        public void TestForMatchingIndexesUsingPrefixes()
        {
            var userNameList = new List<string> { "Razvan Tamas", "Ovidiu Jurje", "Razvan Hidan Bogdan" };
            var nameAndIndexTest = FindMatchingNamesAndIndexesUsingCommonPrefixes(userNameList, "RaBog");
            CollectionAssert.AreEqual(nameAndIndexTest[0].index, new Index[] { new Index(13, 15) });
        }
       

        //the second way using common prefixes



        string BiggestCommonPrefix(string searchLetters, string part,ref int[] matchingIndex, int differenceInIndex)
        {
            int minLength = (searchLetters.Length < part.Length) ? searchLetters.Length : part.Length;
            var largestCommonPrefix = string.Empty;           
            for (int i = 0; i < minLength; i++)
            {
                if (searchLetters[i] == part[i])
                {
                    largestCommonPrefix += searchLetters[i];
                    matchingIndex = CreateMatchingIndexArray(matchingIndex, differenceInIndex, i);
                }
                else
                    return largestCommonPrefix;
            }
            return largestCommonPrefix;
        }

        private static int[] CreateMatchingIndexArray(int[] matchingIndex, int differenceInIndex, int i)
        {
            Array.Resize(ref matchingIndex, matchingIndex.Length + 1);
            matchingIndex[matchingIndex.Length - 1] = differenceInIndex + i;
            return matchingIndex;
        }

        NameAndIndex[] FindMatchingNamesAndIndexesUsingCommonPrefixes(List<string> userNameList, string searchLetters)
        {
            var nameWithIndex = new NameAndIndex[] { };
            string orderedSequence = string.Empty;           
            foreach (var userName in userNameList)
            {
                CheckEachUserForMatchingLetters(ref searchLetters, ref nameWithIndex, userName);
            }
            return nameWithIndex;
        }

        private void CheckEachUserForMatchingLetters(ref string searchLetters, ref NameAndIndex[] nameWithIndex, string userName)
        {
            int differenceInIndex = 0;
            var matchingIndex = new int[0];
            var parts = userName.Split(' ');
            for (int partIndex = 0; partIndex < parts.Length; partIndex++)
            {
                if (partIndex > 0 && partIndex < parts.Length)
                {
                    differenceInIndex += parts[partIndex - 1].Length + 1;
                }
                if (IsMatchUsingCommonPrefixes(ref searchLetters, parts[partIndex], ref matchingIndex, differenceInIndex))
                {
                    Array.Resize(ref nameWithIndex, nameWithIndex.Length + 1);
                    nameWithIndex[nameWithIndex.Length - 1].name = userName;
                    nameWithIndex[nameWithIndex.Length - 1].index = PutNumbersInSequences(matchingIndex);
                }
            }
        }

        public bool IsMatchUsingCommonPrefixes(ref string searchLetters, string text, ref int[] matchingIndex, int differenceInIndex)
        {
            var largestCommonPrefix = BiggestCommonPrefix(searchLetters, text, ref matchingIndex, differenceInIndex);
            if (searchLetters == largestCommonPrefix)
                return true;   
            else if (largestCommonPrefix.Length > 0)
            {
                searchLetters = searchLetters.Replace(largestCommonPrefix, "");
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
