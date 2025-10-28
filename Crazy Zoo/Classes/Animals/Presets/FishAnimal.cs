using Crazy_Zoo.Interfaces;
using Crazy_Zoo.Usables.Localization.CodeLocalization.AnimalCodeLoc;
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
        public FishAnimal(string name, string species, string voice, string introduction = "") : base(name, species, voice, string.Format(AnimalLoc.FishIntro,name)) { }

        public override string EatFood(string food)
        {
            return string.Format(AnimalLoc.FishEating, this.GetName(), food);
        }

        public override string MakeSound()
        {
            return this.GetVoice();
        }

        public string Swim()
        {
            return string.Format(AnimalLoc.FishSwimAction, this.GetName());
        }
    }
}
