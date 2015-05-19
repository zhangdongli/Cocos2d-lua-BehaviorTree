using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BehaviorTreeEditor_Model
{
    /// <summary>
    /// 树
    /// </summary>
    public class Tree : ICloneable
    {
        /// <summary>
        /// 名称
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 是否是模板
        /// </summary>
        public bool IsTemplate { get; set; }

        /// <summary>
        /// 所属模板名称
        /// </summary>
        public string TemplateName { get; set; }

        /// <summary>
        /// 根节点
        /// </summary>
        public Node Root { get; set; }

        public object Clone()
        {
            Tree newValue = new Tree();
            newValue.Name = (string)this.Name.Clone();
            newValue.IsTemplate = this.IsTemplate;
            newValue.TemplateName = (string)this.TemplateName.Clone();
            newValue.Root = (Node)this.Root.Clone();
            return newValue;
        }
    }
}
