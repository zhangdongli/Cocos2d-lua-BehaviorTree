using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BehaviorTreeEditor_Model
{
    /// <summary>
    /// 树的备忘录管理类
    /// </summary>
    public class TreeCaretaker
    {
        private const int maxMementoCount = 8;//最大备忘录个数

        private List<TreeMemento> mementQueue { get; set; }//备忘录队列

        private List<TreeMemento> tmpMementQueue { get; set; }//临时队列

        public TreeCaretaker()
        {
            this.mementQueue = new List<TreeMemento>();
            this.tmpMementQueue = new List<TreeMemento>();
        }

        public TreeMemento getLastMemento()
        {
            if (this.mementQueue.Count > 0)
            {
                this.tmpMementQueue.Add(this.mementQueue[0]);
                if (this.tmpMementQueue.Count > maxMementoCount)
                {
                    this.tmpMementQueue.RemoveAt(0);
                }

                this.mementQueue.RemoveAt(0);
                if (this.mementQueue.Count > 0)
                {
                    return this.mementQueue[0];
                }
            }

            return null;

        }

        public TreeMemento getPrevMemento()
        {
            if (this.tmpMementQueue.Count > 0)
            {
                this.mementQueue.Insert(0, this.tmpMementQueue[this.tmpMementQueue.Count - 1]);
                if (this.mementQueue.Count > maxMementoCount)
                {
                    this.mementQueue.RemoveAt(this.mementQueue.Count - 1);
                }

                this.tmpMementQueue.RemoveAt(this.tmpMementQueue.Count - 1);
                if (this.mementQueue.Count > 0)
                {
                    return this.mementQueue[0];
                }
            }

            return null;
        }

        public void setMemento(TreeMemento memento)
        {
            //如果一个没有直接添加
            if (mementQueue.Count() == 0)
            {
                mementQueue.Add(memento);
                return;
            }

            //插入第一个位置
            mementQueue.Insert(0, memento);

            //如果个数超过最大个数
            if (mementQueue.Count() > maxMementoCount)
            {
                //移除最后一个
                mementQueue.RemoveAt(mementQueue.Count() - 1);
            }

        }

        public void ClearMemento()
        {
            this.mementQueue.Clear();
            this.tmpMementQueue.Clear();
        }
    }
}
