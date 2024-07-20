using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace IsometryTwo
{
    internal class SaverPicture
    {
         public static void ReadPicture(string fName, Bitmap isometricImage, int width, int height)
        {
            using (Image originalImage = Image.FromFile(fName))
            {
                // Используем Graphics для рисования изображения на битмапе
                using (Graphics gSeck = Graphics.FromImage(isometricImage))
                {
                    gSeck.DrawImage(originalImage, new Rectangle(0, 0, width, height));
                }
            }
        }
    }
}
