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
    internal class Monkey : BaseAnimal, ICrazy, IRunnable
    {
        public Monkey(string name = "Bob", string species = "Primate", string voice = "Ou, ou, ou", string introduction = "") : base(name, species, voice, introduction = string.Format(AnimalLoc.MonkeyIntro,name))
        {
        }

        public CrazyActionEnumerates.CrazyActionEnum CrazyAction()
        {
            return CrazyActionEnumerates.CrazyActionEnum.Monkey;
        }

        public override string EatFood(string food)
        {
            return string.Format(AnimalLoc.MonkeyEating,this.GetName(),food);
        }

        public override string MakeSound()
        {
            return GetVoice();
        }

        public string Run()
        {
            return string.Format(AnimalLoc.MonkeyRunAction,this.GetName());
        }
    }
}
