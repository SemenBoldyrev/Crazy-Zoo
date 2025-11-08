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
        public void RemoveAnimalInfo(int inddex);
        public DataTable GetData();
        public void ExecuteCommand(string command);
        void AddAnimalInfo<T>(T animal, Enclosure<T> enclosure = null) where T : BaseAnimal;
    }
}
