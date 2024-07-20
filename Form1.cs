using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using System.Windows.Forms.DataVisualization.Charting;
using System.Diagnostics.Eventing.Reader;

namespace IsometryTwo
{
    public partial class Form1 : Form
    {
        //
        Button ButtonPlay;
        Button ButtonExit;
        Button ButtonPlayScore;
        Button ButtonPlayLevel;
        Button ButtonBack;
        Button ButtonPlayLevelOne;
        Button ButtonPlayLevelTwo;
        Button ButtonPlayLevelThree;
        Button ButtonPlayLevelFour;
        Button ButtonBackLevels;

        Button ButtonExitMenu;

        private TableLayoutPanel tableLayoutPanel;
        BuilderTower builderTower;
        PanelInfo panelInfo;
        IsometricPanel scenePlay;
        Map map;
        Random randomObject;
        System.Windows.Forms.Timer formTimer;
        Sizes sizes;
        int sizeMap;

        //Игровые обьекты
        Gate gate;
        Castle castle;
        BalanceAndResult plaingInfo;

        ListDrawnObjects drawnObjects;

        List<AbstractMonster> monsters;
        List<AbstractBullet> bullets;
        List<AbstractTower> towers;

        public static bool timerStop;

        //Контролеры зажатия клавиш
        bool upPress;
        bool downPress;
        bool rightPress;
        bool leftPress;

        // Скорость перемещения сцены
        private Point ofssetPanel;

        public Form1()
        {
            InitializeComponent();

            CreateButtons();

            timerStop = false;

            randomObject = new Random();

            this.KeyDown += Form1_KeyDown;
            this.KeyUp += Form1_KeyUp;
            this.Resize += Form1_Resize1;

            ofssetPanel = new Point(0, 0);

            upPress = false;
            downPress = false;
            rightPress = false;
            leftPress = false;
        }

        private void Form1_Resize1(object sender, EventArgs e)
        {
                //panelInfo.Width = this.Width;
                ButtonPlay.Location = new Point((this.ClientSize.Width - ButtonPlay.Width) / 2, (this.ClientSize.Height - ButtonPlay.Height) / 2 - ButtonPlay.Height);
                ButtonExit.Location = new Point((this.ClientSize.Width - ButtonExit.Width) / 2, (this.ClientSize.Height - ButtonExit.Height) / 2 + ButtonExit.Height);
                ButtonPlayScore.Location = new Point((this.ClientSize.Width - ButtonPlayScore.Width) / 2, (this.ClientSize.Height - ButtonPlayScore.Height) / 2 - ButtonPlayScore.Height);
                ButtonPlayLevel.Location = new Point((this.ClientSize.Width - ButtonPlayLevel.Width) / 2, (this.ClientSize.Height - ButtonPlayLevel.Height) / 2 + ButtonPlayLevel.Height);
                ButtonBack.Location = new Point((this.ClientSize.Width - ButtonExit.Width) / 2, (this.ClientSize.Height - ButtonExit.Height) / 2 + ButtonPlayLevel.Height * 3);
                ButtonPlayLevelOne.Location = new Point((this.ClientSize.Width - ButtonPlayLevelOne.Width) / 2, (this.ClientSize.Height - ButtonPlayLevelOne.Height) / 2 - ButtonPlayLevelOne.Height * 5);
                ButtonPlayLevelTwo.Location = new Point((this.ClientSize.Width - ButtonPlayLevelTwo.Width) / 2, (this.ClientSize.Height - ButtonPlayLevelTwo.Height) / 2 - ButtonPlayLevelTwo.Height * 3);
                ButtonPlayLevelThree.Location = new Point((this.ClientSize.Width - ButtonPlayLevelThree.Width) / 2, (this.ClientSize.Height - ButtonPlayLevelThree.Height) / 2 - ButtonPlayLevelThree.Height);
                ButtonPlayLevelFour.Location = new Point((this.ClientSize.Width - ButtonPlayLevelFour.Width) / 2, (this.ClientSize.Height - ButtonPlayLevelFour.Height) / 2 + ButtonPlayLevelFour.Height);
                ButtonBackLevels.Location = new Point((this.ClientSize.Width - ButtonBackLevels.Width) / 2, (this.ClientSize.Height - ButtonBackLevels.Height) / 2 + ButtonBackLevels.Height * 3);
                //ButtonExitMenu.Location = ButtonPlayLevelOne.Location = new Point((this.ClientSize.Width - ButtonExitMenu.Width) / 2, (this.ClientSize.Height - ButtonExitMenu.Height) / 2);
        }

        public void CreateButtons()
        {
            PictureBox pictureBox = new PictureBox();
            pictureBox.Image = Image.FromFile("C://Users/banil//source//repos//IsometryTwo//IsometryTwo//BackgroundsScene//BackgroudForm.png");
            pictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox.Dock = DockStyle.Fill;

            ButtonPlay = CreateButton("Play");
            ButtonPlay.Click += ButtonPlay_Click;
            ButtonExit = CreateButton("Exit");
            ButtonExit.Click += ButtonExit_Click;

            ButtonPlay.Location = new Point((this.ClientSize.Width - ButtonPlay.Width) / 2, (this.ClientSize.Height - ButtonPlay.Height) / 2 - ButtonPlay.Height);
            ButtonExit.Location = new Point((this.ClientSize.Width - ButtonExit.Width) / 2, (this.ClientSize.Height - ButtonExit.Height) / 2 + ButtonExit.Height);
            this.Controls.Add(pictureBox);
            this.Controls.Add(ButtonPlay);
            this.Controls.Add(ButtonExit);

            ButtonPlay.BringToFront();
            ButtonExit.BringToFront();

            ButtonPlayScore = CreateButton("Score");
            ButtonPlayScore.Click += ButtonPlayScore_Click;
            ButtonPlayLevel = CreateButton("Level");
            ButtonPlayLevel.Click += ButtonPlayLevel_Click;
            ButtonBack = CreateButton("Back");
            ButtonBack.Click += ButtonBack_Click;

            this.Controls.Add(ButtonPlayScore);
            this.Controls.Add(ButtonPlayLevel);
            this.Controls.Add(ButtonBack);

            ButtonPlayScore.Enabled = false;
            ButtonPlayScore.Visible = false;
            ButtonPlayLevel.Enabled = false;
            ButtonPlayLevel.Visible = false;
            ButtonBack.Enabled = false;
            ButtonBack.Visible = false;

            ButtonPlayScore.BringToFront();
            ButtonPlayLevel.BringToFront();
            ButtonBack.BringToFront();

            ButtonPlayScore.Location = new Point((this.ClientSize.Width - ButtonPlayScore.Width) / 2, (this.ClientSize.Height - ButtonPlayScore.Height) / 2 - ButtonPlayScore.Height);
            ButtonPlayLevel.Location = new Point((this.ClientSize.Width - ButtonPlayLevel.Width) / 2, (this.ClientSize.Height - ButtonPlayLevel.Height) / 2 + ButtonPlayLevel.Height);
            ButtonBack.Location = new Point((this.ClientSize.Width - ButtonExit.Width) / 2, (this.ClientSize.Height - ButtonExit.Height) / 2 + ButtonPlayLevel.Height * 3);

            ButtonPlayLevelOne = CreateButton("Level one");
            ButtonPlayLevelOne.Click += ButtonPlayLevelOne_Click;
            ButtonPlayLevelTwo = CreateButton("Level two");
            ButtonPlayLevelTwo.Click += ButtonPlayLevelTwo_Click;
            ButtonPlayLevelThree = CreateButton("Level Three");
            ButtonPlayLevelThree.Click += ButtonPlayLevelThree_Click;
            ButtonPlayLevelFour = CreateButton("Level Four");
            ButtonPlayLevelFour.Click += ButtonPlayLevelFour_Click;
            ButtonBackLevels = CreateButton("Back");
            ButtonBackLevels.Click += ButtonBackLevels_Click;

            this.Controls.Add(ButtonPlayLevelOne);
            this.Controls.Add(ButtonPlayLevelTwo);
            this.Controls.Add(ButtonPlayLevelThree);
            this.Controls.Add(ButtonPlayLevelFour);
            this.Controls.Add(ButtonBackLevels);

            ButtonPlayLevelOne.Enabled = false;
            ButtonPlayLevelOne.Visible = false;
            ButtonPlayLevelTwo.Enabled = false;
            ButtonPlayLevelTwo.Visible = false;
            ButtonPlayLevelThree.Enabled = false;
            ButtonPlayLevelThree.Visible = false;
            ButtonPlayLevelFour.Enabled = false;
            ButtonPlayLevelFour.Visible = false;
            ButtonBackLevels.Enabled = false;
            ButtonBackLevels.Visible = false;

            ButtonPlayLevelOne.BringToFront();
            ButtonPlayLevelTwo.BringToFront();
            ButtonPlayLevelThree.BringToFront();
            ButtonPlayLevelFour.BringToFront();
            ButtonBackLevels.BringToFront();

            ButtonPlayLevelOne.Location = new Point((this.ClientSize.Width - ButtonPlayLevelOne.Width) / 2, (this.ClientSize.Height - ButtonPlayLevelOne.Height) / 2 - ButtonPlayLevelOne.Height * 5);
            ButtonPlayLevelTwo.Location = new Point((this.ClientSize.Width - ButtonPlayLevelTwo.Width) / 2, (this.ClientSize.Height - ButtonPlayLevelTwo.Height) / 2 - ButtonPlayLevelTwo.Height* 3);
            ButtonPlayLevelThree.Location = new Point((this.ClientSize.Width - ButtonPlayLevelThree.Width) / 2, (this.ClientSize.Height - ButtonPlayLevelThree.Height) / 2 - ButtonPlayLevelThree.Height);
            ButtonPlayLevelFour.Location = new Point((this.ClientSize.Width - ButtonPlayLevelFour.Width) / 2, (this.ClientSize.Height - ButtonPlayLevelFour.Height) / 2 + ButtonPlayLevelFour.Height);
            ButtonBackLevels.Location = new Point((this.ClientSize.Width - ButtonBackLevels.Width) / 2, (this.ClientSize.Height - ButtonBackLevels.Height) / 2 + ButtonBackLevels.Height * 3);
        }

        private void ButtonPlayLevelTwo_Click(object sender, EventArgs e)
        {
            ButtonPlayLevelOne.Enabled = false;
            ButtonPlayLevelOne.Visible = false;
            ButtonPlayLevelTwo.Enabled = false;
            ButtonPlayLevelTwo.Visible = false;
            ButtonPlayLevelThree.Enabled = false;
            ButtonPlayLevelThree.Visible = false;
            ButtonPlayLevelFour.Enabled = false;
            ButtonPlayLevelFour.Visible = false;
            ButtonBackLevels.Enabled = false;
            ButtonBackLevels.Visible = false;

            foreach (Control control in this.Controls)
            {
                control.Dispose();
            }

            this.Controls.Clear();

            StartPlay(2);
        }
        private void ButtonPlayLevelThree_Click(object sender, EventArgs e)
        {
        }
        private void ButtonPlayLevelFour_Click(object sender, EventArgs e)
        {
        }
        private void ButtonBackLevels_Click(object sender, EventArgs e)
        {
            ButtonPlayLevelOne.Enabled = false;
            ButtonPlayLevelOne.Visible = false;
            ButtonPlayLevelTwo.Enabled = false;
            ButtonPlayLevelTwo.Visible = false;
            ButtonPlayLevelThree.Enabled = false;
            ButtonPlayLevelThree.Visible = false;
            ButtonPlayLevelFour.Enabled = false;
            ButtonPlayLevelFour.Visible = false;
            ButtonBackLevels.Enabled = false;
            ButtonBackLevels.Visible = false;

            ButtonPlayScore.Enabled = true;
            ButtonPlayScore.Visible = true;
            ButtonPlayLevel.Enabled = true;
            ButtonPlayLevel.Visible = true;
            ButtonBack.Enabled = true;
            ButtonBack.Visible = true;
        }
        private void ButtonPlayLevel_Click1(object sender, EventArgs e)
        {

        }
        private void ButtonPlayLevelOne_Click(object sender, EventArgs e)
        {
            ButtonPlayLevelOne.Enabled = false;
            ButtonPlayLevelOne.Visible = false;
            ButtonPlayLevelTwo.Enabled = false;
            ButtonPlayLevelTwo.Visible = false;
            ButtonPlayLevelThree.Enabled = false;
            ButtonPlayLevelThree.Visible = false;
            ButtonPlayLevelFour.Enabled = false;
            ButtonPlayLevelFour.Visible = false;
            ButtonBackLevels.Enabled = false;
            ButtonBackLevels.Visible = false;

            foreach (Control control in this.Controls)
            {
                control.Dispose();
            }

            this.Controls.Clear();

            StartPlay(1);
        }
        private void ButtonPlayLevel_Click(object sender, EventArgs e)
        {
            ButtonPlayScore.Enabled = false;
            ButtonPlayScore.Visible = false;
            ButtonPlayLevel.Enabled = false;
            ButtonPlayLevel.Visible = false;
            ButtonBack.Enabled = false;
            ButtonBack.Visible = false;

            ButtonPlayLevelOne.Enabled = true;
            ButtonPlayLevelOne.Visible = true;
            ButtonPlayLevelTwo.Enabled = true;
            ButtonPlayLevelTwo.Visible = true;
            ButtonPlayLevelThree.Enabled = true;
            ButtonPlayLevelThree.Visible = true;
            ButtonPlayLevelFour.Enabled = true;
            ButtonPlayLevelFour.Visible = true;
            ButtonBackLevels.Enabled = true;
            ButtonBackLevels.Visible = true;
        }
        private void ButtonPlayScore_Click(object sender, EventArgs e)
        {
            ButtonPlayLevelOne.Enabled = false;
            ButtonPlayLevelOne.Visible = false;
            ButtonPlayLevelTwo.Enabled = false;
            ButtonPlayLevelTwo.Visible = false;
            ButtonPlayLevelThree.Enabled = false;
            ButtonPlayLevelThree.Visible = false;
            ButtonPlayLevelFour.Enabled = false;
            ButtonPlayLevelFour.Visible = false;
            ButtonBackLevels.Enabled = false;
            ButtonBackLevels.Visible = false;

            foreach (Control control in this.Controls)
            {
                control.Dispose();
            }

            this.Controls.Clear();

            StartPlay(0);
        }
        private void ButtonExit_Click(object sender, EventArgs e)
        {
            this.Close(); 
        }
        private void ButtonPlay_Click(object sender, EventArgs e)
        {
            ButtonPlay.Enabled = false;
            ButtonPlay.Visible = false;
            ButtonExit.Enabled = false;
            ButtonExit.Visible = false;

            ButtonPlayScore.Enabled = true;
            ButtonPlayScore.Visible = true;
            ButtonPlayLevel.Enabled = true;
            ButtonPlayLevel.Visible = true;
            ButtonBack.Enabled = true;
            ButtonBack.Visible = true;
        }
        private void ButtonBack_Click(object sender, EventArgs e)
        {
            ButtonPlayScore.Enabled = false;
            ButtonPlayScore.Visible = false;
            ButtonPlayLevel.Enabled = false;
            ButtonPlayLevel.Visible = false;
            ButtonBack.Enabled = false;
            ButtonBack.Visible = false;

            ButtonPlay.Enabled = true;
            ButtonPlay.Visible = true;
            ButtonExit.Enabled = true;
            ButtonExit.Visible = true;
        }
        private Button CreateButton(string buttonText)
        {
            Button button = new Button();
            button.Text = buttonText;
            button.BackColor = Color.Gray;
            button.ForeColor = Color.White;
            button.Size = new Size(150, 45);

            return button;
        }

        private void StartPlay(int level)
        {

            timerStop = false;
            drawnObjects = new ListDrawnObjects();
            monsters = new List<AbstractMonster>();
            bullets = new List<AbstractBullet>();
            towers = new List<AbstractTower>();

            if (!GenerateLevelOne(level))
            {
                while (!GenerateLevelOne(level)) { };
            }

            tableLayoutPanel = new TableLayoutPanel
            {
                Dock = DockStyle.Fill,
                ColumnCount = 2,
            };
            tableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 10F));
            tableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 90F));

            scenePlay = new IsometricPanel(map, sizes, drawnObjects, builderTower) 
            {
                Dock = DockStyle.Fill
            };

            panelInfo = new PanelInfo(plaingInfo, builderTower)
            {
                Dock = DockStyle.Fill,
                BackColor = Color.FromArgb(50,50, 50)
            };

            tableLayoutPanel.Controls.Add(panelInfo, 0, 0);
            tableLayoutPanel.Controls.Add(scenePlay, 1, 0);

            ButtonExitMenu = CreateButton("Menu");
            ButtonExitMenu.Location = ButtonPlayLevelOne.Location = new Point((this.ClientSize.Width - ButtonExitMenu.Width) / 2, (this.ClientSize.Height - ButtonExitMenu.Height) / 2 );
            ButtonExitMenu.Click += ButtonExitMenu_Click1;
            
            this.BackColor = Color.FromArgb(50, 50, 50);

            this.Controls.Add(ButtonExitMenu);

            ButtonExitMenu.Enabled = false;
            ButtonExitMenu.Visible = false;

            this.Controls.Add(tableLayoutPanel);
            tableLayoutPanel.BringToFront();

            formTimer = new System.Windows.Forms.Timer();
            formTimer.Interval = 16;
            formTimer.Tick += Timer_Tick;
            formTimer.Start();
        }

        private void ButtonExitMenu_Click1(object sender, EventArgs e)
        {
            foreach(Control control in this.Controls)
            {
                control.Dispose();
            }

            this.Controls.Clear();
            CreateButtons();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            //Движение монстров
            for( int i = 0; i <  monsters.Count; i++)
            {
                if (!monsters[i].Step())
                {
                    castle.health -= monsters[i].health;
                    drawnObjects.ListOBJ.Remove((IDrawnObject)monsters[i]);
                    monsters.RemoveAt(i);
                    i--;
                }
            }
            for(int i = 0; i < bullets.Count; i++)
            {
                if (!bullets[i].Step())
                {
                    if(bullets[i] is BulletThree)
                    {
                        bullets[i].Purpose.frozesFlag = true;
                    }
                    bullets[i].Purpose.health -= bullets[i].damage;
                    if (bullets[i].Purpose.deadFlag != true)
                    {
                        plaingInfo.score += bullets[i].damage;
                    }
                    if (bullets[i].Purpose.health < 1)
                    {
                        if (bullets[i].Purpose.deadFlag != true)
                        {
                            plaingInfo.money += bullets[i].Purpose.numLoot;
                        }
                        bullets[i].Purpose.deadFlag = true;
                        drawnObjects.ListOBJ.Remove(bullets[i].Purpose);
                        monsters.Remove(bullets[i].Purpose);
                    }
                    drawnObjects.ListOBJ.Remove(bullets[i]);
                    bullets.RemoveAt(i);
                    i--;                   
                }               
            }

            ControlOffsetScene();
            drawnObjects.SortFromY();
            scenePlay.Invalidate();
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                if (timerStop == false)
                {
                    ButtonExitMenu.Enabled = true;
                    ButtonExitMenu.Visible = true;
                    ButtonExitMenu.BringToFront();
                    formTimer.Stop();
                    timerStop = true;
                }
                else if(timerStop == true)
                {
                    ButtonExitMenu.Enabled = false;
                    ButtonExitMenu.Visible = false;
                    tableLayoutPanel.BringToFront();
                    formTimer.Start();
                    timerStop = false;
                }
            }
            if (e.KeyCode == Keys.Up)
            {
                upPress = true;
            }
            if (e.KeyCode == Keys.Down)
            {
                downPress = true;
            }
            if (e.KeyCode == Keys.Right)
            {
                rightPress = true;
            }
            if (e.KeyCode == Keys.Left)
            {
                leftPress = true;
            }
        }
        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up)
            {
                upPress = false;
            }
            else if (e.KeyCode == Keys.Down)
            {
                downPress = false;
            }
            else if (e.KeyCode == Keys.Right)
            {
                rightPress = false;
            }
            else if (e.KeyCode == Keys.Left)
            {
                leftPress = false;
            }
        }
        private void ControlOffsetScene()
        {
            if (upPress == true && ofssetPanel.Y <= 0)
            {
                    ofssetPanel.Y++;
            }
            if (downPress == true && ofssetPanel.Y > (-map.GetCell(0,0).side) * (sizes.numCells) / (3 * scenePlay.speedMoveScene))
            {
                    ofssetPanel.Y--;
            }
            if (rightPress == true && ofssetPanel.X > (-map.GetCell(0, 0).side) * (sizes.numCells) / scenePlay.speedMoveScene)
            {
                    ofssetPanel.X--;       
            }
            if (leftPress == true && ofssetPanel.X < 0)
            {
                ofssetPanel.X++;
            }

            scenePlay.OffsetPanel = ofssetPanel;
        }
        private bool GenerateLevelOne(int level)
        {
            sizeMap = 40;
            this.sizes = new Sizes(50, sizeMap);
            map = new Map(sizeMap, sizes.sizeCell, randomObject, sizes);

            Point cell = new Point(0, 0);
            castle = new Castle(cell, map.GetCell(cell.X, cell.Y).arrayIsoCoords[0], sizes, drawnObjects.ListOBJ.Count);
            drawnObjects.AddElement(castle);

            cell = new Point(32, 32);

            Point3D settingesGate = new Point3D(20, 80, 100);
            gate = new Gate(cell, map.GetCell(cell.X, cell.Y).arrayIsoCoords[0], sizes, drawnObjects.ListOBJ.Count, monsters, drawnObjects,settingesGate,randomObject);
            drawnObjects.AddElement(gate);

            if(level == 0)
            {
                gate.health = 10000000;
            }
            else if(level == 1)
            {
                gate.health = 100000;
                settingesGate = new Point3D(10, 90, 100);
            }
            else if (level ==2)
            {
                gate.health = 150000;
                settingesGate = new Point3D(20, 60, 100);
            }
            else if (level == 3)
            {
                gate.health = 200000;
                settingesGate = new Point3D(10, 50, 100);
            }
            else if (level == 4)
            {
                gate.health = 400000;
                settingesGate = new Point3D(10, 20, 100);
            }
            gate.settingsCreater= settingesGate;

            plaingInfo = new BalanceAndResult(castle, gate);

            CreaterMap(level, sizeMap, map, gate);

            gate.shortPath = FinderShortestPath.FindShortestPath(gate.mapCoordinates, castle.mapCoordinates, BuilderAdjacencyMatrix.BuildAdjacencyMatrix(map), sizeMap);
            builderTower = new BuilderTower(bullets, drawnObjects, monsters, towers, plaingInfo, gate.shortPath);

            if (gate.shortPath == null)
            {
                return false;
            }
            else return true;
        }

        void CreaterMap(int level, int sizeMap, Map map, Gate gate)
        {
            if (level == 0)
            {
                for (int x = 0; x < sizeMap; x++)
                {
                    for (int y = 0; y < sizeMap; y++)
                    {
                        if (map.GetCell(x, y).MapCoord != gate.mapCoordinates && map.GetCell(x, y).MapCoord != castle.mapCoordinates && randomObject.Next(0, 100) < 10)
                        {
                            int typeObj = randomObject.Next(1, 4);
                            drawnObjects.AddElement(new InteriorObject(sizes, typeObj, map.GetCell(x, y).arrayIsoCoords[0], drawnObjects.ListOBJ.Count));
                            map.GetCell(x, y).typeObject = typeObj;
                        }
                    }
                }
            }
            else if(level == 2) 
            {
                for (int x = 0; x < sizeMap; x++)
                {
                    for (int y = 0; y < sizeMap; y++)
                    {
                        int typeObj = 0;
                        
                        if (x == 10 && y > 5)
                        {
                            typeObj = 1;
                        }                     
                        else if (y == 6 && x <sizeMap -3)
                        {
                            typeObj = 1;
                        }
                        else if(map.GetCell(x, y).MapCoord != gate.mapCoordinates && map.GetCell(x, y).MapCoord != castle.mapCoordinates && randomObject.Next(0, 100) < 10) 
                        {                      
                                typeObj = randomObject.Next(1, 4);                 
                        }

                        if (typeObj != 0)
                        {
                            drawnObjects.AddElement(new InteriorObject(sizes, typeObj, map.GetCell(x, y).arrayIsoCoords[0], drawnObjects.ListOBJ.Count));
                            map.GetCell(x, y).typeObject = typeObj;
                        }
                    }
                }
            }
            else if (level == 1 )
            {
                for (int x = 0; x < sizeMap; x++)
                {
                    for (int y = 0; y < sizeMap; y++)
                    {
                        int typeObj = 0;

                        if (x > 5  && y == 30)
                        {
                            typeObj = 1;
                        }
                        else if (y == 20 && x < 30)
                        {
                            typeObj = 1;
                        }
                        else if (map.GetCell(x, y).MapCoord != gate.mapCoordinates && map.GetCell(x, y).MapCoord != castle.mapCoordinates && randomObject.Next(0, 100) < 10)
                        {
                            typeObj = randomObject.Next(1, 4);
                        }

                        if (typeObj != 0)
                        {
                            drawnObjects.AddElement(new InteriorObject(sizes, typeObj, map.GetCell(x, y).arrayIsoCoords[0], drawnObjects.ListOBJ.Count));
                            map.GetCell(x, y).typeObject = typeObj;
                        }
                    }
                }
            }
        }
    }
}












/*
if (randomObject.Next(0, 100) < 10)
{
    //Генерируем башню
    typeObj = randomObject.Next(4, 8);
    AbstractTower tower = null;

    if (typeObj == 4)
    {
        tower = new TowerOne(sizes, typeObj, map.GetCell(x, y).arrayIsoCoords[0], drawnObjects.ListOBJ.Count, new Point(x, y));
    }
    else if (typeObj == 5)
    {
        tower = new TowerTwo(sizes, typeObj, map.GetCell(x, y).arrayIsoCoords[0], drawnObjects.ListOBJ.Count, new Point(x, y));
    }                       
    else if (typeObj == 6)
    {
        tower = new TowerThree(sizes, typeObj, map.GetCell(x, y).arrayIsoCoords[0], drawnObjects.ListOBJ.Count, new Point(x, y));
    }
    else if (typeObj == 7)
    {
        tower = new TowerFour(sizes, typeObj, map.GetCell(x, y).arrayIsoCoords[0], drawnObjects.ListOBJ.Count, new Point(x, y));
    }
    if (tower != null)
    {
        drawnObjects.AddElement(tower);
        towers.Add(tower);
        map.GetCell(x, y).typeObject = 4;
    }
    continue;
}*/

/*            //Create mobe
            if( timeCounter % 300 == 0 && gate.health >= 100)
            {
                MonsterOne mon = (MonsterOne)gate.CreateMonster(10, drawnObjects.ListOBJ.Count);
                monsters.Add(mon);
                drawnObjects.AddElement(mon);
            }
            if (timeCounter % 500 == 0 && gate.health > 150)
            {
                MonsterTwo mon = (MonsterTwo)gate.CreateMonster(11, drawnObjects.ListOBJ.Count);
                monsters.Add(mon);
                drawnObjects.AddElement(mon);
            }
            if (timeCounter % 900 == 0 && gate.health > 500)
            {
                MonsterThree mon = (MonsterThree)gate.CreateMonster(12, drawnObjects.ListOBJ.Count);
                monsters.Add(mon);
                drawnObjects.AddElement(mon);
            }*/


//алгоритм стреляния
/*
if (timeCounter % 50 == 0 && towers.Count != 0)
{
        int index = randomObject.Next(0, towers.Count);

        AbstractTower tow = towers[index];
        if (tow is TowerOne && monsters.Count != 0)
        {
            AbstractBullet bul = ((TowerOne)tow).Shout(monsters, drawnObjects.ListOBJ.Count);

            if (bul != null)
            {
                bullets.Add(bul);
                drawnObjects.AddElement(bul);
            }
        }
        else if (tow is TowerTwo && monsters.Count != 0)
        {
            AbstractBullet bul = ((TowerTwo)tow).Shout(monsters, drawnObjects.ListOBJ.Count);

            if (bul != null)
            {
                bullets.Add(bul);
                drawnObjects.AddElement(bul);
            }
        }
        else if (tow is TowerThree && monsters.Count != 0)
        {
            AbstractBullet bul = ((TowerThree)tow).Shout(monsters, drawnObjects.ListOBJ.Count);

            if (bul != null)
            {
                bullets.Add(bul);
                drawnObjects.AddElement(bul);
            }
        }
        else if (tow is TowerFour && monsters.Count != 0)
        {
            AbstractBullet bul = ((TowerFour)tow).Shout(monsters, drawnObjects.ListOBJ.Count);

            if (bul != null)
            {
                bullets.Add(bul);
                drawnObjects.AddElement(bul);
            }
        }
}
*/