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

namespace UI
{
    /// <summary>
    /// 添加和修改条件页面
    /// </summary>
    public partial class AddPreconditionForm : Form
    {
        public Precondition editPrecondition { get; set; }

        public List<Precondition> childPreconditions { get; set; }

        public IAddPreconditionForm m_delegate { get; set; }

        private List<Precondition> childDatas { get; set; }

        public AddPreconditionForm()
        {
            InitializeComponent();
        }

        private void AddPreconditionForm_Load(object sender, EventArgs e)
        {

            this.initDatas();

            this.child1DataBanding();
            this.child2DataBanding();

            this.initWindow();
        }


        #region 私有函数

        /// <summary>
        /// 初始化数据
        /// </summary>
        private void initDatas()
        {
            if (this.childPreconditions != null)
            {
                this.childDatas = new List<Precondition>(this.childPreconditions);

                if (this.editPrecondition != null)
                {
                    this.childDatas.Remove(this.editPrecondition);
                }
            }
        }

        /// <summary>
        /// 数据检查
        /// </summary>
        /// <param name="error"></param>
        /// <returns></returns>
        private bool checkDatas(ref string error)
        {
            if (this.nameTextBox.Text == null
                || this.nameTextBox.Text == string.Empty
                || this.nameTextBox.Text.Trim(new char[] { '\n', ' ' }) == string.Empty) {
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


            if (!this.isBasePCheckBox.Checked)
            {
                if (this.numericUpDown1.Value > 0) {
                    if (this.numericUpDown1.Value == 1)
                    {
                        if (this.child1CheckedListBox.SelectedIndex < 0) 
                        {
                            error = "请设置子条件1";
                            return false;
                        }
                    }
                    else if (this.numericUpDown1.Value == 2)
                    {
                        if (this.child1CheckedListBox.SelectedIndex < 0)
                        {
                            error = "请设置子条件1";
                            return false;
                        }

                        if (this.child2CheckedListBox.SelectedIndex < 0)
                        {
                            error = "请设置子条件2";
                            return false;
                        }

                        if (this.childDatas[this.child1CheckedListBox.SelectedIndex] == this.childDatas[this.child2CheckedListBox.SelectedIndex])
                        {
                            error = "2个子条件不可以相同";
                            return false;
                        }
                    }
                }
            }

            return true;
        }

        /// <summary>
        /// 初始化窗口显示
        /// </summary>
        private void initWindow()
        {
            Size size = new Size(447, 290);//447,462
            if (this.editPrecondition != null)
            {
                this.nameTextBox.Text = this.editPrecondition.name;
                this.typeTextBox.Text = this.editPrecondition.type;
                this.numericUpDown1.Value = this.editPrecondition.childCount;
                if (this.editPrecondition.child != null && this.editPrecondition.child.Count > 0)
                {
                    size.Height = 462;
                    this.isBasePCheckBox.Checked = false;
                    if (this.editPrecondition.child.Count() >= 1)
                    {
                        this.child1Panel.Visible = true;
                        this.numericUpDown1.Value = 1;
                        Precondition child1 = this.editPrecondition.child[0];
                        int child1Index = this.findIndexByChild(child1);
                        if (child1Index >= 0) {
                            this.child1CheckedListBox.SelectedIndex = child1Index;
                            this.child1CheckedListBox.SetItemChecked(child1Index,true);
                        }
                    }

                    if (this.editPrecondition.child.Count() >= 2)
                    {
                        this.child2Panel.Visible = true;
                        this.numericUpDown1.Value = 2;
                        Precondition child2 = this.editPrecondition.child[1];
                        int child2Index = this.findIndexByChild(child2);
                        if (child2Index >= 0)
                        {
                            this.child2CheckedListBox.SelectedIndex = child2Index;
                            this.child2CheckedListBox.SetItemChecked(child2Index, true);
                        }
                    }
                }
                else
                {
                    this.isBasePCheckBox.Checked = true;
                }
            }

            if (this.childPreconditions != null && childPreconditions.Count > 0)
            {
                foreach (var item in this.childPreconditions)
                {
                    if (item.isBase && item.childCount > 0)
                    {
                        this.typeTextBox.Items.Add(item.type);
                    }
                }
            }

            this.Size = size;
        }

        /// <summary>
        /// 调整窗口显示
        /// </summary>
        private void setWindow()
        {
            Size size = new Size(447, 290);//447,462

            if (!this.isBasePCheckBox.Checked && this.numericUpDown1.Value > 0)
            {
                size.Height = 462;

                if (this.numericUpDown1.Value >= 1)
                {
                    this.child1Panel.Visible = true;
                }

                if (this.numericUpDown1.Value >= 2)
                {
                    this.child2Panel.Visible = true;
                }
                else
                {
                    this.child2Panel.Visible = false;
                }
            }
            else
            {
                this.child1Panel.Visible = false;
                this.child2Panel.Visible = false;
            }

            this.Size = size;
        }

        /// <summary>
        /// 查找子条件在条件集合的下标
        /// </summary>
        /// <param name="child"></param>
        /// <returns></returns>
        private int findIndexByChild(Precondition child)
        {
            int ret = -1;
            if (this.childDatas != null && this.childDatas.Count > 0) 
            {
                foreach (var item in this.childDatas)
                {
                    if (item.type == child.type && item.name == child.name) 
                    {
                        ret = this.childDatas.IndexOf(item);
                        break;
                    }
                }
            }
            return ret;
        }

        #endregion

        #region 数据绑定
        /// <summary>
        /// 绑定子条件1的数据
        /// </summary>
        private void child1DataBanding()
        {
            if (this.childDatas != null && this.childDatas.Count > 0)
            {
                foreach (var item in this.childDatas)
                {
                    this.child1CheckedListBox.Items.Add(item.name);
                }
            }
        }

        /// <summary>
        /// 绑定子条件2的数据
        /// </summary>
        private void child2DataBanding()
        {
            if (this.childDatas != null && this.childDatas.Count > 0)
            {
                foreach (var item in this.childDatas)
                {
                    this.child2CheckedListBox.Items.Add(item.name);
                }
            }
        }
        #endregion

        #region 事件
        /// <summary>
        /// 是否是基本条件复选框值改变事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void isBasePCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            this.setWindow();
        }

        /// <summary>
        /// 子条件个数值改变事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            this.setWindow();
        }

        /// <summary>
        /// 选择了子条件1的某项
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void child1CheckedListBox_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            if (e.CurrentValue == CheckState.Checked) return;

            for (int i = 0; i < ((CheckedListBox)sender).Items.Count; i++)
            {
                ((CheckedListBox)sender).SetItemChecked(i, false);
            }

            e.NewValue = CheckState.Checked;

        }

        /// <summary>
        /// 选择了子条件2的某项
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void child2CheckedListBox_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            if (e.CurrentValue == CheckState.Checked) return;

            for (int i = 0; i < ((CheckedListBox)sender).Items.Count; i++)
            {
                ((CheckedListBox)sender).SetItemChecked(i, false);
            }

            e.NewValue = CheckState.Checked;
        }

        /// <summary>
        /// 取消按钮点击
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// 确认按钮点击
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void sureButton_Click(object sender, EventArgs e)
        {
            string error = null;
            if (!this.checkDatas(ref error)) {

                MessageBox.Show(error,"错误", MessageBoxButtons.OK);
                return;
            }

            if (this.editPrecondition != null)//编辑
            {
                Precondition tmpP = new Precondition();
                tmpP.name = this.editPrecondition.name;
                tmpP.type = this.editPrecondition.type;

                this.editPrecondition.name = this.nameTextBox.Text.Trim(new char[] { '\n', ' ' });
                this.editPrecondition.type = this.typeTextBox.Text.Trim(new char[] { '\n', ' ' });
                this.editPrecondition.childCount = (int)this.numericUpDown1.Value;
                this.editPrecondition.isBase = this.isBasePCheckBox.Checked;

                if (this.editPrecondition.childCount > 0 && !this.isBasePCheckBox.Checked)
                {
                    this.editPrecondition.child = new List<Precondition>();
                    if (this.editPrecondition.childCount >= 1)
                    {
                        Precondition child1 = this.childDatas[this.child1CheckedListBox.SelectedIndex];
                        this.editPrecondition.child.Add(child1);
                    }

                    if (this.editPrecondition.childCount >= 2)
                    {
                        Precondition child2 = this.childDatas[this.child2CheckedListBox.SelectedIndex];
                        this.editPrecondition.child.Add(child2);
                    }
                }

                List<Precondition> parms = new List<Precondition>();
                parms.Add(tmpP);
                parms.Add(this.editPrecondition);
                NotificationCenter.DefaultCenter().postNotification("PreconditionUpdate", parms);

            }
            else
            {
                Precondition newP = new Precondition();
                newP.name = this.nameTextBox.Text.Trim(new char[]{'\n',' '});
                newP.type = this.typeTextBox.Text.Trim(new char[] { '\n', ' ' });
                newP.childCount = (int)this.numericUpDown1.Value;
                newP.isBase = this.isBasePCheckBox.Checked;
                if (newP.childCount > 0 && !this.isBasePCheckBox.Checked)
                {
                    newP.child = new List<Precondition>();
                    if (newP.childCount >= 1)
                    {
                        Precondition child1 = this.childDatas[this.child1CheckedListBox.SelectedIndex];
                        newP.child.Add(child1);
                    }

                    if (newP.childCount >= 2)
                    {
                        Precondition child2 = this.childDatas[this.child2CheckedListBox.SelectedIndex];
                        newP.child.Add(child2);
                    }
                }

                this.childPreconditions.Add(newP);
            }

            if (this.m_delegate != null)
            {
                this.m_delegate.RefreshPrecondition();
            }

            this.Close();
        }

        #endregion

    }
}
