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
    public partial class Form1 : Form
    {
        public Form1()
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

            MySqlCommand command = new MySqlCommand("SELECT * FROM `users` WHERE `login` = @uL AND `password` = @uP ", db.getConnection());

            command.Parameters.Add("@uL", MySqlDbType.VarChar).Value = loginUsers;
            command.Parameters.Add("@uP", MySqlDbType.VarChar).Value = passUsers;

            adapter.SelectCommand = command;
            adapter.Fill(table);

            if (table.Rows.Count <= 0)
                MessageBox.Show("Ошибка, не верный логин или пароль.");
        }
    }
}
