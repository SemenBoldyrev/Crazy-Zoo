using Crazy_Zoo.Interfaces;
using Crazy_Zoo.Usables.Enums;
using Crazy_Zoo.Usables.Localization.CodeLocalization.AnimalCodeLoc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Crazy_Zoo.Classes.Animals
{
    internal class Bacteria: BaseAnimal, ICrazy
    {
        public Bacteria(string name = "Bacteria", string species = "Prokaryote", string voice = "....", string introduction = "") : base(name, species, voice, introduction = string.Format(AnimalLoc.BacteriaIntro,name))
        {
        }
        public CrazyActionEnumerates.CrazyActionEnum CrazyAction()
        {
            return CrazyActionEnumerates.CrazyActionEnum.Bacteria;
        }
        public override string EatFood(string food)
        {
            return string.Format(AnimalLoc.BacteriaEating,this.GetName(),food);
        }
        public override string MakeSound()
        {
            return this.GetVoice();
        }
    }
}
