using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using BehaviorTreeEditor_Model;
using BehaviorTreeEditor_Components;

namespace BehaviorTreeEditor_BLL
{
    /// <summary>
    /// 树导出类型
    /// </summary>
    public enum ExportType
    {
        Json = 0,
        Xml = 1
    }

    /// <summary>
    /// 逻辑树
    /// </summary>
    public class TreeHandler
    {
        public Tree Tree { get; set; }

        public TreeHandler()
        { 
            
        }

        public TreeHandler(string path)
        {
            if (File.FileIsExist(path))
            {
                this.Read(path);
            }
        }

        #region 公共接口

        #region public bool Write(string path)
        /// <summary>
        /// 写入json文件
        /// </summary>
        /// <param name="path">json文件路径</param>
        /// <returns>是否成功</returns>
        public bool Write(string path)
        {
            if (path == null || path == string.Empty)
            {
                return false;
            }

            if (this.Tree == null)
            {
                return false;
            }

            if (this.Tree.IsTemplate == true)
            {
                return false;
            }

            string jsonString = JsonConvert.SerializeObject(this.Tree);

             if (jsonString == null || jsonString == string.Empty) 
             {
                 return false;
             }

             return this.Save(jsonString, path);
        }

        /// <summary>
        /// 写入指定类型文件
        /// </summary>
        /// <param name="path">文件路径</param>
        /// <param name="type">文件类型</param>
        /// <returns>是否成功</returns>
        public bool Write(string path,ExportType type)
        {
            if (path == null || path == string.Empty)
            {
                return false;
            }

            if (this.Tree == null)
            {
                return false;
            }

            string res = null;

            if (type == ExportType.Json)
            {
                res = JsonConvert.SerializeObject(this.Tree.Root);
            }
            else if (type == ExportType.Xml)
            { 
                //没有实现
            }

            if (res == null || res == string.Empty)
            {
                return false;
            }

            return this.Save(res, path);
        }

        #endregion

        #region public bool Read(string path)
        /// <summary>
        /// 从json文件读取
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public bool Read(string path)
        {
            if (path == null || path == string.Empty)
            {
                return false;
            }

            string jsonString = this.Load(path);

            if (jsonString == null || jsonString == string.Empty)
            {
                return false;
            }

            Tree tree = (Tree)JsonConvert.DeserializeObject(jsonString, typeof(Tree));
            if (tree == null || tree.Root == null)
            {
                return false;
            }

            this.Tree = tree;
            return true;
        }
        #endregion

        #region public TreeMemento createMemento()
        /// <summary>
        /// 创建备忘录
        /// </summary>
        /// <returns></returns>
        public TreeMemento createMemento()
        {
            return new TreeMemento((Node)this.Tree.Root.Clone());
        }
        #endregion

        #region public void restoreMemento(TreeMemento memento)
        /// <summary>
        /// 从备忘录里还原
        /// </summary>
        /// <param name="memento"></param>
        public void restoreMemento(TreeMemento memento)
        {
            this.Tree.Root = memento.state;
        }
        #endregion

        #endregion

        #region 私有接口

        #region private bool Save(string content, string path)
        /// <summary>
        /// 将字符串保存到文件
        /// </summary>
        /// <param name="content">要保存的字符串内容</param>
        /// <param name="path">要保存的路径</param>
        /// <returns></returns>
        private bool Save(string content, string path)
        {
            File.WriteFile(path,content);
            return true;
        }
        #endregion

        #region private string Load(string path)
        /// <summary>
        /// 从文件读取字符串
        /// </summary>
        /// <param name="path">文件路径</param>
        /// <returns>字符串内容</returns>
        private string Load(string path)
        {
            return File.ReadFile(path);
        }
        #endregion

        #endregion
    }
}
