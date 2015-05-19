namespace UI
{
    partial class AddPreconditionForm
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
            this.nameLabel = new System.Windows.Forms.Label();
            this.nameTextBox = new System.Windows.Forms.TextBox();
            this.typeLabel = new System.Windows.Forms.Label();
            this.isBasePCheckBox = new System.Windows.Forms.CheckBox();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.child1Panel = new System.Windows.Forms.Panel();
            this.child1CheckedListBox = new System.Windows.Forms.CheckedListBox();
            this.child1Label = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.child2Panel = new System.Windows.Forms.Panel();
            this.child2CheckedListBox = new System.Windows.Forms.CheckedListBox();
            this.child2Label = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.cancelButton = new System.Windows.Forms.Button();
            this.sureButton = new System.Windows.Forms.Button();
            this.typeTextBox = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            this.child1Panel.SuspendLayout();
            this.child2Panel.SuspendLayout();
            this.SuspendLayout();
            // 
            // nameLabel
            // 
            this.nameLabel.AutoSize = true;
            this.nameLabel.Location = new System.Drawing.Point(49, 47);
            this.nameLabel.Name = "nameLabel";
            this.nameLabel.Size = new System.Drawing.Size(41, 12);
            this.nameLabel.TabIndex = 0;
            this.nameLabel.Text = "名称：";
            // 
            // nameTextBox
            // 
            this.nameTextBox.Location = new System.Drawing.Point(96, 43);
            this.nameTextBox.Name = "nameTextBox";
            this.nameTextBox.Size = new System.Drawing.Size(255, 21);
            this.nameTextBox.TabIndex = 1;
            // 
            // typeLabel
            // 
            this.typeLabel.AutoSize = true;
            this.typeLabel.Location = new System.Drawing.Point(50, 93);
            this.typeLabel.Name = "typeLabel";
            this.typeLabel.Size = new System.Drawing.Size(41, 12);
            this.typeLabel.TabIndex = 2;
            this.typeLabel.Text = "类型：";
            // 
            // isBasePCheckBox
            // 
            this.isBasePCheckBox.AutoSize = true;
            this.isBasePCheckBox.Checked = true;
            this.isBasePCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.isBasePCheckBox.Location = new System.Drawing.Point(245, 131);
            this.isBasePCheckBox.Name = "isBasePCheckBox";
            this.isBasePCheckBox.Size = new System.Drawing.Size(108, 16);
            this.isBasePCheckBox.TabIndex = 4;
            this.isBasePCheckBox.Text = "是否是基本条件";
            this.isBasePCheckBox.UseVisualStyleBackColor = true;
            this.isBasePCheckBox.CheckedChanged += new System.EventHandler(this.isBasePCheckBox_CheckedChanged);
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.Location = new System.Drawing.Point(232, 163);
            this.numericUpDown1.Maximum = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(46, 21);
            this.numericUpDown1.TabIndex = 5;
            this.numericUpDown1.ValueChanged += new System.EventHandler(this.numericUpDown1_ValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(282, 166);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 6;
            this.label1.Text = "子条件个数";
            // 
            // child1Panel
            // 
            this.child1Panel.Controls.Add(this.child1CheckedListBox);
            this.child1Panel.Controls.Add(this.child1Label);
            this.child1Panel.Controls.Add(this.panel2);
            this.child1Panel.Location = new System.Drawing.Point(90, 209);
            this.child1Panel.Name = "child1Panel";
            this.child1Panel.Size = new System.Drawing.Size(128, 146);
            this.child1Panel.TabIndex = 7;
            this.child1Panel.Visible = false;
            // 
            // child1CheckedListBox
            // 
            this.child1CheckedListBox.CheckOnClick = true;
            this.child1CheckedListBox.FormattingEnabled = true;
            this.child1CheckedListBox.HorizontalScrollbar = true;
            this.child1CheckedListBox.Location = new System.Drawing.Point(3, 21);
            this.child1CheckedListBox.Name = "child1CheckedListBox";
            this.child1CheckedListBox.ScrollAlwaysVisible = true;
            this.child1CheckedListBox.Size = new System.Drawing.Size(120, 116);
            this.child1CheckedListBox.TabIndex = 4;
            this.child1CheckedListBox.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.child1CheckedListBox_ItemCheck);
            // 
            // child1Label
            // 
            this.child1Label.AutoSize = true;
            this.child1Label.Location = new System.Drawing.Point(3, 4);
            this.child1Label.Name = "child1Label";
            this.child1Label.Size = new System.Drawing.Size(47, 12);
            this.child1Label.TabIndex = 1;
            this.child1Label.Text = "子条件1";
            // 
            // panel2
            // 
            this.panel2.Location = new System.Drawing.Point(77, 93);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(8, 8);
            this.panel2.TabIndex = 0;
            // 
            // child2Panel
            // 
            this.child2Panel.Controls.Add(this.child2CheckedListBox);
            this.child2Panel.Controls.Add(this.child2Label);
            this.child2Panel.Controls.Add(this.panel4);
            this.child2Panel.Location = new System.Drawing.Point(225, 208);
            this.child2Panel.Name = "child2Panel";
            this.child2Panel.Size = new System.Drawing.Size(128, 147);
            this.child2Panel.TabIndex = 8;
            this.child2Panel.Visible = false;
            // 
            // child2CheckedListBox
            // 
            this.child2CheckedListBox.CheckOnClick = true;
            this.child2CheckedListBox.FormattingEnabled = true;
            this.child2CheckedListBox.HorizontalScrollbar = true;
            this.child2CheckedListBox.Location = new System.Drawing.Point(3, 22);
            this.child2CheckedListBox.Name = "child2CheckedListBox";
            this.child2CheckedListBox.ScrollAlwaysVisible = true;
            this.child2CheckedListBox.Size = new System.Drawing.Size(120, 116);
            this.child2CheckedListBox.TabIndex = 2;
            this.child2CheckedListBox.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.child2CheckedListBox_ItemCheck);
            // 
            // child2Label
            // 
            this.child2Label.AutoSize = true;
            this.child2Label.Location = new System.Drawing.Point(4, 4);
            this.child2Label.Name = "child2Label";
            this.child2Label.Size = new System.Drawing.Size(47, 12);
            this.child2Label.TabIndex = 1;
            this.child2Label.Text = "子条件2";
            // 
            // panel4
            // 
            this.panel4.Location = new System.Drawing.Point(77, 93);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(8, 8);
            this.panel4.TabIndex = 0;
            // 
            // cancelButton
            // 
            this.cancelButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cancelButton.Location = new System.Drawing.Point(167, 382);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(75, 23);
            this.cancelButton.TabIndex = 9;
            this.cancelButton.Text = "取消";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // sureButton
            // 
            this.sureButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.sureButton.Location = new System.Drawing.Point(278, 382);
            this.sureButton.Name = "sureButton";
            this.sureButton.Size = new System.Drawing.Size(75, 23);
            this.sureButton.TabIndex = 10;
            this.sureButton.Text = "确认";
            this.sureButton.UseVisualStyleBackColor = true;
            this.sureButton.Click += new System.EventHandler(this.sureButton_Click);
            // 
            // typeTextBox
            // 
            this.typeTextBox.FormattingEnabled = true;
            this.typeTextBox.Location = new System.Drawing.Point(97, 89);
            this.typeTextBox.Name = "typeTextBox";
            this.typeTextBox.Size = new System.Drawing.Size(254, 20);
            this.typeTextBox.TabIndex = 11;
            // 
            // AddPreconditionForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(431, 424);
            this.Controls.Add(this.typeTextBox);
            this.Controls.Add(this.sureButton);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.child2Panel);
            this.Controls.Add(this.child1Panel);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.numericUpDown1);
            this.Controls.Add(this.isBasePCheckBox);
            this.Controls.Add(this.typeLabel);
            this.Controls.Add(this.nameTextBox);
            this.Controls.Add(this.nameLabel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AddPreconditionForm";
            this.Text = "条件";
            this.Load += new System.EventHandler(this.AddPreconditionForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            this.child1Panel.ResumeLayout(false);
            this.child1Panel.PerformLayout();
            this.child2Panel.ResumeLayout(false);
            this.child2Panel.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label nameLabel;
        private System.Windows.Forms.TextBox nameTextBox;
        private System.Windows.Forms.Label typeLabel;
        private System.Windows.Forms.CheckBox isBasePCheckBox;
        private System.Windows.Forms.NumericUpDown numericUpDown1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel child1Panel;
        private System.Windows.Forms.Label child1Label;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel child2Panel;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label child2Label;
        private System.Windows.Forms.CheckedListBox child1CheckedListBox;
        private System.Windows.Forms.CheckedListBox child2CheckedListBox;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.Button sureButton;
        private System.Windows.Forms.ComboBox typeTextBox;
    }
}