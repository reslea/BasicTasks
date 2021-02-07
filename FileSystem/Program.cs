using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace FileSystem
{
    class Program
    {
        static void Main(string[] args)
        {
            #region using inside
            //var fs = new FileStream("myFile0.csv", FileMode.Open);
            //try
            //{
            //    using (var sr = new StreamReader(fs, detectEncodingFromByteOrderMarks: true))
            //    {
            //        //var encoding = sr.CurrentEncoding;

            //        var allFile = sr.ReadToEnd();
            //        var header = sr.ReadLine();

            //        var line = string.Empty;
            //        while (!sr.EndOfStream)
            //        {
            //            line = sr.ReadLine();
            //            var personInfo = line.Split(",");
            //        }

            //        Console.WriteLine(allFile);
            //    }
            //}
            //finally
            //{
            //    fs.Dispose();
            //}
            #endregion

            var filePath = "myFile0.csv";
            var isExists = File.Exists(filePath);

            if (!isExists)
            {
                Console.WriteLine("no such file found");
            }
            using var fs = new FileStream(filePath, FileMode.Open);
            using var sr = new StreamReader(fs, detectEncodingFromByteOrderMarks: true);
            
            var header = sr.ReadLine();

            var line = string.Empty;
            while (!sr.EndOfStream)
            {
                line = sr.ReadLine();
                Console.WriteLine(line);
                var personInfo = line.Split(",");
            }

            //var buffer = new byte[4096];
            //fs.Read(buffer, 0, 4096);

            //var encoding = Encoding.UTF8;
            //var decoded = encoding.GetString(buffer);
        }
    }

    class MyClass : IDisposable
    {
        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
