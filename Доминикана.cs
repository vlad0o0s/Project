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
    public partial class Доминикана : Form
    {
        DB db = new DB();

        DataTable table = new DataTable();

        MySqlDataAdapter adapter = new MySqlDataAdapter();

        private User authorizedUser;
        private Аккаунт.UserUpdete userUpdete;

        public Доминикана()
        {
            InitializeComponent();
        }

        public Доминикана(User authorizedUser, Аккаунт.UserUpdete userUpdete)
        {
            InitializeComponent();
            this.authorizedUser = authorizedUser;
            this.userUpdete = userUpdete;

        }

        private void Доминикана_Load(object sender, EventArgs e)
        {

            MySqlCommand command = new MySqlCommand("SELECT * FROM `ready_turs` WHERE id = 4", db.getConnection());

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
            DialogResult result1 = MessageBox.Show("Купить тур по Доминикане?", "Подтвержение", MessageBoxButtons.YesNo);
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

                MySqlCommand command = new MySqlCommand("UPDATE `users` SET `Balance` = @obrabotka WHERE `login` = @id_ob; UPDATE `users` SET `name_tur` = @name WHERE `login` = @id_ob; UPDATE `users` SET `Город` = Каир WHERE `login` = @id_ob; UPDATE `users` SET `Отель` = Обычного класса WHERE `login` = @id_ob; UPDATE `users` SET `Экскурсии` = Нет WHERE `login` = @id_ob;", db.getConnection());
                command.Parameters.Add("@obrabotka", MySqlDbType.VarChar).Value = Res;
                command.Parameters.Add("@id_ob", MySqlDbType.VarChar).Value = id_ob;
                command.Parameters.Add("@name", MySqlDbType.VarChar).Value = label3.Text;

                adapter.SelectCommand = command;
                adapter.Fill(table);

                MessageBox.Show("Вы успешно купили тур по Доминикане");
                this.Hide();
                Аккаунт аккаунт = new Аккаунт(authorizedUser);
                аккаунт.Show();
            }
        }
    }
}
