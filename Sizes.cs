using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IsometryTwo
{
    // Класс содержащий размеры всех битмапов
    internal class Sizes
    {
         public Point sizeMonsters;
         public Point renderingOffsetM;

         public Point sizeTowers;
         public Point renderingOffsetT;

        public Point sizeCastle;
        public Point renderingOffsetCastle;

        public Point sizeGate;
        public Point renderingOffsetGate;

        public Point sizeObjects;
         public Point renderingOffsetStoneOne;

        public Point sizeObjectsStoneTwo;
        public Point renderingOffsetStoneTwo;
        
        public Point sizeObjectsTree;
        public Point renderingOffsetTree;

        public Point sizeBullet;
        public Point renderingOffsetBullet;

        public int sizeCell;
        public int numCells;
        public Sizes(int sizeCell, int numCells)
        {
            this.sizeCell = sizeCell;
            this.numCells = numCells;

            sizeObjects = new Point(sizeCell - sizeCell / 7, sizeCell * (3 / 2));
            renderingOffsetStoneOne = new Point((sizeCell - sizeCell / 7) / 2 - 5, - sizeCell / 2 - 5);
            
            sizeObjectsStoneTwo = new Point(sizeCell, sizeCell * (3 / 2));
            renderingOffsetStoneTwo = new Point((sizeCell - sizeCell / 7) / 2 - 5, -sizeCell / 2 - 5);

            sizeObjectsTree = new Point(sizeCell + 25, sizeCell * (3 / 2) + 40);
            //renderingOffsetTree = new Point(0, 0);
            renderingOffsetTree = new Point( -10, -1* sizeCell * (3 / 2) - 18);

            sizeMonsters = new Point(sizeCell - sizeCell / 7, sizeCell * (3 / 2));
            renderingOffsetM = new Point((sizeCell - sizeCell / 7) / 2 - 5, -sizeCell / 2 - 5);
            //renderingOffsetM = new Point(0, 0);

            sizeTowers = new Point(sizeCell + 5, sizeCell * 2 + 10 );
            renderingOffsetT = new Point(10, -2*sizeCell);

            sizeCastle = new Point(sizeCell + 30, sizeCell * 2 + 40);
            renderingOffsetCastle = new Point(-15, -2 * sizeCell - 10);

            sizeGate = new Point(sizeCell *2, sizeCell * 2);
            renderingOffsetGate = new Point(0   , -sizeCell *2 + 40+5);

            sizeBullet = new Point(sizeCell/5, sizeCell/5 );
            renderingOffsetBullet = new Point(0,0);
        }
    }
}
