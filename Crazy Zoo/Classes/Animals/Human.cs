using Crazy_Zoo.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crazy_Zoo.Classes.Animals
{
    internal class Human : BaseAnimal, IRunnable

    {
        public Human(string name, string species = "Human", string voice = "Aaaaaa", string introduction ="") : base(name, species, voice, introduction = $"{name} reading papers")
        {
        }

        public override string EatFood(string food)
        {
            return $"{this.GetName()} dont want to eat {food} from the floor";
        }

        public override string MakeSound()
        {
            return "'I wont make sound for you, do you think im some sort of animal?'";
        }

        public string Run()
        {
            return $"{this.GetName()} is doing cardio";
        }
    }
}
