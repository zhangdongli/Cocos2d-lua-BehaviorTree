namespace UI
{
    partial class MainForm
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.FileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.NewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.OpenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.SaveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.QuitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.EditToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.RevocationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.RestoreToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ExportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.JsonToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.XmlToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.HelpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.AboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.nodeListBox = new System.Windows.Forms.ListBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.preconditionListBox = new System.Windows.Forms.ListBox();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.templateListBox = new System.Windows.Forms.ListBox();
            this.tabControl2 = new System.Windows.Forms.TabControl();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.pDetailContextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.pLookToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pEditToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pDeleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addNContextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.addNodeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addPContextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.addPreconditionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.nDetailContextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.nLookToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.nEditToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.nDeleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.addTContextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.AddTemplateToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tDetailContextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.lookTemplateToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.编辑ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editTemplateNameToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editTemplateNodeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteTemplateToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.pDetailContextMenuStrip.SuspendLayout();
            this.addNContextMenuStrip.SuspendLayout();
            this.addPContextMenuStrip.SuspendLayout();
            this.nDetailContextMenuStrip.SuspendLayout();
            this.addTContextMenuStrip.SuspendLayout();
            this.tDetailContextMenuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.FileToolStripMenuItem,
            this.EditToolStripMenuItem,
            this.ExportToolStripMenuItem,
            this.HelpToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(784, 25);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // FileToolStripMenuItem
            // 
            this.FileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.NewToolStripMenuItem,
            this.OpenToolStripMenuItem,
            this.SaveToolStripMenuItem,
            this.QuitToolStripMenuItem});
            this.FileToolStripMenuItem.Name = "FileToolStripMenuItem";
            this.FileToolStripMenuItem.ShortcutKeyDisplayString = "";
            this.FileToolStripMenuItem.Size = new System.Drawing.Size(44, 21);
            this.FileToolStripMenuItem.Text = "文件";
            // 
            // NewToolStripMenuItem
            // 
            this.NewToolStripMenuItem.Name = "NewToolStripMenuItem";
            this.NewToolStripMenuItem.ShortcutKeyDisplayString = "Ctrl+N";
            this.NewToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.N)));
            this.NewToolStripMenuItem.Size = new System.Drawing.Size(147, 22);
            this.NewToolStripMenuItem.Text = "新建";
            this.NewToolStripMenuItem.Click += new System.EventHandler(this.NewToolStripMenuItem_Click);
            // 
            // OpenToolStripMenuItem
            // 
            this.OpenToolStripMenuItem.Name = "OpenToolStripMenuItem";
            this.OpenToolStripMenuItem.ShortcutKeyDisplayString = "Ctrl+O";
            this.OpenToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.OpenToolStripMenuItem.Size = new System.Drawing.Size(147, 22);
            this.OpenToolStripMenuItem.Text = "打开";
            this.OpenToolStripMenuItem.Click += new System.EventHandler(this.OpenToolStripMenuItem_Click);
            // 
            // SaveToolStripMenuItem
            // 
            this.SaveToolStripMenuItem.Name = "SaveToolStripMenuItem";
            this.SaveToolStripMenuItem.ShortcutKeyDisplayString = "Ctrl+S";
            this.SaveToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.SaveToolStripMenuItem.Size = new System.Drawing.Size(147, 22);
            this.SaveToolStripMenuItem.Text = "保存";
            this.SaveToolStripMenuItem.Click += new System.EventHandler(this.SaveToolStripMenuItem_Click);
            // 
            // QuitToolStripMenuItem
            // 
            this.QuitToolStripMenuItem.Name = "QuitToolStripMenuItem";
            this.QuitToolStripMenuItem.Size = new System.Drawing.Size(147, 22);
            this.QuitToolStripMenuItem.Text = "退出";
            this.QuitToolStripMenuItem.Click += new System.EventHandler(this.QuitToolStripMenuItem_Click);
            // 
            // EditToolStripMenuItem
            // 
            this.EditToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.RevocationToolStripMenuItem,
            this.RestoreToolStripMenuItem});
            this.EditToolStripMenuItem.Name = "EditToolStripMenuItem";
            this.EditToolStripMenuItem.Size = new System.Drawing.Size(44, 21);
            this.EditToolStripMenuItem.Text = "编辑";
            // 
            // RevocationToolStripMenuItem
            // 
            this.RevocationToolStripMenuItem.Name = "RevocationToolStripMenuItem";
            this.RevocationToolStripMenuItem.ShortcutKeyDisplayString = "Ctrl+Z";
            this.RevocationToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Z)));
            this.RevocationToolStripMenuItem.Size = new System.Drawing.Size(144, 22);
            this.RevocationToolStripMenuItem.Text = "撤销";
            this.RevocationToolStripMenuItem.Click += new System.EventHandler(this.RevocationToolStripMenuItem_Click);
            // 
            // RestoreToolStripMenuItem
            // 
            this.RestoreToolStripMenuItem.Name = "RestoreToolStripMenuItem";
            this.RestoreToolStripMenuItem.ShortcutKeyDisplayString = "Ctrl+Y";
            this.RestoreToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Y)));
            this.RestoreToolStripMenuItem.Size = new System.Drawing.Size(144, 22);
            this.RestoreToolStripMenuItem.Text = "还原";
            this.RestoreToolStripMenuItem.Click += new System.EventHandler(this.RestoreToolStripMenuItem_Click);
            // 
            // ExportToolStripMenuItem
            // 
            this.ExportToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.JsonToolStripMenuItem,
            this.XmlToolStripMenuItem});
            this.ExportToolStripMenuItem.Name = "ExportToolStripMenuItem";
            this.ExportToolStripMenuItem.Size = new System.Drawing.Size(44, 21);
            this.ExportToolStripMenuItem.Text = "导出";
            // 
            // JsonToolStripMenuItem
            // 
            this.JsonToolStripMenuItem.Name = "JsonToolStripMenuItem";
            this.JsonToolStripMenuItem.Size = new System.Drawing.Size(102, 22);
            this.JsonToolStripMenuItem.Text = "Json";
            this.JsonToolStripMenuItem.Click += new System.EventHandler(this.JsonToolStripMenuItem_Click);
            // 
            // XmlToolStripMenuItem
            // 
            this.XmlToolStripMenuItem.Name = "XmlToolStripMenuItem";
            this.XmlToolStripMenuItem.Size = new System.Drawing.Size(102, 22);
            this.XmlToolStripMenuItem.Text = "Xml";
            this.XmlToolStripMenuItem.Click += new System.EventHandler(this.XmlToolStripMenuItem_Click);
            // 
            // HelpToolStripMenuItem
            // 
            this.HelpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.AboutToolStripMenuItem});
            this.HelpToolStripMenuItem.Name = "HelpToolStripMenuItem";
            this.HelpToolStripMenuItem.Size = new System.Drawing.Size(44, 21);
            this.HelpToolStripMenuItem.Text = "帮助";
            // 
            // AboutToolStripMenuItem
            // 
            this.AboutToolStripMenuItem.Name = "AboutToolStripMenuItem";
            this.AboutToolStripMenuItem.ShortcutKeyDisplayString = "Ctrl+A";
            this.AboutToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.A)));
            this.AboutToolStripMenuItem.Size = new System.Drawing.Size(145, 22);
            this.AboutToolStripMenuItem.Text = "关于";
            this.AboutToolStripMenuItem.Click += new System.EventHandler(this.AboutToolStripMenuItem_Click);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.splitContainer1.Location = new System.Drawing.Point(0, 28);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.AutoScroll = true;
            this.splitContainer1.Panel1.AutoScrollMinSize = new System.Drawing.Size(150, 0);
            this.splitContainer1.Panel1.Controls.Add(this.tabControl1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.AutoScroll = true;
            this.splitContainer1.Panel2.AutoScrollMinSize = new System.Drawing.Size(600, 0);
            this.splitContainer1.Panel2.Controls.Add(this.tabControl2);
            this.splitContainer1.Size = new System.Drawing.Size(784, 509);
            this.splitContainer1.SplitterDistance = 249;
            this.splitContainer1.SplitterWidth = 8;
            this.splitContainer1.TabIndex = 1;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Cursor = System.Windows.Forms.Cursors.Default;
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.ItemSize = new System.Drawing.Size(50, 18);
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(245, 505);
            this.tabControl1.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.nodeListBox);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(237, 479);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "节点";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // nodeListBox
            // 
            this.nodeListBox.AllowDrop = true;
            this.nodeListBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.nodeListBox.FormattingEnabled = true;
            this.nodeListBox.ItemHeight = 12;
            this.nodeListBox.Location = new System.Drawing.Point(3, 3);
            this.nodeListBox.Name = "nodeListBox";
            this.nodeListBox.Size = new System.Drawing.Size(231, 473);
            this.nodeListBox.TabIndex = 0;
            this.nodeListBox.DragDrop += new System.Windows.Forms.DragEventHandler(this.nodeListBox_DragDrop);
            this.nodeListBox.DragOver += new System.Windows.Forms.DragEventHandler(this.nodeListBox_DragOver);
            this.nodeListBox.DragLeave += new System.EventHandler(this.nodeListBox_DragLeave);
            this.nodeListBox.MouseDown += new System.Windows.Forms.MouseEventHandler(this.nodeListBox_MouseDown);
            this.nodeListBox.MouseUp += new System.Windows.Forms.MouseEventHandler(this.nodeListBox_MouseUp);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.preconditionListBox);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(237, 479);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "条件";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // preconditionListBox
            // 
            this.preconditionListBox.AllowDrop = true;
            this.preconditionListBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.preconditionListBox.FormattingEnabled = true;
            this.preconditionListBox.ItemHeight = 12;
            this.preconditionListBox.Location = new System.Drawing.Point(3, 3);
            this.preconditionListBox.Name = "preconditionListBox";
            this.preconditionListBox.Size = new System.Drawing.Size(231, 473);
            this.preconditionListBox.TabIndex = 0;
            this.preconditionListBox.DragDrop += new System.Windows.Forms.DragEventHandler(this.preconditionListBox_DragDrop);
            this.preconditionListBox.DragOver += new System.Windows.Forms.DragEventHandler(this.preconditionListBox_DragOver);
            this.preconditionListBox.DragLeave += new System.EventHandler(this.preconditionListBox_DragLeave);
            this.preconditionListBox.MouseDown += new System.Windows.Forms.MouseEventHandler(this.preconditionListBox_MouseDown);
            this.preconditionListBox.MouseUp += new System.Windows.Forms.MouseEventHandler(this.preconditionListBox_MouseUp);
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.templateListBox);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(237, 479);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "模板";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // templateListBox
            // 
            this.templateListBox.AllowDrop = true;
            this.templateListBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.templateListBox.FormattingEnabled = true;
            this.templateListBox.ItemHeight = 12;
            this.templateListBox.Location = new System.Drawing.Point(0, 0);
            this.templateListBox.Name = "templateListBox";
            this.templateListBox.Size = new System.Drawing.Size(237, 479);
            this.templateListBox.TabIndex = 0;
            this.templateListBox.DragDrop += new System.Windows.Forms.DragEventHandler(this.templateListBox_DragDrop);
            this.templateListBox.DragOver += new System.Windows.Forms.DragEventHandler(this.templateListBox_DragOver);
            this.templateListBox.DragLeave += new System.EventHandler(this.templateListBox_DragLeave);
            this.templateListBox.MouseDown += new System.Windows.Forms.MouseEventHandler(this.templateListBox_MouseDown);
            this.templateListBox.MouseUp += new System.Windows.Forms.MouseEventHandler(this.templateListBox_MouseUp);
            // 
            // tabControl2
            // 
            this.tabControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl2.DrawMode = System.Windows.Forms.TabDrawMode.OwnerDrawFixed;
            this.tabControl2.Location = new System.Drawing.Point(0, 0);
            this.tabControl2.Name = "tabControl2";
            this.tabControl2.Padding = new System.Drawing.Point(15, 4);
            this.tabControl2.SelectedIndex = 0;
            this.tabControl2.Size = new System.Drawing.Size(600, 488);
            this.tabControl2.TabIndex = 0;
            this.tabControl2.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.tabControl2_DrawItem);
            this.tabControl2.SelectedIndexChanged += new System.EventHandler(this.tabControl2_SelectedIndexChanged);
            this.tabControl2.MouseDown += new System.Windows.Forms.MouseEventHandler(this.tabControl2_MouseDown);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1});
            this.statusStrip1.Location = new System.Drawing.Point(0, 540);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(784, 22);
            this.statusStrip1.TabIndex = 2;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(131, 17);
            this.toolStripStatusLabel1.Text = "toolStripStatusLabel1";
            // 
            // pDetailContextMenuStrip
            // 
            this.pDetailContextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.pLookToolStripMenuItem,
            this.pEditToolStripMenuItem,
            this.pDeleteToolStripMenuItem});
            this.pDetailContextMenuStrip.Name = "contextMenuStrip1";
            this.pDetailContextMenuStrip.Size = new System.Drawing.Size(101, 70);
            // 
            // pLookToolStripMenuItem
            // 
            this.pLookToolStripMenuItem.Name = "pLookToolStripMenuItem";
            this.pLookToolStripMenuItem.Size = new System.Drawing.Size(100, 22);
            this.pLookToolStripMenuItem.Text = "查看";
            this.pLookToolStripMenuItem.Click += new System.EventHandler(this.pLookToolStripMenuItem_Click);
            // 
            // pEditToolStripMenuItem
            // 
            this.pEditToolStripMenuItem.Name = "pEditToolStripMenuItem";
            this.pEditToolStripMenuItem.Size = new System.Drawing.Size(100, 22);
            this.pEditToolStripMenuItem.Text = "编辑";
            this.pEditToolStripMenuItem.Click += new System.EventHandler(this.pEditToolStripMenuItem_Click);
            // 
            // pDeleteToolStripMenuItem
            // 
            this.pDeleteToolStripMenuItem.Name = "pDeleteToolStripMenuItem";
            this.pDeleteToolStripMenuItem.Size = new System.Drawing.Size(100, 22);
            this.pDeleteToolStripMenuItem.Text = "删除";
            this.pDeleteToolStripMenuItem.Click += new System.EventHandler(this.pDeleteToolStripMenuItem_Click);
            // 
            // addNContextMenuStrip
            // 
            this.addNContextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addNodeToolStripMenuItem});
            this.addNContextMenuStrip.Name = "contextMenuStrip2";
            this.addNContextMenuStrip.Size = new System.Drawing.Size(125, 26);
            // 
            // addNodeToolStripMenuItem
            // 
            this.addNodeToolStripMenuItem.Name = "addNodeToolStripMenuItem";
            this.addNodeToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.addNodeToolStripMenuItem.Text = "添加节点";
            this.addNodeToolStripMenuItem.Click += new System.EventHandler(this.addNodeToolStripMenuItem_Click);
            // 
            // addPContextMenuStrip
            // 
            this.addPContextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addPreconditionToolStripMenuItem});
            this.addPContextMenuStrip.Name = "contextMenuStrip3";
            this.addPContextMenuStrip.Size = new System.Drawing.Size(125, 26);
            // 
            // addPreconditionToolStripMenuItem
            // 
            this.addPreconditionToolStripMenuItem.Name = "addPreconditionToolStripMenuItem";
            this.addPreconditionToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.addPreconditionToolStripMenuItem.Text = "添加条件";
            this.addPreconditionToolStripMenuItem.Click += new System.EventHandler(this.addPreconditionToolStripMenuItem_Click);
            // 
            // nDetailContextMenuStrip
            // 
            this.nDetailContextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.nLookToolStripMenuItem,
            this.nEditToolStripMenuItem,
            this.nDeleteToolStripMenuItem});
            this.nDetailContextMenuStrip.Name = "nDetailContextMenuStrip";
            this.nDetailContextMenuStrip.Size = new System.Drawing.Size(101, 70);
            // 
            // nLookToolStripMenuItem
            // 
            this.nLookToolStripMenuItem.Name = "nLookToolStripMenuItem";
            this.nLookToolStripMenuItem.Size = new System.Drawing.Size(100, 22);
            this.nLookToolStripMenuItem.Text = "查看";
            this.nLookToolStripMenuItem.Click += new System.EventHandler(this.nLookToolStripMenuItem_Click);
            // 
            // nEditToolStripMenuItem
            // 
            this.nEditToolStripMenuItem.Name = "nEditToolStripMenuItem";
            this.nEditToolStripMenuItem.Size = new System.Drawing.Size(100, 22);
            this.nEditToolStripMenuItem.Text = "编辑";
            this.nEditToolStripMenuItem.Click += new System.EventHandler(this.nEditToolStripMenuItem_Click);
            // 
            // nDeleteToolStripMenuItem
            // 
            this.nDeleteToolStripMenuItem.Name = "nDeleteToolStripMenuItem";
            this.nDeleteToolStripMenuItem.Size = new System.Drawing.Size(100, 22);
            this.nDeleteToolStripMenuItem.Text = "删除";
            this.nDeleteToolStripMenuItem.Click += new System.EventHandler(this.nDeleteToolStripMenuItem_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            this.openFileDialog1.Filter = "Tree File|*.tree";
            // 
            // saveFileDialog1
            // 
            this.saveFileDialog1.Filter = "Tree File|*.tree";
            // 
            // addTContextMenuStrip
            // 
            this.addTContextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.AddTemplateToolStripMenuItem});
            this.addTContextMenuStrip.Name = "addTContextMenuStrip";
            this.addTContextMenuStrip.Size = new System.Drawing.Size(125, 26);
            // 
            // AddTemplateToolStripMenuItem
            // 
            this.AddTemplateToolStripMenuItem.Name = "AddTemplateToolStripMenuItem";
            this.AddTemplateToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.AddTemplateToolStripMenuItem.Text = "添加模板";
            this.AddTemplateToolStripMenuItem.Click += new System.EventHandler(this.AddTemplateToolStripMenuItem_Click);
            // 
            // tDetailContextMenuStrip
            // 
            this.tDetailContextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lookTemplateToolStripMenuItem,
            this.编辑ToolStripMenuItem,
            this.deleteTemplateToolStripMenuItem});
            this.tDetailContextMenuStrip.Name = "tDetailContextMenuStrip";
            this.tDetailContextMenuStrip.Size = new System.Drawing.Size(101, 70);
            // 
            // lookTemplateToolStripMenuItem
            // 
            this.lookTemplateToolStripMenuItem.Name = "lookTemplateToolStripMenuItem";
            this.lookTemplateToolStripMenuItem.Size = new System.Drawing.Size(100, 22);
            this.lookTemplateToolStripMenuItem.Text = "查看";
            this.lookTemplateToolStripMenuItem.Click += new System.EventHandler(this.lookTemplateToolStripMenuItem_Click);
            // 
            // 编辑ToolStripMenuItem
            // 
            this.编辑ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.editTemplateNameToolStripMenuItem,
            this.editTemplateNodeToolStripMenuItem});
            this.编辑ToolStripMenuItem.Name = "编辑ToolStripMenuItem";
            this.编辑ToolStripMenuItem.Size = new System.Drawing.Size(100, 22);
            this.编辑ToolStripMenuItem.Text = "编辑";
            // 
            // editTemplateNameToolStripMenuItem
            // 
            this.editTemplateNameToolStripMenuItem.Name = "editTemplateNameToolStripMenuItem";
            this.editTemplateNameToolStripMenuItem.Size = new System.Drawing.Size(100, 22);
            this.editTemplateNameToolStripMenuItem.Text = "名称";
            this.editTemplateNameToolStripMenuItem.Click += new System.EventHandler(this.editTemplateNameToolStripMenuItem_Click);
            // 
            // editTemplateNodeToolStripMenuItem
            // 
            this.editTemplateNodeToolStripMenuItem.Name = "editTemplateNodeToolStripMenuItem";
            this.editTemplateNodeToolStripMenuItem.Size = new System.Drawing.Size(100, 22);
            this.editTemplateNodeToolStripMenuItem.Text = "节点";
            this.editTemplateNodeToolStripMenuItem.Click += new System.EventHandler(this.editTemplateNodeToolStripMenuItem_Click);
            // 
            // deleteTemplateToolStripMenuItem
            // 
            this.deleteTemplateToolStripMenuItem.Name = "deleteTemplateToolStripMenuItem";
            this.deleteTemplateToolStripMenuItem.Size = new System.Drawing.Size(100, 22);
            this.deleteTemplateToolStripMenuItem.Text = "删除";
            this.deleteTemplateToolStripMenuItem.Click += new System.EventHandler(this.deleteTemplateToolStripMenuItem_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 562);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.MinimumSize = new System.Drawing.Size(800, 600);
            this.Name = "MainForm";
            this.Text = "行为树编辑器";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.tabPage3.ResumeLayout(false);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.pDetailContextMenuStrip.ResumeLayout(false);
            this.addNContextMenuStrip.ResumeLayout(false);
            this.addPContextMenuStrip.ResumeLayout(false);
            this.nDetailContextMenuStrip.ResumeLayout(false);
            this.addTContextMenuStrip.ResumeLayout(false);
            this.tDetailContextMenuStrip.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem FileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem EditToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ExportToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem HelpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem NewToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem OpenToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem SaveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem QuitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem RevocationToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem RestoreToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem JsonToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem XmlToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem AboutToolStripMenuItem;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.ListBox nodeListBox;
        private System.Windows.Forms.ListBox preconditionListBox;
        private System.Windows.Forms.TabControl tabControl2;
        private System.Windows.Forms.ContextMenuStrip pDetailContextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem pLookToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pEditToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pDeleteToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip addNContextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem addNodeToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip addPContextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem addPreconditionToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip nDetailContextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem nLookToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem nEditToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem nDeleteToolStripMenuItem;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.ListBox templateListBox;
        private System.Windows.Forms.ContextMenuStrip addTContextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem AddTemplateToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip tDetailContextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem lookTemplateToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 编辑ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editTemplateNameToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editTemplateNodeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deleteTemplateToolStripMenuItem;
    }
}