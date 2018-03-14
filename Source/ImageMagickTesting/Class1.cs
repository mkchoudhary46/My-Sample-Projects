using System;
using System.IO;

namespace ImageMagickTesting
{
    public class Class1
    {
        public static void MakeGooglePageSpeedInsightsHappy()
        {
            FileInfo snakewareLogo = new FileInfo( "OptimizeTest.jpg");
                      ImageOptimizer optimizer = new ImageOptimizer();
            optimizer.LosslessCompress(snakewareLogo);

            snakewareLogo.Refresh();
            Console.WriteLine("Bytes after:  " + snakewareLogo.Length);
        }
    }
}
