using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BehaviorTreeEditor_Model
{
    /// <summary>
    /// 树的备忘录
    /// </summary>
    public class TreeMemento
    {
        public Node state { get; set; }

        public TreeMemento(Node state)
        {
            this.state = state;
        }
    }
}
