﻿using System;
using System.Collections;
using System.Collections.Generic;
namespace RepairCenter
{
    public class RepairCases : IEnumerable<RepairCase>
    {
        private RepairCase[] allRepairCases;
        public RepairCases(RepairCase[] allRepairCases)
        {
            this.allRepairCases = allRepairCases;
        }

        public IEnumerator<RepairCase> GetEnumerator()
        {
            return new RepairCasesEnumerator<RepairCase>(allRepairCases);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable<RepairCase>)allRepairCases).GetEnumerator();
        }

        public RepairCase[] SortCasesAccordingToPriority()
        {
            bool areInOrder = false;
            while (areInOrder == false)
            {
                areInOrder = IsInOrder();
            }
            return allRepairCases;
        }

        public RepairCase GetWantedCase(int wantedCase)
        {
            IEnumerator enumerator = allRepairCases.GetEnumerator();
            for (int i = 0; i < wantedCase; i++)
            {
                enumerator.MoveNext();
            }
            return (RepairCase)enumerator.Current;
        }

        private bool IsInOrder()
        {
            bool areInOrder = true;
            for (int i = 1; i < allRepairCases.Length; i++)
            {
                if (allRepairCases[i].ConvertPriorityToInteger() > allRepairCases[i - 1].ConvertPriorityToInteger())
                {
                    SwapCases(i);
                    areInOrder = false;
                }
            }

            return areInOrder;
        }

        private void SwapCases(int i)
        {
            var temp = allRepairCases[i];
            allRepairCases[i] = allRepairCases[i - 1];
            allRepairCases[i - 1] = temp;
        }
    }

    public class RepairCasesEnumerator<T> : IEnumerator<RepairCase>
    {
        private RepairCase[] allRepairCases;
        public int position = -1;

        public RepairCasesEnumerator(RepairCase[] allRepairCases)
        {
            this.allRepairCases = allRepairCases;
        }

        public RepairCase Current
        {
            get
            {
                try
                {
                    return allRepairCases[position];
                }
                catch (IndexOutOfRangeException)
                {
                    throw new InvalidOperationException();
                }
            }
        }

        object IEnumerator.Current
        {
            get
            {
                return Current;
            }        
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public bool MoveNext()
        {
            position++;
            return (position < allRepairCases.Length);
        }

        public void Reset()
        {
            position = -1;
        }
    }
}
