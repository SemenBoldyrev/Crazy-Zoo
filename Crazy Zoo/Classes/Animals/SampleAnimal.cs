using Crazy_Zoo.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Crazy_Zoo.Classes.Animals
{
    internal class SampleAnimal: BaseAnimal, ICrazy, IRunnable
    {
        public SampleAnimal(string name, string species, string introduction, string voice) : base(name, species, introduction, voice) { }

        public void CrazyAction()
        {
            MessageBox.Show("crazy");
        }

        // returns null, if have to do crazy action, doesnt currently works
        public override string Action()
        {
            CrazyAction();
            return null;
        }

        public override string EatFood()
        {
            throw new NotImplementedException();
        }

        public override string MakeSound()
        {
            return GetVoice();
        }

        public void Run()
        {
            throw new NotImplementedException();
        }
    }
}
