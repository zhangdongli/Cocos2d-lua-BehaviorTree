namespace UI
{
    partial class DetailTemplateForm
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
            this.nameTitleLabel = new System.Windows.Forms.Label();
            this.nameLabel = new System.Windows.Forms.Label();
            this.hasNodeTitleLabel = new System.Windows.Forms.Label();
            this.hasNodeLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // nameTitleLabel
            // 
            this.nameTitleLabel.AutoSize = true;
            this.nameTitleLabel.Location = new System.Drawing.Point(144, 58);
            this.nameTitleLabel.Name = "nameTitleLabel";
            this.nameTitleLabel.Size = new System.Drawing.Size(41, 12);
            this.nameTitleLabel.TabIndex = 0;
            this.nameTitleLabel.Text = "名称：";
            // 
            // nameLabel
            // 
            this.nameLabel.AutoSize = true;
            this.nameLabel.Location = new System.Drawing.Point(203, 58);
            this.nameLabel.Name = "nameLabel";
            this.nameLabel.Size = new System.Drawing.Size(23, 12);
            this.nameLabel.TabIndex = 1;
            this.nameLabel.Text = "123";
            // 
            // hasNodeTitleLabel
            // 
            this.hasNodeTitleLabel.AutoSize = true;
            this.hasNodeTitleLabel.Location = new System.Drawing.Point(144, 98);
            this.hasNodeTitleLabel.Name = "hasNodeTitleLabel";
            this.hasNodeTitleLabel.Size = new System.Drawing.Size(53, 12);
            this.hasNodeTitleLabel.TabIndex = 2;
            this.hasNodeTitleLabel.Text = "有节点：";
            // 
            // hasNodeLabel
            // 
            this.hasNodeLabel.AutoSize = true;
            this.hasNodeLabel.Location = new System.Drawing.Point(203, 98);
            this.hasNodeLabel.Name = "hasNodeLabel";
            this.hasNodeLabel.Size = new System.Drawing.Size(23, 12);
            this.hasNodeLabel.TabIndex = 3;
            this.hasNodeLabel.Text = "123";
            // 
            // DetailTemplateForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(482, 172);
            this.Controls.Add(this.hasNodeLabel);
            this.Controls.Add(this.hasNodeTitleLabel);
            this.Controls.Add(this.nameLabel);
            this.Controls.Add(this.nameTitleLabel);
            this.Name = "DetailTemplateForm";
            this.Text = "模板";
            this.Load += new System.EventHandler(this.DetailTemplateForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label nameTitleLabel;
        private System.Windows.Forms.Label nameLabel;
        private System.Windows.Forms.Label hasNodeTitleLabel;
        private System.Windows.Forms.Label hasNodeLabel;
    }
}