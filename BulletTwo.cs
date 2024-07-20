using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IsometryTwo
{
    internal class BulletTwo : AbstractBullet
    {
        public BulletTwo(Sizes sizes, int type, Point panelCoordCell, int id, AbstractMonster monster) : base(type, id, 20, monster, sizes, 2)
        {
            string fName = null;

            fName = "C://Users//banil//source//repos//IsometryTwo//IsometryTwo//PictureBullets//imageBulletOne.png";

            sizeObject.X = sizes.sizeBullet.X;
            sizeObject.Y = sizes.sizeBullet.Y;

            DrawCoord = new Point(panelCoordCell.X + sizes.sizeTowers.X / 2, panelCoordCell.Y - sizes.sizeTowers.Y / 2);

            isometricImage = new Bitmap(sizeObject.X, sizeObject.Y);

            if (fName != null)
            {
                SaverPicture.ReadPicture(fName, isometricImage, sizeObject.X, sizeObject.Y);
            }

            YPanel = DrawCoord.Y + sizeObject.Y;
        }
    }
}
