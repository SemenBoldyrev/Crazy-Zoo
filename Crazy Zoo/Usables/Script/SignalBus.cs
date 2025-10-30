using Crazy_Zoo.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crazy_Zoo.Usables.Script
{
    public static class SignalBus
    {
        public static Action<string> ?writeDial;
        public static Action<BaseAnimal> ?removeSelf;
    }
}
