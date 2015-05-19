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

namespace UI
{
    /// <summary>
    /// 条件查看页面
    /// </summary>
    public partial class DetailPreconditionForm : Form
    {
        public Precondition precondition { get; set; }

        public DetailPreconditionForm()
        {
            InitializeComponent();
        }

        private void DetailPreconditionForm_Load(object sender, EventArgs e)
        {
            if (this.precondition != null)
            {
                this.pTreeViewDataBanding(null,null);
            }
        }

        private void pTreeViewDataBanding(TreeNode node,List<Precondition> childs)
        {
            if (node != null && childs != null && childs.Count > 0)
            {
                foreach (var item in childs)
                {
                    TreeNode child = new TreeNode(item.name + "(" + item.type + ")");
                    node.Nodes.Add(child);
                    if (item.child != null && item.child.Count > 0)
                    {
                        this.pTreeViewDataBanding(child, item.child);
                        child.ExpandAll();
                    }
                }
            }
            else
            {

                TreeNode root = new TreeNode(this.precondition.name + "(" + this.precondition .type + ")");
                this.pTreeView.Nodes.Add(root);
                if (this.precondition.child != null && this.precondition.child.Count > 0)
                {
                    this.pTreeViewDataBanding(root, this.precondition.child);
                    root.ExpandAll();
                }
            }
        }
    }
}
