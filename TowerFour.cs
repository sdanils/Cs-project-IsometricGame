using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IsometryTwo
{
    internal class TowerFour : AbstractTower
    {
        static public int cost = 2000;
        System.Windows.Forms.Timer timerShout;


        //Sizes sizes, int type, Point panelCoordCell, int Id
        public TowerFour(Sizes sizes, int type, Point panelCoordCell, int id, Point mapC, List<AbstractBullet> bullets, List<AbstractMonster> monsters, ListDrawnObjects listDrawn) : base(type, id, mapC, sizes, bullets, monsters, listDrawn)
        {
            string fName = null;

            fName = "C://Users//banil//source//repos//IsometryTwo//IsometryTwo//PictureTowers//imageTowerFour.png";

            sizeObject.X = sizes.sizeTowers.X;
            sizeObject.Y = sizes.sizeTowers.Y;

            DrawCoord = new Point(panelCoordCell.X + sizes.renderingOffsetT.X, panelCoordCell.Y + sizes.renderingOffsetT.Y);

            isometricImage = new Bitmap(sizeObject.X, sizeObject.Y);

            if (fName != null)
            {
                SaverPicture.ReadPicture(fName, isometricImage, sizeObject.X, sizeObject.Y);
            }

            YPanel = DrawCoord.Y + sizeObject.Y;

            timerShout = new System.Windows.Forms.Timer();
            timerShout.Interval = 1200;
            timerShout.Tick += TimerShout_Tick;
            timerShout.Start();
        }

        private void TimerShout_Tick(object sender, EventArgs e)
        {
            Shout();
        }

        public void Shout()
        {
            AbstractMonster nearestMonster = null;
            double minDistance = double.MaxValue;

            foreach (AbstractMonster monster in monsters)
            {
                double distance = Math.Sqrt(Math.Pow(monster.DrawCoord.X - DrawCoord.X, 2) + Math.Pow(monster.DrawCoord.Y - DrawCoord.Y, 2));

                if (distance < minDistance)
                {
                    minDistance = distance;
                    nearestMonster = monster;
                }
            }

            if (nearestMonster != null)
            {
                allBullets.Add(new BulletFour(sizes, 16, new Point(DrawCoord.X - sizes.renderingOffsetT.X, DrawCoord.Y - sizes.renderingOffsetT.Y), listDrawns.ListOBJ.Count, nearestMonster));
                listDrawns.AddElement(allBullets[allBullets.Count - 1]);
            }
        }
    }
}
