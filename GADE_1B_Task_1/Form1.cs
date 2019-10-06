using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GADE_1B_Task_1
{
    public partial class Form1 : Form
    {
        GameEngine gameEngine;
        public Form1()
        {
            
            InitializeComponent();
            
            



        }

        private void timer1_Tick(object sender, System.EventArgs e)
        {
            int timer;
            gameEngine.GameLogic(gameEngine.map.arrUnits);
            
            lblMap.Text = gameEngine.map.MapDisplay();     
            timer = (gameEngine.gameRounds);
            rtxtInfo.Text = gameEngine.OutputString;
            lblTimer.Text = Convert.ToString(timer);
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            timer1.Start();
        }

        private void btnPause_Click(object sender, EventArgs e)
        {
            timer1.Stop();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            gameEngine = new GameEngine();
            gameEngine.map.RandomBattlefield();
        }
    }
}
