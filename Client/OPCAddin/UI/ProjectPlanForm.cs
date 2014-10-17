using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OPCAddin.UI
{
    public partial class ProjectPlanForm : Form
    {
        public ProjectPlanForm()
        {
            InitializeComponent();
        }

        public List<ProjectItem> Projects { get; set; }

        private async void GanttDiagramForm_Load(object sender, EventArgs e)
        {
            var userToken = LoginService.GetInstance().UserToken;
            var projects = await BackendServiceProxy.GetAllProjectsWithChildTasks(userToken);
        }

        private void btnSaveAndClose_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Close();
        }

        private void btnSave_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Close();
        }
    }
}