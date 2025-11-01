using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crazy_Zoo.Classes.Animals.Presets
{
    internal class WormAnimal : BaseAnimal
    {
        public WormAnimal(string name, string species, string voice, string introduction = "", int age = 0) : base(name, species, voice, introduction = $"{name} wiggling like a worm in a jar", age) { }


        public override string EatFood(string food)
        {
            return $"{this.GetName()} sucking on tasty {food}";

        }

        public override string MakeSound()
        {
            return $"{this.GetName()} too weak to even say {this.GetVoice()}";
        }
    }
}
