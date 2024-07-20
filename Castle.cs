using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace IsometryTwo
{
    internal class Castle : IDrawnObject
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
        //тип обьекта
        public int health;
        //
        public Point mapCoordinates;

        public Castle(Point mapC, Point panelCoordCell, Sizes sizes, int id) 
        { 
            Idobject = id;
            mapCoordinates = mapC;
            health = 10000;
            type = 8;

            string fName = "C://Users//banil//source//repos//IsometryTwo//IsometryTwo//Bases//Base.png";

            sizeObject.X = sizes.sizeCastle.X;
            sizeObject.Y = sizes.sizeCastle.Y;

            DrawCoord = new Point(panelCoordCell.X + sizes.renderingOffsetCastle.X, panelCoordCell.Y + sizes.renderingOffsetCastle.Y);

            isometricImage = new Bitmap(sizeObject.X, sizeObject.Y);

            if (fName != null)
            {
                SaverPicture.ReadPicture(fName, isometricImage, sizeObject.X, sizeObject.Y);
            }

            yPanel = DrawCoord.Y + sizeObject.Y;
        }

        public Bitmap GetImage()
        {
            return isometricImage;
        }

    }
}
