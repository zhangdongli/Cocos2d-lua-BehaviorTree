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
    /// <summary>
    /// 添加和修改节点页面
    /// </summary>
    public partial class AddNodeForm : Form
    {
        public Node editNode { get; set; }

        public List<Node> nodeDatas { get; set; }

        public IAddNodeForm m_delegate { get; set; }

        public AddNodeForm()
        {
            InitializeComponent();
        }

        private void AddNodeForm_Load(object sender, EventArgs e)
        {
            if (this.editNode != null)
            {
                this.nameTextBox.Text = this.editNode.name;
                this.typeTextBox.Text = this.editNode.type;
                if (this.editNode.isVirtual)
                {
                    this.isVirtualCheckBox.Checked = true;
                }
                else
                {
                    this.isVirtualCheckBox.Checked = false;
                }
                this.loopCountTxt.Text = this.editNode.loopCount.ToString();
                if (this.editNode.finishCondition == 1)
                {
                    this.k_PFC_OR.Checked = true;
                    this.k_PFC_AND.Checked = false;
                }
                else
                {
                    this.k_PFC_OR.Checked = false;
                    this.k_PFC_AND.Checked = true;
                }
            }
        }

        #region 按钮点击事件

        /// <summary>
        /// 取消按钮点击
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// 确认按钮点击
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button2_Click(object sender, EventArgs e)
        {
            string error = null;
            if (!this.checkData(ref error)) {
                MessageBox.Show(error, "错误", MessageBoxButtons.OK);
                return;
            }

            if (this.editNode != null)//编辑
            {
                 Node tmpNode = new Node();
                 tmpNode.name = this.editNode.name;
                 tmpNode.type = this.editNode.type;
                 tmpNode.loopCount = this.editNode.loopCount;
                 tmpNode.finishCondition = this.editNode.finishCondition;

                this.editNode.name = this.nameTextBox.Text.Trim(new char[] { '\n', ' ' });
                this.editNode.type = this.typeTextBox.Text.Trim(new char[] { '\n', ' ' });
                this.editNode.isVirtual = this.isVirtualCheckBox.Checked;

                int res = -1; 
                if (int.TryParse(this.loopCountTxt.Text,out res)){
                    this.editNode.loopCount = res;
                }
          
                if (this.k_PFC_OR.Checked)
                {
                    this.editNode.finishCondition = 1;
                }
                else
                {
                    this.editNode.finishCondition = 2;
                }
                

                //发送更改通知
               
                List<Node> parms = new List<Node>();
                parms.Add(tmpNode);
                parms.Add(this.editNode);
                NotificationCenter.DefaultCenter().postNotification("NodeUpdate", parms);
            }
            else
            {
                Node newN = new Node();
                newN.name = this.nameTextBox.Text.Trim(new char[]{'\n',' '});
                newN.type = this.typeTextBox.Text.Trim(new char[]{'\n',' '});
                newN.isVirtual = this.isVirtualCheckBox.Checked;
                int res = -1;
                if (int.TryParse(this.loopCountTxt.Text, out res))
                {
                    newN.loopCount = res;
                }

                if (this.k_PFC_OR.Checked)
                {
                    newN.finishCondition = 1;
                }
                else
                {
                    newN.finishCondition = 2;
                }
                this.nodeDatas.Add(newN);
            }

            if (this.m_delegate != null)
            {
                this.m_delegate.RefreshNode();
            }

            this.Close();
        }

        #endregion

        #region 私有函数

        private bool checkData(ref string error)
        {
            if (this.nameTextBox.Text == null
                || this.nameTextBox.Text == string.Empty
                || this.nameTextBox.Text.Trim(new char[] { '\n', ' ' }) == string.Empty)
            {
                error = "名称不可以为空";
                return false;
            }

            if (this.typeTextBox.Text == null
                || this.typeTextBox.Text == string.Empty
                || this.typeTextBox.Text.Trim(new char[] { '\n', ' ' }) == string.Empty)
            {
                error = "类型不可以为空";
                return false;
            }

            if (this.loopCountTxt.Text != null && this.loopCountTxt.Text.Length > 0)
            { 
                int res = -1;
                if (!int.TryParse(this.loopCountTxt.Text, out res))
                {
                    error = "循环次数必须为数字";
                    return false;
                }
                this.loopCountTxt.Text = res.ToString();
            }

            return true;
        }

        #endregion
    }
}
