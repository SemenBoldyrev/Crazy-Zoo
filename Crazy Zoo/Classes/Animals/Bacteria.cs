using Crazy_Zoo.Interfaces;
using Crazy_Zoo.Usables.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crazy_Zoo.Classes.Animals
{
    internal class Bacteria: BaseAnimal, ICrazy
    {
        public Bacteria(string name = "Bacteria", string species = "Prokaryote", string voice = "....", string introduction = "", int age = 0) : base(name, species, voice, introduction = $"{name} multiplying rapidly, \nbut still hardly seen",age)
        {
        }
        public CrazyActionEnumerates.CrazyActionEnum CrazyAction()
        {
            return CrazyActionEnumerates.CrazyActionEnum.Bacteria;
        }
        public override string EatFood(string food)
        {
            return $"{this.GetName()} absorbing {food} through its cell membrane";
        }
        public override string MakeSound()
        {
            return this.GetVoice();
        }
    }
}
