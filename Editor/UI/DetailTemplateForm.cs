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
    public partial class DetailTemplateForm : Form
    {
        public Tree treeInfo { get; set; }

        public DetailTemplateForm()
        {
            InitializeComponent();
        }

        private void DetailTemplateForm_Load(object sender, EventArgs e)
        {
            if (this.treeInfo != null)
            {
                this.nameLabel.Text = this.treeInfo.Name;
                this.hasNodeLabel.Text = "是";
                if (this.treeInfo.Root == null)
                {
                    this.hasNodeLabel.Text = "否";
                }
            }
        }
    }
}
