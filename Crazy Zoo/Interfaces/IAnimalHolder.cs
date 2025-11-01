using Crazy_Zoo.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crazy_Zoo.Interfaces
{
    internal interface IAnimalHolder
    {
        void AddAnimal(BaseAnimal animal);
        void RemoveAnimal(int animalIndex);
    }
}
