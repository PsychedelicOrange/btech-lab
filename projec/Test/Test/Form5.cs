using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Test
{
    public partial class Form5 : Form
    {
        String active_user;
        public Form5(string text)
        {
            active_user = text;
            InitializeComponent();
        }

        private void Form5_Load(object sender, EventArgs e)
        {

        }
    }
}
