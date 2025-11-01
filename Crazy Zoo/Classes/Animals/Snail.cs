using Crazy_Zoo.Interfaces;
using Crazy_Zoo.Usables.Enums;
using Crazy_Zoo.Usables.Script;

namespace Crazy_Zoo.Classes.Animals
{
    internal class Snail : BaseAnimal, ICrazy, IRunnable, INightAnimal
    {
        public Snail(string name = "Blob", string species = "Mollusk", string voice = "...", string introduction = "", int age = 0) : base(name, species, voice, introduction = $"{name} gracefully glides over the leaves",age)
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

        public void NightBehavior()
        {
            SignalBus.writeDial?.Invoke(this.Run());
        }

        public string Run()
        {
            return $"{this.GetName()} hurries with all his might";
        }
    }
}