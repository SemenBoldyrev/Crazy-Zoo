using Crazy_Zoo.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crazy_Zoo.Classes.Animals
{
    internal class Horse : BaseAnimal, IRunnable, ICrazy
    {
        public Horse(string name = "Horse", string species = "Standart horse", string voice = "Brrrr", string introduction = "") : base(name, species, voice, introduction = $"{name} gracefully shakes the earth")
        {
        }

        public override int Action()
        {
            return CrazyAction();
        }

        public int CrazyAction()
        {
            return 1;
        }

        public override string EatFood(string food)
        {
            if (food == "hay" || food == "Hay") { return "Hello!"; }
            return $"{this.GetName()} so hungry, it could eat a {food}...";
        }

        public override string MakeSound()
        {
            return this.GetVoice();
        }

        public string Run()
        {
            return $"{this.GetName()} so fast, you cannot even see its legs";
        }
    }
}
