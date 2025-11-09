using Crazy_Zoo.Classes;
using Crazy_Zoo.Classes.Animals;
using Crazy_Zoo.Classes.Animals.Presets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Animation;

namespace Crazy_Zoo.Usables.Script
{
    public static class AnimalFactory
    {
        public static BaseAnimal CreatAnimal(string _origin ,string _name, int _age, string _species = "none", string _voice = "none", string _introduction = "none")
        {
            switch (_origin)
            {
                case "BirdAnimal": return new BirdAnimal(_name, _species, _voice, _introduction, _age);
                case "FishAnimal": return new FishAnimal(_name, _species, _voice, _introduction, _age);
                case "GroundAnimal": return new GroundAnimal(_name, _species, _voice, _introduction, _age);
                case "WormAnimal": return new WormAnimal(_name, _species, _voice, _introduction, _age);
                case "Bacteria": return new Bacteria(_name, _species, age: _age);
                case "Horse": return new Horse(_name, _species, age: _age);
                case "Human": return new Human(_name, _species, age: _age);
                case "Monkey": return new Monkey(_name, _species, age: _age);
                case "Snail": return new Snail(_name, _species, age: _age);
                case "Virus": return new Virus(_name, _species, age: _age);             
                case "Zebra": return new Zebra(_name, _species, age: _age);
                default: return new WormAnimal(_name, _species, _voice, _introduction, _age);

            }
        }
    }
}
