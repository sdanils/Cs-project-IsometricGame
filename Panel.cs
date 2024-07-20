using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;
using System.Threading;
using System.Security.Cryptography.X509Certificates;
using System.Timers;
using System.Security.Policy;
using System.Xml.Linq;

namespace IsometryTwo
{
    class IsometricPanel : Panel
    {
        Map map;
        Sizes sizes;
        ListDrawnObjects drawnObjects;
        Background backScene;
        BuilderTower builderTower;

        public int speedMoveScene;

        int borderOffset;
        private Point ofssetPanel;
        public Point OffsetPanel
        {
            get { return ofssetPanel; }
            set{ ofssetPanel = value; }
        }

        public IsometricPanel(Map mapF, Sizes sizesF, ListDrawnObjects list, BuilderTower builderTower)
        {
            //Двойная буферизация
            this.SetStyle(ControlStyles.AllPaintingInWmPaint |
                ControlStyles.OptimizedDoubleBuffer |
                ControlStyles.UserPaint, true);

            // Создаем карту
            map = mapF;
            drawnObjects = list;
            this.sizes = sizesF;
            this.builderTower = builderTower;
            this.ofssetPanel = new Point(0, 0);
            speedMoveScene = 8;
            borderOffset = sizesF.numCells * sizesF.sizeCell;

            //Creane backgrpund
            string fName = "C://Users//banil//source//repos//IsometryTwo//IsometryTwo//BackgroundsScene//MoonTwo.png";
            backScene = new Background(fName, sizesF, speedMoveScene);

            // Обработчик события Paint для отрисовки изометрической карты
            this.Paint += DrawIsometricMap;
            this.MouseDoubleClick += IsometricPanel_MouseDoubleClick;
        }

        private void IsometricPanel_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (builderTower.chooseTower != 0 && builderTower.EnoughMoney() == true)
            {
                Point coordClick = new Point(e.X - ofssetPanel.X * speedMoveScene, e.Y - ofssetPanel.Y * speedMoveScene);
                Point chooseCell = new Point(0, 0);
                bool searchFlag = false;

                for (int y = 0; y < map.sizeMap; y++)
                {
                    for (int x = 0; x < map.sizeMap; x++)
                    {
                        Point n = map.GetCell(x, y).arrayIsoCoords[0];
                        Point n2 = map.GetCell(x, y).arrayIsoCoords[2];
                        if (coordClick.X > n.X && coordClick.X < n2.X && coordClick.Y > n.Y && coordClick.Y < n2.Y)
                        {
                            chooseCell.X = x;
                            chooseCell.Y = y;
                            searchFlag= true;
                            break;
                        }                  
                    }
                    if (searchFlag) break;
                }

                if(builderTower.shortPath.Contains<Point>(chooseCell) || map.GetCell(chooseCell.X, chooseCell.Y).typeObject != 0)
                {
                    return;
                }
                else
                {
                    builderTower.CreateTower(sizes, map.GetCell(chooseCell.X, chooseCell.Y).arrayIsoCoords[0], drawnObjects.ListOBJ.Count, chooseCell);
                }
            }
        }

        private void DrawIsometricMap(object sender, PaintEventArgs e)
        {
            // Создайте объект Graphics для рисования
            Graphics grapScene = e.Graphics;

            int bitmapWidth = e.ClipRectangle.Width; // Примерное значение ширины
            int bitmapHeight = e.ClipRectangle.Width; // Примерное значение высоты

            // Создание объекта Bitmap заданного размера
            Bitmap bitmapScene = new Bitmap(bitmapWidth, bitmapHeight);

            // Создание Graphics из Bitmap для отрисовки
            using (Graphics grapBitmap = Graphics.FromImage(bitmapScene))
            {
                // Background
                //grapBitmap.FillRectangle(new SolidBrush(Color.FromArgb(50, 50, 50)), ClientRectangle);

                grapBitmap.DrawImage(backScene.background, ofssetPanel.X * speedMoveScene, ofssetPanel.Y * speedMoveScene);

                for (int y = 0; y < map.sizeMap; y++)
                {
                    for (int x = 0; x < map.sizeMap; x++)
                    {
                        Point[] points = new Point[]
                        {
                            new Point(map.GetCell(x, y).arrayIsoCoords[0].X +ofssetPanel.X*speedMoveScene, map.GetCell(x, y).arrayIsoCoords[0].Y +ofssetPanel.Y * speedMoveScene),
                            new Point(map.GetCell(x, y).arrayIsoCoords[1].X +ofssetPanel.X*speedMoveScene, map.GetCell(x, y).arrayIsoCoords[1].Y +ofssetPanel.Y * speedMoveScene),
                            new Point(map.GetCell(x, y).arrayIsoCoords[2].X +ofssetPanel.X * speedMoveScene, map.GetCell(x, y).arrayIsoCoords[2].Y +ofssetPanel.Y * speedMoveScene),
                            new Point(map.GetCell(x, y).arrayIsoCoords[3].X +ofssetPanel.X * speedMoveScene, map.GetCell(x, y).arrayIsoCoords[3].Y +ofssetPanel.Y * speedMoveScene)
                        };

                        grapBitmap.FillPolygon(map.GetCell(x, y).solidBrushCell, points);
                    }
                }

                for (int i = 0; i < drawnObjects.ListOBJ.Count; i++)
                {
                    if (Math.Abs(drawnObjects.ListOBJ[i].DrawCoord.X) < 10000 && Math.Abs(drawnObjects.ListOBJ[i].DrawCoord.Y) < 10000)
                    {
                        grapBitmap.DrawImage(drawnObjects.ListOBJ[i].GetImage(), drawnObjects.ListOBJ[i].DrawCoord.X + ofssetPanel.X * speedMoveScene, drawnObjects.ListOBJ[i].DrawCoord.Y + ofssetPanel.Y * speedMoveScene);
                    }
                }
            }

            grapScene.DrawImage(bitmapScene, 0, 0);
        }
    }
}
