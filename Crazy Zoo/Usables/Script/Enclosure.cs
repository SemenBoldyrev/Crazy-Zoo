using Crazy_Zoo.Classes;
using Crazy_Zoo.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crazy_Zoo.Usables.Script
{
    internal class Enclosure<T> : IRepository<T> where T : BaseAnimal
    {
        public List<T> container { get; set; } = new List<T>();

        public void Add(T item)
        {
            container.Add(item);
        }

        public IEnumerable<T> Find(Func<T, bool> predicate)
        {
            var result = container.Where(predicate);
            return result;
        }

        public IEnumerable<T> GetAll()
        {
            return container;
        }

        public void Remove(T item)
        {
            if (container.Contains(item))
            {
                container.Remove(item);
            }
        }
    }
}
