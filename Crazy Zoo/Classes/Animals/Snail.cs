using Crazy_Zoo.Interfaces;
using Crazy_Zoo.Usables.Enums;

namespace Crazy_Zoo.Classes.Animals
{
    internal class Snail : BaseAnimal, ICrazy, IRunnable
    {
        public Snail(string name = "Blob", string species = "Mollusk", string voice = "...", string introduction = "") : base(name, species, voice, introduction = $"{name} gracefully glides over the leaves")
        {
        }

        public CrazyActionEnumerates.CrazyActionEnum CrazyAction()
        {
            return CrazyActionEnumerates.CrazyActionEnum.Bacteria;
        }

        public override string EatFood(string food)
        {
            return $"{this.GetName()} eats {food} slowly";
        }

        public override string MakeSound()
        {
            return GetVoice();
        }

        public string Run()
        {
            return $"{this.GetName()} hurries with all his might";
        }
    }
}