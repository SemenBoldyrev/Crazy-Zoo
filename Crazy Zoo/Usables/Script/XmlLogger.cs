using Crazy_Zoo.Interfaces;
using System.IO;

using System.Xml;

namespace Crazy_Zoo.Usables.Script
{
    internal class XmlLogger: ILogger
    {

        private string archiveDerictory = "..\\..\\..\\Usables\\Data\\Archive\\";
        private string nativeDirection = "..\\..\\..\\Usables\\Data\\Xml\\";


        private string justFileName = "log_test";
        private string fileNameSuffix = ".xml";
        private string fileName { get { return justFileName + fileNameSuffix; } }

        private XmlDocument xmlDoc;
        XmlElement curRoot;

        public XmlLogger()
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
            if (!Directory.Exists(nativeDirection))
            {
                Directory.CreateDirectory(nativeDirection);
            }
        }

        private void CreateNewLogFile()
        {
            xmlDoc = new XmlDocument();
            curRoot = xmlDoc.CreateElement("log");
            xmlDoc.AppendChild(curRoot);

            CheckCurDerictory();
            Log("Application started");
        }

        public void Archive()
        {
            CheckCurDerictory();
            string archFilePath = Path.Combine(archiveDerictory, justFileName + $"-[{DateTime.Now.ToString("yyyy-MM-dd_HH-mm-ss")}]"+fileNameSuffix);
            string oldFilePath = Path.Combine(nativeDirection, fileName);

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
            XmlElement date = xmlDoc.CreateElement("Date");
            date.InnerText = DateTime.Now.ToString();
            XmlElement givenMessage = xmlDoc.CreateElement("Message");
            givenMessage.InnerText = message;

            curRoot.AppendChild(date);
            date.AppendChild(givenMessage);

            xmlDoc.Save(Path.Combine(nativeDirection, fileName));
        }


        public void SetFileName(string path)
        {
            justFileName = path;
        }
    }
}
