using Crazy_Zoo.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crazy_Zoo.Classes.Animals
{
    internal class Zebra : Horse, IRunnable, ICrazy
    {
        public Zebra(string name = "Zebra", string species = "Plains Zebra", string voice = "Hufff", string introduction = "") : base(name, species, voice, introduction = $"{name} watches you warily")
        {
        }

        public string Run()
        {
            return $"{this.GetName()} runs playfully with others";
        }
    }
}

