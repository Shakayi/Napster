using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 俄罗斯方块_
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        #region 定义砖块int[i,j,y,x] Tricks:i为那块砖,j为状态,y为列,x为行  
        private int[, , ,] Tricks = {{  
                                      {  
                                          {1,0,0,0},  
                                          {1,0,0,0},  
                                          {1,0,0,0},  
                                          {1,0,0,0}  
                                      },  
                                      {  
                                          {1,1,1,1},  
                                          {0,0,0,0},  
                                          {0,0,0,0},  
                                          {0,0,0,0}  
                                      },  
                                      {  
                                          {1,0,0,0},  
                                          {1,0,0,0},  
                                          {1,0,0,0},  
                                          {1,0,0,0}  
                                      },  
                                      {  
                                          {1,1,1,1},  
                                          {0,0,0,0},  
                                          {0,0,0,0},  
                                          {0,0,0,0}  
                                      }  
                                  },  
                                  {  
                                       {  
                                           {1,1,0,0},  
                                           {1,1,0,0},  
                                           {0,0,0,0},  
                                           {0,0,0,0}  
                                       },  
                                       {  
                                           {1,1,0,0},  
                                           {1,1,0,0},  
                                           {0,0,0,0},  
                                           {0,0,0,0}  
                                       },  
                                       {  
                                           {1,1,0,0},  
                                           {1,1,0,0},  
                                           {0,0,0,0},  
                                           {0,0,0,0}  
                                       },  
                                       {  
                                           {1,1,0,0},  
                                           {1,1,0,0},  
                                           {0,0,0,0},  
                                           {0,0,0,0}  
                                       }  
                                   },  
                                   {  
                                       {  
                                           {1,0,0,0},  
                                           {1,1,0,0},  
                                           {0,1,0,0},  
                                           {0,0,0,0}  
                                       },  
                                       {  
                                           {0,1,1,0},  
                                           {1,1,0,0},  
                                           {0,0,0,0},  
                                           {0,0,0,0}  
                                       },  
                                       {  
                                           {1,0,0,0},  
                                           {1,1,0,0},  
                                           {0,1,0,0},  
                                           {0,0,0,0}  
                                       },  
                                       {  
                                           {0,1,1,0},  
                                           {1,1,0,0},  
                                           {0,0,0,0},  
                                           {0,0,0,0}  
                                       }  
                                   },  
                                   {  
                                       {  
                                           {1,1,0,0},  
                                           {0,1,0,0},  
                                           {0,1,0,0},  
                                           {0,0,0,0}  
                                       },  
                                       {  
                                           {0,0,1,0},  
                                           {1,1,1,0},  
                                           {0,0,0,0},  
                                           {0,0,0,0}  
                                       },  
                                       {  
                                           {1,0,0,0},  
                                           {1,0,0,0},  
                                           {1,1,0,0},  
                                           {0,0,0,0}  
                                       },  
                                       {  
                                           {1,1,1,0},  
                                           {1,0,0,0},  
                                           {0,0,0,0},  
                                           {0,0,0,0}  
                                       }  
                                   }};  
 
        #endregion  
        #region 定义背景  
        private int[,] bgGraoud ={  
                                     {0,0,0,0,0,0,0,0,0,0,0,0,0,0},  
                                     {0,0,0,0,0,0,0,0,0,0,0,0,0,0},  
                                     {0,0,0,0,0,0,0,0,0,0,0,0,0,0},  
                                     {0,0,0,0,0,0,0,0,0,0,0,0,0,0},  
                                     {0,0,0,0,0,0,0,0,0,0,0,0,0,0},  
                                     {0,0,0,0,0,0,0,0,0,0,0,0,0,0},  
                                     {0,0,0,0,0,0,0,0,0,0,0,0,0,0},  
                                     {0,0,0,0,0,0,0,0,0,0,0,0,0,0},  
                                     {0,0,0,0,0,0,0,0,0,0,0,0,0,0},  
                                     {0,0,0,0,0,0,0,0,0,0,0,0,0,0},  
                                     {0,0,0,0,0,0,0,0,0,0,0,0,0,0},  
                                     {0,0,0,0,0,0,0,0,0,0,0,0,0,0},  
                                     {0,0,0,0,0,0,0,0,0,0,0,0,0,0},  
                                     {0,0,0,0,0,0,0,0,0,0,0,0,0,0},  
                                     {0,0,0,0,0,0,0,0,0,0,0,0,0,0},  
                                     {0,0,0,0,0,0,0,0,0,0,0,0,0,0},  
                                     {0,0,0,0,0,0,0,0,0,0,0,0,0,0},  
                                     {0,0,0,0,0,0,0,0,0,0,0,0,0,0},  
                                     {0,0,0,0,0,0,0,0,0,0,0,0,0,0},  
                                     {0,0,0,0,0,0,0,0,0,0,0,0,0,0}  
                                 };  
        #endregion  
        private int[,] CurrentTrick = new int[4, 4]; //当前的砖块  
        //CurrentTrickNum当前砖块的数目, CurrentStatusNum当前状态, CurrentX当前x, CurrentY当前y, Sorce分数  
        private int CurrentTrickNum, CurrentStatusNum, CurrentX, CurrentY, Sorce;  
        private int TricksNum = 4;  
        private int StatusNum = 4;  
        private Image myImage;  
        private Random rand = new Random();  
        private void Form1_Load(object sender, EventArgs e)  
        {  
            //初始化  
            myImage = new Bitmap(panel1.Width, panel1.Height);  
            Sorce = 0;  
        }  
        protected override void OnPaint(PaintEventArgs e)  
        {  
            Draw();  
            base.OnPaint(e);  
        }  
          
        private void button1_Click(object sender, EventArgs e)
        {
            BeginTricks();
        }  
        /// <summary>  
        /// 随机生成方块和状态  
        /// </summary>  
        private void BeginTricks()  
        {  
            //随机生成砖码和状态码  
            int i = rand.Next(0, TricksNum);  
            int j = rand.Next(0, StatusNum);  
            CurrentTrickNum = i;  
            CurrentStatusNum = j;  
            //分配数组  
            for (int y = 0; y < 4; y++)  
            {  
                for (int x = 0; x < 4; x++)  
                {  
                    CurrentTrick[y,x] = Tricks[i,j,y,x];  
                }  
            }  
            CurrentX = 0;  
            CurrentY = 0;  
            timer1.Start();  
        }  
        /// <summary>  
        /// 变化方块  
        /// </summary>  
        private void ChangeTricks()  
        {  
            if (CurrentStatusNum < 3)  
            {  
                CurrentStatusNum++;  
            }  
            else  
            {  
                CurrentStatusNum = 0;  
            }  
            for (int y = 0; y < 4; y++)  
            {  
                for (int x = 0; x < 4; x++)  
                {  
                    CurrentTrick[y, x] = Tricks[CurrentTrickNum, CurrentStatusNum, y, x];  
                }  
            }  
        }  
        /// <summary>  
        /// 下落方块  
        /// </summary>  
        private void DownTricks()  
        {  
            if (CheckIsDown())  
            {  
                CurrentY++;  
            }  
            else  
            {  
                if (CurrentY == 0)  
                {  
                    timer1.Stop();  
                    MessageBox.Show("哈哈，你玩玩了");  
                      
                    return;  
                }  
                //下落完成，修改背景  
                for (int y = 0; y < 4; y++)  
                {  
                    for (int x = 0; x < 4; x++)  
                    {  
                        if (CurrentTrick[y, x] == 1)  
                        {  
                            bgGraoud[CurrentY + y, CurrentX + x] = CurrentTrick[y, x];  
                        }  
                    }  
                }  
                CheckSore();  
                BeginTricks();  
                  
            }  
            Draw();  
        }  
        /// <summary>  
        /// 检测是否可以向下了  
        /// </summary>  
        /// <returns></returns>  
        private bool CheckIsDown()  
        {  
            for (int y = 0; y < 4; y++)  
            {  
                for (int x = 0; x < 4; x++)  
                {  
                    if (CurrentTrick[y, x] == 1)  
                    {  
                        //超过了背景  
                        if (y + CurrentY + 1 >= 20)  
                        {  
                            return false;  
                        }  
                        if (x + CurrentX >= 14)  
                        {  
                            CurrentX = 13 - x;  
                        }  
                        if (bgGraoud[y + CurrentY + 1, x + CurrentX] == 1)  
                        {  
                            return false;  
                        }  
                    }  
                }  
            }  
            return true;  
        }  
        /// <summary>  
        /// 检测是否可以左移  
        /// </summary>  
        /// <returns></returns>  
        private bool CheckIsLeft()  
        {  
            for (int y = 0; y < 4; y++)  
            {  
                for (int x = 0; x < 4; x++)  
                {  
                    if (CurrentTrick[y, x] == 1)  
                    {  
                        if (x + CurrentX - 1 < 0)  
                        {  
                            return false;  
                        }  
                        if (bgGraoud[y + CurrentY, x + CurrentX - 1] == 1)  
                        {  
                            return false;  
                        }  
                    }  
                }  
            }  
            return true;  
        }  
        /// <summary>  
        /// 检测是否可以右移  
        /// </summary>  
        /// <returns></returns>  
        private bool CheckIsRight()  
        {  
            for (int y = 0; y < 4; y++)  
            {  
                for (int x = 0; x < 4; x++)  
                {  
                    if (CurrentTrick[y, x] == 1)  
                    {  
                        if (x + CurrentX + 1 >= 14)  
                        {  
                            return false;  
                        }  
                        if (bgGraoud[y + CurrentY, x + CurrentX+1] == 1)  
                        {  
                            return false;  
                        }  
                    }  
                }  
            }  
            return true;  
        }  
  
        private void Draw()  
        {  
            Graphics g = Graphics.FromImage(myImage);  
            g.Clear(this.BackColor);  
            for (int bgy = 0; bgy < 20; bgy++)  
            {  
                for (int bgx = 0; bgx < 14; bgx++)  
                {  
                    if (bgGraoud[bgy, bgx] == 1)  
                    {  
                         
                        g.FillRectangle(new SolidBrush(Color.Blue), bgx * 20, bgy * 20, 20, 20);  
                    }  
                }  
            }  
            //绘制当前的图片  
            for (int y = 0; y < 4; y++)  
            {  
                for (int x = 0; x < 4; x++)  
                {  
                    if (CurrentTrick[y, x] == 1)  
                    {  
                        g.FillRectangle(new SolidBrush(Color.Blue), (x + CurrentX) * 20, (y + CurrentY) * 20, 20, 20);  
                    }  
                }  
            }  
            Graphics gg = panel1.CreateGraphics();  
           
            gg.DrawImage(myImage, 0, 0);  
        }  
  
  
        private void timer1_Tick(object sender, EventArgs e)  
        {  
            DownTricks();  
        }  
  
        private void Form1_KeyDown(object sender, KeyEventArgs e)  
        {  
            if (e.KeyCode == Keys.W)  
            {  
                ChangeTricks();  
                Draw();  
            }  
            else if (e.KeyCode == Keys.A)  
            {  
                if (CheckIsLeft())  
                {  
                    CurrentX--;  
                }  
                Draw();  
            }  
            else if (e.KeyCode == Keys.D)  
            {  
                if (CheckIsRight())  
                {  
                    CurrentX++;  
                }  
                Draw();  
            }  
            else if (e.KeyCode == Keys.S)  
            {  
                timer1.Stop();  
                timer1.Interval = 10;  
                timer1.Start();  
            }  
        }  
  
        private void Form1_KeyUp(object sender, KeyEventArgs e)  
        {  
            if (e.KeyCode == Keys.S)  
            {  
                timer1.Stop();  
                timer1.Interval = 1000;  
                timer1.Start();  
            }  
        }  
  
        private void CheckSore()  
        {  
            for (int y = 19; y > -1; y--)  
            {  
                bool isFull = true;  
                for (int x = 13; x > -1; x--)  
                {  
                    if (bgGraoud[y, x] == 0)  
                    {  
                        isFull = false;  
                        break;  
                    }  
                }  
                if (isFull)  
                {  
                    //增加积分  
                    Sorce = Sorce + 100;  
                    for (int yy = y; yy > 0; yy--)  
                    {  
                        for (int xx = 0; xx < 14; xx++)  
                        {  
                            int temp = bgGraoud[yy - 1, xx];  
                            bgGraoud[yy, xx] = temp;  
                        }  
                    }  
                    y++;  
                    label1.Text = Sorce.ToString(); ;  
                    Draw();  
                }  
                 
            }  
        }  
  
        private void button2_Click(object sender, EventArgs e)
        {
            clear();
        }

        private void clear()
        {
            for (int i = 0; i < 20; i++)
                for (int j = 0; j < 14; j++)
                    bgGraoud[i, j] = 0;

            for (int i = 0; i < 4; i++)
                for (int j = 0; j < 4; j++)
                    CurrentTrick[i, j] = 0;
        }
 
    }
}
