using System;
using System.Collections;
using System.Collections.Generic;
namespace RepairCenter
{
    public class RepairCases:IEnumerable<RepairCase>
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
