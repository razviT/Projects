using System;
using System.Collections;
using System.Collections.Generic;
namespace CentralizedVoting
{
    public class CentralizedPoliticiansList : IEnumerable<PoliticiansList>
    {
        private PoliticiansList[] centralizedLists;
        public CentralizedPoliticiansList(PoliticiansList[] centralizedLists)
        {
            this.centralizedLists = centralizedLists;
        }

        public IEnumerator<PoliticiansList> GetEnumerator()
        {
            return new CentralizedPoliticiansListEnumerator<PoliticiansList>(centralizedLists);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable<PoliticiansList>)centralizedLists).GetEnumerator();
        }
    }

    public class CentralizedPoliticiansListEnumerator<PoliticiansList> : IEnumerator<PoliticiansList>
    {
        public int position = -1;
        public PoliticiansList[] centralizedLists;
        public CentralizedPoliticiansListEnumerator(PoliticiansList[] centralizedLists)
        {
            this.centralizedLists = centralizedLists;
        }

        public PoliticiansList Current
        {
            get
            {
                return centralizedLists[position];
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
            return (position < centralizedLists.Length);
        }

        public void Reset()
        {
            position = -1;
        }
    }
}
