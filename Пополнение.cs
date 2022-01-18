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
    public partial class Пополнение : Form
    {
        DB db = new DB();

        DataTable table = new DataTable();

        MySqlDataAdapter adapter = new MySqlDataAdapter();
        private User authorizedUser;
        private Аккаунт.UserUpdete userUpdete;

        public Пополнение()
        {
            InitializeComponent();
        }
        public Пополнение(User authorizedUser, Аккаунт.UserUpdete userUpdete)
        {
            InitializeComponent();
            this.authorizedUser = authorizedUser;
            this.userUpdete = userUpdete;

        }
        private void Пополнение_Load(object sender, EventArgs e)
        {
            Console.WriteLine(userUpdete.balance);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                MessageBox.Show("Введите сумму");
                return;
            }
            int y = Convert.ToInt32(userUpdete.balance);
            int x = Convert.ToInt32(textBox1.Text);

            int next = y + x;

            if (x < 0)
            {
                MessageBox.Show("ошибка");
                return;
            }
            
            string id_ob = authorizedUser.login;
            MySqlCommand command = new MySqlCommand("UPDATE `users` SET `balance` = @popolnenie WHERE `login` = @id_ob", db.getConnection());
            command.Parameters.Add("@popolnenie", MySqlDbType.VarChar).Value = next;
            command.Parameters.Add("@id_ob", MySqlDbType.VarChar).Value = id_ob;
            adapter.SelectCommand = command;
            adapter.Fill(table);
            MessageBox.Show("Вы пополнили кошелек на сумму " + x + " Руб.");
            this.Hide();
            Аккаунт аккаунт = new Аккаунт(authorizedUser);
            аккаунт.Show();

        }


    }
}