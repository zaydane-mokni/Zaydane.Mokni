using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace Zaydane.Mokni.Ocr.Console
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var images = new List<byte[]>();
            foreach (var path in args)
            {
                var bytes = await File.ReadAllBytesAsync(path);
                images.Add(bytes);
            }
            
            var ocrResults = await new Ocr().ReadAsync(images);
            foreach (var ocrResult in ocrResults)
            {
                System.Console.WriteLine($"Confidence : {ocrResult.Confidence}");
                System.Console.WriteLine($"Text : {ocrResult.Text}");
            }
        }
    }
}