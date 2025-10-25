using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crazy_Zoo.Classes
{
    public abstract class BaseAnimal
    {
        string _name;
        string _species;
        string _introduction;
        string _voice;
        public BaseAnimal(string name, string species, string voice, string introduction) 
        {
            _name = name;
            _species = species;
            _introduction = introduction;
            _voice = voice;
        }

        public string GetName() => _name;
        public string GetSpecies() => _species;
        public string GetIntroduction() => _introduction;
        public string GetVoice() => _voice;

        public abstract string EatFood(string food);
        public abstract string MakeSound();
    }
}
