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
    public partial class Готовые_туры : Form
    {
        DB db = new DB();

        DataTable table = new DataTable();

        MySqlDataAdapter adapter = new MySqlDataAdapter();
        private User authorizedUser;
        private Аккаунт.UserUpdete userUpdete;

        public Готовые_туры()
        {
            InitializeComponent();
        }
        public Готовые_туры(User authorizedUser, Аккаунт.UserUpdete userUpdete)
        {
            InitializeComponent();
            this.authorizedUser = authorizedUser;
            this.userUpdete = userUpdete;

        }

        private void Готовые_туры_Load(object sender, EventArgs e)
        {

        }


        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Hide();

            Египет eg = new Египет(authorizedUser, userUpdete);
            eg.Show();

        }

        private void pictureBox1_MouseLeave(object sender, EventArgs e)
        {
            label1.Font = new Font("Microsoft Sans Serif", 17, FontStyle.Bold);
            pictureBox1.Width = 322;
            pictureBox1.Height = 157;
        }

        private void pictureBox1_MouseEnter(object sender, EventArgs e)
        {
            label1.Font = new Font("Microsoft Sans Serif", 20, FontStyle.Bold);
            pictureBox1.Width = 330;
            pictureBox1.Height = 165;
        }

        private void pictureBox2_MouseLeave(object sender, EventArgs e)
        {
            label2.Font = new Font("Microsoft Sans Serif", 17, FontStyle.Bold);
            pictureBox2.Width = 322;
            pictureBox2.Height = 157;
        }

        private void pictureBox2_MouseEnter(object sender, EventArgs e)
        {
            label2.Font = new Font("Microsoft Sans Serif", 20, FontStyle.Bold);
            pictureBox2.Width = 330;
            pictureBox2.Height = 165;
        }

        private void pictureBox3_MouseLeave(object sender, EventArgs e)
        {
            label3.Font = new Font("Microsoft Sans Serif", 17, FontStyle.Bold);
            pictureBox3.Width = 322;
            pictureBox3.Height = 157;
        }

        private void pictureBox3_MouseEnter(object sender, EventArgs e)
        {
            label3.Font = new Font("Microsoft Sans Serif", 20, FontStyle.Bold);
            pictureBox3.Width = 330;
            pictureBox3.Height = 165;
        }

        private void pictureBox4_MouseLeave(object sender, EventArgs e)
        {
            label4.Font = new Font("Microsoft Sans Serif", 17, FontStyle.Bold);
            pictureBox4.Width = 322;
            pictureBox4.Height = 157;
        }

        private void pictureBox4_MouseEnter(object sender, EventArgs e)
        {
            label4.Font = new Font("Microsoft Sans Serif", 20, FontStyle.Bold);
            pictureBox4.Width = 330;
            pictureBox4.Height = 165;
        }
    }
}
