using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IsometryTwo
{
    internal class BuilderTower
    {
        public int chooseTower;
        public List<AbstractTower> towers;
        public List<Point> shortPath;
        public BalanceAndResult plaingInfo;

        List<AbstractBullet> allBullets;
        ListDrawnObjects listDrawns;
        List<AbstractMonster> monsters;

        public BuilderTower(List<AbstractBullet> allBullets, ListDrawnObjects listDrawns, List<AbstractMonster> monsters, List<AbstractTower> towers, BalanceAndResult plaingInfo, List<Point> shortPath)
        {
            this.allBullets = allBullets;
            this.listDrawns = listDrawns;
            this.monsters = monsters;
            this.towers = towers;
            this.shortPath = shortPath;
            this.plaingInfo = plaingInfo;
            chooseTower = 0;
        }
        public bool EnoughMoney()
        {
            if (chooseTower == 4 && plaingInfo.money < TowerOne.cost || chooseTower == 5 && plaingInfo.money < TowerTwo.cost || chooseTower == 6 && plaingInfo.money < TowerThree.cost || chooseTower == 7 && plaingInfo.money < TowerFour.cost)
            {
                return false;
            }
            else return true;
        }

        public void CreateTower(Sizes sizes, Point panelCoordCell, int id, Point mapC)
        {
            if (Form1.timerStop == false)
            {
                if (chooseTower == 4)
                {
                    towers.Add(new TowerOne(sizes, 4, panelCoordCell, id, mapC, allBullets, monsters, listDrawns));
                    plaingInfo.money -= TowerOne.cost;
                }
                else if (chooseTower == 5)
                {
                    towers.Add(new TowerTwo(sizes, 5, panelCoordCell, id, mapC, allBullets, monsters, listDrawns));
                    plaingInfo.money -= TowerTwo.cost;
                }
                else if (chooseTower == 6)
                {
                    towers.Add(new TowerThree(sizes, 6, panelCoordCell, id, mapC, allBullets, monsters, listDrawns));
                    plaingInfo.money -= TowerThree.cost;
                }
                else if (chooseTower == 7)
                {
                    towers.Add(new TowerFour(sizes, 7, panelCoordCell, id, mapC, allBullets, monsters, listDrawns));
                    plaingInfo.money -= TowerFour.cost;
                }
                chooseTower = 0;

                listDrawns.AddElement(towers[towers.Count - 1]);
            }
        }
    }
}
