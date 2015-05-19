using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using BehaviorTreeEditor_Model;
using BehaviorTreeEditor_BLL;
using BehaviorTreeEditor_Components;

namespace UI
{
    public partial class AddTemplateForm : Form
    {
        public Tree editTree { get; set; }

        public List<Tree> treeDatas { get; set; }

        public IAddTemplateForm m_delegate { get; set; }

        public AddTemplateForm()
        {
            InitializeComponent();
        }

        private void AddTemplateForm_Load(object sender, EventArgs e)
        {
            if (this.editTree != null)
            {
                this.nameTextBox.Text = this.editTree.Name;
            }
        }

        /// <summary>
        /// 取消按钮点击事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// 确认按钮点击事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void sureButton_Click(object sender, EventArgs e)
        {
            string error = null;
            if (!this.checkData(ref error))
            {
                MessageBox.Show(error, "错误", MessageBoxButtons.OK);
                return;
            }

            if(this.editTree != null)
            {
                Tree tmpP = new Tree();
                tmpP.Name = this.editTree.Name;

                this.editTree.Name = this.nameTextBox.Text.Trim();

                List<Tree> parms = new List<Tree>();
                parms.Add(tmpP);
                parms.Add(this.editTree);
                NotificationCenter.DefaultCenter().postNotification("TreeUpdate", parms);
            }
            else
            {
                Tree newTree = new Tree();
                newTree.Name = this.nameTextBox.Text.Trim();
                newTree.IsTemplate = true;
                newTree.TemplateName = null;
                this.treeDatas.Add(newTree);
            }

            if (this.m_delegate != null)
            {
                this.m_delegate.RefreshTemplateForm();
            }

            this.Close();
        }


        /// <summary>
        /// 检查数据合法性
        /// </summary>
        /// <param name="error"></param>
        /// <returns></returns>
        private bool checkData(ref string error)
        {
            if (this.nameTextBox.Text == null || this.nameTextBox.Text.Trim().Length == 0) {
                error = "名称不可以为空";
                return false;
            }

            if (this.treeDatas != null && this.treeDatas.Count > 0)
            {
                var res = this.treeDatas.Find(delegate(Tree t) { return t.Name == this.nameTextBox.Text.Trim(); });
                if(res != null)
                {
                    error = "已经存在相同名称的模板了。";
                    return false;
                }

            }

            return true;
        }
    }
}
