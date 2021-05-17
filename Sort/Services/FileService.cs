using System.IO;
using System.Collections;

namespace SortAPI.Services
{
    public class FileService : IStorageService
    {
        private readonly string _resultPath = @"Files\result.txt";
        private readonly string _performancePath = @"Files\performace.txt";

        public void StoreNewResult(ArrayList result)
        {
            if (result != null || result.Count > 0)
            {
                using StreamWriter file = new StreamWriter(_resultPath);
                for (var i = 0; i < result.Count; i++)
                {
                    file.Write(result[i].ToString());
                    if (i < result.Count - 1)
                    {
                        file.Write(" ");
                    }
                }
            } else
            {
                throw new InvalidDataException("Cannot store null or empty result.");
            }
            
        }

        public void StorePerformance(long performance)
        {
            using StreamWriter file = new StreamWriter(_performancePath);
            file.Write(performance.ToString());
        }

        public ArrayList GetLatestResult()
        {
            if (!File.Exists(_resultPath))
            {
                throw new FileNotFoundException("There is no previous result.");
            }

            using StreamReader streamReader = File.OpenText(_resultPath);
            //TODO: smarter file to ArrayList conversion?
            ArrayList result = new ArrayList();
            string line;
            string fileContent = "";
            while ((line = streamReader.ReadLine()) != null)
            {
                fileContent += line;
            }

            string[] stringArr = fileContent.Split(" ");
            foreach (string number in stringArr)
            {
                result.Add(long.Parse(number));
            }

            return result;
        }

        public long GetLatestPerformance()
        {
            if (!File.Exists(_performancePath))
            {
                throw new FileNotFoundException("There is no previous performance.");
            }

            using StreamReader streamReader = File.OpenText(_performancePath);
            string perfString = streamReader.ReadLine();
            return long.Parse(perfString);
        }
    }
}
