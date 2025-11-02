using Crazy_Zoo.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

namespace Crazy_Zoo.Usables.Script
{
    internal class TextLogger : ILogger
    {
        private string directory = "..\\..\\..\\Usables\\Data\\Text\\";
        private string fileName = "log_test.txt";

        public void Archive()
        {
            string archFilePath = $"..\\..\\..\\Usables\\Data\\Archive\\log-{DateTime.Now.ToString()}.txt";
            var oldFilePath = Path.Combine(directory, fileName);
            File.Copy(oldFilePath, archFilePath);
            File.Move(Path.Combine(directory, fileName), "..\\..\\..\\Usables\\Data\\Archive");
            File.Delete(oldFilePath);
        }

        public void Log(string message)
        {
            var path = Path.Combine(directory, fileName);
            File.AppendAllText(path,$"[{System.DateTime.Now.ToString()}] -- '{message}'\n");
        }


        public void SetFileName(string path)
        {
            fileName = path + ".txt";
        }
    }
}
