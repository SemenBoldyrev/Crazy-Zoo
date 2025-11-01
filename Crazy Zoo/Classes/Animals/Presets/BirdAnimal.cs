using Crazy_Zoo.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Crazy_Zoo.Classes.Animals.Presets
{
    internal class BirdAnimal: BaseAnimal, IFlyable
    {
        public BirdAnimal(string name, string species, string voice, string introduction = "", int age = 0) : base(name, species, voice, $"{name} cutting the very sky", age) { }

        public override string EatFood(string food)
        {
            return $"{this.GetName()} dives like a needle for {food}";
        }

        public string Fly()
        {
            return $"{this.GetName()} cannot even fly longer than 3 seconds \nin his cage";
        }

        public override string MakeSound()
        {
            return this.GetVoice();
        }

    }
}
