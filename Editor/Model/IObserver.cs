using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BehaviorTreeEditor_Model
{
    /// <summary>
    /// 接受通知接口
    /// </summary>
    public interface IObserver
    {
        /// <summary>
        /// 接受通知函数
        /// </summary>
        /// <param name="notification">通知对象</param>
        void Notice(Notification notification);
    }
}
