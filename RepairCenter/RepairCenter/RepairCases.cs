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
            foreach (RepairCase repairCase in allRepairCases)
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
            IEnumerator enumerator = allRepairCases.GetEnumerator();
            enumerator.MoveNext();
            return (RepairCase)enumerator.Current;
        }
    } 
}
