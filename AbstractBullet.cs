using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IsometryTwo
{
    abstract class AbstractBullet : IDrawnObject
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

        public Bitmap isometricImage;
        //Цель снаряда
        public AbstractMonster Purpose;
        public Point derictionMove;
        public int speedMove;
        public int damage;
        public int boost;

        public Point sizeObject;

        public AbstractBullet(int type, int id, int damage, AbstractMonster monster, Sizes sizes, int boost)
        {
            Idobject = id;
            this.type = type;
            Purpose = monster;
            this.damage = damage;
            speedMove = sizes.numCells / 6;
            this.boost = boost;
        }
        public Bitmap GetImage()
        {
            return isometricImage;
        }

        public bool Step()
        {
            PointF derCalc = new PointF((Purpose.DrawCoord.X + 10 - DrawCoord.X), (Purpose.DrawCoord.Y + 10 - DrawCoord.Y));

            double length = Math.Sqrt(derCalc.X * derCalc.X + derCalc.Y * derCalc.Y);

            if (length < speedMove * boost)
            {
                return false;
            }
            else
            {
                PointF normalizedVector = new PointF(speedMove * boost * derCalc.X / (float)length, speedMove*boost * derCalc.Y / (float)length);

                derictionMove.X = (int)normalizedVector.X;
                derictionMove.Y = (int)normalizedVector.Y;

                drawCoord.X += derictionMove.X;
                drawCoord.Y += derictionMove.Y;

                YPanel = drawCoord.Y + sizeObject.Y;

                return true;
            }
        }
    }
}
