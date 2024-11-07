namespace BankingApp
{
    partial class Form2
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.Name_text = new System.Windows.Forms.Label();
            this.Balance_text = new System.Windows.Forms.Label();
            this.Last_Access_text = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(25, 42);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Name";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(25, 68);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(46, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Balance";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(25, 95);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Last Access";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(25, 123);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(109, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Recent Transactions:";
            this.label4.Click += new System.EventHandler(this.label4_Click);
            // 
            // Name_text
            // 
            this.Name_text.AutoSize = true;
            this.Name_text.Location = new System.Drawing.Point(66, 42);
            this.Name_text.Name = "Name_text";
            this.Name_text.Size = new System.Drawing.Size(58, 13);
            this.Name_text.TabIndex = 4;
            this.Name_text.Text = "Name_text";
            // 
            // Balance_text
            // 
            this.Balance_text.AutoSize = true;
            this.Balance_text.Location = new System.Drawing.Point(89, 68);
            this.Balance_text.Name = "Balance_text";
            this.Balance_text.Size = new System.Drawing.Size(69, 13);
            this.Balance_text.TabIndex = 5;
            this.Balance_text.Text = "Balance_text";
            // 
            // Last_Access_text
            // 
            this.Last_Access_text.AutoSize = true;
            this.Last_Access_text.Location = new System.Drawing.Point(99, 95);
            this.Last_Access_text.Name = "Last_Access_text";
            this.Last_Access_text.Size = new System.Drawing.Size(91, 13);
            this.Last_Access_text.TabIndex = 6;
            this.Last_Access_text.Text = "Last_Access_text";
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.Last_Access_text);
            this.Controls.Add(this.Balance_text);
            this.Controls.Add(this.Name_text);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "Form2";
            this.Text = "Form2";
            this.Load += new System.EventHandler(this.Form2_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label Name_text;
        private System.Windows.Forms.Label Balance_text;
        private System.Windows.Forms.Label Last_Access_text;
    }
}