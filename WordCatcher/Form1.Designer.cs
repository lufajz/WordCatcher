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
            this.descriptionTxt = new System.Windows.Forms.TextBox();
            this.driveTree = new System.Windows.Forms.TreeView();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.saveBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // wordTxt
            // 
            this.wordTxt.Location = new System.Drawing.Point(12, 12);
            this.wordTxt.Name = "wordTxt";
            this.wordTxt.Size = new System.Drawing.Size(912, 26);
            this.wordTxt.TabIndex = 0;
            this.wordTxt.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.wordTxt_KeyPress);
            // 
            // goBtn
            // 
            this.goBtn.Location = new System.Drawing.Point(930, 7);
            this.goBtn.Name = "goBtn";
            this.goBtn.Size = new System.Drawing.Size(52, 31);
            this.goBtn.TabIndex = 1;
            this.goBtn.Text = "GO";
            this.goBtn.UseVisualStyleBackColor = true;
            this.goBtn.Click += new System.EventHandler(this.goBtn_Click);
            // 
            // descriptionTxt
            // 
            this.descriptionTxt.Location = new System.Drawing.Point(988, 63);
            this.descriptionTxt.Multiline = true;
            this.descriptionTxt.Name = "descriptionTxt";
            this.descriptionTxt.Size = new System.Drawing.Size(360, 376);
            this.descriptionTxt.TabIndex = 3;
            // 
            // driveTree
            // 
            this.driveTree.Location = new System.Drawing.Point(988, 445);
            this.driveTree.Name = "driveTree";
            this.driveTree.Size = new System.Drawing.Size(360, 285);
            this.driveTree.TabIndex = 4;
            this.driveTree.BeforeExpand += new System.Windows.Forms.TreeViewCancelEventHandler(this.driveTree_BeforeExpand);
            this.driveTree.AfterExpand += new System.Windows.Forms.TreeViewEventHandler(this.driveTree_AfterExpand);
            // 
            // tabControl1
            // 
            this.tabControl1.Location = new System.Drawing.Point(12, 44);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(970, 686);
            this.tabControl1.TabIndex = 5;
            // 
            // saveBtn
            // 
            this.saveBtn.Location = new System.Drawing.Point(988, 7);
            this.saveBtn.Name = "saveBtn";
            this.saveBtn.Size = new System.Drawing.Size(84, 31);
            this.saveBtn.TabIndex = 6;
            this.saveBtn.Text = "Save";
            this.saveBtn.UseVisualStyleBackColor = true;
            this.saveBtn.Click += new System.EventHandler(this.saveBtn_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1360, 742);
            this.Controls.Add(this.saveBtn);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.driveTree);
            this.Controls.Add(this.descriptionTxt);
            this.Controls.Add(this.goBtn);
            this.Controls.Add(this.wordTxt);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox wordTxt;
        private System.Windows.Forms.Button goBtn;
        private System.Windows.Forms.TextBox descriptionTxt;
        private System.Windows.Forms.TreeView driveTree;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.Button saveBtn;
    }
}

