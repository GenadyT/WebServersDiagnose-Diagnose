using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebServersManager.DP
{
    public interface IAggregate<T>
    {
        public SimpleIterator<T> CreateIterator(int iteratorType);
    }
}
