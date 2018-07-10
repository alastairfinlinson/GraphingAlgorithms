using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using GraphingAlgorithms.GraphObjects;
using GraphingAlgorithmsUI.Helpers;
using GraphingAlgorithmsUI.Settings;

namespace GraphingAlgorithms.Helpers
{
    public interface IFileReader
    {
        string ReadSample(string location);
        AppSettings ReadSettingsFile(string settingsFileLocation);
    }

    public class FileReader : IFileReader
    {
        const string DATA_FILE_LOCATIONS = @"D:\Programming\C#\GraphingAlgorithmsUI\GraphingAlgorithmsUI\DataFiles\location";

        private JsonParser jsonParser = new JsonParser();

        public string ReadSample(string location)
        {
            using (StreamReader reader = new StreamReader(Path.Combine(DATA_FILE_LOCATIONS + location + ".txt")))
            {
                return reader.ReadToEnd();     
            }
        }

        public AppSettings ReadSettingsFile(string settingsFileLocation)
        {
            AppSettings settings = null;
            using (StreamReader reader = new StreamReader(settingsFileLocation))
            {
                string fileData = reader.ReadToEnd();
                settings = jsonParser.ReadJson<AppSettings>(fileData);
            }
            return settings;
        }
    }
}