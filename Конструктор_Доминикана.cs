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
    public partial class Конструктор_Доминикана : Form
    {
        private User authorizedUser;
        private Конструктор.country konstruktorEgipet;
        private Аккаунт.UserUpdete userUpdete;
        DB db = new DB();

        DataTable table = new DataTable();

        MySqlDataAdapter adapter = new MySqlDataAdapter();


        public Конструктор_Доминикана()
        {
            InitializeComponent();
        }

        public Конструктор_Доминикана(Конструктор.country konstruktorEgipet, User authorizedUser, Аккаунт.UserUpdete userUpdete)
        {
            InitializeComponent();
            this.authorizedUser = authorizedUser;
            this.konstruktorEgipet = konstruktorEgipet;
            this.userUpdete = userUpdete;
        }

        private void Конструктор_Доминикана_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            int a = konstruktorEgipet.egipet;
            int b = 0;
            int c = 0;
            int d = 0;
            int day = 0;
            if (comboBox1.Text == "Санто-Доминго")
            {
                table.Clear();
                MySqlCommand command = new MySqlCommand("SELECT * FROM `city` WHERE `id` = 10", db.getConnection());
                adapter.SelectCommand = command;
                adapter.Fill(table);
                DataRow city = table.Rows[0];
                b = Convert.ToInt32(city["price"]);
            }
            if (comboBox1.Text == "Лос-Алькаррисос")
            {
                table.Clear();
                MySqlCommand command = new MySqlCommand("SELECT * FROM `city` WHERE `id` = 11", db.getConnection());
                adapter.SelectCommand = command;
                adapter.Fill(table);
                DataRow city = table.Rows[0];
                b = Convert.ToInt32(city["price"]);
            }
            if (comboBox1.Text == "Игуэй")
            {
                table.Clear();
                MySqlCommand command = new MySqlCommand("SELECT * FROM `city` WHERE `id` = 12", db.getConnection());
                adapter.SelectCommand = command;
                adapter.Fill(table);
                DataRow city = table.Rows[0];
                b = Convert.ToInt32(city["price"]);
            }
            if (comboBox2.Text == "Обычного класса")
            {
                table.Clear();
                MySqlCommand command = new MySqlCommand("SELECT * FROM `hotel` WHERE `id` = 1", db.getConnection());
                adapter.SelectCommand = command;
                adapter.Fill(table);
                DataRow city = table.Rows[0];
                c = Convert.ToInt32(city["price"]);
            }
            if (comboBox2.Text == "Среднего класса")
            {
                table.Clear();
                MySqlCommand command = new MySqlCommand("SELECT * FROM `hotel` WHERE `id` = 2", db.getConnection());
                adapter.SelectCommand = command;
                adapter.Fill(table);
                DataRow city = table.Rows[0];
                c = Convert.ToInt32(city["price"]);
            }
            if (comboBox2.Text == "Высокого класса")
            {
                table.Clear();
                MySqlCommand command = new MySqlCommand("SELECT * FROM `hotel` WHERE `id` = 3", db.getConnection());
                adapter.SelectCommand = command;
                adapter.Fill(table);
                DataRow city = table.Rows[0];
                c = Convert.ToInt32(city["price"]);
            }
            if (comboBox3.Text == "Нет")
            {
                table.Clear();
                MySqlCommand command = new MySqlCommand("SELECT * FROM `ex` WHERE `id` = 4", db.getConnection());
                adapter.SelectCommand = command;
                adapter.Fill(table);
                DataRow city = table.Rows[0];
                d = Convert.ToInt32(city["price"]);
            }
            if (comboBox3.Text == "Остров Саона Делюкс")
            {
                table.Clear();
                MySqlCommand command = new MySqlCommand("SELECT * FROM `ex` WHERE `id` = 11", db.getConnection());
                adapter.SelectCommand = command;
                adapter.Fill(table);
                DataRow city = table.Rows[0];
                d = Convert.ToInt32(city["price"]);
            }
            if (comboBox3.Text == "Секрет Саманы - Ринкон")
            {
                table.Clear();
                MySqlCommand command = new MySqlCommand("SELECT * FROM `ex` WHERE `id` = 12", db.getConnection());
                adapter.SelectCommand = command;
                adapter.Fill(table);
                DataRow city = table.Rows[0];
                d = Convert.ToInt32(city["price"]);
            }
            if (comboBox3.Text == "Ужин в небесах: самый необычный ресторан в Доминикане!")
            {
                table.Clear();
                MySqlCommand command = new MySqlCommand("SELECT * FROM `ex` WHERE `id` = 13", db.getConnection());
                adapter.SelectCommand = command;
                adapter.Fill(table);
                DataRow city = table.Rows[0];
                d = Convert.ToInt32(city["price"]);
            }
            if (comboBox4.Text == "3")
            {

                day = Convert.ToInt32(comboBox4.Text);
            }
            if (comboBox4.Text == "5")
            {

                day = Convert.ToInt32(comboBox4.Text);
            }
            if (comboBox4.Text == "7")
            {

                day = Convert.ToInt32(comboBox4.Text);
            }
            if (comboBox4.Text == "14")
            {

                day = Convert.ToInt32(comboBox4.Text);
            }
            if (comboBox4.Text == "21")
            {

                day = Convert.ToInt32(comboBox4.Text);
            }
            if (comboBox4.Text == "30")
            {

                day = Convert.ToInt32(comboBox4.Text);
            }
            int res = 0;
            res = a + b + c * day + d;
            string res1 = Convert.ToString(res);
            DialogResult result = MessageBox.Show("Сумма к оплате " + res1 + " Руб.", "Стоимость тура", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                int x = Convert.ToInt32(userUpdete.balance);
                int id_ob = Convert.ToInt32(authorizedUser.login);

                if (res > x)
                {
                    DialogResult result1 = MessageBox.Show("Недостаточно средств, пополнить кошелек?", "Ошибка", MessageBoxButtons.YesNo);
                    if (result == DialogResult.Yes)
                    {
                        this.Hide();
                        Аккаунт account = new Аккаунт(authorizedUser);
                        account.Show();
                    }
                    return;
                }

                int Res = x - res;

                MySqlCommand command = new MySqlCommand("UPDATE `users` SET `balance` = @obrabotka WHERE `login` = @id_ob; UPDATE `users` SET `turs` = @name WHERE `login` = @id_ob; UPDATE `users` SET `city` = @city WHERE `login` = @id_ob; UPDATE `users` SET `hotel` = @hotel WHERE `login` = @id_ob; UPDATE `users` SET `ex` = @ex WHERE `login` = @id_ob; UPDATE `users` SET `day` = @day WHERE `login` = @id_ob;", db.getConnection());
                command.Parameters.Add("@obrabotka", MySqlDbType.VarChar).Value = Res;
                command.Parameters.Add("@id_ob", MySqlDbType.VarChar).Value = id_ob;
                command.Parameters.Add("@name", MySqlDbType.VarChar).Value = "Доминикана";
                command.Parameters.Add("@city", MySqlDbType.VarChar).Value = comboBox1.Text;
                command.Parameters.Add("@hotel", MySqlDbType.VarChar).Value = comboBox2.Text;
                command.Parameters.Add("@ex", MySqlDbType.VarChar).Value = comboBox3.Text;
                command.Parameters.Add("@day", MySqlDbType.VarChar).Value = comboBox4.Text;

                adapter.SelectCommand = command;
                adapter.Fill(table);

                MessageBox.Show("Вы успешно купили тур по Доминикане");
                this.Hide();
                Аккаунт аккаунт = new Аккаунт(authorizedUser);
                аккаунт.Show();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Аккаунт аккаунт = new Аккаунт(authorizedUser);
            аккаунт.Show();
        }
    }
}
