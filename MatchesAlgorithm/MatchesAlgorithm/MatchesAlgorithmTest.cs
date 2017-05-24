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
        [TestMethod]
        public void TestForMatchingIndexesNine()
        {
            var userNameList = new List<string> { "Razvan Tamas", "Ovidiu Jurje", "Razvan Hidan" };
            var nameAndIndexTest = FindMatchingNamesAndIndexes(userNameList, "Razvan");
            CollectionAssert.AreEqual(nameAndIndexTest[0].index, new Index[] { new Index(0, 5) });
        }
        [TestMethod]
        public void TestForAdrianAdriana()
        {
            var userNameList = new List<string> {"Ainasdas Airasd Airxsadad" };
            var nameAndIndexTest = FindMatchingNamesAndIndexes(userNameList, "Airxsadad");
            CollectionAssert.AreEqual(nameAndIndexTest[0].index, new Index[] { new Index(16,24) });
        }


        NameAndIndex[] FindMatchingNamesAndIndexes(List<string> userNameList, string searchLetters)
        {
            var nameWithIndex = new NameAndIndex[] { };
            string orderedSequence = string.Empty; 
            foreach (var userName in userNameList)
            {                
                var parts = userName.Split(' ');               
                var matchingIndex = new int[searchLetters.Length];              
                int differenceBetweenIndexes = 0;
                for (int partIndex = 0; partIndex < parts.Length; partIndex++)
                {
                    if (partIndex > 0 && partIndex<parts.Length)
                        differenceBetweenIndexes += parts[partIndex - 1].Length + 1;
                    if (IsMatching(searchLetters, userName, ref matchingIndex, partIndex, differenceBetweenIndexes))
                    {
                        Array.Resize(ref nameWithIndex, nameWithIndex.Length + 1);
                        nameWithIndex[nameWithIndex.Length - 1].name = userName;
                        nameWithIndex[nameWithIndex.Length - 1].index = PutNumbersInSequences(matchingIndex);
                    }
                    
                }

            }
            return nameWithIndex;
        }

        public bool IsMatching(string searchLetters, string text, ref int[] matchingIndex,int partIndex,int differenceBetweenIndexes)
        {
            var parts = text.Split(' ');
            int j = 0;
            int i = 0;                             
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
                    if (partIndex + 1 < parts.Length && i <= searchLetters.Length - 1 && j==parts[partIndex].Length-1)
                    {
                        partIndex++;
                        differenceBetweenIndexes += parts[partIndex - 1].Length  + 1;
                        j = 0;
                    }
                    else
                    {
                        j++;
                    }                 
                }
                else if (partIndex + 1 < parts.Length && i <= searchLetters.Length-1)
                {
                    partIndex++;
                    differenceBetweenIndexes += parts[partIndex - 1].Length + 1;
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
