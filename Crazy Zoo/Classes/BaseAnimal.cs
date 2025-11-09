using Crazy_Zoo.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Crazy_Zoo.Classes
{
    public abstract class BaseAnimal
    {
        int _age;
        string _name;
        string _species;
        string _introduction;
        string _voice;
        public BaseAnimal(string name, string species, string voice, string introduction, int age = 0) 
        {
            _age = age;
            _name = name;
            _species = species;
            _introduction = introduction;
            _voice = voice;
        }

        public string GetUnique() => _name;
        public string GetOrigin() => this.GetType().Name.Replace(this.GetType().Namespace + ".","");
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
