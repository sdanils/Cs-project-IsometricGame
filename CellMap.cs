using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace IsometryTwo
{
        internal class CellMap
        {
            //Координаты мира
            public Point MapCoord;
            //Координаты панели. Массив координат углов клетки в панели. Первый элемент - верхний левый угол
            public Point[] arrayIsoCoords;
            //Длина стороны в мире
            public int side;
            //Тип распаложенного обьекта
            public int typeObject;
            //
            Sizes sizes;
            //
            public SolidBrush solidBrushCell;

            public CellMap(int wX, int hY, int s, Random rand, Sizes sizes)
            {
                MapCoord.X = wX;
                MapCoord.Y = hY;
                typeObject = 0;
                side = s;

                this.sizes = sizes;

                arrayIsoCoords = new Point[] {
                        new Point(hY * side + wX * (side / 2) + 30, wX * side / 2 + 100),
                        new Point(hY * side + wX * (side / 2) + 30 + side, wX * side / 2 + 100),
                        new Point(hY * side + wX * (side / 2) + 30 +  (int)(side * 1.5) , wX * side / 2 + 100 + side / 2),
                        new Point(hY * side + wX * (side / 2) + 30 +  (side / 2), wX * side / 2 + 100 + side / 2)
                };
            /*
            new Point(hY * side + wX * (side / 2) + 30, wX * side / 2 + 100),
                        new Point(hY * side + wX * (side / 2) + 30 + side, wX * side / 2 + 100),
                        new Point(hY * side + wX * (side / 2) + 30 + (int)(side * 1.5), wX * side / 2 + 100 + side / 2),
                        new Point(hY * side + wX * (side / 2) + 30 + (side / 2), wX * side / 2 + 100 + side / 2)
            */
                int color = rand.Next(70, 80);
                Color cellColor = Color.FromArgb(color, color, color);
                solidBrushCell = new SolidBrush(cellColor);
            }
        }
}
