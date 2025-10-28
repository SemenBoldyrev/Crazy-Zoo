using Crazy_Zoo.Interfaces;
using Crazy_Zoo.Usables.Enums;
using Crazy_Zoo.Usables.Localization.CodeLocalization.AnimalCodeLoc;

namespace Crazy_Zoo.Classes.Animals
{
    internal class Snail : BaseAnimal, ICrazy, IRunnable
    {
        public Snail(string name = "Blob", string species = "Mollusk", string voice = "...", string introduction = "") : base(name, species, voice, introduction = string.Format(AnimalLoc.SnailIntro,name))
        {
        }

        public CrazyActionEnumerates.CrazyActionEnum CrazyAction()
        {
            return CrazyActionEnumerates.CrazyActionEnum.Bacteria;
        }

        public override string EatFood(string food)
        {
            return string.Format(AnimalLoc.SnailEats,this.GetName(),food);
        }

        public override string MakeSound()
        {
            return GetVoice();
        }

        public string Run()
        {
            return string.Format(AnimalLoc.SnailRunAction,this.GetName());
        }
    }
}