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
    internal class GroundAnimal : BaseAnimal, IRunnable
    {
        public GroundAnimal(string name, string species, string voice, string introduction = "") : base(name, species, voice, string.Format(AnimalLoc.GroundIntro,name)) { }

        public override string EatFood(string food)
        {
            return string.Format(AnimalLoc.GroundEating,this.GetName(),food);
        }

        public override string MakeSound()
        {
            return this.GetVoice();
        }

        public string Run()
        {
            return string.Format(AnimalLoc.GroundRunAction,this.GetName());
        }
    }
}
