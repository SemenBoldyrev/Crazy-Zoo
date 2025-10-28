using Crazy_Zoo.Interfaces;
using Crazy_Zoo.Usables.Localization.CodeLocalization.AnimalCodeLoc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crazy_Zoo.Classes.Animals
{
    internal class Zebra : Horse, IRunnable, ICrazy
    {
        public Zebra(string name = "Zebra", string species = "Plains Zebra", string voice = "Hufff", string introduction = "") : base(name, species, voice, introduction = string.Format(AnimalLoc.ZebraIntro,name))
        {
        }

        public string Run()
        {
            return string.Format(AnimalLoc.ZebraRunAction,this.GetName());
        }
    }
}

