using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Navigation;

namespace Crazy_Zoo.Interfaces
{
    internal interface IRepository<T>
    {
        void Add(T item);
        void Remove(T item);
        void clear();
        IEnumerable<T> GetAll();
        IEnumerable<T> Find(Func<T, bool> predicate);
    }
}
