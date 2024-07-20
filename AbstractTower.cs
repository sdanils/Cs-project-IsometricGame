using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace IsometryTwo
{
    internal class AbstractTower : IDrawnObject
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

        public Sizes sizes;
        public Bitmap isometricImage;

        public Point sizeObject;
        public Point mapCoordinates;

         public List<AbstractBullet> allBullets;
        public ListDrawnObjects listDrawns;
        public List<AbstractMonster> monsters;

        public AbstractTower(int type, int id, Point mapC, Sizes sizes, List<AbstractBullet> bullets, List<AbstractMonster> monsters, ListDrawnObjects listDrawn)
        {
            this.sizes = sizes;
            Idobject = id;
            mapCoordinates = mapC;
            this.type= type;

            allBullets = bullets;
            listDrawns = listDrawn;
            this.monsters = monsters;
        }

        public Bitmap GetImage()
        {
            return isometricImage;
        }
    }
}
