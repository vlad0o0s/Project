using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Kurse
{
    public partial class Конструктор : Form
    {
        private User authorizedUser;

        public Конструктор(User authorizedUser)
        {
            InitializeComponent();
            this.authorizedUser = authorizedUser;
        }
        public Конструктор()
        {
            InitializeComponent();
        }

        private void Конструктор_Load(object sender, EventArgs e)
        {

        }

        public class Constructor
        {
            //Страна
            public int egipet;
            int turciya;
            int tayland;
            int daminikana;
            //Город
            int e_name1;
            int e_name2;
            int e_name3;
            int e_name4;

            int tu_name1;
            int tu_name2;
            int tu_name3;
            int tu_name4;

            int ta_name1;
            int ta_name2;
            int ta_name3;
            int ta_name4;

            int da_name1;
            int da_name2;
            int da_name3;
            int da_name4;
            //Отель
            int otel1;
            int otel2;
            int otel3;
            //Экскурси
            public Constructor()
            {
                turciya = 1;
                tayland = 1;
                daminikana = 1;

                e_name1 = 1;
                e_name2 = 1;
                e_name3 = 1;
                e_name4 = 1;

                tu_name1 = 1;
                tu_name2 = 1;
                tu_name3 = 1;
                tu_name4 = 1;

                ta_name1 = 1;
                ta_name2 = 1;
                ta_name3 = 1;
                ta_name4 = 1;

                da_name1 = 1;
                da_name2 = 1;
                da_name3 = 1;
                da_name4 = 1;

            }

        }

        private void pictureBox1_MouseLeave(object sender, EventArgs e)
        {
            label1.Font = new Font("Microsoft Sans Serif", 17, FontStyle.Bold);
            pictureBox1.Width = 241;
            pictureBox1.Height = 129;
        }

        private void pictureBox1_MouseEnter(object sender, EventArgs e)
        {
            label1.Font = new Font("Microsoft Sans Serif", 20, FontStyle.Bold);
            pictureBox1.Width = 246;
            pictureBox1.Height = 134;
        }

        private void pictureBox2_MouseLeave(object sender, EventArgs e)
        {
            label2.Font = new Font("Microsoft Sans Serif", 17, FontStyle.Bold);
            pictureBox2.Width = 241;
            pictureBox2.Height = 129;
        }

        private void pictureBox2_MouseEnter(object sender, EventArgs e)
        {
            label2.Font = new Font("Microsoft Sans Serif", 20, FontStyle.Bold);
            pictureBox2.Width = 246;
            pictureBox2.Height = 134;
        }

        private void pictureBox3_MouseLeave(object sender, EventArgs e)
        {
            label3.Font = new Font("Microsoft Sans Serif", 17, FontStyle.Bold);
            pictureBox3.Width = 241;
            pictureBox3.Height = 129;
        }

        private void pictureBox3_MouseEnter(object sender, EventArgs e)
        {
            label3.Font = new Font("Microsoft Sans Serif", 20, FontStyle.Bold);
            pictureBox3.Width = 246;
            pictureBox3.Height = 134;
        }

        private void pictureBox4_MouseLeave(object sender, EventArgs e)
        {
            label4.Font = new Font("Microsoft Sans Serif", 17, FontStyle.Bold);
            pictureBox4.Width = 241;
            pictureBox4.Height = 129;
        }

        private void pictureBox4_MouseEnter(object sender, EventArgs e)
        {
            label4.Font = new Font("Microsoft Sans Serif", 20, FontStyle.Bold);
            pictureBox4.Width = 246;
            pictureBox4.Height = 134;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            var konstruktorEgipet = new Constructor();
            this.Hide();
            Консруктор_Египет conE = new Консруктор_Египет(authorizedUser, konstruktorEgipet);
            conE.Show();
        }
    }
}

