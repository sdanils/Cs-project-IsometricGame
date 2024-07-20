using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace IsometryTwo
{
    internal class Gate : IDrawnObject
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

        public Point sizeObject;
        //Модель
        public Bitmap isometricImage;
        //тип обьекта
        public int health;
        //
        public Point mapCoordinates;
        //
        public Sizes sizes;
        //
        public Point panelCoordCell;
        //
        public List<Point> shortPath;

        List<AbstractMonster> monsters;
        ListDrawnObjects drawnObjects;

        System.Windows.Forms.Timer timer;

        public Point3D settingsCreater;
        Random randomObject;

        public Gate(Point mapC, Point panelCoordCell, Sizes sizes, int id, List<AbstractMonster> monsters, ListDrawnObjects draO, Point3D settings, Random randomObject)
        {
            type = 9;
            this.sizes = sizes;
            mapCoordinates = mapC;
            health = 100000;
            Idobject = id;

            settingsCreater = settings;
            this.monsters = monsters;
            this.drawnObjects = draO;
            this.panelCoordCell = panelCoordCell;
            this.randomObject = randomObject;

            string fName = "C://Users//banil//source//repos//IsometryTwo//IsometryTwo//Bases//Portal.png";

            sizeObject.X = sizes.sizeGate.X;
            sizeObject.Y = sizes.sizeGate.Y;

            DrawCoord = new Point(panelCoordCell.X + sizes.renderingOffsetGate.X, panelCoordCell.Y + sizes.renderingOffsetGate.Y);

            isometricImage = new Bitmap(sizeObject.X, sizeObject.Y);

            if (fName != null)
            {
                SaverPicture.ReadPicture(fName, isometricImage, sizeObject.X, sizeObject.Y);
            }

            yPanel = drawCoord.Y + sizeObject.Y;

            timer = new System.Windows.Forms.Timer();
            timer.Interval = 1000;
            timer.Tick += Timer_Tick;
            timer.Start();
            this.randomObject = randomObject;
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            if (Form1.timerStop == false && randomObject.Next(0,3) ==1)
            {
                CreateMonster();
            }
        }

        public void CreateMonster()
        {
            if (health >= 100)
            {
                int choose = randomObject.Next(0, 101);

                if (choose <= settingsCreater.X)
                {
                    monsters.Add(new MonsterOne(panelCoordCell, mapCoordinates, sizes, shortPath, drawnObjects.ListOBJ.Count));
                }
                else if (choose <= settingsCreater.Y)
                {
                    monsters.Add(new MonsterTwo(panelCoordCell, mapCoordinates, sizes, shortPath, drawnObjects.ListOBJ.Count));
                }
                else
                {
                    monsters.Add(new MonsterThree(panelCoordCell, mapCoordinates, sizes, shortPath, drawnObjects.ListOBJ.Count));
                }
                drawnObjects.AddElement(monsters[monsters.Count - 1]);
                health -= monsters[monsters.Count - 1].health;
            }
        }

        public Bitmap GetImage()
        {
            return isometricImage;
        }
    }
}
