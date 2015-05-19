namespace UI
{
    partial class DetailNodeForm
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
            this.typeTitleLabel = new System.Windows.Forms.Label();
            this.nameLabel = new System.Windows.Forms.Label();
            this.typeLabel = new System.Windows.Forms.Label();
            this.virtualLabel = new System.Windows.Forms.Label();
            this.virtualTitleLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // nameTitleLabel
            // 
            this.nameTitleLabel.AutoSize = true;
            this.nameTitleLabel.Location = new System.Drawing.Point(147, 34);
            this.nameTitleLabel.Name = "nameTitleLabel";
            this.nameTitleLabel.Size = new System.Drawing.Size(41, 12);
            this.nameTitleLabel.TabIndex = 0;
            this.nameTitleLabel.Text = "名称：";
            // 
            // typeTitleLabel
            // 
            this.typeTitleLabel.AutoSize = true;
            this.typeTitleLabel.Location = new System.Drawing.Point(147, 86);
            this.typeTitleLabel.Name = "typeTitleLabel";
            this.typeTitleLabel.Size = new System.Drawing.Size(41, 12);
            this.typeTitleLabel.TabIndex = 1;
            this.typeTitleLabel.Text = "类型：";
            // 
            // nameLabel
            // 
            this.nameLabel.AutoSize = true;
            this.nameLabel.Location = new System.Drawing.Point(204, 35);
            this.nameLabel.Name = "nameLabel";
            this.nameLabel.Size = new System.Drawing.Size(119, 12);
            this.nameLabel.TabIndex = 2;
            this.nameLabel.Text = "xxxxxxxxxxxxxxxxxxx";
            // 
            // typeLabel
            // 
            this.typeLabel.AutoSize = true;
            this.typeLabel.Location = new System.Drawing.Point(204, 86);
            this.typeLabel.Name = "typeLabel";
            this.typeLabel.Size = new System.Drawing.Size(119, 12);
            this.typeLabel.TabIndex = 3;
            this.typeLabel.Text = "xxxxxxxxxxxxxxxxxxx";
            // 
            // virtualLabel
            // 
            this.virtualLabel.AutoSize = true;
            this.virtualLabel.Location = new System.Drawing.Point(214, 135);
            this.virtualLabel.Name = "virtualLabel";
            this.virtualLabel.Size = new System.Drawing.Size(17, 12);
            this.virtualLabel.TabIndex = 5;
            this.virtualLabel.Text = "是";
            // 
            // virtualTitleLabel
            // 
            this.virtualTitleLabel.AutoSize = true;
            this.virtualTitleLabel.Location = new System.Drawing.Point(145, 135);
            this.virtualTitleLabel.Name = "virtualTitleLabel";
            this.virtualTitleLabel.Size = new System.Drawing.Size(53, 12);
            this.virtualTitleLabel.TabIndex = 4;
            this.virtualTitleLabel.Text = "虚节点：";
            // 
            // DetailNodeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(482, 198);
            this.Controls.Add(this.virtualLabel);
            this.Controls.Add(this.virtualTitleLabel);
            this.Controls.Add(this.typeLabel);
            this.Controls.Add(this.nameLabel);
            this.Controls.Add(this.typeTitleLabel);
            this.Controls.Add(this.nameTitleLabel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "DetailNodeForm";
            this.Text = "节点";
            this.Load += new System.EventHandler(this.DetailNodeForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label nameTitleLabel;
        private System.Windows.Forms.Label typeTitleLabel;
        private System.Windows.Forms.Label nameLabel;
        private System.Windows.Forms.Label typeLabel;
        private System.Windows.Forms.Label virtualLabel;
        private System.Windows.Forms.Label virtualTitleLabel;
    }
}