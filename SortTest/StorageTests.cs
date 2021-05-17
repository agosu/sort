using SortAPI.Services;
using System.Collections;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using Xunit;

namespace SortTest
{
    public class StorageTests
    {
        private readonly IStorageService _fileService = new FileService();

        [Fact]
        public void TestFileServiceStoring()
        {
            //TODO: I can't manage to make files to go to the actual build location, so this test does not work
            string resultPath = @"Files\result.txt";
            string expectedPath = @"Files\ok.txt";

            ArrayList inputData = new ArrayList(new long[] { 0, 5, 6, -11, long.MaxValue, 10, 17, long.MinValue, 2, 4 });

            _fileService.StoreNewResult(inputData);

            var resultHash = GetFileHash(resultPath);
            var expectedHash = GetFileHash(expectedPath);

            Xunit.Assert.Equal(expectedHash, resultHash);

        }

        [Fact]
        public void TestFileSreviceRetrieving()
        {
            //TODO: implement when file directory in test project is not a mistery.
        }

        private string GetFileHash(string path)
        {
            var hash = new SHA1Managed();
            var clearBytes = File.ReadAllBytes(path);
            var hashedBytes = hash.ComputeHash(clearBytes);

            return ConvertBytesToHex(hashedBytes);
        }

        private string ConvertBytesToHex(byte[] bytes)
        {
            var stringBuilder = new StringBuilder();
            for (var i = 0; i < bytes.Length; i++)
            {
                stringBuilder.Append(bytes[i].ToString("x"));
            }

            return stringBuilder.ToString();
        }
    }
}
