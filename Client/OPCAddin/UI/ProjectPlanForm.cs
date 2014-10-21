using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
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

            webBrowser1.ObjectForScripting = new ScriptManager(this);
        }

        public List<ProjectItem> Projects { get; set; }

        private async void GanttDiagramForm_Load(object sender, EventArgs e)
        {
            webBrowser1.Navigate("http://localhost:1337/ProjectPlan.html");
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

    [ComVisible(true)]
    public class ScriptManager
    {
        ProjectPlanForm form;
        public ScriptManager(ProjectPlanForm form)
        {
            this.form = form;
        }

        public string GetGridData()
        {
            var userToken = LoginService.GetInstance().UserToken;
            var s = BackendServiceProxy.GetProjectsPlan(userToken).Result;
            return s.Data;
        }

        public void Save()
        {
        }
    }
}