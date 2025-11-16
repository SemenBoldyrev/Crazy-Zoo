using Crazy_Zoo.Classes;
using Crazy_Zoo.Usables.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crazy_Zoo.Interfaces
{
    public interface IAnimalFactory
    {
        public BaseAnimal CreatAnimal(string _origin, string _name, int _age, string _species = "none", string _voice = "none", string _introduction = "none");
    }
}
