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
using Outlook = Microsoft.Office.Interop.Outlook;

namespace OPCAddin.UI
{
    public partial class ProjectItemForm : Form
    {
        public ProjectItemForm()
        {
            InitializeComponent();
        }

        private ProjectItem project;

        private ProjectItem Project
        {
            get
            {
                if (this.project == null)
                {
                    this.project = new ProjectItem();
                }

                this.Invoke((MethodInvoker)delegate
                {
                    this.project.Name = txtProjectName.Text;
                    this.project.InternalCode = txtInternalCode.Text;
                    this.project.Description = rtbDescription.Text;
                    this.project.Start = dtpStart.Value;
                    this.project.End = dtpEnd.Value;
                });

                return this.project;
            }
            set
            {
                this.project = value;
            }
        }

        private async void CreateProject(bool shouldClose = false)
        {
            try
            {
                var result = await BackendServiceProxy.CreateProject(this.Project);

                if (result.Success)
                {
                    this.Project.Id = result.ProjectId;
                    if (shouldClose)
                    {
                        this.Invoke((MethodInvoker)delegate
                        {
                            this.Close();
                        });
                    }
                }
                else
                {
                    this.Invoke((MethodInvoker)delegate
                    {
                        MessageBox.Show(result.Msg);
                    });
                }
            }
            catch (Exception)
            {
                MessageBox.Show("An error occured while creating project");
            }
        }

        private async void UpdateProject(bool shouldClose = false)
        {
            try
            {
                var result = await BackendServiceProxy.UpdateProject(this.Project);

                if (result.Success)
                {
                    if (shouldClose)
                    {
                        this.Invoke((MethodInvoker)delegate
                        {
                            this.Close();
                        });
                    }
                }
                else
                {
                    this.Invoke((MethodInvoker)delegate
                    {
                        MessageBox.Show(result.Msg);
                    });
                }
            }
            catch (Exception)
            {
                MessageBox.Show("An error occured while updating project");
            }
        }

        private void Save(bool shouldClose = false)
        {
            if (this.Project.IsInsering())
            {
                this.CreateProject(shouldClose);
            }
            else
            {
                this.UpdateProject(shouldClose);
            }
        }

        private void btnSaveAndClose_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Save(true);
        }

        private void btnSave_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Save();
        }

        private async void btnDelete_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var res = MessageBox.Show("Sind Sie sicher dass Sie das Projekt löschen wollen?",
                   "Outlook Project Cloud",
                   MessageBoxButtons.YesNo);
            if (res != System.Windows.Forms.DialogResult.Yes)
            {
                return;
            }

            if (this.Project.IsInsering())
            {
                this.Close();
                return;
            }

            try
            {
                var result = await BackendServiceProxy.DeleteProject(this.Project);

                if (result.Success)
                {
                    this.Invoke((MethodInvoker)delegate
                    {
                        this.Close();
                    });
                }
                else
                {
                    this.Invoke((MethodInvoker)delegate
                    {
                        MessageBox.Show(result.Msg);
                    });
                }
            }
            catch (Exception)
            {
                MessageBox.Show("An error occured while deleting project");
            }
        }

        private void ribbonControl1_Click(object sender, EventArgs e)
        {

        }

        private void ProjectItemForm_Load(object sender, EventArgs e)
        {
            cboCategory.SelectedIndex = 0;
            cboProjectManager.SelectedIndex = 0;
        }

        private Outlook.TaskItem task = null;

        private void btnCreateTask_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Outlook.Application app = new Outlook.Application();
            this.task = (Outlook.TaskItem)app.CreateItem(Outlook.OlItemType.olTaskItem);
            this.task.Display();
            this.task.Write += task_Write;
        }

        const int TASK_EXTENSION_FORM_INDEX = 0;

        void task_Write(ref bool Cancel)
        {
            var taskExtensionForm = AddinModule.CurrentInstance.formsManager.Items[TASK_EXTENSION_FORM_INDEX].GetCurrentForm() as TaskExtensionForm;
            string projectId = string.Empty;

            if (taskExtensionForm != null)
            {
                projectId = taskExtensionForm.GetFormData();
            }

            var task = new TaskItem
            {
                Subject = this.task.Subject,
                StartDate = this.task.StartDate,
                DueDate = this.task.DueDate,
                Status = (int)this.task.Status,
                SchedulePlusPriority = this.task.SchedulePlusPriority,
                PercentComplete = this.task.PercentComplete,
                Body = this.task.Body,
                ProjectId = projectId
            };
            this.CreateTaskOnServer(task);
        }

        private async void CreateTaskOnServer(TaskItem task)
        {
            try
            {
                var result = await BackendServiceProxy.CreateTask(task);

                if (result.Success)
                {
                    //this.Project.Id = result.ProjectId;
                    //if (shouldClose)
                    //{
                    //    this.Invoke((MethodInvoker)delegate
                    //    {
                    //        this.Close();
                    //    });
                    //}
                }
                else
                {
                    //this.Invoke((MethodInvoker)delegate
                    //{
                    MessageBox.Show(result.Msg);
                    //});
                }
            }
            catch (Exception)
            {
                MessageBox.Show("An error occured while creating task");
            }
        }

        private void btnGantt_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            ProjectPlanForm form = new ProjectPlanForm();
            form.Show();
        }

        private void btnDocuments_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Process process = new Process();
            process.StartInfo.FileName = "explorer.exe";
            process.Start();
        }
    }
}
