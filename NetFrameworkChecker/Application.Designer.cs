namespace NetFrameworkChecker {
    partial class Application {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.neededVersion = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.checkBoxInstalled = new System.Windows.Forms.CheckBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.message = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.linkWeb = new System.Windows.Forms.LinkLabel();
            this.linkOffline = new System.Windows.Forms.LinkLabel();
            this.label10 = new System.Windows.Forms.Label();
            this.buttonOk = new System.Windows.Forms.Button();
            this.buttonInstall = new System.Windows.Forms.Button();
            this.message2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // listBox1
            // 
            this.listBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listBox1.FormattingEnabled = true;
            this.listBox1.Location = new System.Drawing.Point(13, 157);
            this.listBox1.Margin = new System.Windows.Forms.Padding(3, 10, 3, 3);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(472, 82);
            this.listBox1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(10, 114);
            this.label1.Margin = new System.Windows.Forms.Padding(0, 7, 0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(175, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Is required version installed : ";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(10, 134);
            this.label3.Margin = new System.Windows.Forms.Padding(0, 7, 0, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(185, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "(info) List of installed versions :";
            // 
            // neededVersion
            // 
            this.neededVersion.AutoSize = true;
            this.neededVersion.Location = new System.Drawing.Point(124, 74);
            this.neededVersion.Name = "neededVersion";
            this.neededVersion.Size = new System.Drawing.Size(19, 13);
            this.neededVersion.TabIndex = 5;
            this.neededVersion.Text = "v?";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(10, 74);
            this.label4.Margin = new System.Windows.Forms.Padding(0, 7, 0, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(111, 13);
            this.label4.TabIndex = 4;
            this.label4.Text = "Required version :";
            // 
            // checkBoxInstalled
            // 
            this.checkBoxInstalled.AutoSize = true;
            this.checkBoxInstalled.Location = new System.Drawing.Point(188, 113);
            this.checkBoxInstalled.Name = "checkBoxInstalled";
            this.checkBoxInstalled.Size = new System.Drawing.Size(40, 17);
            this.checkBoxInstalled.TabIndex = 6;
            this.checkBoxInstalled.Text = "No";
            this.checkBoxInstalled.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(10, 10);
            this.label2.Margin = new System.Windows.Forms.Padding(0);
            this.label2.Name = "label2";
            this.label2.Padding = new System.Windows.Forms.Padding(0, 3, 0, 3);
            this.label2.Size = new System.Drawing.Size(470, 19);
            this.label2.TabIndex = 7;
            this.label2.Text = "The software you are trying to use requires a certain version of the Microsoft .n" +
    "et framework to run.";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(10, 29);
            this.label5.Margin = new System.Windows.Forms.Padding(0);
            this.label5.Name = "label5";
            this.label5.Padding = new System.Windows.Forms.Padding(0, 3, 0, 3);
            this.label5.Size = new System.Drawing.Size(293, 19);
            this.label5.TabIndex = 8;
            this.label5.Text = "This application is here to check if you fullfill this requirement.";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(10, 48);
            this.label6.Margin = new System.Windows.Forms.Padding(0);
            this.label6.Name = "label6";
            this.label6.Padding = new System.Windows.Forms.Padding(0, 3, 0, 3);
            this.label6.Size = new System.Drawing.Size(261, 19);
            this.label6.TabIndex = 9;
            this.label6.Text = "It will help you install the needed framework if needed.";
            // 
            // message
            // 
            this.message.AutoSize = true;
            this.message.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.message.Location = new System.Drawing.Point(10, 269);
            this.message.Margin = new System.Windows.Forms.Padding(0);
            this.message.Name = "message";
            this.message.Padding = new System.Windows.Forms.Padding(0, 3, 0, 3);
            this.message.Size = new System.Drawing.Size(405, 19);
            this.message.TabIndex = 10;
            this.message.Text = "You have the required version of .net framework installed, nothing needs to be do" +
    "ne!";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(10, 249);
            this.label8.Margin = new System.Windows.Forms.Padding(0, 7, 0, 7);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(100, 13);
            this.label8.TabIndex = 11;
            this.label8.Text = "Action required?";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(10, 94);
            this.label9.Margin = new System.Windows.Forms.Padding(0, 7, 0, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(199, 13);
            this.label9.TabIndex = 12;
            this.label9.Text = "Required version download links :";
            // 
            // linkWeb
            // 
            this.linkWeb.AutoSize = true;
            this.linkWeb.Location = new System.Drawing.Point(213, 94);
            this.linkWeb.Name = "linkWeb";
            this.linkWeb.Size = new System.Drawing.Size(68, 13);
            this.linkWeb.TabIndex = 13;
            this.linkWeb.TabStop = true;
            this.linkWeb.Text = "Web installer";
            this.linkWeb.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkWeb_LinkClicked);
            // 
            // linkOffline
            // 
            this.linkOffline.AutoSize = true;
            this.linkOffline.LinkBehavior = System.Windows.Forms.LinkBehavior.AlwaysUnderline;
            this.linkOffline.Location = new System.Drawing.Point(310, 94);
            this.linkOffline.Name = "linkOffline";
            this.linkOffline.Size = new System.Drawing.Size(75, 13);
            this.linkOffline.TabIndex = 14;
            this.linkOffline.TabStop = true;
            this.linkOffline.Text = "Offline installer";
            this.linkOffline.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkOffline_LinkClicked);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(287, 94);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(16, 13);
            this.label10.TabIndex = 15;
            this.label10.Text = "or";
            // 
            // buttonOk
            // 
            this.buttonOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonOk.Location = new System.Drawing.Point(410, 327);
            this.buttonOk.Name = "buttonOk";
            this.buttonOk.Size = new System.Drawing.Size(75, 23);
            this.buttonOk.TabIndex = 16;
            this.buttonOk.Text = "Ok";
            this.buttonOk.UseVisualStyleBackColor = true;
            this.buttonOk.Click += new System.EventHandler(this.buttonOk_Click);
            // 
            // buttonInstall
            // 
            this.buttonInstall.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonInstall.Location = new System.Drawing.Point(258, 327);
            this.buttonInstall.Name = "buttonInstall";
            this.buttonInstall.Size = new System.Drawing.Size(146, 23);
            this.buttonInstall.TabIndex = 17;
            this.buttonInstall.Text = "Install required version";
            this.buttonInstall.UseVisualStyleBackColor = true;
            this.buttonInstall.Click += new System.EventHandler(this.buttonInstall_Click);
            // 
            // message2
            // 
            this.message2.AutoSize = true;
            this.message2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.message2.Location = new System.Drawing.Point(10, 288);
            this.message2.Margin = new System.Windows.Forms.Padding(0);
            this.message2.Name = "message2";
            this.message2.Padding = new System.Windows.Forms.Padding(0, 3, 0, 3);
            this.message2.Size = new System.Drawing.Size(0, 19);
            this.message2.TabIndex = 18;
            // 
            // Application
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(498, 363);
            this.Controls.Add(this.message2);
            this.Controls.Add(this.buttonInstall);
            this.Controls.Add(this.buttonOk);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.linkOffline);
            this.Controls.Add(this.linkWeb);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.message);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.checkBoxInstalled);
            this.Controls.Add(this.neededVersion);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.listBox1);
            this.Name = "Application";
            this.Padding = new System.Windows.Forms.Padding(10);
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label neededVersion;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.CheckBox checkBoxInstalled;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label message;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.LinkLabel linkWeb;
        private System.Windows.Forms.LinkLabel linkOffline;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Button buttonOk;
        private System.Windows.Forms.Button buttonInstall;
        private System.Windows.Forms.Label message2;
    }
}

