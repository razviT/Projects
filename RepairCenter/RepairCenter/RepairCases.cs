using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace RepairCenter
{
    public class RepairCases : IEnumerable<RepairCase>
    {
        private  List<RepairCase> allRepairCases;
        public RepairCases(IEnumerable<RepairCase> allRepairCases)
        {
            this.allRepairCases =(List<RepairCase>) allRepairCases;
        }

        public IEnumerator<RepairCase> GetEnumerator()
        {
            return new RepairCasesEnumerator(allRepairCases);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return allRepairCases.GetEnumerator();
        }

        public void Add(RepairCase newRepairCase)
        {
            int index = 0;
            bool added = false;
            foreach (RepairCase repairCase in allRepairCases.ToArray())
            {
                if (repairCase.ConvertPriorityToInteger() < newRepairCase.ConvertPriorityToInteger())
                {
                    allRepairCases.Insert(index, newRepairCase);
                    added = true;
                    break;
                }                
                index++;
            }
            if (!added)
            {
                allRepairCases.Insert(allRepairCases.Count, newRepairCase);
            }                   
        }

        public RepairCase GetNextCase()
        {
           return allRepairCases[0];
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
