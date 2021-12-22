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
        private UserUpdete userUpdete;




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
            string id_ob = authorizedUser.login;
            MySqlCommand command = new MySqlCommand("SELECT * FROM `users` WHERE `login` = @id_ob", db.getConnection());
            command.Parameters.Add("@id_ob", MySqlDbType.VarChar).Value = id_ob;
            adapter.SelectCommand = command;
            adapter.Fill(table);
            var userUpdete = new UserUpdete(table.Rows[0]);

            label2.Text = "Здравствуйте, " + authorizedUser.FIO;

            Balanc.Text = userUpdete.Balance + " Руб.";
            label4.Text = userUpdete.turs;
            label8.Text = userUpdete.city;
            label9.Text = userUpdete.hotel;
            label10.Text = userUpdete.ex;

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
            var userUpdete = new UserUpdete(table.Rows[0]);
            Готовые_туры gt = new Готовые_туры(authorizedUser, userUpdete);
            gt.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            var userUpdete = new UserUpdete(table.Rows[0]);
            Пополнение popolnenie = new Пополнение(authorizedUser, userUpdete);
            popolnenie.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Hide();
            var userUpdete = new UserUpdete(table.Rows[0]);
            Конструктор con = new Конструктор(authorizedUser, userUpdete);
            con.Show();
        }
        public class UserUpdete
        {
            public string Balance;
            public string turs;
            public string city;
            public string hotel;
            public string ex;
            public UserUpdete(DataRow dataRow)
            {
                Balance = dataRow[4] as string;
                turs = dataRow[5] as string;
                city = dataRow[6] as string;
                hotel = dataRow[7] as string;
                ex = dataRow[8] as string;
            }
        }
    }

}
