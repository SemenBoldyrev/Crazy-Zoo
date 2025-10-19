using Crazy_Zoo.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crazy_Zoo.Classes.Animals
{
    internal class Virus : BaseAnimal, ICrazy, IRunnable
    {
        public Virus(string name = "Unknown", string species = "Virus", string voice = "...", string introduction = "") : base(name, species, voice, introduction = $"{name} waiting for his hour to conquer the world")
        {
        }

        public override int Action()
        {
            return CrazyAction();
        }

        public int CrazyAction()
        {
            return 2;
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
