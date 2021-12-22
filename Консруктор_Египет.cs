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
        private Конструктор.Const konstruktorEgipet;
        private Аккаунт.UserUpdete userUpdete;
        DB db = new DB();

        DataTable table = new DataTable();

        MySqlDataAdapter adapter = new MySqlDataAdapter();


        public Консруктор_Египет()
        {
            InitializeComponent();
        }

        public Консруктор_Египет(Конструктор.Const konstruktorEgipet, User authorizedUser, Аккаунт.UserUpdete userUpdete)
        {
            InitializeComponent();
            this.authorizedUser = authorizedUser;
            this.konstruktorEgipet = konstruktorEgipet;
            this.userUpdete = userUpdete;
        }

        private void Консруктор_Египет_Load(object sender, EventArgs e)
        {
            label4.Text = userUpdete.Balance;
            
        }

        private void button1_Click(object sender, EventArgs e)
        {

            int a = konstruktorEgipet.egipet;
            int b = 0;
            int c = 0;
            int d = 0;
            if (comboBox1.Text == "Каир")
            {
                b = konstruktorEgipet.e_name1;
            }
            if (comboBox1.Text == "Александрия")
            {
                b = konstruktorEgipet.e_name2;
            }
            if (comboBox1.Text == "Гиза")
            {
                b = konstruktorEgipet.e_name3;
            }
            if (comboBox2.Text == "Обычного класса")
            {
                c = konstruktorEgipet.otel1;
            }
            if (comboBox2.Text == "Среднего класса")
            {
                c = konstruktorEgipet.otel2;
            }
            if (comboBox2.Text == "Высокого класса")
            {
                c = konstruktorEgipet.otel3;
            }
            if (comboBox3.Text == "1")
            {
                d = konstruktorEgipet.ex1;
            }
            if (comboBox3.Text == "2")
            {
                d = konstruktorEgipet.ex2;
            }
            if (comboBox3.Text == "4")
            {
                d = konstruktorEgipet.ex3;
            }
            int res = 0;
            res = a + b + c + d;
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

                MySqlCommand command = new MySqlCommand("UPDATE `users` SET `Balance` = @obrabotka WHERE `login` = @id_ob; UPDATE `users` SET `name_tur` = @name WHERE `login` = @id_ob; UPDATE `users` SET `Город` = @city WHERE `login` = @id_ob; UPDATE `users` SET `Отель` = @hotel WHERE `login` = @id_ob; UPDATE `users` SET `Экскурсии` = @ex WHERE `login` = @id_ob ", db.getConnection());
                command.Parameters.Add("@obrabotka", MySqlDbType.VarChar).Value = Res;
                command.Parameters.Add("@id_ob", MySqlDbType.VarChar).Value = id_ob;
                command.Parameters.Add("@name", MySqlDbType.VarChar).Value = "Египет";
                command.Parameters.Add("@city", MySqlDbType.VarChar).Value = comboBox1.Text;
                command.Parameters.Add("@hotel", MySqlDbType.VarChar).Value = comboBox2.Text;
                command.Parameters.Add("@ex", MySqlDbType.VarChar).Value = comboBox3.Text;

                adapter.SelectCommand = command;
                adapter.Fill(table);

                MessageBox.Show("Вы успешно купили тур по Египту");
                this.Hide();
                Аккаунт аккаунт = new Аккаунт(authorizedUser);
                аккаунт.Show();
            }
        }
    }
}
