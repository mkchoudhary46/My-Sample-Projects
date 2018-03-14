using ImageMagick;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            MakeGooglePageSpeedInsightsHappy();
        }

        public static void MakeGooglePageSpeedInsightsHappy()
        {
            // Read from file
            using (MagickImage image = new MagickImage(@"C:\Users\manoj\Desktop\3435 - Copy (2).jpg"))
            {
                MagickGeometry size = new MagickGeometry(100, 100);
                // This will resize the image to a fixed size without maintaining the aspect ratio.
                // Normally an image will be resized to fit inside the specified size.
                size.IgnoreAspectRatio = true;

                image.Resize(size);

                // Save the result
                image.Write(@"C:\Users\manoj\Desktop\3435 - Copy (3).jpg");
            }
            Console.ReadKey();
        }

        public static void LosslessCompress()
        {
            FileInfo snakewareLogo = new FileInfo("Snakeware.jpg");

            Console.WriteLine("Bytes before: " + snakewareLogo.Length);

            ImageOptimizer optimizer = new ImageOptimizer();
            optimizer.LosslessCompress(snakewareLogo);

            snakewareLogo.Refresh();
            Console.WriteLine("Bytes after:  " + snakewareLogo.Length);

            var image = new ImageMagickObject.MagickImage();
            image.Convert("InputImage.jpg", "-resize", "50%", "OutputImage.jpg");
        }


        public Bitmap ScaleImage(Bitmap image, double scale)
        {
            int newWidth = (int)(image.Width * scale);
            int newHeight = (int)(image.Height * scale);

            Bitmap result = new Bitmap(newWidth, newHeight, PixelFormat.Format24bppRgb);
            result.SetResolution(image.HorizontalResolution, image.VerticalResolution);

            using (Graphics g = Graphics.FromImage(result))
            {
                g.InterpolationMode = InterpolationMode.HighQualityBicubic;
                g.CompositingQuality = CompositingQuality.HighQuality;
                g.SmoothingMode = SmoothingMode.HighQuality;
                g.PixelOffsetMode = PixelOffsetMode.HighQuality;

                g.DrawImage(image, 0, 0, result.Width, result.Height);
            }
            return result;
        }
    }
}
