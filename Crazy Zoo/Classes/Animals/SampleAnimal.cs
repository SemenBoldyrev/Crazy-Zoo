using Crazy_Zoo.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace Crazy_Zoo.Classes.Animals
{
    internal class SampleAnimal: BaseAnimal, ICrazy
    {
        public SampleAnimal(string name, string species, string introduction, string voice) : base(name, species, introduction, voice) { }

        //Retruns int, which will show, which crazy actiont to start from main window script
        public int CrazyAction()
        {
            return 1;
        }

        // returns crazy action, if have to do crazy action, else reyurn 0 (or just return any value without adding ICrazy)
        public override int Action() => CrazyAction();


        // gets food, then returns str reaction on it
        public override string EatFood(string food)
        {
            return $"{this.GetName()} eating {food}";
        }

        // returns voice of animal
        public override string MakeSound()
        {
            return GetVoice();
        }
    }
}
