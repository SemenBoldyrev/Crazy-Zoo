using Crazy_Zoo.Classes;
using Crazy_Zoo.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crazy_Zoo.Usables.Script
{
    public class Enclosure<T> : IRepository<T>, IEnumerable<T> where T : BaseAnimal
    {
        private List<T> container;

        private string name;

        private Action<T>? itemAdded;

        public Enclosure(string name)
        {
            container = new List<T>();
            this.name = name;
            App.Services?.GetService<IAnimalDatabaseController>()?.AddEnclosureInfo(this);
        }

        public void Add(T item)
        {
            container.Add(item);
            ConnectToEvents(item);
            itemAdded?.Invoke(item);
            App.Services?.GetService<ILogger>()?.Log($"'{item}' added to enclosure -- '{this.name}'");
            App.Services?.GetService<IAnimalDatabaseController>()?.AddAnimalInfo(item, this);
        }

        private void ConnectToEvents(T item) 
        {
            if (item is IReactor) { itemAdded += ((IReactor)item).React; }
            if (item is INightAnimal) { SignalBus.nihtTime += ((INightAnimal)item).NightBehavior; }
        }

        public void clear()
        {
            container.Clear();
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

        public IEnumerator<T> GetEnumerator()
        {
            throw new NotImplementedException();
        }

        public void Remove(T item)
        {
            if (container.Contains(item))
            {
                container.Remove(item);
                App.Services.GetService<IAnimalDatabaseController>()?.RemoveAnimalInfo(item.GetUnique());
            }
        }

        public override string ToString()
        {
            return "Enclosure: "+"'"+this.name+"'";
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public string GetName()
        {
            return name;
        }
    }
}
