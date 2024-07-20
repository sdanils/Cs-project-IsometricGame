using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IsometryTwo
{
    internal class InteriorObject : IDrawnObject
    {
        int Idobject;
        public int IDobject { get { return Idobject; } set { Idobject = value; } }

        int yPanel;
        public int YPanel { get { return yPanel; } set { yPanel = value; } }

        Point drawCoord;
        public Point DrawCoord { get { return drawCoord; } set { drawCoord = value; } }

        int type;
        public int TypeObj
        {
            get { return type; }
            set { type = value; }
        }

        //размеры битмапа
        public Point sizeObject;
        //Модель
        public Bitmap isometricImage;

        public InteriorObject(Sizes sizes, int type, Point panelCoordCell, int Id)
        {
            this.type = type;
            string fName = null;

            if (type == 1)
            {
                fName = "C://Users//banil//source//repos//IsometryTwo//IsometryTwo//PictureObjects//stoneOne.png";

                sizeObject.X = sizes.sizeObjects.X;
                sizeObject.Y = sizes.sizeObjects.Y;

                drawCoord.X = sizes.renderingOffsetStoneOne.X + panelCoordCell.X;
                drawCoord.Y = sizes.renderingOffsetStoneOne.Y + panelCoordCell.Y;
            }
            else if(type == 3)
            {
                fName = "C://Users//banil//source//repos//IsometryTwo//IsometryTwo//PictureObjects//treeOne.png";

                sizeObject.X = sizes.sizeObjectsTree.X;
                sizeObject.Y = sizes.sizeObjectsTree.Y;

                drawCoord.X = sizes.renderingOffsetTree.X + panelCoordCell.X;
                drawCoord.Y = sizes.renderingOffsetTree.Y + panelCoordCell.Y;
            }
            else if (type == 2)
            {
                fName = "C://Users//banil//source//repos//IsometryTwo//IsometryTwo//PictureObjects//stoneTwo.png";

                sizeObject.X = sizes.sizeObjectsStoneTwo.X;
                sizeObject.Y = sizes.sizeObjectsStoneTwo.Y;

                drawCoord.X = sizes.renderingOffsetStoneTwo.X + panelCoordCell.X;
                drawCoord.Y = sizes.renderingOffsetStoneTwo.Y + panelCoordCell.Y;
            }

            isometricImage = new Bitmap(sizeObject.X, sizeObject.Y);

            if (fName != null)
            {
                SaverPicture.ReadPicture(fName, isometricImage, sizeObject.X, sizeObject.Y);
            }

            yPanel = drawCoord.Y + sizeObject.Y;

            Idobject = Id;
        }

        public Bitmap GetImage()
        {
            return isometricImage;
        }
    }
}
