using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TrayNotify;
using System.Xml.Linq;

namespace IsometryTwo
{
    internal class PanelInfo : Panel
    {
        
        public BalanceAndResult plaingInfo;
        System.Windows.Forms.Timer timer;
        BuilderTower builderTower;
        Brush brush;
        Font font;

        Bitmap back0;
        Bitmap back1;
        Bitmap back2;
        Bitmap back3;
        Bitmap back4;
        Bitmap towerOne;
        Bitmap towerTwo;
        Bitmap towerThree;
        Bitmap towerFour;


        public PanelInfo(BalanceAndResult plaingInfo, BuilderTower builderTower)
        {
            this.SetStyle(ControlStyles.AllPaintingInWmPaint |
                ControlStyles.OptimizedDoubleBuffer |
            ControlStyles.UserPaint, true);
            this.plaingInfo = plaingInfo;

            brush = new SolidBrush(Color.FromArgb(13, 70, 204));
            font = new Font("Lucida Console", 12);

            SaveImages();

            this.Paint += PanelInfo_Paint;
            this.MouseDoubleClick += PanelInfo_MouseDoubleClick;
            timer = new System.Windows.Forms.Timer();
            timer.Interval = 250;
            timer.Tick += Timer_Tick;
            timer.Start();
            this.builderTower = builderTower;
        }

        private void PanelInfo_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            int y = Height;
            if(e.Y > Height / 3 && e.Y < Height * 2 / 3)
            {
                if(e.X < Width * 3 / 4 - towerTwo.Width)
                {
                    if (builderTower.chooseTower == 4)
                    {
                        builderTower.chooseTower = 0;
                    }
                    else
                    {
                        builderTower.chooseTower = 4;
                    }
                }
                else
                {
                    if (builderTower.chooseTower == 5)
                    {
                        builderTower.chooseTower = 0;
                    }
                    else
                    {
                        builderTower.chooseTower = 5;
                    }
                }
            }
            else if(e.Y > Height * 2 / 3)
            {
                if (e.X < Width * 3 / 4 - towerTwo.Width )
                {
                    if (builderTower.chooseTower == 6)
                    {
                        builderTower.chooseTower = 0;
                    }
                    else
                    {
                        builderTower.chooseTower = 6;
                    }
                }
                else
                {
                    if (builderTower.chooseTower == 7)
                    {
                        builderTower.chooseTower = 0;
                    }
                    else
                    {
                        builderTower.chooseTower = 7;
                    }
                }
            }
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            this.Invalidate();
        }

        private void PanelInfo_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.DrawImage(GetCurrentBack(), new Rectangle(0, 0, this.Width, this.Height));
            g.DrawString($"All damage:", font, brush, new PointF(20, 20));
            g.DrawString($"{plaingInfo.score}", font, brush, new PointF(30, 40));

            if (builderTower.chooseTower == 4 && plaingInfo.money < TowerOne.cost || builderTower.chooseTower == 5 && plaingInfo.money < TowerTwo.cost || builderTower.chooseTower == 6 && plaingInfo.money < TowerThree.cost || builderTower.chooseTower == 7 && plaingInfo.money < TowerFour.cost)
            {
                g.DrawString($"Coins: ", font, Brushes.Red, new PointF(20, 60));
                g.DrawString($"{plaingInfo.money}", font, Brushes.Red, new PointF(30, 80));
            }
            else
            {
                g.DrawString($"Coins: ", font, brush, new PointF(20, 60));
                g.DrawString($"{plaingInfo.money}", font, brush, new PointF(30, 80));
            }
            g.DrawString($"Healht", font, brush, new PointF(20, 110));
            g.DrawString($"castle:", font, brush, new PointF(20, 130));
            g.DrawString($"{plaingInfo.castle.health}", font, brush, new PointF(30, 150));
            g.DrawString($"Portal", font, brush, new PointF(20, 170));
            g.DrawString($"resource:", font, brush, new PointF(20, 190));
            g.DrawString($"{plaingInfo.gate.health}", font, brush, new PointF(30, 210));

            g.DrawImage(towerOne, Width / 4 - towerOne.Width/2, Height/3);
            g.DrawImage(towerTwo, Width*3 / 4 - towerTwo.Width / 2, Height / 3);
            g.DrawImage(towerThree, Width / 4 - towerOne.Width / 2, Height*2 / 3);
            g.DrawImage(towerFour, Width * 3 / 4 - towerTwo.Width / 2, Height * 2 / 3);
            
            g.DrawString($"{TowerOne.cost}", font, brush, new PointF(Width / 4 - towerOne.Width / 2 + 5, Height / 3 + towerOne.Height + 20));
            g.DrawString($"{TowerTwo.cost}", font, brush, new PointF(Width * 3 / 4 - towerTwo.Width / 2 + 5, Height / 3 + towerTwo.Height + 20));
            g.DrawString($"{TowerThree.cost}", font, brush, new PointF(Width / 4 - towerOne.Width / 2 + 5, Height * 2 / 3 + towerThree.Height + 20));
            g.DrawString($"{TowerFour.cost}", font, brush, new PointF(Width * 3 / 4 - towerTwo.Width / 2 + 5, Height * 2 / 3 + towerFour.Height + 20));
        }
        void SaveImages()
        {
            
            back0 = new Bitmap(300, 1000);
            string fName = "C://Users//banil//source//repos//IsometryTwo//IsometryTwo//PanelInfoBack//BackNoChoose.png";
            if (fName != null)
            {
                SaverPicture.ReadPicture(fName, back0, back0.Width, back0.Height);
            }

            back1 = new Bitmap(300, 1000);
            fName = "C://Users//banil//source//repos//IsometryTwo//IsometryTwo//PanelInfoBack//BackChooseOne.png";
            if (fName != null)
            {
                SaverPicture.ReadPicture(fName, back1, back1.Width, back1.Height);
            }

            back2 = new Bitmap(300, 1000);
            fName = "C://Users//banil//source//repos//IsometryTwo//IsometryTwo//PanelInfoBack//BackChooseTwo.png";
            if (fName != null)
            {
                SaverPicture.ReadPicture(fName, back2, back2.Width, back2.Height);
            }

            back3 = new Bitmap(300, 1000);
            fName = "C://Users//banil//source//repos//IsometryTwo//IsometryTwo//PanelInfoBack//BackChooseThree.png";
            if (fName != null)
            {
                SaverPicture.ReadPicture(fName, back3, back3.Width, back3.Height);
            }

            back4 = new Bitmap(300, 1000);
            fName = "C://Users//banil//source//repos//IsometryTwo//IsometryTwo//PanelInfoBack//BackChooseFour.png";
            if (fName != null)
            {
                SaverPicture.ReadPicture(fName, back4, back4.Width, back4.Height);
            }

            Point sT = new Point(50, 150);

            fName = "C://Users//banil//source//repos//IsometryTwo//IsometryTwo//PictureTowers//imageTowerOne.png";
            towerOne = new Bitmap(sT.X, sT.Y);
            if (fName != null)
            {
                SaverPicture.ReadPicture(fName, towerOne, sT.X, sT.Y);
            }

            fName = "C://Users//banil//source//repos//IsometryTwo//IsometryTwo//PictureTowers//imageTowerTwo.png";
            towerTwo = new Bitmap(sT.X, sT.Y);
            if (fName != null)
            {
                SaverPicture.ReadPicture(fName, towerTwo, sT.X, sT.Y);
            }

            fName = "C://Users//banil//source//repos//IsometryTwo//IsometryTwo//PictureTowers//imageTowerThree.png";
            towerThree = new Bitmap(sT.X, sT.Y);
            if (fName != null)
            {
                SaverPicture.ReadPicture(fName, towerThree, sT.X, sT.Y);
            }

            fName = "C://Users//banil//source//repos//IsometryTwo//IsometryTwo//PictureTowers//imageTowerFour.png";
            towerFour = new Bitmap(sT.X, sT.Y);
            if (fName != null)
            {
                SaverPicture.ReadPicture(fName, towerFour, sT.X, sT.Y);
            }
        }
        Bitmap GetCurrentBack()
        {
            if (builderTower.chooseTower == 0) return back0;
            else if (builderTower.chooseTower == 4) return back1;
            else if (builderTower.chooseTower == 5) return back2;
            else if (builderTower.chooseTower == 6) return back3;
            else return back4;
        }
    }
}
