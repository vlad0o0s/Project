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
        private Constructor konstruktorEgipet;
        public Консруктор_Египет(User authorizedUser)
        {
            InitializeComponent();

            this.authorizedUser = authorizedUser;
        }

        public Консруктор_Египет(Constructor konstruktorEgipet)
        {
            InitializeComponent();

            this.konstruktorEgipet = konstruktorEgipet;
        }
        public Консруктор_Египет()
        {
            InitializeComponent();
        }

        private void Консруктор_Египет_Load(object sender, EventArgs e)
        {

        }
    }
}
