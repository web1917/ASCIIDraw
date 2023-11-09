using System;
using System.IO;
using System.Drawing;
using ASCIIDraw;

internal class Program
{
        private static void Main(string[] args)
    {
        Console.WriteLine("Hello, press any key....");
        Console.ReadKey();
        while (true)
        {
            var bitmap = new Bitmap("./test.jpg");
            bitmap = Resize(bitmap);
            bitmap.ToGrayGaradient();
            ASCIIDraw.ImageConverter converter = new ASCIIDraw.ImageConverter(bitmap);
            char[][] ascii_image = converter.Convert();
            foreach (var item in ascii_image)
            {
                Console.WriteLine(item);
            }
            Console.SetCursorPosition(0, 0);
            Console.ReadKey();
        }
    }
    static Bitmap Resize(Bitmap image)
    {
        int max_width = 450;
        double width_offset = 2.5;
        double height = image.Height / width_offset * max_width / image.Width;
        if (image.Width > max_width || image.Height > height)
            image = new Bitmap(image, new Size(max_width, (int)height));
        return image;
    }
}