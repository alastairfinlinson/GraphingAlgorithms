using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GraphingAlgorithms.GraphObjects;
using GraphingAlgorithms.Helpers;
using GraphingAlgorithmsUI.Helpers;
using GraphingAlgorithmsUI.Settings;

namespace GraphingAlgorithmsUI.Services
{
    public enum SampleSize
    {
        Small,
        Medium,
        Large,
        CrazyBalls
    }

    public interface IDataInterfaceProvider
    {
        IEnumerable<INode> ReadNodeCollectionFile(SampleSize sampleSize);
        IEnumerable<INode> GenerateNodeScatter(int sampleSize);

    }

    public class DataInterfaceProvider : IDataInterfaceProvider
    {
        const string SETTINGS_FILE_LOCATION = @"D:\Programming\C#\GraphingAlgorithmsUI\GraphingAlgorithmsUI\Settings\Settings.txt";

        readonly IFileReader _fileReader;

        AppSettings appSettings = new AppSettings();    

        public DataInterfaceProvider(IFileReader fileReader)
        {
            _fileReader = fileReader;
            ReadSettingsFile();
        }

        private void ReadSettingsFile()
        {
            appSettings = _fileReader.ReadSettingsFile(SETTINGS_FILE_LOCATION);
        }

        public IEnumerable<INode> ReadNodeCollectionFile(SampleSize sampleSize)
        {
            string fileName = string.Empty;
            switch (sampleSize)
            {
                case SampleSize.Small:
                    {
                        fileName = "SmallSample";
                        break;
                    }                   
                case SampleSize.Medium:
                    {
                        fileName = "MediumSample";
                        break;
                    }
                case SampleSize.Large:
                    {
                        fileName = "LargeSample";
                        break;
                    }                    
                case SampleSize.CrazyBalls:
                    {
                        fileName = "CrazyBallsSample";
                        break;
                    }                    
            }
            JsonParser jsonParser = new JsonParser();
            return jsonParser.ReadJson<IEnumerable<INode>>(_fileReader.ReadSample(fileName));
        }

        public IEnumerable<INode> GenerateNodeScatter(int sampleSize)
        {
            Random random = new Random();
            for (int i = 0; i < sampleSize; i++)
            {
                yield return new Node(new CartesianPoint(random.Next(0, 200), random.Next(0, 120)), "");
            }
        }
    }
}