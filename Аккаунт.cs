using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySqlConnector;

namespace Kurse
{
    public partial class Аккаунт : Form
    {
        DB db = new DB();

        DataTable table = new DataTable();

        MySqlDataAdapter adapter = new MySqlDataAdapter();
        private User authorizedUser;

        public Аккаунт()
        {
            InitializeComponent();
        }
        public Аккаунт(User authorizedUser)
        {
            InitializeComponent();
            this.authorizedUser = authorizedUser;
            
        }


        private void Аккаунт_Load(object sender, EventArgs e)
        {
            label2.Text = "Здравствуйте, " + authorizedUser.FIO;

            Balanc.Text = authorizedUser.Balance+ " Руб.";
            label4.Text = authorizedUser.turs;
        }


        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Авторизация authorization = new Авторизация();
            authorization.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();

            Готовые_туры gt = new Готовые_туры(authorizedUser);
            gt.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Пополнение popolnenie = new Пополнение(authorizedUser);
            popolnenie.Show();
        }
    }

}
