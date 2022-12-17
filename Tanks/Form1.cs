using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tanks
{
    public partial class Form1 : Form
    {
        int speed, score;
        public Form1()
        {
            InitializeComponent();
        }
        void Strike()
        {
            PictureBox Strike = new PictureBox();
            Strike.Image = Properties.Resources.strike;
            Strike.Size = new Size(5, 20);//размер снаряда
            Strike.Tag = "strike";
            Strike.Location = new Point(Tank.Left + Tank.Width / 2, Tank.Top - 20);//позиция снаряда возле танка
            Controls.Add(Strike);
        }
        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Left) speed = -10;//движение танка влево
            if (e.KeyCode == Keys.Right) speed = 10;//движение танка вправо
            if (e.KeyCode == Keys.Space) Strike();//стрельба
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Tank.Left += speed;
            if (Tank.Left < -30) Tank.Left += 20;//отскок слева (чтобы не заезжать за поля)
            if (Tank.Right > Width + 10) Tank.Left -= 20;//отскок справа

            foreach (PictureBox item in Controls)
            {
                if (item.Tag == "Opponent")//движение врагов
                {
                    item.Left += 2;//скорость движения врагов
                    if (item.Right > Width)//если враги выезжают за поля, то 
                    {
                        item.Left = 0;//переносим на начало поля
                        item.Top += 80;//приближаем к танку
                    }
                    if (item.Bounds.IntersectsWith(Tank.Bounds))//если танк и враг пересеклись
                    {
                        timer1.Stop();
                        MessageBox.Show("Game Over:( Score: " + score);
                    }
                }
                if (item.Tag == "strike")
                {
                    item.Top -= 20;//снаряд летит
                    if (item.Top < 0) Controls.Remove(item);//удаление снарядов, которые вылетели из поля, из памяти
                }
            }
            //попадание снаряда в объект
            foreach (PictureBox x in Controls)
                foreach (PictureBox y in Controls)
                    if (x.Tag == "Opponent" 
                        && y.Tag == "strike"
                        && x.Bounds.IntersectsWith(y.Bounds))//если враг и снаряд пересекаются, то удаляем врага и снаряд
                    {
                        Controls.Remove(x);
                        Controls.Remove(y);
                        score++;
                    }
            Text = "Score - " + score;
            if (score == 33)
            {
                timer1.Stop();
                MessageBox.Show("You Win:) Score: " + score);
            }
        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Left || e.KeyCode == Keys.Right) speed = 0;//отпускание клавиши для остановки
        }
    }
}
