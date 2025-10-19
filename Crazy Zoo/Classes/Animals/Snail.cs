using Crazy_Zoo.Interfaces;

namespace Crazy_Zoo.Classes.Animals
{
    internal class Snail : BaseAnimal, ICrazy, IRunnable
    {
        public Snail(string name = "Blob", string species = "Mollusk", string voice = "...", string introduction = "") : base(name, species, voice, introduction = $"{name} gracefully glides over the leaves")
        {
        }

        public override int Action()
        {
            return CrazyAction();
        }

        public int CrazyAction()
        {
            return 1;
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