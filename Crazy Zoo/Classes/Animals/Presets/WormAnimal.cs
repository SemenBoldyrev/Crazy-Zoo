using Crazy_Zoo.Usables.Localization.CodeLocalization.AnimalCodeLoc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crazy_Zoo.Classes.Animals.Presets
{
    internal class WormAnimal : BaseAnimal
    {
        public WormAnimal(string name, string species, string voice, string introduction = "") : base(name, species, voice, introduction = string.Format(AnimalLoc.WormIntro,name)) { }



        public override string EatFood(string food)
        {
            return string.Format(AnimalLoc.WormEating,this.GetName(),food);

        }

        public override string MakeSound()
        {
            return string.Format(AnimalLoc.WormSound,this.GetName(),this.GetVoice());
        }
    }
}
