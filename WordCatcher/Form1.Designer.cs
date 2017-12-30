namespace WordCatcher
{
    partial class Form1
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
            this.wordTxt = new System.Windows.Forms.TextBox();
            this.goBtn = new System.Windows.Forms.Button();
            this.driveTree = new System.Windows.Forms.TreeView();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.saveBtn = new System.Windows.Forms.Button();
            this.newFileBtn = new System.Windows.Forms.Button();
            this.newFileTxt = new System.Windows.Forms.TextBox();
            this.queueLbx = new System.Windows.Forms.ListBox();
            this.extraInfoTxt = new System.Windows.Forms.TextBox();
            this.tabControl2 = new System.Windows.Forms.TabControl();
            this.text1Tab = new System.Windows.Forms.TabPage();
            this.text2Tab = new System.Windows.Forms.TabPage();
            this.text3Tab = new System.Windows.Forms.TabPage();
            this.text4Tab = new System.Windows.Forms.TabPage();
            this.text1Txt = new System.Windows.Forms.TextBox();
            this.text2Txt = new System.Windows.Forms.TextBox();
            this.text3Txt = new System.Windows.Forms.TextBox();
            this.text4Txt = new System.Windows.Forms.TextBox();
            this.toText1Btn = new System.Windows.Forms.Button();
            this.toText2Btn = new System.Windows.Forms.Button();
            this.toText3Btn = new System.Windows.Forms.Button();
            this.toText4Btn = new System.Windows.Forms.Button();
            this.tabControl2.SuspendLayout();
            this.text1Tab.SuspendLayout();
            this.text2Tab.SuspendLayout();
            this.text3Tab.SuspendLayout();
            this.text4Tab.SuspendLayout();
            this.SuspendLayout();
            // 
            // wordTxt
            // 
            this.wordTxt.Location = new System.Drawing.Point(8, 8);
            this.wordTxt.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.wordTxt.Name = "wordTxt";
            this.wordTxt.Size = new System.Drawing.Size(609, 20);
            this.wordTxt.TabIndex = 0;
            this.wordTxt.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.wordTxt_KeyPress);
            // 
            // goBtn
            // 
            this.goBtn.Location = new System.Drawing.Point(620, 5);
            this.goBtn.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.goBtn.Name = "goBtn";
            this.goBtn.Size = new System.Drawing.Size(35, 20);
            this.goBtn.TabIndex = 1;
            this.goBtn.Text = "GO";
            this.goBtn.UseVisualStyleBackColor = true;
            this.goBtn.Click += new System.EventHandler(this.goBtn_Click);
            // 
            // driveTree
            // 
            this.driveTree.Location = new System.Drawing.Point(659, 289);
            this.driveTree.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.driveTree.Name = "driveTree";
            this.driveTree.Size = new System.Drawing.Size(241, 187);
            this.driveTree.TabIndex = 4;
            this.driveTree.BeforeExpand += new System.Windows.Forms.TreeViewCancelEventHandler(this.driveTree_BeforeExpand);
            this.driveTree.AfterExpand += new System.Windows.Forms.TreeViewEventHandler(this.driveTree_AfterExpand);
            // 
            // tabControl1
            // 
            this.tabControl1.Location = new System.Drawing.Point(8, 29);
            this.tabControl1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(647, 473);
            this.tabControl1.TabIndex = 5;
            // 
            // saveBtn
            // 
            this.saveBtn.Location = new System.Drawing.Point(659, 5);
            this.saveBtn.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.saveBtn.Name = "saveBtn";
            this.saveBtn.Size = new System.Drawing.Size(56, 20);
            this.saveBtn.TabIndex = 6;
            this.saveBtn.Text = "Save";
            this.saveBtn.UseVisualStyleBackColor = true;
            this.saveBtn.Click += new System.EventHandler(this.saveBtn_Click);
            // 
            // newFileBtn
            // 
            this.newFileBtn.Location = new System.Drawing.Point(659, 480);
            this.newFileBtn.Name = "newFileBtn";
            this.newFileBtn.Size = new System.Drawing.Size(75, 23);
            this.newFileBtn.TabIndex = 7;
            this.newFileBtn.Text = "New file";
            this.newFileBtn.UseVisualStyleBackColor = true;
            this.newFileBtn.Click += new System.EventHandler(this.newFileBtn_Click);
            // 
            // newFileTxt
            // 
            this.newFileTxt.Location = new System.Drawing.Point(741, 482);
            this.newFileTxt.Name = "newFileTxt";
            this.newFileTxt.Size = new System.Drawing.Size(159, 20);
            this.newFileTxt.TabIndex = 8;
            // 
            // queueLbx
            // 
            this.queueLbx.FormattingEnabled = true;
            this.queueLbx.Location = new System.Drawing.Point(905, 41);
            this.queueLbx.Name = "queueLbx";
            this.queueLbx.Size = new System.Drawing.Size(164, 459);
            this.queueLbx.TabIndex = 9;
            // 
            // extraInfoTxt
            // 
            this.extraInfoTxt.Location = new System.Drawing.Point(659, 187);
            this.extraInfoTxt.Margin = new System.Windows.Forms.Padding(2);
            this.extraInfoTxt.Multiline = true;
            this.extraInfoTxt.Name = "extraInfoTxt";
            this.extraInfoTxt.Size = new System.Drawing.Size(241, 98);
            this.extraInfoTxt.TabIndex = 10;
            // 
            // tabControl2
            // 
            this.tabControl2.Controls.Add(this.text1Tab);
            this.tabControl2.Controls.Add(this.text2Tab);
            this.tabControl2.Controls.Add(this.text3Tab);
            this.tabControl2.Controls.Add(this.text4Tab);
            this.tabControl2.Location = new System.Drawing.Point(659, 31);
            this.tabControl2.Name = "tabControl2";
            this.tabControl2.SelectedIndex = 0;
            this.tabControl2.Size = new System.Drawing.Size(241, 151);
            this.tabControl2.TabIndex = 11;
            // 
            // text1Tab
            // 
            this.text1Tab.Controls.Add(this.text1Txt);
            this.text1Tab.Location = new System.Drawing.Point(4, 22);
            this.text1Tab.Name = "text1Tab";
            this.text1Tab.Padding = new System.Windows.Forms.Padding(3);
            this.text1Tab.Size = new System.Drawing.Size(233, 125);
            this.text1Tab.TabIndex = 0;
            this.text1Tab.Text = "Text 1";
            this.text1Tab.UseVisualStyleBackColor = true;
            // 
            // text2Tab
            // 
            this.text2Tab.Controls.Add(this.text2Txt);
            this.text2Tab.Location = new System.Drawing.Point(4, 22);
            this.text2Tab.Name = "text2Tab";
            this.text2Tab.Padding = new System.Windows.Forms.Padding(3);
            this.text2Tab.Size = new System.Drawing.Size(233, 125);
            this.text2Tab.TabIndex = 1;
            this.text2Tab.Text = "Text 2";
            this.text2Tab.UseVisualStyleBackColor = true;
            // 
            // text3Tab
            // 
            this.text3Tab.Controls.Add(this.text3Txt);
            this.text3Tab.Location = new System.Drawing.Point(4, 22);
            this.text3Tab.Name = "text3Tab";
            this.text3Tab.Padding = new System.Windows.Forms.Padding(3);
            this.text3Tab.Size = new System.Drawing.Size(233, 125);
            this.text3Tab.TabIndex = 2;
            this.text3Tab.Text = "Text 3";
            this.text3Tab.UseVisualStyleBackColor = true;
            // 
            // text4Tab
            // 
            this.text4Tab.Controls.Add(this.text4Txt);
            this.text4Tab.Location = new System.Drawing.Point(4, 22);
            this.text4Tab.Name = "text4Tab";
            this.text4Tab.Padding = new System.Windows.Forms.Padding(3);
            this.text4Tab.Size = new System.Drawing.Size(233, 125);
            this.text4Tab.TabIndex = 3;
            this.text4Tab.Text = "Text 4";
            this.text4Tab.UseVisualStyleBackColor = true;
            // 
            // text1Txt
            // 
            this.text1Txt.Dock = System.Windows.Forms.DockStyle.Fill;
            this.text1Txt.Location = new System.Drawing.Point(3, 3);
            this.text1Txt.Multiline = true;
            this.text1Txt.Name = "text1Txt";
            this.text1Txt.Size = new System.Drawing.Size(227, 119);
            this.text1Txt.TabIndex = 0;
            // 
            // text2Txt
            // 
            this.text2Txt.Dock = System.Windows.Forms.DockStyle.Fill;
            this.text2Txt.Location = new System.Drawing.Point(3, 3);
            this.text2Txt.Multiline = true;
            this.text2Txt.Name = "text2Txt";
            this.text2Txt.Size = new System.Drawing.Size(227, 119);
            this.text2Txt.TabIndex = 1;
            // 
            // text3Txt
            // 
            this.text3Txt.Dock = System.Windows.Forms.DockStyle.Fill;
            this.text3Txt.Location = new System.Drawing.Point(3, 3);
            this.text3Txt.Multiline = true;
            this.text3Txt.Name = "text3Txt";
            this.text3Txt.Size = new System.Drawing.Size(227, 119);
            this.text3Txt.TabIndex = 1;
            // 
            // text4Txt
            // 
            this.text4Txt.Dock = System.Windows.Forms.DockStyle.Fill;
            this.text4Txt.Location = new System.Drawing.Point(3, 3);
            this.text4Txt.Multiline = true;
            this.text4Txt.Name = "text4Txt";
            this.text4Txt.Size = new System.Drawing.Size(227, 119);
            this.text4Txt.TabIndex = 1;
            // 
            // toText1Btn
            // 
            this.toText1Btn.Location = new System.Drawing.Point(8, 507);
            this.toText1Btn.Name = "toText1Btn";
            this.toText1Btn.Size = new System.Drawing.Size(38, 23);
            this.toText1Btn.TabIndex = 12;
            this.toText1Btn.Tag = "1";
            this.toText1Btn.Text = "1";
            this.toText1Btn.UseVisualStyleBackColor = true;
            this.toText1Btn.Click += new System.EventHandler(this.toText1Btn_Click);
            // 
            // toText2Btn
            // 
            this.toText2Btn.Location = new System.Drawing.Point(52, 507);
            this.toText2Btn.Name = "toText2Btn";
            this.toText2Btn.Size = new System.Drawing.Size(38, 23);
            this.toText2Btn.TabIndex = 13;
            this.toText2Btn.Tag = "2";
            this.toText2Btn.Text = "2";
            this.toText2Btn.UseVisualStyleBackColor = true;
            this.toText2Btn.Click += new System.EventHandler(this.toText1Btn_Click);
            // 
            // toText3Btn
            // 
            this.toText3Btn.Location = new System.Drawing.Point(96, 507);
            this.toText3Btn.Name = "toText3Btn";
            this.toText3Btn.Size = new System.Drawing.Size(38, 23);
            this.toText3Btn.TabIndex = 14;
            this.toText3Btn.Tag = "3";
            this.toText3Btn.Text = "3";
            this.toText3Btn.UseVisualStyleBackColor = true;
            this.toText3Btn.Click += new System.EventHandler(this.toText1Btn_Click);
            // 
            // toText4Btn
            // 
            this.toText4Btn.Location = new System.Drawing.Point(140, 507);
            this.toText4Btn.Name = "toText4Btn";
            this.toText4Btn.Size = new System.Drawing.Size(38, 23);
            this.toText4Btn.TabIndex = 15;
            this.toText4Btn.Tag = "4";
            this.toText4Btn.Text = "4";
            this.toText4Btn.UseVisualStyleBackColor = true;
            this.toText4Btn.Click += new System.EventHandler(this.toText1Btn_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1077, 551);
            this.Controls.Add(this.toText4Btn);
            this.Controls.Add(this.toText3Btn);
            this.Controls.Add(this.toText2Btn);
            this.Controls.Add(this.toText1Btn);
            this.Controls.Add(this.tabControl2);
            this.Controls.Add(this.extraInfoTxt);
            this.Controls.Add(this.queueLbx);
            this.Controls.Add(this.newFileTxt);
            this.Controls.Add(this.newFileBtn);
            this.Controls.Add(this.saveBtn);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.driveTree);
            this.Controls.Add(this.goBtn);
            this.Controls.Add(this.wordTxt);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.tabControl2.ResumeLayout(false);
            this.text1Tab.ResumeLayout(false);
            this.text1Tab.PerformLayout();
            this.text2Tab.ResumeLayout(false);
            this.text2Tab.PerformLayout();
            this.text3Tab.ResumeLayout(false);
            this.text3Tab.PerformLayout();
            this.text4Tab.ResumeLayout(false);
            this.text4Tab.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox wordTxt;
        private System.Windows.Forms.Button goBtn;
        private System.Windows.Forms.TreeView driveTree;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.Button saveBtn;
        private System.Windows.Forms.Button newFileBtn;
        private System.Windows.Forms.TextBox newFileTxt;
        private System.Windows.Forms.ListBox queueLbx;
        private System.Windows.Forms.TextBox extraInfoTxt;
        private System.Windows.Forms.TabControl tabControl2;
        private System.Windows.Forms.TabPage text1Tab;
        private System.Windows.Forms.TabPage text2Tab;
        private System.Windows.Forms.TabPage text3Tab;
        private System.Windows.Forms.TabPage text4Tab;
        private System.Windows.Forms.TextBox text1Txt;
        private System.Windows.Forms.TextBox text2Txt;
        private System.Windows.Forms.TextBox text3Txt;
        private System.Windows.Forms.TextBox text4Txt;
        private System.Windows.Forms.Button toText1Btn;
        private System.Windows.Forms.Button toText2Btn;
        private System.Windows.Forms.Button toText3Btn;
        private System.Windows.Forms.Button toText4Btn;
    }
}

