using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IsometryTwo
{
    internal class MonsterThree : AbstractMonster
    {
        public MonsterThree(Point panelCoordCell, Point mapC, Sizes sizes, List<Point> shortPath, int id) : base(sizes, shortPath, mapC, id, 10)
        {
            health = 500;
            numLoot = 1000;
            speedMove = 1;

            sizeCell = sizes.sizeCell;

            //save coordinate drawing
            DrawCoord = new Point(panelCoordCell.X + sizes.renderingOffsetM.X, panelCoordCell.Y + sizes.renderingOffsetM.Y);

            //Сохранение модели.
            modelRight = new Bitmap(sizes.sizeMonsters.X, sizes.sizeMonsters.Y);
            modelLeft = new Bitmap(sizes.sizeMonsters.X, sizes.sizeMonsters.Y);
            modelUp = new Bitmap(sizes.sizeMonsters.X, sizes.sizeMonsters.Y);
            modelDown = new Bitmap(sizes.sizeMonsters.X, sizes.sizeMonsters.Y);

            string fName = "C://Users//banil//source//repos//IsometryTwo//IsometryTwo//Monsters//MobeThree//GoingFromMe.png";
            SaverPicture.ReadPicture(fName, modelUp, sizes.sizeMonsters.X, sizes.sizeMonsters.Y);
            fName = "C://Users//banil//source//repos//IsometryTwo//IsometryTwo//Monsters//MobeThree//GoingRight.png";
            SaverPicture.ReadPicture(fName, modelRight, sizes.sizeMonsters.X, sizes.sizeMonsters.Y);
            fName = "C://Users//banil//source//repos//IsometryTwo//IsometryTwo//Monsters//MobeThree//GoingLeft.png";
            SaverPicture.ReadPicture(fName, modelLeft, sizes.sizeMonsters.X, sizes.sizeMonsters.Y);
            fName = "C://Users//banil//source//repos//IsometryTwo//IsometryTwo//Monsters//MobeThree//GoingMe.png";
            SaverPicture.ReadPicture(fName, modelDown, sizes.sizeMonsters.X, sizes.sizeMonsters.Y);

            YPanel = DrawCoord.Y + sizes.sizeMonsters.Y;
            /*
            //Create hitbox
            int widthBit = modelRight.Width/4;
            int heightBit = modelLeft.Height/4;

            hitbox = new Point[]
            {
                new Point(drawCoord.X + widthBit, drawCoord.Y + heightBit),
                new Point(drawCoord.X + widthBit * 3, drawCoord.Y + heightBit),
                new Point(drawCoord.X + widthBit * 3, drawCoord.Y + heightBit * 3),
                new Point(drawCoord.X + widthBit, drawCoord.Y + heightBit * 3)
            };*/
        }
    }
}
