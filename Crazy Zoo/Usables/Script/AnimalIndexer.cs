using Crazy_Zoo.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crazy_Zoo.Usables.Script
{
    internal class AnimalIndexer : IIndexer
    {
        private int index = -1;
        public int GetUnique()
        {
            index++;
            return index;
        }
    }
}
