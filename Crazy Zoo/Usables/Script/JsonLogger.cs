using Crazy_Zoo.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;

namespace Crazy_Zoo.Usables.Script
{
    internal class JsonContainer { string time; string message; }
    internal class JsonLogger : ILogger
    {
        private string directory = "..\\..\\..\\Usables\\Data\\Json\\";
        private string fileName = "log_test.json";
        private string justFileName = "log_test";

        public JsonLogger()
        {
            CheckCurDerictory();
            CreateNewLogFile();
        }

        private void CheckCurDerictory()
        {
            if (!Directory.Exists(directory))
            {
                Directory.CreateDirectory(directory);
            }
        }

        private void CreateNewLogFile()
        {
            string filePath = Path.Combine(directory, fileName);
            CheckCurDerictory();
            File.AppendAllText(filePath, $"== Log started on [{System.DateTime.Now.ToString()}] ==\n");
        }

        public void Archive()
        {
            string archFilePath = Path.Combine("..\\..\\..\\Usables\\Data\\Archive\\", justFileName + $"-[{DateTime.Now.ToString("yyyy-MM-dd_HH-mm-ss")}].txt");
            string oldFilePath = Path.Combine(directory, fileName);

            try
            {
                File.Move(oldFilePath, archFilePath);
                File.Delete(oldFilePath);
                CreateNewLogFile();
            }
            catch { return; }
        }

        public void Log(string message)
        {
            var path = Path.Combine(directory, fileName);
            File.AppendAllText(path, $"[{System.DateTime.Now.ToString()}] -- '{message}'\n");
        }


        public void SetFileName(string path)
        {
            fileName = path + ".json";
            justFileName = path;
        }
    }
}
