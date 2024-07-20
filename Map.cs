using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.AxHost;

namespace IsometryTwo
{
    internal class Map
    {
        // Array cells
        private CellMap[,] cells;
        public int sizeMap;

        public Map(int sizeMap, int sizeCell, Random rand, Sizes sizes)
        {
            this.sizeMap = sizeMap;

            cells = new CellMap[sizeMap, sizeMap];

            for (int x = 0; x < sizeMap; x++)
            {
                for(int y = 0; y < sizeMap; y++)
                {
                    cells[x, y] = new CellMap(x, y, sizeCell, rand, sizes);
                }
            }
        }
        public CellMap GetCell(int x, int y)
        {
            return cells[x, y];
        }
    }
}
