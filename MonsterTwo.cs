using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace IsometryTwo
{
    internal class MonsterTwo : AbstractMonster
    {
        public MonsterTwo(Point panelCoordCell, Point mapC, Sizes sizes, List<Point> shortPath, int id) : base(sizes, shortPath, mapC, id, 11)
        {
            health = 200;
            numLoot = 200;
            speedMove = 2;
            currentPos = 4;

            sizeCell = sizes.sizeCell;

            //save coordinate drawing
            DrawCoord = new Point(panelCoordCell.X + sizes.renderingOffsetM.X, panelCoordCell.Y + sizes.renderingOffsetM.Y);

            //Сохранение модели.
            modelRight = new Bitmap(sizes.sizeMonsters.X, sizes.sizeMonsters.Y);
            modelLeft = new Bitmap(sizes.sizeMonsters.X, sizes.sizeMonsters.Y);
            modelUp = new Bitmap(sizes.sizeMonsters.X, sizes.sizeMonsters.Y);
            modelDown = new Bitmap(sizes.sizeMonsters.X, sizes.sizeMonsters.Y);

            //Сохранине модели
            string fName = "C://Users//banil//source//repos//IsometryTwo//IsometryTwo//Monsters//MobeTwo//GoingFromMe.png";
            SaverPicture.ReadPicture(fName, modelUp, sizes.sizeMonsters.X, sizes.sizeMonsters.Y);
            fName = "C://Users//banil//source//repos//IsometryTwo//IsometryTwo//Monsters//MobeTwo//GoingRight.png";
            SaverPicture.ReadPicture(fName, modelRight, sizes.sizeMonsters.X, sizes.sizeMonsters.Y);
            fName = "C://Users//banil//source//repos//IsometryTwo//IsometryTwo//Monsters//MobeTwo//GoingLeft.png";
            SaverPicture.ReadPicture(fName, modelLeft, sizes.sizeMonsters.X, sizes.sizeMonsters.Y);
            fName = "C://Users//banil//source//repos//IsometryTwo//IsometryTwo//Monsters//MobeTwo//GoingMe.png";
            SaverPicture.ReadPicture(fName, modelDown, sizes.sizeMonsters.X, sizes.sizeMonsters.Y);

            YPanel = DrawCoord.Y + sizes.sizeMonsters.Y;
            /*
            int widthBit = modelRight.Width / 4;
            int heightBit = modelLeft.Height / 4;

            hitbox = new Point[]
            {
                new Point(positionPanel.X + widthBit, positionPanel.Y + heightBit),
                new Point(positionPanel.X + widthBit * 3, positionPanel.Y + heightBit),
                new Point(positionPanel.X + widthBit * 3, positionPanel.Y + heightBit * 3),
                new Point(positionPanel.X + widthBit, positionPanel.Y + heightBit * 3)
            };*/
        }
    }
}
