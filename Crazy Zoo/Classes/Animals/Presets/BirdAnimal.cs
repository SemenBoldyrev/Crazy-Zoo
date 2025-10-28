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
    internal class BirdAnimal: BaseAnimal, IFlyable
    {
        public BirdAnimal(string name, string species, string voice, string introduction = "") : base(name, species, voice, string.Format(AnimalLoc.BirdIntro, name)) { }

        public override string EatFood(string food)
        {
            return string.Format(AnimalLoc.BirdEating,this.GetName(),food);
        }

        public string Fly()
        {
            return string.Format(AnimalLoc.BirdFlyAction,this.GetName());
        }

        public override string MakeSound()
        {
            return this.GetVoice();
        }

    }
}
