using Crazy_Zoo.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Crazy_Zoo.Classes.Animals.Presets
{
    internal class GroundAnimal : BaseAnimal, IRunnable
    {
        public GroundAnimal(string name, string species, string voice, string introduction = "") : base(name, species, voice, $"{name} furyously running in his cage") { }

        public override string EatFood(string food)
        {
            return $"{this.GetName()} biting juicy {food}";
        }

        public override string MakeSound()
        {
            return this.GetVoice();
        }

        public string Run()
        {
            return $"{this.GetName()} walking in circles";
        }
    }
}
