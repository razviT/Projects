using System.Collections.Generic;
using System;
using System.Collections;

namespace CentralizedVoting
{
    public class PoliticiansList : IEnumerable<Politician>
    {
        private Politician[] politicians;
        public PoliticiansList(Politician[] politicians)
        {
            this.politicians = politicians;
        }

        public IEnumerator<Politician> GetEnumerator()
        {
            return new PoliticiansListEnumerator<Politician>(politicians);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable<Politician>)politicians).GetEnumerator();
        }
    }

    public class PoliticiansListEnumerator<Politician> : IEnumerator<Politician>
    {
        public Politician[] politicians;
        int position = -1;
        public PoliticiansListEnumerator(Politician[] politicians)
        {
            this.politicians = politicians;
        }
        public Politician Current
        {
            get
            {
                return politicians[position];
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
            return (position < politicians.Length);
        }

        public void Reset()
        {
            position = -1;
        }
    }

}
