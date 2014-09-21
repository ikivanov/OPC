using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OPCAddin.UI
{
    public partial class ProjectItemForm : Form
    {
        public ProjectItemForm()
        {
            InitializeComponent();
        }

        private void btnSaveAndClose_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //TODO:
            this.Close();
        }

        private void btnDelete_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //TODO:
            this.Close();
        }

        private void ribbonControl1_Click(object sender, EventArgs e)
        {

        }
    }
}
