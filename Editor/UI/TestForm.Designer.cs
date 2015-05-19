namespace UI
{
    partial class TestForm
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
            this.components = new System.ComponentModel.Container();
            this.nodeContextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.lookNToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lookPToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.removeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.nodeContextMenuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // nodeContextMenuStrip
            // 
            this.nodeContextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lookNToolStripMenuItem,
            this.lookPToolStripMenuItem,
            this.removeToolStripMenuItem});
            this.nodeContextMenuStrip.Name = "nodeContextMenuStrip";
            this.nodeContextMenuStrip.Size = new System.Drawing.Size(173, 92);
            // 
            // lookNToolStripMenuItem
            // 
            this.lookNToolStripMenuItem.Name = "lookNToolStripMenuItem";
            this.lookNToolStripMenuItem.Size = new System.Drawing.Size(172, 22);
            this.lookNToolStripMenuItem.Text = "查看节点";
            this.lookNToolStripMenuItem.Click += new System.EventHandler(this.lookNToolStripMenuItem_Click);
            // 
            // lookPToolStripMenuItem
            // 
            this.lookPToolStripMenuItem.Name = "lookPToolStripMenuItem";
            this.lookPToolStripMenuItem.Size = new System.Drawing.Size(172, 22);
            this.lookPToolStripMenuItem.Text = "查看条件";
            this.lookPToolStripMenuItem.Click += new System.EventHandler(this.lookPToolStripMenuItem_Click);
            // 
            // removeToolStripMenuItem
            // 
            this.removeToolStripMenuItem.Name = "removeToolStripMenuItem";
            this.removeToolStripMenuItem.Size = new System.Drawing.Size(172, 22);
            this.removeToolStripMenuItem.Text = "从父亲节点中移除";
            this.removeToolStripMenuItem.Click += new System.EventHandler(this.removeToolStripMenuItem_Click);
            // 
            // TestForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(690, 460);
            this.Name = "TestForm";
            this.Text = "TestForm";
            this.nodeContextMenuStrip.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ContextMenuStrip nodeContextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem lookNToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem lookPToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem removeToolStripMenuItem;


    }
}