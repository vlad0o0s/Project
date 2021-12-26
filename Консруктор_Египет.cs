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
    public partial class Консруктор_Египет : Form
    {
        private User authorizedUser;
        private Конструктор.country konstruktorEgipet;
        private Аккаунт.UserUpdete userUpdete;
        DB db = new DB();

        DataTable table = new DataTable();

        MySqlDataAdapter adapter = new MySqlDataAdapter();


        public Консруктор_Египет()
        {
            InitializeComponent();
        }

        public Консруктор_Египет(Конструктор.country konstruktorEgipet, User authorizedUser, Аккаунт.UserUpdete userUpdete)
        {
            InitializeComponent();
            this.authorizedUser = authorizedUser;
            this.konstruktorEgipet = konstruktorEgipet;
            this.userUpdete = userUpdete; 
        }

        private void Консруктор_Египет_Load(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int a = konstruktorEgipet.egipet;
            int b = 0;
            int c = 0;
            int d = 0;
            int day = 0;
                if (comboBox1.Text == "Каир")
                {
                    table.Clear();
                    MySqlCommand command = new MySqlCommand("SELECT * FROM `city` WHERE `id` = 1", db.getConnection());
                    adapter.SelectCommand = command;
                    adapter.Fill(table);
                    DataRow city = table.Rows[0];
                    b = Convert.ToInt32(city["price"]);
                }
                if (comboBox1.Text == "Александрия")
                {
                    table.Clear();
                    MySqlCommand command = new MySqlCommand("SELECT * FROM `city` WHERE `id` = 2", db.getConnection());
                    adapter.SelectCommand = command;
                    adapter.Fill(table);
                    DataRow city = table.Rows[0];
                    b = Convert.ToInt32(city["price"]);
                }
                if (comboBox1.Text == "Гиза")
                {
                    table.Clear();
                    MySqlCommand command = new MySqlCommand("SELECT * FROM `city` WHERE `id` = 3", db.getConnection());
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
                if (comboBox3.Text == "Личный гид на один день")
                {
                    table.Clear();
                    MySqlCommand command = new MySqlCommand("SELECT * FROM `ex` WHERE `id` = 1", db.getConnection());
                    adapter.SelectCommand = command;
                    adapter.Fill(table);
                    DataRow city = table.Rows[0];
                    d = Convert.ToInt32(city["price"]);
                }
                if (comboBox3.Text == "Оазис Бахария из Каира")
                {
                    table.Clear();
                    MySqlCommand command = new MySqlCommand("SELECT * FROM `ex` WHERE `id` = 2", db.getConnection());
                    adapter.SelectCommand = command;
                    adapter.Fill(table);
                    DataRow city = table.Rows[0];
                    d = Convert.ToInt32(city["price"]);
                }
                if (comboBox3.Text == "В Луксор на самолёте")
                {
                    table.Clear();
                    MySqlCommand command = new MySqlCommand("SELECT * FROM `ex` WHERE `id` = 3", db.getConnection());
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
            res = a + b + c * day + d; //a - билеты в страну b - город c - отель d - экскурсии day - кол-во дней
            string res1 = Convert.ToString(res);
                DialogResult result = MessageBox.Show("Сумма к оплате " + res1 + " Руб.", "Стоимость тура", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    int x = Convert.ToInt32(userUpdete.Balance);
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

                    MySqlCommand command = new MySqlCommand("UPDATE `users` SET `Balance` = @obrabotka WHERE `login` = @id_ob; UPDATE `users` SET `name_tur` = @name WHERE `login` = @id_ob; UPDATE `users` SET `Город` = @city WHERE `login` = @id_ob; UPDATE `users` SET `Отель` = @hotel WHERE `login` = @id_ob; UPDATE `users` SET `Экскурсии` = @ex WHERE `login` = @id_ob; UPDATE `users` SET `days` = @day WHERE `login` = @id_ob ", db.getConnection());
                    command.Parameters.Add("@obrabotka", MySqlDbType.VarChar).Value = Res;
                    command.Parameters.Add("@id_ob", MySqlDbType.VarChar).Value = id_ob;
                    command.Parameters.Add("@name", MySqlDbType.VarChar).Value = "Египет";
                    command.Parameters.Add("@city", MySqlDbType.VarChar).Value = comboBox1.Text;
                    command.Parameters.Add("@hotel", MySqlDbType.VarChar).Value = comboBox2.Text;
                    command.Parameters.Add("@ex", MySqlDbType.VarChar).Value = comboBox3.Text;
                command.Parameters.Add("@day", MySqlDbType.VarChar).Value = comboBox4.Text;

                adapter.SelectCommand = command;
                    adapter.Fill(table);

                    MessageBox.Show("Вы успешно купили тур по Египту");
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
