using Crazy_Zoo.Classes;
using Crazy_Zoo.Classes.Animals;
using Crazy_Zoo.Classes.Animals.Presets;
using Crazy_Zoo.Interfaces;
using Crazy_Zoo.Usables.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Animation;

namespace Crazy_Zoo.Usables.Script
{
    public  class AnimalFactory: IAnimalFactory
    {
        public  BaseAnimal CreatAnimal(string _origin ,string _name, int _age, string _species = "Extinct", string _voice = "none", string _introduction = "none")
        {
            switch (_origin)
            {
                case AnimalNameSet.BIRD_ANIMAL: return new BirdAnimal(_name, _species, _voice, _introduction, _age);
                case AnimalNameSet.FISH_ANIMAL: return new FishAnimal(_name, _species, _voice, _introduction, _age);
                case AnimalNameSet.GROUND_ANIMAL: return new GroundAnimal(_name, _species, _voice, _introduction, _age);
                case AnimalNameSet.WORM_ANIMAL: return new WormAnimal(_name, _species, _voice, _introduction, _age);
                case AnimalNameSet.BACTERIA: return new Bacteria(_name, _species, age: _age);
                case AnimalNameSet.HORSE: return new Horse(_name, _species, age: _age);
                case AnimalNameSet.HUMAN: return new Human(_name, _species, age: _age);
                case AnimalNameSet.MONKEY: return new Monkey(_name, _species, age: _age);
                case AnimalNameSet.SNAIL: return new Snail(_name, _species, age: _age);
                case AnimalNameSet.VIRUS: return new Virus(_name, _species, age: _age);
                case AnimalNameSet.ZEBRA: return new Zebra(_name, _species, age: _age);
                default: return new WormAnimal(_name, _species, _voice, _introduction, _age);
            }
        }
    }
}
