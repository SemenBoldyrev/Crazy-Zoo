using Crazy_Zoo.Interfaces;
using Crazy_Zoo.Usables.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crazy_Zoo.Classes.Animals
{
    internal class Virus : BaseAnimal, ICrazy, IRunnable
    {
        public Virus(string name = "Unknown", string species = "Virus", string voice = "...", string introduction = "", int age = 0) : base(name, species, voice, introduction = $"{name} waiting for his hour to conquer the world",age)
        {
        }

        public CrazyActionEnumerates.CrazyActionEnum CrazyAction()
        {
            return CrazyActionEnumerates.CrazyActionEnum.Monkey;
        }

        public override string EatFood(string food)
        {
            return $"Such powerful creature as {this.GetName()} doesn't need any {food}";
        }

        public override string MakeSound()
        {
            return GetVoice();
        }

        public string Run()
        {
            return $"{this.GetName()} moves in microscopic scale";
        }
    }
}
