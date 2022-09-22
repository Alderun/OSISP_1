using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab_1
{
    public partial class Form1 : Form
    {

        int x, y;
        int width, height;
        Bitmap picture;
        bool isShiftPress;

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.ShiftKey:
                    isShiftPress = true;
                    break;
                case Keys.Up:
                    y -= 15;
                    checkY();
                    Invalidate();
                    break;
                case Keys.Down:
                    y += 15;
                    checkY();
                    Invalidate();
                    break;
                case Keys.Left:
                    x -= 15;
                    checkX();
                    Invalidate();
                    break;
                case Keys.Right:
                    x += 15;
                    checkX();
                    Invalidate();
                    break;
            }
        }

        private void checkY()
        {
            if (y < 0)
            {
                y = 20;
            }
            if (y > ClientSize.Height - height)
            {
                y = ClientSize.Height - height - 20;
            }
        }

        private void checkX()
        {
            if (x < 0)
            {
                x = 20;
            }
            if (x > ClientSize.Width - width)
            {
                x = ClientSize.Width - width - 20;
            }
        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.ShiftKey)
            {
                isShiftPress = false;
            }
        }

        private void MouseWheelScroll(object sender, MouseEventArgs e)
        {
            if(e.Delta > 0)
            {
                if (isShiftPress)
                {
                    x += 15;
                    checkX();
                } else
                {
                    y -= 15;
                    checkY();
                }
            } else if(e.Delta < 0)
            {
                if (isShiftPress)
                {
                    x -= 15;
                    checkX();
                }
                else
                {
                    y += 15;
                    checkY();
                }
            }
            Invalidate();
        }


        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.DrawImage(picture, x, y);
        }

        public Form1()
        {
            InitializeComponent();
            x = 0;
            y = 0;
            picture = new Bitmap(@"D:\ОСИСП лабы\Lab_1\utka.png", true);
            width = picture.Width;
            height = picture.Height;
            isShiftPress = false;
            this.MouseWheel += new MouseEventHandler(MouseWheelScroll);
        }
    }
}
