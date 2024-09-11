using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DP
{
    public abstract class SimpleIterator<T>
    {
        protected int index;
        //protected int count = 0;

        public abstract T Current { get; }

        public SimpleIterator() {
            this.index = 0;
        }

        public abstract bool MoveNext();

        public void Reset()
        {
            //index = -1;
            index = 0;
        }

        public abstract bool Exists(int serverID);
    }
}
