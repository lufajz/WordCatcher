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
            this.driveTree = new System.Windows.Forms.TreeView();
            this.newFileBtn = new System.Windows.Forms.Button();
            this.newFileTxt = new System.Windows.Forms.TextBox();
            this.queueLbx = new System.Windows.Forms.ListBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.newTabBtn = new System.Windows.Forms.Button();
            this.addToQueueBtn = new System.Windows.Forms.Button();
            this.takeFromQueueBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // driveTree
            // 
            this.driveTree.Location = new System.Drawing.Point(902, 331);
            this.driveTree.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.driveTree.Name = "driveTree";
            this.driveTree.Size = new System.Drawing.Size(164, 158);
            this.driveTree.TabIndex = 4;
            this.driveTree.BeforeExpand += new System.Windows.Forms.TreeViewCancelEventHandler(this.driveTree_BeforeExpand);
            this.driveTree.AfterExpand += new System.Windows.Forms.TreeViewEventHandler(this.driveTree_AfterExpand);
            // 
            // newFileBtn
            // 
            this.newFileBtn.Location = new System.Drawing.Point(906, 490);
            this.newFileBtn.Name = "newFileBtn";
            this.newFileBtn.Size = new System.Drawing.Size(75, 23);
            this.newFileBtn.TabIndex = 7;
            this.newFileBtn.Text = "New file";
            this.newFileBtn.UseVisualStyleBackColor = true;
            this.newFileBtn.Click += new System.EventHandler(this.newFileBtn_Click);
            // 
            // newFileTxt
            // 
            this.newFileTxt.Location = new System.Drawing.Point(986, 493);
            this.newFileTxt.Name = "newFileTxt";
            this.newFileTxt.Size = new System.Drawing.Size(80, 20);
            this.newFileTxt.TabIndex = 8;
            // 
            // queueLbx
            // 
            this.queueLbx.FormattingEnabled = true;
            this.queueLbx.Location = new System.Drawing.Point(905, 41);
            this.queueLbx.Name = "queueLbx";
            this.queueLbx.Size = new System.Drawing.Size(164, 251);
            this.queueLbx.TabIndex = 9;
            // 
            // tabControl1
            // 
            this.tabControl1.Location = new System.Drawing.Point(12, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(888, 527);
            this.tabControl1.TabIndex = 10;
            // 
            // newTabBtn
            // 
            this.newTabBtn.Location = new System.Drawing.Point(907, 12);
            this.newTabBtn.Name = "newTabBtn";
            this.newTabBtn.Size = new System.Drawing.Size(162, 23);
            this.newTabBtn.TabIndex = 11;
            this.newTabBtn.Text = "New tab";
            this.newTabBtn.UseVisualStyleBackColor = true;
            this.newTabBtn.Click += new System.EventHandler(this.newTabBtn_Click);
            // 
            // addToQueueBtn
            // 
            this.addToQueueBtn.Location = new System.Drawing.Point(905, 298);
            this.addToQueueBtn.Name = "addToQueueBtn";
            this.addToQueueBtn.Size = new System.Drawing.Size(61, 23);
            this.addToQueueBtn.TabIndex = 12;
            this.addToQueueBtn.Text = "Add";
            this.addToQueueBtn.UseVisualStyleBackColor = true;
            this.addToQueueBtn.Click += new System.EventHandler(this.addToQueueBtn_Click);
            // 
            // takeFromQueueBtn
            // 
            this.takeFromQueueBtn.Location = new System.Drawing.Point(1008, 298);
            this.takeFromQueueBtn.Name = "takeFromQueueBtn";
            this.takeFromQueueBtn.Size = new System.Drawing.Size(61, 23);
            this.takeFromQueueBtn.TabIndex = 13;
            this.takeFromQueueBtn.Text = "Take";
            this.takeFromQueueBtn.UseVisualStyleBackColor = true;
            this.takeFromQueueBtn.Click += new System.EventHandler(this.takeFromQueueBtn_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1077, 551);
            this.Controls.Add(this.takeFromQueueBtn);
            this.Controls.Add(this.addToQueueBtn);
            this.Controls.Add(this.newTabBtn);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.queueLbx);
            this.Controls.Add(this.newFileTxt);
            this.Controls.Add(this.newFileBtn);
            this.Controls.Add(this.driveTree);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TreeView driveTree;
        private System.Windows.Forms.Button newFileBtn;
        private System.Windows.Forms.TextBox newFileTxt;
        private System.Windows.Forms.ListBox queueLbx;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.Button newTabBtn;
        private System.Windows.Forms.Button addToQueueBtn;
        private System.Windows.Forms.Button takeFromQueueBtn;
    }
}

