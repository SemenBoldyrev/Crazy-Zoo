using Crazy_Zoo.Interfaces;
using Crazy_Zoo.Usables.Localization.CodeLocalization.AnimalCodeLoc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crazy_Zoo.Classes.Animals
{
    internal class Human : BaseAnimal, IRunnable

    {
        public Human(string name, string species = "Human", string voice = "Aaaaaa", string introduction ="") : base(name, species, voice, introduction = string.Format(AnimalLoc.HumanIntro,name))
        {
        }

        public override string EatFood(string food)
        {
            return string.Format(AnimalLoc.HumanEating,this.GetName(),food);
        }

        public override string MakeSound()
        {
            return AnimalLoc.HumanVoice;
        }

        public string Run()
        {
            return string.Format(AnimalLoc.HumanRunAction,this.GetName());
        }
    }
}
