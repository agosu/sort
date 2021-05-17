using System.IO;
using System.Collections;

namespace SortAPI.Services
{
    public class FileService : IStorageService
    {
        private readonly string _path = @"Files\result.txt";

        public void StoreNewResult(ArrayList result)
        {
            if (result != null)
            {
                using StreamWriter file = new StreamWriter(_path);
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
                throw new InvalidDataException("Cannot store null result.");
            }
            
        }

        public ArrayList GetLatestResult()
        {
            if (!File.Exists(_path))
            {
                throw new FileNotFoundException("There is no previous result.");
            }

            using (StreamReader streamReader = File.OpenText(_path))
            {
                //TODO: smarter file to ArrayList conversion
                string[] resultString;
                ArrayList result = new ArrayList();
                string s;
                string fileContent = "";
                while ((s = streamReader.ReadLine()) != null)
                {
                    fileContent += s;
                }
                resultString = fileContent.Split(" ");
                foreach (string number in resultString)
                {
                    result.Add(long.Parse(number));
                }

                return result;
            }
        }
    }
}
