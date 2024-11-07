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
    public partial class Form2 : Form
    {
        String active_user;
        DataTable activeUser_rooms;
        String active_chat;
        Decimal active_dm;
        public Form2(String text)
        {
            active_user = text;
            //richTextBox2.KeyDown += new KeyEventHandler(richTextBox2_KeyDown);
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            updateRooms();
            active_chat = (string)listView1.Items[0].Tag;
            updateMessages();
        }
        public void updateRooms()
        {
            activeUser_rooms = dbsHelper.getDataSet("select * from ROOMS where RUID in ( select RUID from USER_ROOM where UUID = " + active_user + ")").Tables[0];
            listView1.Clear();
            foreach (DataRow dr in activeUser_rooms.Rows)
            {
                ListViewItem listViewItem = new ListViewItem();
                if (dr["ISGROUP"].ToString() == "0")
                {
                    active_dm = (Decimal)dbsHelper.ExecuteCommand("select UUID from user_room where RUID = " + dr["RUID"] + "AND UUID !=" + active_user);
                    listViewItem.Text = dbsHelper.getUserName(active_dm.ToString());
                }
                else
                {
                    listViewItem.Text = dr["NAME"].ToString();
                }
                listViewItem.Tag = dr["RUID"].ToString();
                listView1.Items.Add(listViewItem);
            }
        }
        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count == 0)
                return;
            active_chat = (string)listView1.SelectedItems[0].Tag;
            updateMessages();
        }


       
        private void updateMessages()
        {
            chat.Clear();
            DataSet ds = dbsHelper.getDataSet("select * from MESSAGES where RUID = " + active_chat + "order by time ASC");
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                chat.Text += dbsHelper.getUserName(dr["UUID"].ToString()) + " : " + dr["CONTENT"].ToString() + "\n";
            }
        }

        private void richTextBox2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                dbsHelper.SendMsg(int.Parse(active_user),int.Parse( active_chat), richTextBox2.Text);
                System.Console.WriteLine(int.Parse(active_user) +""+ int.Parse(active_chat) + richTextBox2.Text);
                richTextBox2.Clear();
            }
            updateMessages();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            updateMessages();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form3 form = new Form3(active_user,listView1,this);
            form.Show();
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            updateRooms();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (dbsHelper.getIsGroup(active_chat) == "1")
            {
                Form4 form = new Form4(active_chat,active_user);
                form.Show();
            }
            else
            {
                Form5 form = new Form5(active_chat);
                form.Show();
            }
        }
    }
}
