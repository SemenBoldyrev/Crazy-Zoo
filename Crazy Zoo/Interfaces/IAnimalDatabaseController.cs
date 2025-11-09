using Crazy_Zoo.Classes;
using Crazy_Zoo.Usables.Script;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crazy_Zoo.Interfaces
{
    public interface IAnimalDatabaseController
    {
        public DataTable GetAnimalData();
        public DataTable GetEnclosureData();
        public void ExecuteCommand(string command);
        public void AddAnimalInfo<T>(T animal, Enclosure<T> enclosure = null) where T : BaseAnimal;
        public void RemoveAnimalInfo(string name);
        public void AddEnclosureInfo<T>(Enclosure<T> enclosure = null) where T : BaseAnimal;
        public void RemoveEnclosureInfo(string name);

        public bool IsUniqueAnimal(BaseAnimal animal);
        public bool IsUniqueEnclosure<T>(Enclosure<T> enclosure) where T : BaseAnimal;
    }
}
