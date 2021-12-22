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

        public Консруктор_Египет()
        {
            InitializeComponent();
        }

        public Консруктор_Египет(Конструктор.Const konstruktorEgipet, User authorizedUser)
        {
            InitializeComponent();
            this.authorizedUser = authorizedUser;
            this.konstruktorEgipet = konstruktorEgipet;
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
            if (comboBox1.Text == "Каир")
            {
                b = konstruktorEgipet.e_name1;
                return;
            }
            Console.WriteLine(b);
            if (comboBox1.Text == "Александрия")
            {
                b = konstruktorEgipet.e_name2;
                return;
            }
            if (comboBox1.Text == "Гиза")
            {
                b = konstruktorEgipet.e_name3;
                return;
            }
            if (comboBox2.Text == "Отель обычного класса")
            {
                c = konstruktorEgipet.otel1;
                return;
            }
            if (comboBox2.Text == "Отель среднего класса")
            {
                c = konstruktorEgipet.otel2;
                return;
            }
            if (comboBox2.Text == "Отель высокого класса")
            {
                c = konstruktorEgipet.otel3;
                return;
            }
            if (comboBox3.Text == "1 Экскурсия")
            {
                d = konstruktorEgipet.ex1;
                return;
            }
            if (comboBox3.Text == "2 Экскурсии")
            {
                d = konstruktorEgipet.ex2;
                return;
            }
            if (comboBox3.Text == "4 Экскурсии")
            {
                d = konstruktorEgipet.ex3;
                return;
            }
            
            int res = a + b + c + d;
            Console.WriteLine(res);
            MessageBox.Show("Сумма к оплате " + res + " Руб.");
        }
    }
}
