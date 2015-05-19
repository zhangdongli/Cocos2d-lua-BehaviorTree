namespace UI
{
    partial class DetailPreconditionForm
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
            this.pTreeView = new System.Windows.Forms.TreeView();
            this.SuspendLayout();
            // 
            // pTreeView
            // 
            this.pTreeView.Cursor = System.Windows.Forms.Cursors.Default;
            this.pTreeView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pTreeView.ItemHeight = 15;
            this.pTreeView.Location = new System.Drawing.Point(0, 0);
            this.pTreeView.Name = "pTreeView";
            this.pTreeView.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.pTreeView.Size = new System.Drawing.Size(367, 287);
            this.pTreeView.TabIndex = 0;
            // 
            // DetailPreconditionForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(367, 287);
            this.Controls.Add(this.pTreeView);
            this.MinimumSize = new System.Drawing.Size(383, 325);
            this.Name = "DetailPreconditionForm";
            this.Text = "条件";
            this.Load += new System.EventHandler(this.DetailPreconditionForm_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TreeView pTreeView;
    }
}