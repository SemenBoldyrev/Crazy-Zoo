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
    internal class Virus : BaseAnimal, ICrazy, IRunnable
    {
        public Virus(string name = "Unknown", string species = "Virus", string voice = "...", string introduction = "") : base(name, species, voice, introduction = string.Format(AnimalLoc.VirusIntro,name))
        {
        }

        public CrazyActionEnumerates.CrazyActionEnum CrazyAction()
        {
            return CrazyActionEnumerates.CrazyActionEnum.Monkey;
        }

        public override string EatFood(string food)
        {
            return string.Format(AnimalLoc.VirusEating,this.GetName(),food);
        }

        public override string MakeSound()
        {
            return GetVoice();
        }

        public string Run()
        {
            return string.Format(AnimalLoc.VirusRunAction,this.GetName());
        }
    }
}
