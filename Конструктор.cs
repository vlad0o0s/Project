using MySqlConnector;
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
        DB db = new DB();

        DataTable table = new DataTable(); 
        DataTable table_city = new DataTable();

        MySqlDataAdapter adapter = new MySqlDataAdapter();

        private User authorizedUser;
        private Аккаунт.UserUpdete userUpdete;

        public Конструктор(User authorizedUser, Аккаунт.UserUpdete userUpdete)
        {
            InitializeComponent();
            this.authorizedUser = authorizedUser;
            this.userUpdete = userUpdete;
        }
        public Конструктор()
        {
            InitializeComponent();
        }

        private void Конструктор_Load(object sender, EventArgs e)
        {


        }

        public class country
        {
            //Страна
            public int egipet;
            public int turciya;
            public int tayland;
            public int daminikana;
            public country(DataRow dataRow)
            {
                egipet = (int)dataRow[2];
                turciya = (int)dataRow[2];
                tayland = (int)dataRow[2];
                daminikana = (int)dataRow[2];
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
            MySqlCommand command = new MySqlCommand("SELECT * FROM `country` WHERE `id` = 1", db.getConnection());
            adapter.SelectCommand = command;
            adapter.Fill(table);
            var konstruktorEgipet = new country(table.Rows[0]);


            this.Hide();
            Консруктор_Египет conE = new Консруктор_Египет(konstruktorEgipet, authorizedUser, userUpdete);
            conE.Show();
        }
        private void pictureBox2_Click(object sender, EventArgs e)
        {
            MySqlCommand command = new MySqlCommand("SELECT * FROM `country` WHERE `id` = 2", db.getConnection());
            adapter.SelectCommand = command;
            adapter.Fill(table);
            var konstruktorEgipet = new country(table.Rows[0]);


            this.Hide();
            Конструктор_Турция conE = new Конструктор_Турция(konstruktorEgipet, authorizedUser, userUpdete);
            conE.Show();
        }
        private void pictureBox3_Click(object sender, EventArgs e)
        {
            MySqlCommand command = new MySqlCommand("SELECT * FROM `country` WHERE `id` = 3", db.getConnection());
            adapter.SelectCommand = command;
            adapter.Fill(table);
            var konstruktorEgipet = new country(table.Rows[0]);


            this.Hide();
            Констрктор_Тайланд conE = new Констрктор_Тайланд(konstruktorEgipet, authorizedUser, userUpdete);
            conE.Show();
        }
        private void pictureBox4_Click(object sender, EventArgs e)
        {
            MySqlCommand command = new MySqlCommand("SELECT * FROM `country` WHERE `id` = 4", db.getConnection());
            adapter.SelectCommand = command;
            adapter.Fill(table);
            var konstruktorEgipet = new country(table.Rows[0]);


            this.Hide();
            Конструктор_Доминикана conE = new Конструктор_Доминикана(konstruktorEgipet, authorizedUser, userUpdete);
            conE.Show();
        }
    }
}

