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
            throw new NotImplementedException();
        }

        public BaseAnimal Find(Func<BaseAnimal, bool> predicate)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<BaseAnimal> GetAll()
        {
            throw new NotImplementedException();
        }

        public void Remove(BaseAnimal item)
        {
            throw new NotImplementedException();
        }

        IEnumerable<BaseAnimal> IRepository<BaseAnimal>.Find(Func<BaseAnimal, bool> predicate)
        {
            throw new NotImplementedException();
        }
    }
}
