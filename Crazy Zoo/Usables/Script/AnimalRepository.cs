using Crazy_Zoo.Classes;
using Crazy_Zoo.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crazy_Zoo.Usables.Script
{
    internal class AnimalRepository : IRepository<BaseAnimal>
    {
        public List<BaseAnimal> container { get; set; } = new List<BaseAnimal>();

        public void Add(BaseAnimal item)
        {
            container.Add(item);
        }

        public void clear()
        {
            this.container.Clear();
        }

        public IEnumerable<BaseAnimal> Find(Func<BaseAnimal, bool> predicate)
        {
            var result = container.Where(predicate);
            return result;
        }

        public IEnumerable<BaseAnimal> GetAll()
        {
            return container;
        }

        public void Remove(BaseAnimal item)
        {
            container.Remove(item);
        }

        IEnumerable<BaseAnimal> IRepository<BaseAnimal>.Find(Func<BaseAnimal, bool> predicate)
        {
            var result = container.Where(predicate);
            return result;
        }
    }
}
