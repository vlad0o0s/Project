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

        public Пополнение()
        {
            InitializeComponent();
        }
        public Пополнение(User authorizedUser)
        {
            InitializeComponent();
            this.authorizedUser = authorizedUser;

        }
        private void Пополнение_Load(object sender, EventArgs e)
        {
           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string Next = textBox1.Text;
            
            string id_ob = authorizedUser.login;
            MySqlCommand command = new MySqlCommand("UPDATE `users` SET `Balance` = @popolnenie WHERE `login` = @id_ob", db.getConnection());
            command.Parameters.Add("@popolnenie", MySqlDbType.VarChar).Value = Next;
            command.Parameters.Add("@id_ob", MySqlDbType.VarChar).Value = id_ob;
            adapter.SelectCommand = command;
            adapter.Fill(table);
        }


    }
}