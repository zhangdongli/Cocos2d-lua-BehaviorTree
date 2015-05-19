using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BehaviorTreeEditor_Model;
using BehaviorTreeEditor_BLL;
using BehaviorTreeEditor_Components;
using System.Drawing;

namespace UI
{
    /// <summary>
    /// 逻辑树页面状态
    /// </summary>
    public enum PageState
    {
        Default = 0,
        Edit = 1,
        Save = 2
    }

    /// <summary>
    /// 逻辑树页面
    /// </summary>
    public class Page : IObserver
    {
        #region 属性
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.ContextMenuStrip nodeContextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem lookNToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem lookPToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem removeToolStripMenuItem;

        public TabPage tabPage { get; set; }

        public TreeView treeView { get; set; }

        public TreeHandler treeHandler { get; set; }

        public TreeCaretaker treeCaretaker { get; set; }

        public string name { get; set; }

        public string savePath { get; set; }

        public Node dragNode { get; set; }

        public Precondition dragPrecondition { get; set; }

        public Tree dragTree { get; set; }

        public bool isTemplate { get; set; }

        private PageState _state;
        public PageState state
        {
            get
            {
                return _state;
            }
            set
            {
                if (this.state == value) return;
                if (value == PageState.Edit)
                {
                    //显示未保存
                    this.tabPage.Text = this.tabPage.Name + "*";
                }
                else if (value == PageState.Save)
                {
                    //显示未保存
                    this.tabPage.Text = this.tabPage.Name;
                }
                _state = value;
            }
        }

        #endregion

        #region 构造函数

        public Page()
        {
            this.InitPage();
        }

        public Page(string filePath)
        {
            if (File.FileIsExist(filePath))
            {
                this.treeHandler = new TreeHandler(filePath);
                this.savePath = filePath;
                this.name = System.IO.Path.GetFileNameWithoutExtension(filePath);
            }
            this.InitPage();
        }

        public Page(Tree t)
        {
            if (t != null)
            {
                this.treeHandler = new TreeHandler();
                this.treeHandler.Tree = t;
                this.name = t.Name;
                this.isTemplate = true;
            }
            this.InitPage();
        }

        ~Page()
        {
            NotificationCenter.DefaultCenter().removeObserver(this);
        }

        #endregion

        #region 公共函数

        /// <summary>
        /// 保存修改
        /// </summary>
        public void AddMemento()
        {
            TreeMemento treeMemento = new TreeMemento((Node)this.treeHandler.Tree.Root.Clone());
            this.treeCaretaker.setMemento(treeMemento);
        }

        /// <summary>
        /// 撤销修改
        /// </summary>
        public void Revocation()
        {
            if (this.treeHandler != null && this.treeHandler.Tree.Root != null)
            {
                TreeMemento treeMemento = this.treeCaretaker.getLastMemento();
                if (treeMemento != null)
                {
                    this.treeHandler.Tree.Root = (Node)treeMemento.state.Clone();
                    if (this.treeHandler.Tree.Root != null)
                    {
                        this.BandIngTreeView(null, null);
                        this.state = PageState.Edit;
                    }
                }
            }
        }

        /// <summary>
        /// 还原撤销
        /// </summary>
        public void Restore()
        {
            if (this.treeHandler != null && this.treeHandler.Tree.Root != null)
            {
                TreeMemento treeMemento = this.treeCaretaker.getPrevMemento();
                if (treeMemento != null)
                {
                    this.treeHandler.Tree.Root = (Node)treeMemento.state.Clone();
                    if (this.treeHandler.Tree.Root != null)
                    {
                        this.BandIngTreeView(null, null);
                        this.state = PageState.Edit;
                    }
                }
            }
        }

        /// <summary>
        /// 保存Tree到文件
        /// </summary>
        /// <param name="path"></param>
        public void SaveTree(string path)
        {
            if (path != null && path.Length > 0)
            {

                this.savePath = path;
                this.name = System.IO.Path.GetFileNameWithoutExtension(path);

                this.tabPage.Text = this.name;
                this.tabPage.Name = this.name;
            }

            if (this.savePath != null && this.savePath.Length > 0)
            {
                this.treeHandler.Write(this.savePath);
                this.treeCaretaker.ClearMemento();
            }
        }

        /// <summary>
        /// 检查树是否完整
        /// </summary>
        public bool CheckTree(ref string error, TreeNodeCollection childs)
        {
            if (childs != null && childs.Count > 0)
            {
                foreach (var item in childs)
                {
                    ZDLTreeNode child = item as ZDLTreeNode;
                    if (child.ForeColor == Color.Red)
                    {
                        error = string.Format("第{0}层，{1}的条件不可以为空。", child.Level + 1, child.Text);
                        return false;
                    }
                    else
                    {
                        if (child.Nodes.Count > 0)
                        {
                            return this.CheckTree(ref error, child.Nodes);
                        }
                    }
                }
            }
            else
            {
                ZDLTreeNode root = (ZDLTreeNode)this.treeView.Nodes[0];
                if (root.ForeColor == Color.Red)
                {
                    error = string.Format("第{0}层，{1}的条件不可以为空。", root.Level + 1, root.Text);
                    return false;
                }
                else
                {
                    if (root.Nodes.Count > 0)
                    {
                        return this.CheckTree(ref error, root.Nodes);
                    }
                }
            }

            return true;
        }

        /// <summary>
        /// 导出树
        /// </summary>
        /// <param name="path">导出的路径</param>
        /// <param name="type">导出类型</param>
        public void ExportTree(string path, ExportType type)
        {
            if (path != null && path.Length > 0)
            {
                if (type == ExportType.Json)
                {
                    this.treeHandler.Write(path, type);
                }
                else if (type == ExportType.Xml)
                {
                    //暂时没有处理
                }
            }
        }

        #endregion

        #region 私有函数

        #region 辅助

        /// <summary>
        /// 初始化
        /// </summary>
        private void InitPage()
        {
            this.tabPage = new TabPage();
            this.tabPage.Text = "untitled";
            this.tabPage.Name = "untitled";
            if (this.name != null)
            {
                this.tabPage.Text = this.name;
                this.tabPage.Name = this.name;
                if (this.isTemplate)
                {
                    this.tabPage.Text = "(T)"+this.name;
                    this.tabPage.Name = "(T)"+this.name;
                }
            }

            //
            //treeView
            //
            this.treeView = new TreeView();
            //this.treeView.BackColor = Color.Yellow;
            this.treeView.AllowDrop = true;
            this.treeView.Cursor = System.Windows.Forms.Cursors.Default;
            this.treeView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeView.ItemHeight = 15;
            this.treeView.Location = new System.Drawing.Point(0, 0);
            this.treeView.Name = "treeView";
            this.treeView.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.treeView.TabIndex = 0;
            this.treeView.ShowNodeToolTips = true;
            this.treeView.DragDrop += new System.Windows.Forms.DragEventHandler(this.treeView_DragDrop);
            this.treeView.DragEnter += new System.Windows.Forms.DragEventHandler(this.treeView_DragEnter);
            this.treeView.ItemDrag += new System.Windows.Forms.ItemDragEventHandler(this.treeView_ItemDrag);
            this.treeView.MouseDown += new System.Windows.Forms.MouseEventHandler(this.treeView_MouseDown);
            this.tabPage.Controls.Add(this.treeView);

            //
            //nodeContextMenuStrip
            //
            this.components = new System.ComponentModel.Container();
            this.nodeContextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.lookNToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lookPToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.removeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.nodeContextMenuStrip.SuspendLayout();
            //this.SuspendLayout();
            // 
            // nodeContextMenuStrip
            // 
            this.nodeContextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lookNToolStripMenuItem,
            this.lookPToolStripMenuItem,
            this.removeToolStripMenuItem});
            this.nodeContextMenuStrip.Name = "nodeContextMenuStrip";
            this.nodeContextMenuStrip.Size = new System.Drawing.Size(173, 92);
            this.nodeContextMenuStrip.ResumeLayout(false);
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

            //注册通知
            NotificationCenter.DefaultCenter().addObserver(this, "NodeUpdate", 1);//节点更新
            NotificationCenter.DefaultCenter().addObserver(this, "PreconditionUpdate", 1);//条件更新
            NotificationCenter.DefaultCenter().addObserver(this, "TreeUpdate", 1);//模板更新
            //创建备忘录管理器
            this.treeCaretaker = new TreeCaretaker();

            //页面显示
            if (this.treeHandler != null && this.treeHandler.Tree != null && this.treeHandler.Tree.Root != null)
            {
                this.AddMemento();
                this.BandIngTreeView(null, null);
            }
        }

        private bool isHasTreeNode(List<Node> nodes, Node node)
        {
            if (node != null && nodes != null && nodes.Count > 0)
            {
                foreach (var item in nodes)
                {
                    if (item == node)
                    {
                        return true;
                    }
                    else
                    {
                        if (item.child != null && item.child.Count > 0)
                        {
                            return this.isHasTreeNode(item.child, node);
                        }
                    }
                }
            }
            return false;
        }

        /// <summary>
        /// 绑定树
        /// </summary>
        /// <param name="node"></param>
        /// <param name="childs"></param>
        private void BandIngTreeView(ZDLTreeNode node, List<Node> childs)
        {
            if (node != null && childs != null && childs.Count > 0)
            {
                foreach (var item in childs)
                {
                    ZDLTreeNode child = new ZDLTreeNode(item.name + "(" + item.type + ")");
                    child.ObjNode = item;
                    if (item.precondition != null)
                    {
                        child.ToolTipText = item.precondition.name;
                        child.ForeColor = Color.Black;
                    }
                    else
                    {
                        child.ToolTipText = "没有设置进入条件";
                        child.ForeColor = Color.Red;
                    }
                    node.Nodes.Add(child);
                    if (item.child != null && item.child.Count > 0)
                    {
                        this.BandIngTreeView(child, item.child);
                        child.ExpandAll();
                    }
                }
            }
            else
            {
                ZDLTreeNode root = new ZDLTreeNode(this.treeHandler.Tree.Root.name + "(" + this.treeHandler.Tree.Root.type + ")");
                root.ObjNode = this.treeHandler.Tree.Root;
                this.treeView.Nodes.Clear();
                this.treeView.Nodes.Add(root);
                if (this.treeHandler.Tree.Root.precondition != null)
                {
                    root.ToolTipText = this.treeHandler.Tree.Root.precondition.name;
                    root.ForeColor = Color.Black;
                }
                else
                {
                    root.ToolTipText = "没有设置进入条件";
                    root.ForeColor = Color.Red;
                }
                if (this.treeHandler.Tree.Root.child != null && this.treeHandler.Tree.Root.child.Count > 0)
                {
                    this.BandIngTreeView(root, this.treeHandler.Tree.Root.child);
                    root.ExpandAll();
                }
            }
        }

        #endregion

        #region 事件

        #region TreeView拖拽

        private void treeView_ItemDrag(object sender, ItemDragEventArgs e)
        {
            // 开始进行拖放操作，并将拖放的效果设置成移动。
            if (e.Item as ZDLTreeNode == this.treeView.Nodes[0]) return;//根节点不允许移动
            this.treeView.DoDragDrop(e.Item, DragDropEffects.Move);
        }

        private void treeView_DragDrop(object sender, DragEventArgs e)
        {
            Point p = this.treeView.PointToClient(new Point(e.X, e.Y));
            ZDLTreeNode node = (ZDLTreeNode)this.treeView.GetNodeAt(p.X, p.Y);//拖拽到的节点
            Node objNode = null;//拖拽到的节点对应的行为树节点
            if (node != null)
            {
                objNode = node.ObjNode;
            }

            object treeNodeData = e.Data.GetData(typeof(ZDLTreeNode));
            object stringData = e.Data.GetData(DataFormats.Text);

            #region 是从左边列表拖进来的
            if (stringData != null)
            {
                string stringDataValue = e.Data.GetData(DataFormats.Text).ToString();

                bool isRoot = false;
                if (this.treeHandler == null || this.treeHandler.Tree.Root == null)
                {
                    isRoot = true;
                }

                if (stringDataValue == "Node")
                {
                    #region 节点
                    if (this.dragNode != null)
                    {
                        if (isRoot)
                        {
                            //创建树
                            Node root = (Node)this.dragNode.Clone();

                            if (this.treeHandler == null)
                            {
                                this.treeHandler = new TreeHandler();
                            }

                            Tree tree = this.treeHandler.Tree;
                            if (tree == null)
                            {
                                tree = new Tree();
                                tree.Name = "untitled";
                                tree.IsTemplate = false;
                                tree.TemplateName = null;
                                this.treeHandler.Tree = tree;
                            }
                            tree.Root = root;
                            this.AddMemento();

                            //添加根节点视图
                            ZDLTreeNode rootNodeView = new ZDLTreeNode(this.dragNode.name + "(" + this.dragNode.type + ")");
                            rootNodeView.ObjNode = root;
                            rootNodeView.ToolTipText = "没有设置进入条件";
                            rootNodeView.ForeColor = Color.Red;
                            this.treeView.Nodes.Add(rootNodeView);
                            this.treeView.ExpandAll();

                            //为编辑状态
                            this.state = PageState.Edit;

                        }
                        else if (node != null && objNode != null)
                        {
                            if (objNode.isVirtual)
                            {
                                //添加对象
                                Node dragNodeClone = (Node)this.dragNode.Clone();
                                objNode.child.Add(dragNodeClone);
                                this.AddMemento();

                                //添加视图
                                ZDLTreeNode nodeView = new ZDLTreeNode(this.dragNode.name + "(" + this.dragNode.type + ")");
                                nodeView.ObjNode = dragNodeClone;
                                nodeView.ToolTipText = "没有设置进入条件";
                                nodeView.ForeColor = Color.Red;
                                node.Nodes.Add(nodeView);
                                node.ExpandAll();

                                //为编辑状态
                                this.state = PageState.Edit;
                            }
                        }
                    }
                    #endregion
                }
                else if (stringDataValue == "Tree")
                {
                    #region 树

                    //如果是拖拽模板创建模板是不允许的
                    if (this.isTemplate)
                    {
                        MessageBox.Show("暂不支持模板拖拽到模板", "提示", MessageBoxButtons.OK);
                        return;
                    }
                    if (this.isTemplate == false && this.dragTree != null && this.dragTree.Root != null)
                    {
                        if (isRoot)
                        {
                            //创建树
                            if (this.treeHandler == null)
                            {
                                this.treeHandler = new TreeHandler();
                            }

                            if (this.treeHandler.Tree == null)
                            {
                                //这种是拖拽模板创建普通树的情况
                                this.treeHandler.Tree = new Tree();
                                this.treeHandler.Tree.TemplateName = this.dragTree.Name;
                                this.treeHandler.Tree.Name = "untitled";
                                this.treeHandler.Tree.IsTemplate = false;
                            }

                            this.treeHandler.Tree.Root = (Node)this.dragTree.Root.Clone();
                            this.AddMemento();

                            //添加根节点视图
                            this.BandIngTreeView(null, null);

                            //为编辑状态
                            this.state = PageState.Edit;
                        }
                        else if (node != null && objNode != null)
                        {
                            if (objNode.isVirtual)
                            {
                                //添加对象
                                Node dragNodeClone = (Node)this.dragTree.Root.Clone();
                                objNode.child.Add(dragNodeClone);
                                this.AddMemento();

                                //添加根节点视图
                                this.BandIngTreeView(null, null);

                                //为编辑状态
                                this.state = PageState.Edit;
                            }
                        }
                    }
                    #endregion
                }
                else if (stringDataValue == "Precondition")
                {
                    #region 条件
                    if (this.dragPrecondition != null)
                    {
                        if (node != null && objNode != null)
                        {
                            Precondition dragPreconditionClone = (Precondition)this.dragPrecondition.Clone();
                            objNode.precondition = dragPreconditionClone;
                            this.AddMemento();

                            node.ExpandAll();
                            node.ToolTipText = dragPreconditionClone.name;
                            node.ForeColor = Color.Black;

                            //为编辑状态
                            this.state = PageState.Edit;
                        }
                    }
                    #endregion
                }
            }
            #endregion

            #region 树本身节点拖拽
            if (treeNodeData != null)
            {
                ZDLTreeNode dNode = treeNodeData as ZDLTreeNode;
                if (dNode != null && node != null && objNode != null && dNode != node)
                {
                    Node dObjNode = dNode.ObjNode;
                    if (dObjNode != null && dObjNode != objNode)
                    {
                        //如果拖拽的节点不是目标节点父亲
                        if (!this.isHasTreeNode(dObjNode.child, objNode))
                        {
                            //如果目标节点不是虚节点，那么只有交换顺序的情况                            
                            if (!objNode.isVirtual)
                            {
                                #region 交换顺序
                                ZDLTreeNode dParentNode = (ZDLTreeNode)dNode.Parent;
                                if (dParentNode != null)
                                {
                                    Node dObjParentNode = dParentNode.ObjNode;
                                    if (dObjParentNode != null)
                                    {
                                        ZDLTreeNode parentNode = (ZDLTreeNode)node.Parent;
                                        if (parentNode != null)
                                        {
                                            Node objParentNode = parentNode.ObjNode;

                                            if (objParentNode != null)
                                            {
                                                if (dParentNode == parentNode)//调整顺序
                                                {
                                                    //数据
                                                    dObjParentNode.child.Remove(dObjNode);
                                                    int index = dObjParentNode.child.IndexOf(objNode);
                                                    dObjParentNode.child.Insert(index, dObjNode);
                                                    this.AddMemento();

                                                    //视图
                                                    dParentNode.Nodes.Remove(dNode);
                                                    index = dParentNode.Nodes.IndexOf(node);
                                                    dParentNode.Nodes.Insert(index, dNode);
                                                    dParentNode.ExpandAll();

                                                    //为编辑状态
                                                    this.state = PageState.Edit;

                                                }

                                            }
                                        }
                                    }
                                }
                                #endregion
                            }
                            else//移动到另一个父亲节点
                            {
                                if (node != dNode.Parent && MessageBox.Show("插入到该节点吗？", "提示", MessageBoxButtons.YesNo) == DialogResult.Yes)
                                {
                                    #region 插入到该节点
                                    ZDLTreeNode dParentNode = (ZDLTreeNode)dNode.Parent;
                                    Node dObjParentNode = dParentNode.ObjNode;

                                    if (dParentNode != null && dObjParentNode != null)
                                    {
                                        //数据
                                        dObjParentNode.child.Remove(dObjNode);
                                        objNode.child.Add(dObjNode);
                                        this.AddMemento();

                                        //视图
                                        dParentNode.Nodes.Remove(dNode);
                                        node.Nodes.Add(dNode);
                                        node.ExpandAll();

                                        //为编辑状态
                                        this.state = PageState.Edit;
                                    }
                                    #endregion
                                }
                                else
                                {
                                    #region 交换顺序
                                    ZDLTreeNode dParentNode = (ZDLTreeNode)dNode.Parent;
                                    if (dParentNode != null)
                                    {
                                        Node dObjParentNode = dParentNode.ObjNode;
                                        if (dObjParentNode != null)
                                        {
                                            ZDLTreeNode parentNode = (ZDLTreeNode)node.Parent;
                                            if (parentNode != null)
                                            {
                                                Node objParentNode = parentNode.ObjNode;

                                                if (objParentNode != null)
                                                {
                                                    if (dParentNode == parentNode)//调整顺序
                                                    {
                                                        //数据
                                                        dObjParentNode.child.Remove(dObjNode);
                                                        int index = dObjParentNode.child.IndexOf(objNode);
                                                        dObjParentNode.child.Insert(index, dObjNode);
                                                        this.AddMemento();

                                                        //视图
                                                        dParentNode.Nodes.Remove(dNode);
                                                        index = dParentNode.Nodes.IndexOf(node);
                                                        dParentNode.Nodes.Insert(index, dNode);
                                                        dParentNode.ExpandAll();

                                                        //为编辑状态
                                                        this.state = PageState.Edit;

                                                    }

                                                }
                                            }
                                        }
                                    }
                                    #endregion
                                }
                            }
                        }
                    }
                }
            }
            #endregion
        }

        private void treeView_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.Text))
            {
                e.Effect = DragDropEffects.Copy;
            }
            else
            {
                if (e.Data.GetDataPresent(typeof(ZDLTreeNode)))
                {
                    e.Effect = DragDropEffects.Move;
                }
                else
                {
                    e.Effect = DragDropEffects.None;
                }
            }
        }

        private void treeView_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                TreeNode downNode = this.treeView.GetNodeAt(e.X, e.Y);
                if (downNode != null)
                {
                    treeView.SelectedNode = downNode;
                    this.nodeContextMenuStrip.Show(this.treeView, new Point(e.X, e.Y));
                }
            }
        }

        #endregion

        #region 节点右击菜单
        private void lookNToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Node lookN = ((ZDLTreeNode)this.treeView.SelectedNode).ObjNode;
            if (lookN != null)
            {
                DetailNodeForm detailNodeForm = new DetailNodeForm();
                detailNodeForm.node = lookN;
                detailNodeForm.ShowDialog();
            }
        }

        private void lookPToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Precondition lookP = ((ZDLTreeNode)this.treeView.SelectedNode).ObjNode.precondition;
            if (lookP != null)
            {
                DetailPreconditionForm detailPreconditionForm = new DetailPreconditionForm();
                detailPreconditionForm.precondition = lookP;
                detailPreconditionForm.ShowDialog();
            }
        }

        private void removeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("确定移除吗？", "提示", MessageBoxButtons.OKCancel) == DialogResult.Cancel)
            {
                return;
            }

            ZDLTreeNode deleteN = (ZDLTreeNode)this.treeView.SelectedNode;
            Node deleteObjN = deleteN.ObjNode;
            if (deleteN != null && deleteObjN != null)
            {
                ZDLTreeNode parentN = (ZDLTreeNode)deleteN.Parent;
                Node parentObjN = parentN.ObjNode;
                if (parentN != null && parentObjN != null)
                {
                    //数据
                    parentObjN.child.Remove(deleteObjN);
                    this.AddMemento();

                    //显示
                    parentN.Nodes.Remove(deleteN);

                    //状态
                    this.state = PageState.Edit;
                }
            }
        }

        #endregion

        #region 通知
        public void Notice(Notification notification)
        {
            if (notification.name == "NodeUpdate")
            {
                this.BandIngTreeView(null, null);
            }
            else if (notification.name == "PreconditionUpdate")
            {
                this.BandIngTreeView(null, null);
            }
            else if (notification.name == "TreeUpdate")
            {
                this.name = this.treeHandler.Tree.Name;
                this.tabPage.Name = this.treeHandler.Tree.Name;
                if (this.isTemplate)
                {
                    this.tabPage.Name = "(T)" + this.treeHandler.Tree.Name;
                }
                if (this.state == PageState.Edit)
                {
                    this.tabPage.Text = this.tabPage.Name + "*";
                }
                else
                {
                    this.tabPage.Text = this.tabPage.Name;
                }
            }
        }
        #endregion

        #endregion

        #endregion
    }
}
