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
    public partial class Form3 : Form
    {
        String active_user;
        String desired_user;
        ListView prevl;
        Form2 form2;
        public Form3(String text,ListView prevl_,Form2 form)
        {
            form2 = form;
            prevl = prevl_;
            active_user = text;
            InitializeComponent();
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            dbsHelper.createDM(Int32.Parse(active_user),Int32.Parse(desired_user));
            // form2 update list
            form2.updateRooms();
            this.Close();
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            DataTable userlist = dbsHelper.getDataSet("select * from users where UUID != " + active_user ).Tables[0];
            foreach (DataRow dr in userlist.Rows)
            {
                ListViewItem listViewItem = new ListViewItem(dr["NAME"].ToString());
                listViewItem.Tag = dr["UUID"].ToString();
                bool dont = false;
                for(int i =0 ; i < prevl.Items.Count;i++)
                {
                    if (prevl.Items[i].Text == listViewItem.Text && dbsHelper.getIsGroup((string)prevl.Items[i].Tag) == "0")
                    {
                        dont = true;
                    }
                }
                if (!dont)
                {
                    listView1.Items.Add(listViewItem);
                }
            }
            if (listView1.Items.Count != 0)
                desired_user = (string)listView1.Items[0].Tag;
            else
            {
                listView1.Items.Add(new ListViewItem("such empty much wow"));
                button1.Enabled = false;
            }

        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count == 0)
                return;
            active_user = (string)listView1.SelectedItems[0].Tag;
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            dbsHelper.createROOM(textBox1.Text, Int32.Parse(active_user));
            form2.updateRooms();
            this.Close();
        }
    }
}
