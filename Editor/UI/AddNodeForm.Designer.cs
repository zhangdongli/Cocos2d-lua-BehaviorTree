namespace UI
{
    partial class AddNodeForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.nameTextBox = new System.Windows.Forms.TextBox();
            this.typeTextBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.isVirtualCheckBox = new System.Windows.Forms.CheckBox();
            this.label3 = new System.Windows.Forms.Label();
            this.loopCountTxt = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.k_PFC_OR = new System.Windows.Forms.RadioButton();
            this.k_PFC_AND = new System.Windows.Forms.RadioButton();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(84, 43);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "名称：";
            // 
            // nameTextBox
            // 
            this.nameTextBox.Location = new System.Drawing.Point(131, 40);
            this.nameTextBox.Name = "nameTextBox";
            this.nameTextBox.Size = new System.Drawing.Size(240, 21);
            this.nameTextBox.TabIndex = 1;
            // 
            // typeTextBox
            // 
            this.typeTextBox.Location = new System.Drawing.Point(131, 78);
            this.typeTextBox.Name = "typeTextBox";
            this.typeTextBox.Size = new System.Drawing.Size(240, 21);
            this.typeTextBox.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(84, 81);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 12);
            this.label2.TabIndex = 2;
            this.label2.Text = "类型：";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(203, 228);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 4;
            this.button1.Text = "取消";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(295, 228);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 5;
            this.button2.Text = "确认";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // isVirtualCheckBox
            // 
            this.isVirtualCheckBox.AutoSize = true;
            this.isVirtualCheckBox.Location = new System.Drawing.Point(295, 115);
            this.isVirtualCheckBox.Name = "isVirtualCheckBox";
            this.isVirtualCheckBox.Size = new System.Drawing.Size(72, 16);
            this.isVirtualCheckBox.TabIndex = 6;
            this.isVirtualCheckBox.Text = "是虚节点";
            this.isVirtualCheckBox.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(84, 148);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(59, 12);
            this.label3.TabIndex = 7;
            this.label3.Text = "循环次数:";
            // 
            // loopCountTxt
            // 
            this.loopCountTxt.Location = new System.Drawing.Point(245, 145);
            this.loopCountTxt.Name = "loopCountTxt";
            this.loopCountTxt.Size = new System.Drawing.Size(125, 21);
            this.loopCountTxt.TabIndex = 8;
            this.loopCountTxt.Text = "-1";
            this.loopCountTxt.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(84, 182);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(59, 12);
            this.label4.TabIndex = 9;
            this.label4.Text = "并行条件:";
            // 
            // k_PFC_OR
            // 
            this.k_PFC_OR.AutoSize = true;
            this.k_PFC_OR.Checked = true;
            this.k_PFC_OR.Location = new System.Drawing.Point(245, 182);
            this.k_PFC_OR.Name = "k_PFC_OR";
            this.k_PFC_OR.Size = new System.Drawing.Size(47, 16);
            this.k_PFC_OR.TabIndex = 10;
            this.k_PFC_OR.TabStop = true;
            this.k_PFC_OR.Text = "或者";
            this.k_PFC_OR.UseVisualStyleBackColor = true;
            // 
            // k_PFC_AND
            // 
            this.k_PFC_AND.AutoSize = true;
            this.k_PFC_AND.Location = new System.Drawing.Point(324, 182);
            this.k_PFC_AND.Name = "k_PFC_AND";
            this.k_PFC_AND.Size = new System.Drawing.Size(47, 16);
            this.k_PFC_AND.TabIndex = 11;
            this.k_PFC_AND.Text = "并且";
            this.k_PFC_AND.UseVisualStyleBackColor = true;
            // 
            // AddNodeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(482, 287);
            this.Controls.Add(this.k_PFC_AND);
            this.Controls.Add(this.k_PFC_OR);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.loopCountTxt);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.isVirtualCheckBox);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.typeTextBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.nameTextBox);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AddNodeForm";
            this.Text = "节点";
            this.Load += new System.EventHandler(this.AddNodeForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox nameTextBox;
        private System.Windows.Forms.TextBox typeTextBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.CheckBox isVirtualCheckBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox loopCountTxt;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.RadioButton k_PFC_OR;
        private System.Windows.Forms.RadioButton k_PFC_AND;
    }
}