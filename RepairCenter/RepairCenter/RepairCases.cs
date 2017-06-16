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

        public void Add(string caseName, string priority)
        {
            Add(new RepairCase(caseName, priority));
        }

        public void Add(RepairCase newRepairCase)
        {
            int index = 0;
            bool added = false;
            foreach (RepairCase repairCase in allRepairCases)
            {
                if (repairCase.GetPriorityInInt() < newRepairCase.GetPriorityInInt())
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
      
        public RepairCase GetNext()
        {
            IEnumerator enumerator = allRepairCases.GetEnumerator();
            enumerator.MoveNext();
            return (RepairCase)enumerator.Current;
        }//List<T> IList<T>....sa ma uit la iList<T> la metode....sa fac array de <t> la list care are 8 la inceput si 
        //cand ajunge la 8 sa dublez si tot asa (array.resize)
    } 
}
