using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using BehaviorTreeEditor_Model;

namespace UI
{
    /// <summary>
    /// 显示的树节点表示类
    /// </summary>
    public class ZDLTreeNode:TreeNode
    {
        public Node ObjNode { get; set; }

        public ZDLTreeNode():base()
        { 
            
        }

        public ZDLTreeNode(string text)
            : base(text)
        { 
            
        }
    }
}
