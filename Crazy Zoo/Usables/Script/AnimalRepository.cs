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
        private List<BaseAnimal> animals = new List<BaseAnimal>();
        public void Add(BaseAnimal item)
        {
            animals.Add(item);
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


    }
}
