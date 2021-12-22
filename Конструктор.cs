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
    public partial class Конструктор : Form
    {
        private User authorizedUser;

        public Конструктор(User authorizedUser)
        {
            InitializeComponent();
            this.authorizedUser = authorizedUser;
        }
        public Конструктор()
        {
            InitializeComponent();
        }

        private void Конструктор_Load(object sender, EventArgs e)
        {

        }
    }
}
