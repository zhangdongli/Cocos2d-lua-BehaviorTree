using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BehaviorTreeEditor_Model
{
    /// <summary>
    /// 通知中心
    /// </summary>
    public class NotificationCenter
    {
        private List<Notification> notifications {get;set;}

        private static NotificationCenter obj = null;

        public static NotificationCenter DefaultCenter()
        {
            if (obj == null)
            {
                obj = new NotificationCenter();
            }

            return obj;
        }

        private NotificationCenter()
        {
            this.notifications = new List<Notification>();
        }

        private bool IsHasObservers(IObserver observer,string name)
        {
            Notification res = this.notifications.Find(item => item.name == name && item.observer == observer);
            if (res == null)
            {
                return false;
            }
            return true;
        }

        #region 对外接口

        /// <summary>
        /// 观察某个事件
        /// </summary>
        /// <param name="observer">观察者</param>
        /// <param name="name">事件名称</param>
        public void addObserver(IObserver observer,string name)
        {

            if(!this.IsHasObservers(observer,name))
            {
                Notification notice = new Notification();
                notice.name = name;
                notice.obj = null;
                notice.observer = observer;

                this.notifications.Add(notice);
            }

            
        }

        /// <summary>
        /// 观察某个事件
        /// </summary>
        /// <param name="observer">观察者</param>
        /// <param name="name">事件名称</param>
        /// <param name="priority">调用优先级</param>
        public void addObserver(IObserver observer, string name, int priority)
        {
            Notification res = this.notifications.Find(item => item.name == name && item.observer == observer);

            if (res != null && res.priority != priority)
            {
                res.priority = priority;
                return;
            }

            Notification notice = new Notification();
            notice.name = name;
            notice.obj = null;
            notice.observer = observer;
            notice.priority = priority;

            this.notifications.Add(notice);
        }


        /// <summary>
        /// 移除观察者
        /// </summary>
        /// <param name="observer">观察者</param>
        public void removeObserver(IObserver observer)
        {
            List<Notification> res = this.notifications.FindAll(itme => itme.observer == observer);
            if (res != null && res.Count > 0)
            {
                foreach (var item in res)
                {
                    this.notifications.Remove(item);
                }
            }
        }


        /// <summary>
        /// 移除观察某个事件的观察者
        /// </summary>
        /// <param name="observer">观察者</param>
        /// <param name="name">事件名称</param>
        public void removeObserver(IObserver observer, string name)
        {
            Notification res = this.notifications.Find(item => item.name == name && item.observer == observer);
            if (res != null)
            {
                this.notifications.Remove(res);
            }
        }

        /// <summary>
        /// 触发事件
        /// </summary>
        /// <param name="name">事件名称</param>
        /// <param name="obj">传递参数</param>
        public void postNotification(string name,object obj)
        {
            List<Notification> res = this.notifications.FindAll(itme=>itme.name == name);
            if(res != null &&　res.Count > 0)
            {
                res.Sort((left, right) =>
                {
                    return left.priority.CompareTo(right.priority);
                });

                foreach (var item in res)
	            {
                     if (item.observer != null)
                     {
                         Notification notice = new Notification();
                         notice.name = name;
                         notice.obj = obj;
                         notice.observer = item.observer;
                         notice.priority = item.priority;
                         item.observer.Notice(notice);
                     }
	            }
            }
        }

        #endregion
    }
}
