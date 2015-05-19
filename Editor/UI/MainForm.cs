using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using BehaviorTreeEditor_Model;
using BehaviorTreeEditor_BLL;
using BehaviorTreeEditor_Components;

namespace UI
{
    /// <summary>
    /// 主页面
    /// </summary>
    public partial class MainForm : Form, IAddNodeForm, IAddPreconditionForm,IAddTemplateForm
    {
        #region 属性

        private static MainForm instance = null;

        private Page currentFile { get; set; }

        private List<Page> openFiles { get; set; }//打开的文件集合

        private List<Precondition> basePreconditions { get; set; }//基本条件集合

        private List<Node> baseNodes { get; set; }//基本节点集合

        private List<Tree> baseTrees { get; set; }//基本模版集合

        public Node dragNode { get; set; }

        public Precondition dragPrecondition { get; set; }

        public Tree dragTree { get; set; }

        #endregion

        #region 获取对像

        public static MainForm GetInstance()
        {
            if (instance == null)
            {
                instance = new MainForm();
            }

            return instance;
        }

        #endregion

        #region 窗体事件

        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            //初始化数据
            this.openFiles = new List<Page>();
            this.basePreconditions = PreconditionHandler.getInstance().getBasePreconditions();
            if (this.basePreconditions == null)
            {
                this.basePreconditions = new List<Precondition>();
            }
            this.baseNodes = NodeHandler.getInstance().getBaseNodes();
            if (this.baseNodes == null)
            {
                this.baseNodes = new List<Node>();
            }
            this.baseTrees = TemplateHandler.getInstance().getBaseTrees();
            if (this.baseTrees == null)
            {
                this.baseTrees = new List<Tree>();
            }

            //数据源绑定
            this.NodeListBoxDataBinding();
            this.PreconditionListBoxDataBinding();
            this.TemplateListBoxDataBinding();

            //显示
            this.toolStripStatusLabel1.Text = "版本: 1.0.1.0";

            //加载最后修改文件
            string path = PageHandler.getInstance().getLastPage();
            if (path != null && path.Length > 0 && File.FileIsExist(path))
            {
                Page page = new Page(path);
                this.tabControl2.TabPages.Add(page.tabPage);
                this.tabControl2.SelectedTab = page.tabPage;
                this.openFiles.Add(page);
                this.currentFile = page;

                
            }
        }

        private void MainForm_Closing(object sender, CancelEventArgs e)
        {
            this.quit();
        }

        protected override void OnClosing(CancelEventArgs e)
        {
            this.MainForm_Closing(this, e);
        }

        #endregion

        #region 菜单按钮点击事件

        #region 主菜单

        private void NewToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Page page = new Page();
            this.tabControl2.TabPages.Add(page.tabPage);
            this.tabControl2.SelectedTab = page.tabPage;
            this.openFiles.Add(page);
            this.currentFile = page;
        }

        private void OpenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                Page page = new Page(this.openFileDialog1.FileName);
                this.tabControl2.TabPages.Add(page.tabPage);
                this.tabControl2.SelectedTab = page.tabPage;
                this.openFiles.Add(page);
                this.currentFile = page;
            }
        }

        private void SaveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.currentFile != null)
            {
                if (this.currentFile.treeHandler.Tree.IsTemplate == false)
                {
                    this.saveFileDialog1.FileName = this.currentFile.tabPage.Name + ".tree";
                    this.saveFileDialog1.Filter = "Tree File|*.tree";
                    if (this.currentFile.savePath != null)
                    {
                        this.saveFileDialog1.InitialDirectory = this.currentFile.savePath;
                    }

                    if (this.saveFileDialog1.ShowDialog() == DialogResult.OK)
                    {
                        if (this.saveFileDialog1.FileName.Trim().Length > 0)
                        {
                            this.currentFile.SaveTree(this.saveFileDialog1.FileName);
                            this.currentFile.state = PageState.Save;
                        }
                    }
                }
                else
                {
                    TemplateHandler.getInstance().setBaseTrees(this.baseTrees);
                    this.currentFile.state = PageState.Save;
                }
            }
        }

        private void QuitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void RevocationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.currentFile != null)
            {
                this.currentFile.Revocation();
            }
        }

        private void RestoreToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.currentFile != null)
            {
                this.currentFile.Restore();
            }
        }

        private void JsonToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.currentFile != null)
            {
                if (this.currentFile.treeHandler != null && this.currentFile.treeHandler.Tree.Root != null)
                {
                    string error = null;
                    if (!this.currentFile.CheckTree(ref error, null))
                    {
                        MessageBox.Show(error, "错误", MessageBoxButtons.OK);
                        return;
                    }

                    this.saveFileDialog1.FileName = this.currentFile.tabPage.Name + ".json";
                    this.saveFileDialog1.Filter = "Json File|*.json";
                    if (this.saveFileDialog1.ShowDialog() == DialogResult.OK)
                    {
                        if (this.saveFileDialog1.FileName.Trim().Length > 0)
                        {
                            this.currentFile.ExportTree(this.saveFileDialog1.FileName, ExportType.Json);
                        }
                    }
                   
                }
            }
        }

        private void XmlToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //暂时没有实现
        }

        private void AboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AboutForm aboutF = new AboutForm();
            aboutF.ShowDialog();
        }

        #endregion

        #region 条件菜单

        #region addPContextMenuStrip
        private void addPreconditionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddPreconditionForm addPreconditionForm = new AddPreconditionForm();
            addPreconditionForm.childPreconditions = this.basePreconditions;
            addPreconditionForm.m_delegate = this;
            addPreconditionForm.ShowDialog();
        }
        #endregion

        #region pDetailContextMenuStrip

        private void pLookToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Precondition lookP = this.basePreconditions[this.preconditionListBox.SelectedIndex];
            DetailPreconditionForm detailPreconditionForm = new DetailPreconditionForm();
            detailPreconditionForm.precondition = lookP;
            detailPreconditionForm.ShowDialog();
        }

        private void pEditToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Precondition editP = this.basePreconditions[this.preconditionListBox.SelectedIndex];
            AddPreconditionForm addPreconditionForm = new AddPreconditionForm();
            addPreconditionForm.editPrecondition = editP;
            addPreconditionForm.childPreconditions = this.basePreconditions;
            addPreconditionForm.m_delegate = this;
            addPreconditionForm.ShowDialog();
        }

        private void pDeleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult ret = MessageBox.Show("确定要删除吗？", "提示", MessageBoxButtons.YesNo);
            if (ret == DialogResult.Yes)
            {
                bool canDelete = true;
                string error = null;
                Precondition deleteP = this.basePreconditions[this.preconditionListBox.SelectedIndex];
                foreach (var item in this.basePreconditions)
                {
                    if (item == deleteP) continue;

                    if (item.type == deleteP.type && deleteP.isBase)
                    {
                        canDelete = false;
                        error = "条件[" + item.name + "]使用了该条件。";
                        break;
                    }

                    if (item.child != null && item.child.Count > 0)
                    {
                        foreach (var childItem in item.child)
                        {
                            if (childItem.type == deleteP.type
                                && childItem.name == deleteP.name)
                            {
                                canDelete = false;
                                error = "条件[" + item.name + "]的子条件是该条件。";
                                break;
                            }
                        }
                        if (!canDelete)
                        {
                            break;
                        }
                    }
                }

                if (!canDelete)
                {
                    MessageBox.Show(error, "错误", MessageBoxButtons.OK);
                    return;
                }

                this.basePreconditions.Remove(deleteP);
                this.PreconditionListBoxDataBinding();
            }
        }

        #endregion

        #endregion

        #region 节点菜单

        #region addNContextMenuStrip
        private void addNodeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddNodeForm addNodeForm = new AddNodeForm();
            addNodeForm.nodeDatas = this.baseNodes;
            addNodeForm.m_delegate = this;
            addNodeForm.ShowDialog();
        }
        #endregion

        #region nDetailContextMenuStrip

        private void nLookToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Node lookN = this.baseNodes[this.nodeListBox.SelectedIndex];
            DetailNodeForm detailNodeForm = new DetailNodeForm();
            detailNodeForm.node = lookN;
            detailNodeForm.ShowDialog();
        }

        private void nEditToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Node editN = this.baseNodes[this.nodeListBox.SelectedIndex];
            AddNodeForm addNodeForm = new AddNodeForm();
            addNodeForm.editNode = editN;
            addNodeForm.nodeDatas = this.baseNodes;
            addNodeForm.m_delegate = this;
            addNodeForm.ShowDialog();
        }

        private void nDeleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult ret = MessageBox.Show("确定要删除吗？", "提示", MessageBoxButtons.YesNo);
            if (ret == DialogResult.Yes)
            {
                Node deleteN = this.baseNodes[this.nodeListBox.SelectedIndex];
                this.baseNodes.Remove(deleteN);
                this.NodeListBoxDataBinding();
            }
        }

        #endregion

        #endregion

        #region 模板菜单
        /// <summary>
        /// 添加模板菜单点击事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AddTemplateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddTemplateForm addTemplateForm = new AddTemplateForm();
            addTemplateForm.treeDatas = this.baseTrees;
            addTemplateForm.m_delegate = this;
            addTemplateForm.ShowDialog();
        }

        /// <summary>
        /// 查看模板菜单点击事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lookTemplateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Tree lookT = this.baseTrees[this.templateListBox.SelectedIndex];
            DetailTemplateForm detailTemplateForm = new DetailTemplateForm();
            detailTemplateForm.treeInfo = lookT;
            detailTemplateForm.ShowDialog();
        }

        /// <summary>
        /// 编辑模板名称菜单点击事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void editTemplateNameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Tree editT = this.baseTrees[this.templateListBox.SelectedIndex];
            AddTemplateForm addTemplateForm = new AddTemplateForm();
            addTemplateForm.editTree = editT;
            addTemplateForm.treeDatas = this.baseTrees;
            addTemplateForm.m_delegate = this;
            addTemplateForm.ShowDialog();
        }

        /// <summary>
        /// 编辑模板节点菜单点击事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void editTemplateNodeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Tree editT = this.baseTrees[this.templateListBox.SelectedIndex];
            Page page = new Page(editT);
            page.isTemplate = true;
            this.tabControl2.TabPages.Add(page.tabPage);
            this.tabControl2.SelectedTab = page.tabPage;
            this.openFiles.Add(page);
            this.currentFile = page;
        }

        /// <summary>
        /// 删除模板菜单点击事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void deleteTemplateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult ret = MessageBox.Show("确定要删除吗？", "提示", MessageBoxButtons.YesNo);
            if (ret == DialogResult.Yes)
            {
                Tree deleteT = this.baseTrees[this.templateListBox.SelectedIndex];
                if (this.baseTrees.Contains(deleteT))
                {
                    this.baseTrees.Remove(deleteT);
                    this.TemplateListBoxDataBinding();
                }
            }
        }
        #endregion

        #endregion

        #region listBox 数据源绑定

        private void NodeListBoxDataBinding()
        {
            this.nodeListBox.SelectedIndex = -1;
            this.nodeListBox.SelectedItems.Clear();
            this.nodeListBox.Items.Clear();
            if (this.baseNodes != null && this.baseNodes.Count > 0)
            {
                for (int i = 0; i < this.baseNodes.Count; i++)
                {
                    Node itme = this.baseNodes[i];

                    this.nodeListBox.Items.Add(itme.name);
                }
            }
        }

        private void PreconditionListBoxDataBinding()
        {
            this.preconditionListBox.SelectedIndex = -1;
            this.preconditionListBox.SelectedItems.Clear();
            this.preconditionListBox.Items.Clear();
            if (this.basePreconditions != null && this.basePreconditions.Count > 0)
            {
                for (int i = 0; i < this.basePreconditions.Count; i++)
                {
                    Precondition item = this.basePreconditions[i];
                    this.preconditionListBox.Items.Add(item.name);
                }
            }
        }

        private void TemplateListBoxDataBinding()
        {
            this.templateListBox.SelectedIndex = -1;
            this.templateListBox.SelectedItems.Clear();
            this.templateListBox.Items.Clear();
            if (this.baseTrees != null && this.baseTrees.Count > 0)
            {
                for (int i = 0; i < this.baseTrees.Count; i++)
                {
                    Tree item = this.baseTrees[i];
                    this.templateListBox.Items.Add(item.Name);
                }
            }
        }

        #endregion

        #region listBox 事件

        #region nodeListBox

        private void nodeListBox_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                Point p = this.nodeListBox.PointToScreen(new Point(e.Location.X, e.Location.Y));
                if (this.nodeListBox.SelectedItem != null && this.nodeListBox.IndexFromPoint(e.Location.X, e.Location.Y) == this.nodeListBox.SelectedIndex)
                {
                    this.nDetailContextMenuStrip.Show(this, this.PointToClient(p));
                }
                else
                {
                    this.addNContextMenuStrip.Show(this, this.PointToClient(p));
                }
            }
        }

        private void nodeListBox_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Left)
            {

                ListBox box = (ListBox)sender;
                if (box.Items.Count == 0)
                {
                    return;
                }

                int index = box.IndexFromPoint(e.X, e.Y);

                if (box.SelectedIndex != index)
                {
                    return;
                }

                if (index >= 0 && index < box.Items.Count)
                {
                    Node dragNode = this.baseNodes[index];
                    this.dragNode = dragNode;
                    if (this.currentFile != null)
                    {
                        this.currentFile.dragNode = dragNode;
                    }
                    this.nodeListBox.DoDragDrop("Node", DragDropEffects.All);
                }
            }
        }

        private void nodeListBox_DragOver(object sender, DragEventArgs e)
        {
            if (this.dragNode != null )
            {
                e.Effect = DragDropEffects.Move;
            }
        }

        private void nodeListBox_DragDrop(object sender, DragEventArgs e)
        {
            Point p = this.nodeListBox.PointToClient(new Point(e.X, e.Y));
            int index = this.nodeListBox.IndexFromPoint(p);
            if (index != ListBox.NoMatches && index >= 0 && index < this.baseNodes.Count)
            {
                Node dragNode = this.dragNode;
                Node dragOverNode = this.baseNodes[index];
                if (dragNode != null && dragOverNode != null && dragNode != dragOverNode)
                {
                    this.baseNodes.Remove(dragNode);
                    this.baseNodes.Insert(index, dragNode);
                    this.NodeListBoxDataBinding();
                    this.dragNode = null;
                }
            }
        }

        private void nodeListBox_DragLeave(object sender, EventArgs e)
        {
            if (this.dragNode != null)
            {
                this.dragNode = null;
            }
        }

        #endregion

        #region preconditionListBox

        private void preconditionListBox_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                Point p = this.preconditionListBox.PointToScreen(new Point(e.Location.X, e.Location.Y));
                if (this.preconditionListBox.SelectedItem != null && this.preconditionListBox.IndexFromPoint(e.Location.X, e.Location.Y) == this.preconditionListBox.SelectedIndex)
                {

                    this.pDetailContextMenuStrip.Show(this, this.PointToClient(p));
                }
                else
                {
                    this.addPContextMenuStrip.Show(this, this.PointToClient(p));
                }
            }
        }

        private void preconditionListBox_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Left)
            {
                    ListBox box = (ListBox)sender;
                    if (box.Items.Count == 0)
                    {
                        return;
                    }

                    int index = box.IndexFromPoint(e.X, e.Y);

                    if (box.SelectedIndex != index)
                    {
                        return;
                    }

                    if (index >= 0 && index < box.Items.Count)
                    {
                        Precondition dragPrecondition = this.basePreconditions[index];
                        this.dragPrecondition = dragPrecondition;
                        if (this.currentFile != null && this.currentFile.treeHandler != null && this.currentFile.treeHandler.Tree.Root != null)
                        {
                            this.currentFile.dragPrecondition = dragPrecondition;
                        }
                        this.preconditionListBox.DoDragDrop("Precondition", DragDropEffects.All);
                    }
            }
        }

        private void preconditionListBox_DragOver(object sender, DragEventArgs e)
        {
            if (this.dragPrecondition != null)
            {
                e.Effect = DragDropEffects.Move;
            }
        }

        private void preconditionListBox_DragDrop(object sender, DragEventArgs e)
        {
            Point p = this.preconditionListBox.PointToClient(new Point(e.X, e.Y));
            int index = this.preconditionListBox.IndexFromPoint(p);
            if (index != ListBox.NoMatches && index >= 0 && index < this.basePreconditions.Count)
            {
                Precondition dragPrecondition = this.dragPrecondition;
                Precondition dragOverPrecondition = this.basePreconditions[index];
                if (dragPrecondition != null && dragOverPrecondition != null && dragPrecondition != dragOverPrecondition)
                {
                    this.basePreconditions.Remove(dragPrecondition);
                    this.basePreconditions.Insert(index, dragPrecondition);
                    this.PreconditionListBoxDataBinding();
                    this.dragPrecondition = null;
                }
            }
        }

        private void preconditionListBox_DragLeave(object sender, EventArgs e)
        {
            if (this.dragPrecondition != null)
            {
                this.dragPrecondition = null;
            }
        }

        #endregion

        #region templateListBox

        private void templateListBox_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                Point p = this.templateListBox.PointToScreen(new Point(e.Location.X, e.Location.Y));
                if (this.templateListBox.SelectedItem != null && this.templateListBox.IndexFromPoint(e.Location.X, e.Location.Y) == this.templateListBox.SelectedIndex)
                {

                    this.tDetailContextMenuStrip.Show(this, this.PointToClient(p));
                }
                else
                {
                    this.addTContextMenuStrip.Show(this, this.PointToClient(p));
                }
            }
        }

        private void templateListBox_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Left)
            {
                    ListBox box = (ListBox)sender;
                    if (box.Items.Count == 0)
                    {
                        return;
                    }

                    int index = box.IndexFromPoint(e.X, e.Y);

                    if (box.SelectedIndex != index)
                    {
                        return;
                    }

                    if (index >= 0 && index < box.Items.Count)
                    {
                        Tree dragTree = this.baseTrees[index];
                        this.dragTree = dragTree;
                        if (this.currentFile != null && dragTree.Root != null)
                        {
                            this.currentFile.dragTree = dragTree;
                        }
                        this.templateListBox.DoDragDrop("Tree", DragDropEffects.All);
                    }
                
            }
        }

        private void templateListBox_DragOver(object sender, DragEventArgs e)
        {
            if (this.dragTree != null)
            {
                e.Effect = DragDropEffects.Move;
            }
        }

        private void templateListBox_DragDrop(object sender, DragEventArgs e)
        {
            Point p = this.templateListBox.PointToClient(new Point(e.X, e.Y));
            int index = this.templateListBox.IndexFromPoint(p);
            if (index != ListBox.NoMatches && index >= 0 && index < this.baseTrees.Count)
            {
                Tree dragTree = this.dragTree;
                Tree dragOverTree = this.baseTrees[index];
                if (dragTree != null && dragOverTree != null && dragTree != dragOverTree)
                {
                    this.baseTrees.Remove(dragTree);
                    this.baseTrees.Insert(index, dragTree);
                    this.TemplateListBoxDataBinding();
                    this.dragTree = null;
                }
            } 
        }

        private void templateListBox_DragLeave(object sender, EventArgs e)
        {
            if (this.dragTree != null)
            {
                this.dragTree = null;
            }
        }

        #endregion

        #endregion

        #region 工作区TabControl事件

        private void tabControl2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.openFiles != null && this.openFiles.Count > 0)
            {
                if (this.tabControl2.SelectedIndex >= 0 && this.tabControl2.SelectedIndex < this.openFiles.Count)
                {
                    this.currentFile = this.openFiles[this.tabControl2.SelectedIndex];
                }
            }
        }

        /// <summary>
        /// 自己绘制关闭按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tabControl2_DrawItem(object sender, DrawItemEventArgs e)
        {
            try
            {
                Rectangle myTabRect = this.tabControl2.GetTabRect(e.Index);

                //先添加选中的白色背景
                if (e.State == DrawItemState.Selected)
                {
                    using (Pen p = new Pen(Color.White))
                    {
                        e.Graphics.DrawRectangle(p, myTabRect);
                    }
                    using (Brush b = new SolidBrush(Color.White))
                    {
                        e.Graphics.FillRectangle(b, myTabRect);
                    }
                }

                //再添加TabPage属性   
                e.Graphics.DrawString(this.tabControl2.TabPages[e.Index].Text, this.Font, SystemBrushes.ControlText, myTabRect.X + 2, myTabRect.Y + 2);



                //再画一个矩形框
                using (Pen p = new Pen(Color.Gray))
                {
                    myTabRect.Offset(myTabRect.Width - (15 + 3), 2);
                    myTabRect.Width = 15;
                    myTabRect.Height = 15;
                    e.Graphics.DrawRectangle(p, myTabRect);
                }

                //填充矩形框
                Color recColor = e.State != DrawItemState.Selected ? Color.White : Color.FromArgb(232, 233, 232);
                using (Brush b = new SolidBrush(recColor))
                {
                    e.Graphics.FillRectangle(b, myTabRect);
                }

                //画关闭符号
                using (Pen objpen = new Pen(Color.Black, 1))
                {
                    ////=============================================
                    //自己画X
                    //  "\"线
                    Point p1 = new Point(myTabRect.X + 3, myTabRect.Y + 3);
                    Point p2 = new Point(myTabRect.X + myTabRect.Width - 3, myTabRect.Y + myTabRect.Height - 3);
                    e.Graphics.DrawLine(objpen, p1, p2);
                    //  "/"线
                    Point p3 = new Point(myTabRect.X + 3, myTabRect.Y + myTabRect.Height - 3);
                    Point p4 = new Point(myTabRect.X + myTabRect.Width - 3, myTabRect.Y + 3);
                    e.Graphics.DrawLine(objpen, p3, p4);
                }
                e.Graphics.Dispose();
            }
            catch (Exception) { }

        }

        private void tabControl2_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                int x = e.X, y = e.Y;
                Point p = new Point(x, y);
                TabPage child = (TabPage)this.GetPageByPoint(this.tabControl2, p);
                if (child != null)
                {
                    int index = this.tabControl2.TabPages.IndexOf(child);
                    if (index >= 0 && index < this.tabControl2.TabPages.Count)
                    {
                        //计算关闭区域   
                        Rectangle myTabRect = this.tabControl2.GetTabRect(index);

                        myTabRect.Offset(myTabRect.Width - (15 + 3), 2);
                        myTabRect.Width = 15;
                        myTabRect.Height = 15;

                        //如果鼠标在区域内就关闭选项卡   
                        bool isClose = x > myTabRect.X && x < myTabRect.Right && y > myTabRect.Y && y < myTabRect.Bottom;
                        if (isClose == true)
                        {

                            Page closePage = this.openFiles[index];
                            if (closePage.state == PageState.Edit)
                            {
                                DialogResult ret = MessageBox.Show("没有保存就关闭吗？", "提示", MessageBoxButtons.OKCancel);
                                isClose = ret == System.Windows.Forms.DialogResult.OK;
                            }

                            if (isClose)
                            {
                                if (this.currentFile.tabPage == child)
                                {
                                    this.currentFile = null;
                                    int tmpIndex = index <= 0 ? 0 : index - 1;
                                    if (tmpIndex >= 0 && tmpIndex < this.tabControl2.TabPages.Count)
                                    {
                                        this.currentFile = this.openFiles[tmpIndex];
                                        this.tabControl2.SelectedIndex = tmpIndex;
                                    }
                                }
                                this.openFiles.RemoveAt(index);
                                this.tabControl2.TabPages.Remove(child);
                            }
                        }

                    }
                }
            }
        }

        private TabPage GetPageByPoint(TabControl tabControl, Point point)
        {
            for (int i = 0; i < tabControl.TabPages.Count; i++)
            {
                TabPage page = tabControl.TabPages[i];
                if (tabControl.GetTabRect(i).Contains(point))
                    return page;
            }
            return null;
        }

        #endregion

        #region IAddNodeForm接口实现

        public void RefreshNode()
        {
            this.NodeListBoxDataBinding();
        }

        #endregion

        #region IAddPreconditionForm接口实现

        public void RefreshPrecondition()
        {
            this.PreconditionListBoxDataBinding();
        }

        #endregion

        #region IAddTemplateForm接口实现
        public void RefreshTemplateForm()
        {
            this.TemplateListBoxDataBinding();
        }
        #endregion

        #region 私有函数

        /// <summary>
        /// 退出
        /// </summary>
        private void quit()
        {
            NodeHandler.getInstance().setBaseNodes(this.baseNodes);
            PreconditionHandler.getInstance().setBasePreconditions(this.basePreconditions);
            TemplateHandler.getInstance().setBaseTrees(this.baseTrees);
            if (this.currentFile != null && this.currentFile.savePath != null && this.currentFile.isTemplate == false)
            {
                PageHandler.getInstance().setLastPage(this.currentFile.savePath);
            }

            if (this.openFiles != null && this.openFiles.Count > 0)
            {
                foreach (var item in this.openFiles)
                {
                    if (item.savePath != null && item.savePath.Length > 0)
                    {
                        item.SaveTree(item.savePath);
                    }
                }
            }
        }

        #endregion

       

    }
}
