using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASCIIDraw
{
    
    internal class ImageConverter
    {
        private char[] ascii_garadient = new char[] { '.', ':', '-', '=', '+', '*', '#', '%', '@' };
      private  Bitmap _image;
        public ImageConverter(Bitmap image)
        {
            _image = image;

        }

        public char[][] Convert()
        {
            char[][] result = new char[_image.Height][];
            for (int y = 0; y < _image.Height; y++)
            {
                result[y] = new char[_image.Width];
                for (int x = 0; x < _image.Width; x++)
                {
                    int index = (int)Map(_image.GetPixel(x, y).R, 0, 255, 0, ascii_garadient.Length - 1);
                    result[y][x] = ascii_garadient[index];
                }
            }

            return result;
        }

        public float Map(float valueToMap , float start1 , float end1 ,float start2 , float end2) 
        {
            return ((valueToMap - start1) / (end1 - start1) * (end2 - start2) + start2);
        }
    }
}
