using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BankingApp
{
    public partial class Form2 : Form
    {
        User user;
        public Form2(User user_input)
        {
            user = user_input;
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            Name_text.Text = user.username;
            Balance_text.Text = user.Balance.ToString();
            Last_Access_text.Text = user.LastAccess;

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }
    }
}
