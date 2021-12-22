using MySqlConnector;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Kurse
{
    public partial class Авторизация : Form
    {
        public Авторизация()
        {
            InitializeComponent();
        }

        private void buttonlogin_Click(object sender, EventArgs e)
        {
            String loginUsers = login.Text;
            String passUsers = password.Text;

            DB db = new DB();

            DataTable table = new DataTable();

            MySqlDataAdapter adapter = new MySqlDataAdapter();

            MySqlCommand command = new MySqlCommand("SELECT * FROM `users` WHERE `login` = @uL AND `pass` = @uP ", db.getConnection());

            command.Parameters.Add("@uL", MySqlDbType.VarChar).Value = loginUsers;
            command.Parameters.Add("@uP", MySqlDbType.VarChar).Value = passUsers;

            adapter.SelectCommand = command;
            adapter.Fill(table);

            if (table.Rows.Count > 0)
            { 
                this.Hide();
                var authorizedUser = new User(table.Rows[0]);
                Аккаунт account = new Аккаунт(authorizedUser);
                account.Show();
            }
            else
                MessageBox.Show("Ошибка, не верный логин или пароль.");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Регистрация register = new Регистрация();
            register.Show();
        }

        private void Авторизация_Load(object sender, EventArgs e)
        {

        }
    }
    public class User
    {
        public string FIO;
        public string Balance;
        public string login;
        public string turs;
        public User(DataRow dataRow)
        {   
            login = dataRow[1] as string;
            FIO = dataRow[3] as string;
            Balance = dataRow[4] as string;
            turs = dataRow[5] as string;
        }


    }
}
