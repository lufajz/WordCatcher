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
            this.favoritesLbx = new System.Windows.Forms.ListBox();
            this.addFileToFavoritesBtn = new System.Windows.Forms.Button();
            this.removeFromFavoritesBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // driveTree
            // 
            this.driveTree.HideSelection = false;
            this.driveTree.HotTracking = true;
            this.driveTree.Location = new System.Drawing.Point(1353, 543);
            this.driveTree.Name = "driveTree";
            this.driveTree.Size = new System.Drawing.Size(244, 207);
            this.driveTree.TabIndex = 4;
            this.driveTree.BeforeExpand += new System.Windows.Forms.TreeViewCancelEventHandler(this.driveTree_BeforeExpand);
            this.driveTree.AfterExpand += new System.Windows.Forms.TreeViewEventHandler(this.driveTree_AfterExpand);
            // 
            // newFileBtn
            // 
            this.newFileBtn.Location = new System.Drawing.Point(1359, 754);
            this.newFileBtn.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.newFileBtn.Name = "newFileBtn";
            this.newFileBtn.Size = new System.Drawing.Size(112, 35);
            this.newFileBtn.TabIndex = 7;
            this.newFileBtn.Text = "New file";
            this.newFileBtn.UseVisualStyleBackColor = true;
            this.newFileBtn.Click += new System.EventHandler(this.newFileBtn_Click);
            // 
            // newFileTxt
            // 
            this.newFileTxt.Location = new System.Drawing.Point(1479, 758);
            this.newFileTxt.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.newFileTxt.Name = "newFileTxt";
            this.newFileTxt.Size = new System.Drawing.Size(118, 26);
            this.newFileTxt.TabIndex = 8;
            // 
            // queueLbx
            // 
            this.queueLbx.FormattingEnabled = true;
            this.queueLbx.ItemHeight = 20;
            this.queueLbx.Location = new System.Drawing.Point(1358, 63);
            this.queueLbx.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.queueLbx.Name = "queueLbx";
            this.queueLbx.Size = new System.Drawing.Size(244, 204);
            this.queueLbx.TabIndex = 9;
            // 
            // tabControl1
            // 
            this.tabControl1.Location = new System.Drawing.Point(18, 18);
            this.tabControl1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1328, 811);
            this.tabControl1.TabIndex = 10;
            // 
            // newTabBtn
            // 
            this.newTabBtn.Location = new System.Drawing.Point(1360, 18);
            this.newTabBtn.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.newTabBtn.Name = "newTabBtn";
            this.newTabBtn.Size = new System.Drawing.Size(243, 35);
            this.newTabBtn.TabIndex = 11;
            this.newTabBtn.Text = "New tab";
            this.newTabBtn.UseVisualStyleBackColor = true;
            this.newTabBtn.Click += new System.EventHandler(this.newTabBtn_Click);
            // 
            // addToQueueBtn
            // 
            this.addToQueueBtn.Location = new System.Drawing.Point(1360, 277);
            this.addToQueueBtn.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.addToQueueBtn.Name = "addToQueueBtn";
            this.addToQueueBtn.Size = new System.Drawing.Size(92, 35);
            this.addToQueueBtn.TabIndex = 12;
            this.addToQueueBtn.Text = "Add";
            this.addToQueueBtn.UseVisualStyleBackColor = true;
            this.addToQueueBtn.Click += new System.EventHandler(this.addToQueueBtn_Click);
            // 
            // takeFromQueueBtn
            // 
            this.takeFromQueueBtn.Location = new System.Drawing.Point(1514, 277);
            this.takeFromQueueBtn.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.takeFromQueueBtn.Name = "takeFromQueueBtn";
            this.takeFromQueueBtn.Size = new System.Drawing.Size(92, 35);
            this.takeFromQueueBtn.TabIndex = 13;
            this.takeFromQueueBtn.Text = "Take";
            this.takeFromQueueBtn.UseVisualStyleBackColor = true;
            this.takeFromQueueBtn.Click += new System.EventHandler(this.takeFromQueueBtn_Click);
            // 
            // favoritesLbx
            // 
            this.favoritesLbx.FormattingEnabled = true;
            this.favoritesLbx.ItemHeight = 20;
            this.favoritesLbx.Location = new System.Drawing.Point(1359, 322);
            this.favoritesLbx.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.favoritesLbx.Name = "favoritesLbx";
            this.favoritesLbx.Size = new System.Drawing.Size(244, 164);
            this.favoritesLbx.TabIndex = 14;
            // 
            // addFileToFavoritesBtn
            // 
            this.addFileToFavoritesBtn.Location = new System.Drawing.Point(1359, 496);
            this.addFileToFavoritesBtn.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.addFileToFavoritesBtn.Name = "addFileToFavoritesBtn";
            this.addFileToFavoritesBtn.Size = new System.Drawing.Size(92, 35);
            this.addFileToFavoritesBtn.TabIndex = 15;
            this.addFileToFavoritesBtn.Text = "Bookmark";
            this.addFileToFavoritesBtn.UseVisualStyleBackColor = true;
            this.addFileToFavoritesBtn.Click += new System.EventHandler(this.addFileToFavoritesBtn_Click);
            // 
            // removeFromFavoritesBtn
            // 
            this.removeFromFavoritesBtn.Location = new System.Drawing.Point(1514, 496);
            this.removeFromFavoritesBtn.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.removeFromFavoritesBtn.Name = "removeFromFavoritesBtn";
            this.removeFromFavoritesBtn.Size = new System.Drawing.Size(92, 35);
            this.removeFromFavoritesBtn.TabIndex = 16;
            this.removeFromFavoritesBtn.Text = "Remove";
            this.removeFromFavoritesBtn.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1616, 848);
            this.Controls.Add(this.removeFromFavoritesBtn);
            this.Controls.Add(this.addFileToFavoritesBtn);
            this.Controls.Add(this.favoritesLbx);
            this.Controls.Add(this.takeFromQueueBtn);
            this.Controls.Add(this.addToQueueBtn);
            this.Controls.Add(this.newTabBtn);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.queueLbx);
            this.Controls.Add(this.newFileTxt);
            this.Controls.Add(this.newFileBtn);
            this.Controls.Add(this.driveTree);
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
        private System.Windows.Forms.ListBox favoritesLbx;
        private System.Windows.Forms.Button addFileToFavoritesBtn;
        private System.Windows.Forms.Button removeFromFavoritesBtn;
    }
}

