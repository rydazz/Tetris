using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tetris
{

    public partial class Form1 : Form
    {
        Blocks CurrentBlock;
        int size;
        int[,] map = new int[20, 10];

        public Form1()
        {
            InitializeComponent();
            Tick();
        }

        public void Tick()
        {
            size = 25;
            CurrentBlock = new Blocks(3, 0);
            
            timer1.Interval = 1000;
            timer1.Tick += new EventHandler(Update);
            timer1.Start();
        }



        private void Update(object sender, EventArgs e)
        {
            Reset();
            CurrentBlock.MoveDown();
            
            Merge();

            Invalidate();


        }

        public void Merge()
        {
            for (int i = CurrentBlock.y; i < CurrentBlock.y + 3; i++)
            {
                for (int j = CurrentBlock.x; j < CurrentBlock.x + 3; j++)
                {
                    map[i, j] = CurrentBlock.Shapes[i - CurrentBlock.y, j - CurrentBlock.x];
                }
            }
        }

        public void Reset()
        {
            for (int i = CurrentBlock.y; i < CurrentBlock.y + 3; i++)
            {
                for (int j = CurrentBlock.x; j < CurrentBlock.x + 3; j++)
                {
                    map[i, j] = 0;
                }
            }
        }

        public void DrawShape(Graphics e)
        {
            for (int i = 0; i < 20; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    if (map[i, j] == 1)
                    {
                        e.FillRectangle(Brushes.Red, new Rectangle(300 + j * (size) + 1, 25 + i * (size) + 1, (size) - 1, (size) - 1));

                    }
                }

            }
            

        }

        public void DrawMap(Graphics g)
        {
            for (int i = 0; i <= 20; i++)
            {
                g.DrawLine(Pens.Black, new Point(300, 50 + i * size), new Point(300 + 10 * size, 50 + i * size));
               
            }

            for (int j = 0; j <= 10; j++)
            {
                g.DrawLine(Pens.Black, new Point(300 + j * size, 50), new Point(300 + j * size, 300 + 10 * size));
              
            }

        }



        private void OnPaint(object sender, PaintEventArgs e)
        {
            DrawMap(e.Graphics);
            DrawShape(e.Graphics);
        }
    }
}