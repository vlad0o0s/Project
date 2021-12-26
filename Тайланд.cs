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
    public partial class Тайланд : Form
    {
        DB db = new DB();

        DataTable table = new DataTable();

        MySqlDataAdapter adapter = new MySqlDataAdapter();

        private User authorizedUser;
        private Аккаунт.UserUpdete userUpdete;

        public Тайланд()
        {
            InitializeComponent();
        }

        public Тайланд(User authorizedUser, Аккаунт.UserUpdete userUpdete)
        {
            InitializeComponent();
            this.authorizedUser = authorizedUser;
            this.userUpdete = userUpdete;

        }

        private void Тайланд_Load(object sender, EventArgs e)
        {

            MySqlCommand command = new MySqlCommand("SELECT * FROM `ready_turs` WHERE id = 3", db.getConnection());

            adapter.SelectCommand = command;
            adapter.Fill(table);
            var TursPrice = new Turs(table.Rows[0]);
            string t1 = TursPrice.Price.ToString();
            label1.Text = t1 + " Руб.";
            Balance.Text = userUpdete.Balance + " Руб.";

        }


        public class Turs
        {
            public int Price;
            public Turs(DataRow dataRow)
            {
                Price = (int)dataRow[2];

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Аккаунт account = new Аккаунт(authorizedUser);
            account.Show();
        }
        private void label4_MouseLeave(object sender, EventArgs e)
        {
            label4.Font = new Font("Microsoft Sans Serif", 8);

        }

        private void label4_MouseEnter(object sender, EventArgs e)
        {
            label4.Font = new Font("Microsoft Sans Serif", 8, FontStyle.Italic);

        }
        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult result1 = MessageBox.Show("Купить тур по Тайланду?", "Подтвержение", MessageBoxButtons.YesNo);
            if (result1 == DialogResult.Yes)
            {
                var TursPrice = new Turs(table.Rows[0]);
                int t1 = TursPrice.Price;
                int x = Convert.ToInt32(userUpdete.Balance);
                int y = t1;
                int id_ob = Convert.ToInt32(authorizedUser.login);


                if (y > x)
                {
                    DialogResult result = MessageBox.Show("Недостаточно средств, пополнить кошелек?", "Ошибка", MessageBoxButtons.YesNo);
                    if (result == DialogResult.Yes)
                    {
                        this.Hide();
                        Аккаунт account = new Аккаунт(authorizedUser);
                        account.Show();
                    }

                    return;
                }
                int Res = x - y;

                MySqlCommand command = new MySqlCommand("UPDATE `users` SET `Balance` = @obrabotka WHERE `login` = @id_ob; UPDATE `users` SET `name_tur` = @name WHERE `login` = @id_ob; UPDATE `users` SET `Город` = @city WHERE `login` = @id_ob; UPDATE `users` SET `Отель` = @hotel WHERE `login` = @id_ob; UPDATE `users` SET `Экскурсии` = @ex WHERE `login` = @id_ob; UPDATE `users` SET `days` = @day WHERE `login` = @id_ob;", db.getConnection());
                command.Parameters.Add("@obrabotka", MySqlDbType.VarChar).Value = Res;
                command.Parameters.Add("@id_ob", MySqlDbType.VarChar).Value = id_ob;
                command.Parameters.Add("@name", MySqlDbType.VarChar).Value = label3.Text;
                command.Parameters.Add("@day", MySqlDbType.VarChar).Value = "7";
                command.Parameters.Add("@city", MySqlDbType.VarChar).Value = "Бангкок";
                command.Parameters.Add("@ex", MySqlDbType.VarChar).Value = "Нет";
                command.Parameters.Add("@hotel", MySqlDbType.VarChar).Value = "Обычного класса";

                adapter.SelectCommand = command;
                adapter.Fill(table);

                MessageBox.Show("Вы успешно купили тур по Тайланду");
                this.Hide();
                Аккаунт аккаунт = new Аккаунт(authorizedUser);
                аккаунт.Show();
            }
        }
    }
}
