using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Drawing2D;


namespace dlyadoklada
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        GraphicsPath gPath = new GraphicsPath();                //Создаем обьект GraphicsPath
        private void Form1_Load(object sender, EventArgs e)     
        {
            this.FormBorderStyle = FormBorderStyle.None;        
            this.BackColor = Color.Orange;                      
            gPath.AddEllipse(0, 0, Width, Height);              //Добавляем фигуру в gPath (иначе окно инвертируется после клика)
            Region = new Region(gPath);                         //Присваеваем региону наш шаблон
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)   //Функция для того, чтобы можно было перетаскивать окно
        {
            base.Capture = false;
            Message m = Message.Create(base.Handle, 0xa1, new IntPtr(2), IntPtr.Zero);
            this.WndProc(ref m);
        }

        private void Form1_MouseClick(object sender, MouseEventArgs e)  //Функция для создания дырок (кроме пкм, тк "мешает" функци)
        {
            int radius = 20;                                            
            int x, y;
            x = e.Location.X;
            y = e.Location.Y;
            gPath.AddEllipse(x - radius/2, y - radius/2, radius, radius);
            Region = new Region(gPath);
        }
    }
}