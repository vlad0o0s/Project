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
    public partial class Регистрация : Form
    {
        public Регистрация()
        {
            InitializeComponent();
        }

        private void buttonRegister_Click(object sender, EventArgs e)
        {
            if (login.Text == "")
            {
                MessageBox.Show("Введите логин");
                return;
            }

            if (password.Text == "")
            {
                MessageBox.Show("Введите пароль");
                return;
            }

            if (fio.Text == "")
            {
                MessageBox.Show("Введите ФИО");
                return;
            }


            if (isUserExists())
                return;

            DB db = new DB();


            MySqlCommand command = new MySqlCommand();
            command.CommandText = "INSERT INTO `users` (`login`, `pass`, `FIO`) VALUES (@login, @pass, @fio)";
            command.Connection = db.getConnection();

            command.Parameters.Add("@login", MySqlDbType.VarChar).Value = login.Text;
            command.Parameters.Add("@pass", MySqlDbType.VarChar).Value = password.Text;
            command.Parameters.Add("@fio", MySqlDbType.VarChar).Value = fio.Text;


            db.openConnection();

            if (command.ExecuteNonQuery() == 1)
                MessageBox.Show("Вы успешно зарегистрированы");
            else
                MessageBox.Show("Ошибка, аккаунт не был создан");

            db.closeConnection();
        }

        private void Регистрация_Load(object sender, EventArgs e)
        {

        }

        public Boolean isUserExists()
        {
            DB db = new DB();

            DataTable table = new DataTable();

            MySqlDataAdapter adapter = new MySqlDataAdapter();

            MySqlCommand command = new MySqlCommand("SELECT * FROM `users` WHERE `login` = @uL", db.getConnection());

            command.Parameters.Add("@uL", MySqlDbType.VarChar).Value = login.Text;

            adapter.SelectCommand = command;
            adapter.Fill(table);

            if (table.Rows.Count > 0)
            {
                MessageBox.Show("Такой логин уже зарегистрирован, введите другой");
                return true;
            }

            else
                return false;
               
        }



        private void buttonBack_Click(object sender, EventArgs e)
        {
            this.Hide();
            Авторизация authorization = new Авторизация();
            authorization.Show();
        }
    }
}
