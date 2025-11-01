using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crazy_Zoo.Interfaces
{
    public interface ILogger
    {
        public void Log(string message);
        public void SetFileName(string path);
        public void Archive();
    }
}
