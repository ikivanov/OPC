using System;
using System.Drawing;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using AddinExpress.OL;
using OPCAddin;
  
namespace OPCAddin.UI
{
    public partial class TaskExtensionForm : AddinExpress.OL.ADXOlForm
    {
        private BindingSource projectsBinding;
        public TaskExtensionForm()
        {
            InitializeComponent();

            projectsBinding = new BindingSource();
            OPCAddin.AddinModule.CurrentInstance.Events.ItemLoad += adxOutlookEvents_ItemLoad;
        }

        void adxOutlookEvents_ItemLoad(object sender, object item)
        {
            //var task = item as Microsoft.Office.Interop.Outlook.TaskItem;
            //if (task == null)
            //{
            //    return;
            //}

            //var id = task.ConversationIndex;
        }

        public string GetFormData()
        {

            var val = this.cboProjekt.SelectedValue;

            return val != null ? val.ToString() : string.Empty;
        }

        private async void TaskExtensionForm_Load(object sender, EventArgs e)
        {
            var userToken = OPCAddin.AddinModule.CurrentInstance.UserToken;
            var result = await BackendServiceProxy.LookupProjects(userToken);
            
            this.SetBinding(result.Projects);
        }

        private void SetBinding(ProjectItem[] projects)
        {
            projectsBinding.DataSource = projects;
            cboProjekt.DataSource = projectsBinding;
            cboProjekt.DisplayMember = "Name";
            cboProjekt.ValueMember = "Id";
        }
    }
}
