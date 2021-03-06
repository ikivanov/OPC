﻿using System;
using System.Runtime.InteropServices;
using System.ComponentModel;
using System.Windows.Forms;
using AddinExpress.MSO;
using Outlook = Microsoft.Office.Interop.Outlook;
using System.Threading.Tasks;
using OPCAddin.UI;

namespace OPCAddin
{
    /// <summary>
    ///   Add-in Express Add-in Module
    /// </summary>
    [GuidAttribute("F78BEB2B-8FEE-44CE-B1E6-17CB0252650B"), ProgId("OPCAddin.AddinModule")]
    public partial class AddinModule : AddinExpress.MSO.ADXAddinModule
    {
        public AddinModule()
        {
            Application.EnableVisualStyles();
            InitializeComponent();
            // Please add any initialization code to the AddinInitialize event handler

            this.AddinInitialize += AddinModule_AddinInitialize;
        }

        void AddinModule_AddinInitialize(object sender, EventArgs e)
        {
            LoginService.GetInstance().LogedIn += this.OnLoggedIn;
        }

        private void OnLoggedIn(object sender, EventArgs e)
        {
            this.EnableUI();
        }

        private void EnableUI(bool enable = true)
        {
            this.btnDashboard.Enabled = enable;
            this.btnNewProject.Enabled = enable;
            this.btnNewTask.Enabled = enable;
            this.btnNewContact.Enabled = enable;
            this.btnProjectPlan.Enabled = enable;
        }

        #region Add-in Express automatic code
 
        // Required by Add-in Express - do not modify
        // the methods within this region
 
        public override System.ComponentModel.IContainer GetContainer()
        {
            if (components == null)
                components = new System.ComponentModel.Container();
            return components;
        }
 
        [ComRegisterFunctionAttribute]
        public static void AddinRegister(Type t)
        {
            AddinExpress.MSO.ADXAddinModule.ADXRegister(t);
        }
 
        [ComUnregisterFunctionAttribute]
        public static void AddinUnregister(Type t)
        {
            AddinExpress.MSO.ADXAddinModule.ADXUnregister(t);
        }
 
        public override void UninstallControls()
        {
            base.UninstallControls();
        }

        #endregion

        public static new AddinModule CurrentInstance 
        {
            get
            {
                return AddinExpress.MSO.ADXAddinModule.CurrentInstance as AddinModule;
            }
        }

        public Outlook._Application OutlookApp
        {
            get
            {
                return (HostApplication as Outlook._Application);
            }
        }

        private void btnLogin_OnClick(object sender, IRibbonControl control, bool pressed)
        {
            LoginForm form = new LoginForm();
            form.ShowDialog();
        }

        private void btnNewProject_OnClick(object sender, IRibbonControl control, bool pressed)
        {
            ProjectItemForm form = new ProjectItemForm();
            form.Show();
        }

        private Outlook.TaskItem task = null;
        private void btnNewTask_OnClick(object sender, IRibbonControl control, bool pressed)
        {
            Outlook.Application app = new Outlook.Application();
            this.task = (Outlook.TaskItem) app.CreateItem(Outlook.OlItemType.olTaskItem);
            this.task.Display();
            this.task.Write += task_Write;
        }

        const int TASK_EXTENSION_FORM_INDEX = 0;

        void task_Write(ref bool Cancel)
        {
            var  taskExtensionForm = this.formsManager.Items[TASK_EXTENSION_FORM_INDEX].GetCurrentForm() as TaskExtensionForm;
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

        private void btnNewContact_OnClick(object sender, IRibbonControl control, bool pressed)
        {
            Outlook.Application app = new Outlook.Application();
            Outlook.ContactItem contact = (Outlook.ContactItem)app.CreateItem(Outlook.OlItemType.olContactItem);
            contact.Display();
        }

        public AddinExpress.MSO.ADXOutlookAppEvents Events
        {
            get
            {
                return this.adxOutlookEvents;
            }
        }

        string serviceUrl = string.Empty;
        public string ServiceUrl
        {
            get
            {
                if (string.IsNullOrEmpty(this.serviceUrl))
                {
                    this.serviceUrl = OPCAddinSettings.Default.ServiceUrl;
                    if (string.IsNullOrEmpty(this.serviceUrl))
                    {
                        this.serviceUrl = "http://localhost:3000";
                    }
                }

                return this.serviceUrl;
            }
        }

        private void btnDashboard_OnClick(object sender, IRibbonControl control, bool pressed)
        {
            DashboardForm form = new DashboardForm();
            form.Show();
        }

        private void btnProjectPlan_OnClick(object sender, IRibbonControl control, bool pressed)
        {
            ProjectPlanForm form = new ProjectPlanForm();
            form.Show();
        }
    }
}