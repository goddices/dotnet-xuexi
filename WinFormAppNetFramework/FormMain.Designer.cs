namespace WinFormAppNetFramework
{
    partial class FormMain
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.messagingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.同步方法ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.task方法ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.await之后ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.waitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.manualToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // listBox1
            // 
            this.listBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listBox1.DisplayMember = "ClientName";
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 15;
            this.listBox1.Location = new System.Drawing.Point(1, 37);
            this.listBox1.Margin = new System.Windows.Forms.Padding(4);
            this.listBox1.Name = "listBox1";
            this.listBox1.ScrollAlwaysVisible = true;
            this.listBox1.Size = new System.Drawing.Size(541, 574);
            this.listBox1.TabIndex = 2;
            this.listBox1.ValueMember = "SessionID";
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.messagingToolStripMenuItem,
            this.waitToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(540, 28);
            this.menuStrip1.TabIndex = 5;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // messagingToolStripMenuItem
            // 
            this.messagingToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.同步方法ToolStripMenuItem,
            this.task方法ToolStripMenuItem,
            this.await之后ToolStripMenuItem});
            this.messagingToolStripMenuItem.Name = "messagingToolStripMenuItem";
            this.messagingToolStripMenuItem.Size = new System.Drawing.Size(100, 24);
            this.messagingToolStripMenuItem.Text = "Messaging";
            // 
            // 同步方法ToolStripMenuItem
            // 
            this.同步方法ToolStripMenuItem.Name = "同步方法ToolStripMenuItem";
            this.同步方法ToolStripMenuItem.Size = new System.Drawing.Size(246, 26);
            this.同步方法ToolStripMenuItem.Text = "基于事件的同步方法";
            this.同步方法ToolStripMenuItem.Click += new System.EventHandler(this.SyncMethod_Click);
            // 
            // task方法ToolStripMenuItem
            // 
            this.task方法ToolStripMenuItem.Name = "task方法ToolStripMenuItem";
            this.task方法ToolStripMenuItem.Size = new System.Drawing.Size(246, 26);
            this.task方法ToolStripMenuItem.Text = "Task.Factory.StartNew";
            this.task方法ToolStripMenuItem.Click += new System.EventHandler(this.TaskFactoryStartNew_Click);
            // 
            // await之后ToolStripMenuItem
            // 
            this.await之后ToolStripMenuItem.Name = "await之后ToolStripMenuItem";
            this.await之后ToolStripMenuItem.Size = new System.Drawing.Size(246, 26);
            this.await之后ToolStripMenuItem.Text = "await之后";
            this.await之后ToolStripMenuItem.Click += new System.EventHandler(this.AfterAwaitMethod_Click);
            // 
            // waitToolStripMenuItem
            // 
            this.waitToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.manualToolStripMenuItem});
            this.waitToolStripMenuItem.Name = "waitToolStripMenuItem";
            this.waitToolStripMenuItem.Size = new System.Drawing.Size(54, 24);
            this.waitToolStripMenuItem.Text = "Wait";
            // 
            // manualToolStripMenuItem
            // 
            this.manualToolStripMenuItem.Name = "manualToolStripMenuItem";
            this.manualToolStripMenuItem.Size = new System.Drawing.Size(216, 26);
            this.manualToolStripMenuItem.Text = "Manual";
            this.manualToolStripMenuItem.Click += new System.EventHandler(this.manualToolStripMenuItem_Click);
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(540, 623);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "FormMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "WIN32 Messaging";
            this.Load += new System.EventHandler(this.FormMain_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem messagingToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 同步方法ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem task方法ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem await之后ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem waitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem manualToolStripMenuItem;
    }
}

