using Crazy_Zoo.Interfaces;
using Crazy_Zoo.Usables.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crazy_Zoo.Classes.Animals
{
    internal class Monkey : BaseAnimal, ICrazy, IRunnable
    {
        public Monkey(string name = "Bob", string species = "Primate", string voice = "Ou, ou, ou", string introduction = "") : base(name, species, voice, introduction = $"{name} jumping from tree to tree")
        {
        }

        public CrazyActionEnumerates.CrazyActionEnum CrazyAction()
        {
            return CrazyActionEnumerates.CrazyActionEnum.Monkey;
        }

        public override string EatFood(string food)
        {
            return $"{this.GetName()} destroying {food} before eating";
        }

        public override string MakeSound()
        {
            return GetVoice();
        }

        public string Run()
        {
            return $"{this.GetName()} running in his cage, like nothing matters";
        }
    }
}
