using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IsometryTwo
{
    abstract internal class AbstractMonster : IDrawnObject
    {
        public int health;
        public int speedMove;
        public int currentPos;
        public int numLoot;
        public int sizeCell;
        public int nextCell;
        public bool deadFlag;
        public bool frozesFlag;

        public int offsetBottom;

        public Point derictionMove;
        //public Point[] hitbox;

        public List<Point> shortPath;

        public Bitmap modelRight;
        public Bitmap modelLeft;
        public Bitmap modelUp;
        public Bitmap modelDown;

        public Point changePosition;

        //Interface
        int Idobject;
        public int IDobject { get { return Idobject; } set { Idobject = value; } }

        int yPanel;
        public int YPanel { get { return yPanel; } set { yPanel = value; } }

        Point drawCoord;
        public Point DrawCoord { get { return drawCoord; } set
            {
                drawCoord = value;
                YPanel = value.Y + offsetBottom;
            }
        }

        int type;
        public int TypeObj
        {
            get { return type; }
            set { type = value; }
        }
        //

        public Point DerictionMove
        {
            get { return derictionMove; }
            set
            {
                derictionMove = value;
                if (value.X == 1 && value.Y == 0) currentPos = 1;
                else if (value.X == -1 && value.Y == 0) currentPos = 2;
                else if (value.X == -1 && value.Y == -1) currentPos = 3;
                else if (value.X == 1 && value.Y == 1) currentPos = 4;
            }
        }

        public AbstractMonster(Sizes sizes, List<Point> shortPath, Point mapC, int id, int type)
        {
            Idobject = id;
            this.type = type;
            deadFlag = false;
            frozesFlag= false;
            nextCell = 1;
            this.shortPath = shortPath;

            derictionMove = new Point(0, 0);
            changePosition = new Point(0, 0);

            currentPos = 4;

            offsetBottom = sizes.sizeMonsters.Y;
        }

        private void SearchDirection()
        {
            if (nextCell > 0 && nextCell <= shortPath.Count - 1)
            {
                if (shortPath[nextCell].X - shortPath[nextCell - 1].X == -1)
                {
                    DerictionMove = new Point(-1, -1);
                }
                else if (shortPath[nextCell].X - shortPath[nextCell - 1].X == 1)
                {
                    DerictionMove = new Point(1, 1);
                }
                else if (shortPath[nextCell].Y - shortPath[nextCell - 1].Y == -1)
                {
                    DerictionMove = new Point(-1, 0);
                }
                else if (shortPath[nextCell].Y - shortPath[nextCell - 1].Y == 1)
                {
                    DerictionMove = new Point(1, 0);
                }
            }
        }
        public bool Step()
        {
            //При замарозки монстр не двигается
            if(frozesFlag == true)
            {
                return true;
            }

            if (nextCell != shortPath.Count)
            {
                SearchDirection();
                if (nextCell > 0)
                {                                             
                    DrawCoord = new Point(drawCoord.X + derictionMove.X, drawCoord.Y + derictionMove.Y);
                }
                else
                {
                    return false;
                }

                changePosition.X += Math.Abs(derictionMove.X);
                changePosition.Y += Math.Abs(derictionMove.Y );

                //Проверка наизменение клетки
                if (changePosition.X >= sizeCell || changePosition.Y >= sizeCell / 2)
                {
                    if (shortPath.Count == 0)
                    {
                        this.health = 0;
                    }

                    nextCell++;

                    SearchDirection();

                    changePosition.X = 0;
                    changePosition.Y = 0;
                }

                return true;
            }

            return false;
        }

        public Bitmap GetImage()
        {
            if (currentPos == 4) return modelDown;
            else if (currentPos == 3) return modelUp;
            else if (currentPos == 2) return modelLeft;
            else return modelRight;
        }

    }
}
