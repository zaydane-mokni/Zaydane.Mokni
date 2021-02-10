using System;
using Xunit;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Threading.Tasks;

namespace Zaydane.Mokni.Ocr.Test
{
    public class OcrUnitTest
    {
        [Fact]
        public async Task ImagesShouldBeReadCorrectly()
        {
            var executingPath = GetExecutingPath();
            var images = new List<byte[]>();
            foreach (var imagePath in
                Directory.EnumerateFiles(Path.Combine(executingPath, "images")))
            {
                var imageBytes = await File.ReadAllBytesAsync(imagePath);
                images.Add(imageBytes);
            }
            var ocrResults = await new Ocr().ReadAsync(images);

            Assert.Equal(ocrResults[0].Text, @"Visual Studio, etc.). Un MVP peut apporter une vrai valeur à une ESN, une équipe. L'entreprise doit aussi jouer le jeu.");
            Assert.Equal(ocrResults[0].Confidence, 1);
            Assert.Equal(ocrResults[1].Text, @"Et c'est aussi un argument pour négocier la salire.");
            Assert.Equal(ocrResults[1].Confidence, 1);
            Assert.Equal(ocrResults[2].Text, @"Dès le début, .NET s'est appuyé sur un compilateur juste à temps (JIT) pour traduir le code de langage intermédiaire (IL) en code optimisé. Depuis ce temps, Microsoft a construit un runtime géré");
            Assert.Equal(ocrResults[2].Confidence, 1);
        }
        private static string GetExecutingPath()
        {
            var executingAssemblyPath =
                Assembly.GetExecutingAssembly().Location;
            var executingPath =
                Path.GetDirectoryName(executingAssemblyPath);
            return executingPath;
        }
    } 
}