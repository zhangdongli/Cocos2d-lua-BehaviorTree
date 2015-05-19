using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BehaviorTreeEditor_Model
{
    /// <summary>
    /// 通知
    /// </summary>
    public class Notification
    {
        /// <summary>
        /// 事件名称
        /// </summary>
        public string name { get; set; }

        /// <summary>
        /// 事件传递对象
        /// </summary>
        public object obj { get; set; }

        /// <summary>
        /// 观察者
        /// </summary>
        public IObserver observer { get; set; }

        /// <summary>
        /// 优先级
        /// </summary>
        public int priority { get; set; }

    }
}
