using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NotePadApplication
{
    public partial class Form1 : Form
    {
        bool is_saved = true;
        bool skip_change = false;
        string currFileName = "Untitled";
        public Form1()
        {
            InitializeComponent();
        }

        private void formatToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!is_saved)
            {
                DialogResult result = MessageBox.Show("Current file is not saved. Do you want to discard ?", "New", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    currFileName = "Untitled";
                    this.Text = "Untitled - Notepad";
                    skip_change = true;
                    richTextBox1.Clear();
                    skip_change = false;
                    is_saved = true;
                }
            }
            else
            {
                currFileName = "Untitled";
                this.Text = "Untitled - Notepad";
                skip_change = true;
                richTextBox1.Clear();
                skip_change = false;
                is_saved = true;
            }
        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {

        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!is_saved)
            {
                DialogResult result = MessageBox.Show("Current file is not saved. Do you want to discard ?", "Open", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    openFileDialog1.Filter = "Text Files (*.txt) | *.txt";
                    if (openFileDialog1.ShowDialog() == DialogResult.OK)
                    {
                        richTextBox1.Text = System.IO.File.ReadAllText(openFileDialog1.FileName);
                    }
                    currFileName = openFileDialog1.FileName;
                    this.Text = openFileDialog1.FileName + " - " + "Notepad";
                    is_saved = true;
                }
            }
            else
            {
                openFileDialog1.Filter = "Text Files (*.txt) | *.txt";
                if (openFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    richTextBox1.Text = System.IO.File.ReadAllText(openFileDialog1.FileName);
                }
                currFileName = openFileDialog1.FileName;
                this.Text = openFileDialog1.FileName + " - " + "Notepad";
                is_saved = true;
            }
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                System.IO.File.WriteAllText(saveFileDialog1.FileName, richTextBox1.Text);
                currFileName = saveFileDialog1.FileName;
                this.Text = saveFileDialog1.FileName + " - " + "Notepad";
                is_saved = true;
            }
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {
            if (!skip_change)
            {
                if (is_saved)
                {
                    is_saved = false;
                    this.Text = currFileName + "* - " + "Notepad";
                }
            }
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.Text = "Untitled - Notepad";
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!is_saved)
            {
                DialogResult result = MessageBox.Show("File is not saved. Do you still want to exit ?", "Exit", MessageBoxButtons.YesNoCancel);
                if (result == DialogResult.Yes)
                {
                    this.Close();
                }
            }
            else
            {
                this.Close();
            }
        }

        private void cutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Cut();
        }

        private void copyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Copy();
        }

        private void pasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Paste();
        }

        private void selectAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.SelectAll();
        }

        private void fontToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fontDialog1.ShowDialog();
            richTextBox1.Font = fontDialog1.Font;
        }

        private void colorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            colorDialog1.ShowDialog();
            richTextBox1.ForeColor = colorDialog1.Color;
        }

        private void aboutUsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Made in DBS Lab by Parth");
        }
    }
}
