using Crazy_Zoo.Interfaces;
using Crazy_Zoo.Usables.Enums;
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

        //Retruns CrazyActionEnumerates.CrazyActionEnum, which will show, which crazy actiont to start from main window script
        public CrazyActionEnumerates.CrazyActionEnum CrazyAction()
        {
            return CrazyActionEnumerates.CrazyActionEnum.None;
        }

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
