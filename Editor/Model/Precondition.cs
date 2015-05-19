using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BehaviorTreeEditor_Model
{
    /// <summary>
    /// 前提条件类
    /// </summary>
    public class Precondition : ICloneable,IObserver
    {
        public string name { get; set; }

        public string type { get; set; }

        public int childCount { get; set; }

        public bool isBase { get; set; }

        public List<Precondition> child { get; set; }

        public Precondition()
        {
            this.name = null;
            this.type = null;
            this.childCount = 0;
            this.isBase = true;
            this.child = null;

            NotificationCenter.DefaultCenter().addObserver(this, "PreconditionUpdate");

        }

         ~Precondition()
        {
            NotificationCenter.DefaultCenter().removeObserver(this);
        }

        public object Clone()
        {
            Precondition res = new Precondition();
            res.name = (string)this.name.Clone();
            res.type = (string)this.type.Clone();
            res.childCount = this.childCount;
            res.isBase = this.isBase;
            if (this.child != null)
            {
                List<Precondition> childs = new List<Precondition>();
                foreach (var children in this.child)
                {
                    childs.Add((Precondition)children.Clone());
                }
                res.child = childs;
            }
            return res;
        }

        /// <summary>
        /// 添加子条件
        /// </summary>
        /// <param name="child"></param>
        /// <returns></returns>
        public bool AddChild(Precondition child)
        {
            if (this.child.Count() >= this.childCount)
            {
                return false;
            }

            this.child.Add(child);
            return true;
        }


        public void Notice(Notification notification)
        {
            List<Precondition> obj = (List<Precondition>)notification.obj;
            if (obj != null && obj.Count == 2)
            {
                Precondition org = obj[0];
                Precondition now = obj[1];

                if (org != null && now != null && now != this && org.name == this.name && org.type == this.type)
                {
                    this.name = now.name;
                    this.type = now.type;
                    this.childCount = now.childCount;
                    this.isBase = now.isBase;
                }
            }
        }
    }
}
