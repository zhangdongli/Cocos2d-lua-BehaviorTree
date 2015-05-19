using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BehaviorTreeEditor_Model
{
    /// <summary>
    /// 节点类
    /// </summary>
    public class Node:ICloneable,IObserver
    {
        public string name { get; set; }

        public string type { get; set; }

        public bool isVirtual { get; set; }

        public Precondition precondition { get; set; }

        public List<Node> child { get; set; }

        public Node()
        {
            this.name = null;
            this.type = null;
            this.isVirtual = false;
            this.precondition = null;
            this.child = new List<Node>();
            NotificationCenter.DefaultCenter().addObserver(this, "NodeUpdate");
        }

        ~Node()
        {
            NotificationCenter.DefaultCenter().removeObserver(this);
        }

        public object Clone()
        {
            Node res = new Node();
            res.name = (string)this.name.Clone();
            res.type = (string)this.type.Clone();
            res.isVirtual = this.isVirtual;
            if (this.precondition != null)
            {
                res.precondition = (Precondition)this.precondition.Clone();
            }
            if (this.child != null)
            {
                List<Node> childs = new List<Node>();
                foreach (var children in this.child)
                {
                    childs.Add((Node)children.Clone());
                }
                res.child = childs;
            }
            return res;
        }

        public void Notice(Notification notification)
        {
            List<Node> obj = (List<Node>)notification.obj;
            if (obj != null && obj.Count == 2)
            {
                Node org = obj[0];
                Node now = obj[1];
                if (org != null && now != null && now != this && org.name == this.name && org.type == this.type)
                {
                    this.name = now.name;
                    this.type = now.type;
                    this.isVirtual = now.isVirtual;
                }
            }
        }
    }
}
