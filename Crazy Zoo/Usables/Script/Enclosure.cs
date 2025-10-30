﻿using Crazy_Zoo.Classes;
using Crazy_Zoo.Interfaces;
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
        }

        public void Add(T item)
        {
            container.Add(item);
            itemAdded?.Invoke(item);
            if (item is IReactor) { itemAdded += ((IReactor)item).React; }
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
