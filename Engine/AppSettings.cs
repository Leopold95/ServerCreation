using System.IO;
using System.Xml.Serialization;

namespace ServerCreation.Engine
{
    public class AppSettings
    {
        public void Save()
        {
            string fileName = Globals.SettingsFile;

            if (File.Exists(fileName))
                File.Delete(fileName);

            using (FileStream fileStream = new FileStream(fileName, FileMode.Create))
            {
                XmlSerializer xser = new XmlSerializer(typeof(AppSettings));
                xser.Serialize(fileStream, this);
                fileStream.Close();
            }
        }

        public static AppSettings GetSettings()
        {
            AppSettings settings;
            string fileName = Globals.SettingsFile;

            if (File.Exists(fileName))
            {
                using (FileStream fileStream = new FileStream(fileName, FileMode.Open))
                {
                    XmlSerializer xser = new XmlSerializer(typeof(AppSettings));
                    settings = (AppSettings)xser.Deserialize(fileStream);
                    fileStream.Close();
                }
            }
            else settings = new AppSettings();

            return settings;
        }


        public bool IsServer { get; set; }
        public string ServerIp { get; set; }
        public int ServerPort { get; set; }
    }

    public static class Globals
    {
        public static string SettingsFile = "settings.xml";
    }
}
