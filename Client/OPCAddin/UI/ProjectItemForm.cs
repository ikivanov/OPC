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
                var userToken = AddinModule.CurrentInstance.UserToken;
                var result = await BackendServiceProxy.CreateProject(userToken, this.Project);

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
                var userToken = AddinModule.CurrentInstance.UserToken;
                var result = await BackendServiceProxy.UpdateProject(userToken, this.Project);

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
                var userToken = AddinModule.CurrentInstance.UserToken;
                var result = await BackendServiceProxy.DeleteProject(userToken, this.Project);

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
    }
}
