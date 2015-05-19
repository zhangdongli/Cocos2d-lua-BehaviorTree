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

namespace UI
{
    /// <summary>
    /// 节点查看页面
    /// </summary>
    public partial class DetailNodeForm : Form
    {
        public Node node { get; set; }

        public DetailNodeForm()
        {
            InitializeComponent();
        }

        private void DetailNodeForm_Load(object sender, EventArgs e)
        {
            if (this.node != null)
            {
                this.nameLabel.Text = this.node.name;
                this.typeLabel.Text = this.node.type;

                if (this.node.isVirtual)
                {
                    this.virtualLabel.Text = "是";
                }
                else
                {
                    this.virtualLabel.Text = "否";
                }
            }
        }
    }
}
