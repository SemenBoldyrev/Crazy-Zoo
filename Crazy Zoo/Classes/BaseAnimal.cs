using Crazy_Zoo.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crazy_Zoo.Classes
{
    public abstract class BaseAnimal
    {
        int _index;
        int _age;
        string _name;
        string _species;
        string _introduction;
        string _voice;
        public BaseAnimal(string name, string species, string voice, string introduction, int age = 0) 
        {
            _index = App.Services.GetService<IIndexer>().GetUnique();
            _age = age;
            _name = name;
            _species = species;
            _introduction = introduction;
            _voice = voice;
        }

        public int GetUnique() => _index;
        public int GetAge() => _age;
        public string GetName() => _name;
        public string GetSpecies() => _species;
        public string GetIntroduction() => _introduction;
        public string GetVoice() => _voice;

        public abstract string EatFood(string food);
        public abstract string MakeSound();

        public override string ToString()
        {
            return $"{GetSpecies()}: {_name}";
        }
    }
}
