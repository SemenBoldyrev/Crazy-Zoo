using Crazy_Zoo.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Crazy_Zoo.Classes.Animals.Presets
{
    internal class FishAnimal: BaseAnimal, ISwimable
    {
        public FishAnimal(string name, string species, string voice, string introduction = "") : base(name, species, voice, $"{name} swimming in fog of lenses") { }

        public override int Action()
        {
            MessageBox.Show(Swim());
            return 0;
        }

        public override string EatFood(string food)
        {
            return $"{this.GetName()} trying to devour {food} mercilessly";
        }

        public override string MakeSound()
        {
            return this.GetVoice();
        }

        public string Swim()
        {
            return $"{this.GetName()} waiting for something to happen";
        }
    }
}
