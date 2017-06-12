using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace RepairCenter
{
    public class RepairCases : IEnumerable<RepairCase>
    {
        private List<RepairCase> allRepairCases;
        public RepairCases(List<RepairCase> allRepairCases)
        {
            this.allRepairCases = allRepairCases;
        }

        public IEnumerator<RepairCase> GetEnumerator()
        {
            return new RepairCasesEnumerator(allRepairCases);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable<RepairCase>)allRepairCases).GetEnumerator();
        }

        public List<RepairCase> AddRepairCaseInOrderOfPriority(RepairCase newRepairCase)
        {
            int index = 0;
            foreach (RepairCase repairCase in allRepairCases)
            {
                if (repairCase.ConvertPriorityToInteger() < newRepairCase.ConvertPriorityToInteger())
                {
                    allRepairCases.Insert(index, newRepairCase);
                    return allRepairCases;
                }
                index++;
            }
            allRepairCases.Insert(allRepairCases.Count, newRepairCase);
            return allRepairCases;
        }
    } 
    public class RepairCasesEnumerator : IEnumerator<RepairCase>
    {
        private List<RepairCase> allRepairCases;
        public int position = -1;

        public RepairCasesEnumerator(List<RepairCase> allRepairCases)
        {
            this.allRepairCases = allRepairCases;
        }

        public RepairCase Current
        {
            get
            {
                return allRepairCases[position];
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
            return (position < allRepairCases.Count-1);
        }

        public void Reset()
        {
            position = -1;
        }
    }
}
