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
    public partial class Form4 : Form
    {
        String active_chat;
        String active_user;
        String desired_user;
        public Form4(string text,string text2)
        {
            active_chat = text;
            active_user = text2;
            InitializeComponent();
        }

        private void Form4_Load(object sender, EventArgs e)
        {
            updateParticipantsList();
            DataTable adduserlist = dbsHelper.getDataSet("select * from Users MINUS select * from Users where UUID in ( select UUID from user_room where RUID = " + active_chat + ")" ).Tables[0];
            foreach (DataRow dr in adduserlist.Rows)
            {
                ListViewItem listViewItem = new ListViewItem(dr["NAME"].ToString());
                listViewItem.Tag = dr["UUID"].ToString();
                listView2.Items.Add(listViewItem);
            }
        }
        private void updateParticipantsList()
        {
            DataTable userlist = dbsHelper.getDataSet("select * from Users where UUID in ( select UUID from user_room where RUID = " + active_chat + " AND UUID != "+active_user+")").Tables[0];
            listView1.Clear();
            foreach (DataRow dr in userlist.Rows)
            {
                ListViewItem listViewItem = new ListViewItem(dr["NAME"].ToString());
                listViewItem.Tag = dr["UUID"].ToString();   
                listView1.Items.Add(listViewItem);
            }
            listView1.Items.Add("You");
        }

        private void listView2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listView2.Items.Count != 0)
                desired_user = (string)listView1.Items[0].Tag;
            else
            {
                listView2.Items.Add(new ListViewItem("such empty much wow"));
                button2.Enabled = false;
            }
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            dbsHelper.AddUser(Int32.Parse(desired_user), Int32.Parse(active_chat));
            updateParticipantsList();
        }
    }
}
