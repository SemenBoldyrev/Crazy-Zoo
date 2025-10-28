using Crazy_Zoo.Interfaces;
using Crazy_Zoo.Usables.Enums;
using Crazy_Zoo.Usables.Localization.CodeLocalization.AnimalCodeLoc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crazy_Zoo.Classes.Animals
{
    internal class Horse : BaseAnimal, IRunnable, ICrazy
    {
        public Horse(string name = "Horse", string species = "Standart horse", string voice = "Brrrr", string introduction = "") : base(name, species, voice, introduction = string.Format(AnimalLoc.HorseIntro,name))
        {
        }

        public CrazyActionEnumerates.CrazyActionEnum CrazyAction()
        {
            return CrazyActionEnumerates.CrazyActionEnum.Horse;
        }

        public override string EatFood(string food)
        {
            if (food == "hay" || food == "Hay") { return "Hello!"; }
            return string.Format(AnimalLoc.HorseEating,this.GetName(),food);
        }

        public override string MakeSound()
        {
            return this.GetVoice();
        }

        public string Run()
        {
            return string.Format(AnimalLoc.HorseRunActin,this.GetName());
        }
    }
}
