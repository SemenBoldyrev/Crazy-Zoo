using Crazy_Zoo.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Windows.Shapes;
using Path = System.IO.Path;

namespace Crazy_Zoo.Usables.Script
{

    //Dont save without archiving, stores data in list for more comfort usage
    internal class JsonLogger : ILogger
    {

        private int index;
        private class LogJsonData
        {
            public int id {  get; set; }
            public DateTime date { get; set; }
            public string message { get; set; }
        }

        private string archiveDerictory = "..\\..\\..\\Usables\\Data\\Archive\\";


        private string justFileName = "log";
        private string fileNameSuffix = ".json";
        private string fileName { get { return justFileName + fileNameSuffix; } }

        private List<LogJsonData> data = new List<LogJsonData>();

        public JsonLogger()
        {
            CheckCurDerictory();
            CreateNewLogFile();
        }

        private void CheckCurDerictory()
        {
            if (!Directory.Exists(archiveDerictory))
            {
                Directory.CreateDirectory(archiveDerictory);
            }
        }

        private void CreateNewLogFile()
        {
            index = 0;
            Log("Application started");
        }

        public void Archive()
        {
            CheckCurDerictory();
            string archFilePath = Path.Combine(archiveDerictory, justFileName + $"-[{DateTime.Now.ToString("yyyy-MM-dd_HH-mm-ss")}]"+fileNameSuffix);
            File.WriteAllText(archFilePath, JsonSerializer.Serialize(data, new JsonSerializerOptions
            {
                WriteIndented = true,
                Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping
            }));
        }

        public void Log(string message)
        {
            data.Add(new LogJsonData()
            {
                id = index,
                date = DateTime.Now,
                message = message
            });
            index++;
        }


        public void SetFileName(string path)
        {
            justFileName = path;
        }
    }
}
