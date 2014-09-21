namespace OPCAddin
{
    partial class AddinModule
    {
        /// <summary>
        /// Required by designer
        /// </summary>
        private System.ComponentModel.IContainer components;
 
        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code
        /// <summary>
        /// Required by designer support - do not modify
        /// the following method
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.opcRibbonTab = new AddinExpress.MSO.ADXRibbonTab(this.components);
            this.adxRibbonGroup1 = new AddinExpress.MSO.ADXRibbonGroup(this.components);
            this.btnLogin = new AddinExpress.MSO.ADXRibbonButton(this.components);
            this.adxRibbonGroup2 = new AddinExpress.MSO.ADXRibbonGroup(this.components);
            this.btnNewTask = new AddinExpress.MSO.ADXRibbonButton(this.components);
            this.btnNewProject = new AddinExpress.MSO.ADXRibbonButton(this.components);
            this.formsManager = new AddinExpress.OL.ADXOlFormsManager(this.components);
            this.adxOlFormsCollectionItem1 = new AddinExpress.OL.ADXOlFormsCollectionItem(this.components);
            this.adxContextMenu1 = new AddinExpress.MSO.ADXContextMenu(this.components);
            this.adxCommandBarButton1 = new AddinExpress.MSO.ADXCommandBarButton(this.components);
            this.adxRibbonButton1 = new AddinExpress.MSO.ADXRibbonButton(this.components);
            this.btnNewContact = new AddinExpress.MSO.ADXRibbonButton(this.components);
            // 
            // opcRibbonTab
            // 
            this.opcRibbonTab.Caption = "OPC";
            this.opcRibbonTab.Controls.Add(this.adxRibbonGroup1);
            this.opcRibbonTab.Controls.Add(this.adxRibbonGroup2);
            this.opcRibbonTab.Id = "adxRibbonTab_c02fca88250b44da9f36b9f16705c503";
            this.opcRibbonTab.Ribbons = ((AddinExpress.MSO.ADXRibbons)((AddinExpress.MSO.ADXRibbons.msrOutlookTask | AddinExpress.MSO.ADXRibbons.msrOutlookExplorer)));
            // 
            // adxRibbonGroup1
            // 
            this.adxRibbonGroup1.Caption = "General";
            this.adxRibbonGroup1.Controls.Add(this.btnLogin);
            this.adxRibbonGroup1.Id = "adxRibbonGroup_95f1f164a1ca42d8b76f69e909d9ac61";
            this.adxRibbonGroup1.ImageTransparentColor = System.Drawing.Color.Transparent;
            this.adxRibbonGroup1.Ribbons = ((AddinExpress.MSO.ADXRibbons)((AddinExpress.MSO.ADXRibbons.msrOutlookTask | AddinExpress.MSO.ADXRibbons.msrOutlookExplorer)));
            // 
            // btnLogin
            // 
            this.btnLogin.Caption = "Login";
            this.btnLogin.Id = "adxRibbonButton_8b37be3448a14ba59dd3d8ceb5fd2bff";
            this.btnLogin.ImageTransparentColor = System.Drawing.Color.Transparent;
            this.btnLogin.Ribbons = ((AddinExpress.MSO.ADXRibbons)((AddinExpress.MSO.ADXRibbons.msrOutlookTask | AddinExpress.MSO.ADXRibbons.msrOutlookExplorer)));
            this.btnLogin.Size = AddinExpress.MSO.ADXRibbonXControlSize.Large;
            this.btnLogin.OnClick += new AddinExpress.MSO.ADXRibbonOnAction_EventHandler(this.btnLogin_OnClick);
            // 
            // adxRibbonGroup2
            // 
            this.adxRibbonGroup2.Caption = "Actions";
            this.adxRibbonGroup2.Controls.Add(this.btnNewProject);
            this.adxRibbonGroup2.Controls.Add(this.btnNewTask);
            this.adxRibbonGroup2.Controls.Add(this.btnNewContact);
            this.adxRibbonGroup2.Id = "adxRibbonGroup_7744f30276104f07b33b9a5d9db4c94e";
            this.adxRibbonGroup2.ImageTransparentColor = System.Drawing.Color.Transparent;
            this.adxRibbonGroup2.Ribbons = ((AddinExpress.MSO.ADXRibbons)((AddinExpress.MSO.ADXRibbons.msrOutlookTask | AddinExpress.MSO.ADXRibbons.msrOutlookExplorer)));
            // 
            // btnNewTask
            // 
            this.btnNewTask.Caption = "New Task";
            this.btnNewTask.Id = "adxRibbonButton_a5993cf3eb924d788b15d71b20d6d5cb";
            this.btnNewTask.ImageTransparentColor = System.Drawing.Color.Transparent;
            this.btnNewTask.Ribbons = ((AddinExpress.MSO.ADXRibbons)((AddinExpress.MSO.ADXRibbons.msrOutlookTask | AddinExpress.MSO.ADXRibbons.msrOutlookExplorer)));
            this.btnNewTask.Size = AddinExpress.MSO.ADXRibbonXControlSize.Large;
            this.btnNewTask.OnClick += new AddinExpress.MSO.ADXRibbonOnAction_EventHandler(this.btnNewTask_OnClick);
            // 
            // btnNewProject
            // 
            this.btnNewProject.Caption = "New Project";
            this.btnNewProject.Id = "adxRibbonButton_cc91ed65db3840ab838b6faceeb5b38c";
            this.btnNewProject.ImageTransparentColor = System.Drawing.Color.Transparent;
            this.btnNewProject.Ribbons = ((AddinExpress.MSO.ADXRibbons)((AddinExpress.MSO.ADXRibbons.msrOutlookTask | AddinExpress.MSO.ADXRibbons.msrOutlookExplorer)));
            this.btnNewProject.Size = AddinExpress.MSO.ADXRibbonXControlSize.Large;
            this.btnNewProject.OnClick += new AddinExpress.MSO.ADXRibbonOnAction_EventHandler(this.btnNewProject_OnClick);
            // 
            // formsManager
            // 
            this.formsManager.Items.Add(this.adxOlFormsCollectionItem1);
            this.formsManager.SetOwner(this);
            // 
            // adxOlFormsCollectionItem1
            // 
            this.adxOlFormsCollectionItem1.AlwaysShowHeader = true;
            this.adxOlFormsCollectionItem1.FormClassName = "OPCAddin.UI.TaskExtensionForm";
            this.adxOlFormsCollectionItem1.InspectorItemTypes = AddinExpress.OL.ADXOlInspectorItemTypes.olTask;
            this.adxOlFormsCollectionItem1.InspectorLayout = AddinExpress.OL.ADXOlInspectorLayout.BottomSubpane;
            this.adxOlFormsCollectionItem1.UseOfficeThemeForBackground = true;
            // 
            // adxContextMenu1
            // 
            this.adxContextMenu1.CommandBarName = "Context Menu";
            this.adxContextMenu1.CommandBarTag = "eb5a3e97-7958-4ae9-bf94-a784792ae285";
            this.adxContextMenu1.Controls.Add(this.adxCommandBarButton1);
            this.adxContextMenu1.SupportedApp = AddinExpress.MSO.ADXOfficeHostApp.ohaOutlook;
            this.adxContextMenu1.SupportedApps = AddinExpress.MSO.ADXOfficeHostApp.ohaOutlook;
            this.adxContextMenu1.Temporary = true;
            this.adxContextMenu1.UpdateCounter = 5;
            // 
            // adxCommandBarButton1
            // 
            this.adxCommandBarButton1.BeforeID = 1100;
            this.adxCommandBarButton1.Caption = "Zu OPC Projekt hinzufügen";
            this.adxCommandBarButton1.ControlTag = "59840f91-d840-44a2-bdbc-3c4796eccd85";
            this.adxCommandBarButton1.ImageTransparentColor = System.Drawing.Color.Transparent;
            this.adxCommandBarButton1.OlExplorerItemTypes = ((AddinExpress.MSO.ADXOlExplorerItemTypes)((AddinExpress.MSO.ADXOlExplorerItemTypes.olMailItem | AddinExpress.MSO.ADXOlExplorerItemTypes.olTaskItem)));
            this.adxCommandBarButton1.OlInspectorItemTypes = ((AddinExpress.MSO.ADXOlInspectorItemTypes)((AddinExpress.MSO.ADXOlInspectorItemTypes.olMail | AddinExpress.MSO.ADXOlInspectorItemTypes.olTask)));
            this.adxCommandBarButton1.Temporary = true;
            this.adxCommandBarButton1.UpdateCounter = 4;
            // 
            // adxRibbonButton1
            // 
            this.adxRibbonButton1.Caption = "adxRibbonButton1";
            this.adxRibbonButton1.Id = "adxRibbonButton_9c2b92641787420d8912546c2d855343";
            this.adxRibbonButton1.ImageTransparentColor = System.Drawing.Color.Transparent;
            this.adxRibbonButton1.Ribbons = ((AddinExpress.MSO.ADXRibbons)((AddinExpress.MSO.ADXRibbons.msrOutlookTask | AddinExpress.MSO.ADXRibbons.msrOutlookExplorer)));
            // 
            // btnNewContact
            // 
            this.btnNewContact.Caption = "New Contact";
            this.btnNewContact.Id = "adxRibbonButton_c4ed7dc3b73f4558ab38b81b41dfb195";
            this.btnNewContact.ImageTransparentColor = System.Drawing.Color.Transparent;
            this.btnNewContact.Ribbons = ((AddinExpress.MSO.ADXRibbons)((AddinExpress.MSO.ADXRibbons.msrOutlookTask | AddinExpress.MSO.ADXRibbons.msrOutlookExplorer)));
            this.btnNewContact.Size = AddinExpress.MSO.ADXRibbonXControlSize.Large;
            this.btnNewContact.OnClick += new AddinExpress.MSO.ADXRibbonOnAction_EventHandler(this.btnNewContact_OnClick);
            // 
            // AddinModule
            // 
            this.AddinName = "OPCAddin";
            this.SupportedApps = AddinExpress.MSO.ADXOfficeHostApp.ohaOutlook;

        }
        #endregion

        private AddinExpress.MSO.ADXRibbonTab opcRibbonTab;
        private AddinExpress.MSO.ADXRibbonGroup adxRibbonGroup1;
        private AddinExpress.MSO.ADXRibbonButton btnLogin;
        private AddinExpress.MSO.ADXRibbonButton btnNewProject;
        private AddinExpress.MSO.ADXRibbonButton btnNewTask;
        private AddinExpress.OL.ADXOlFormsManager formsManager;
        private AddinExpress.OL.ADXOlFormsCollectionItem adxOlFormsCollectionItem1;
        private AddinExpress.MSO.ADXContextMenu adxContextMenu1;
        private AddinExpress.MSO.ADXCommandBarButton adxCommandBarButton1;
        private AddinExpress.MSO.ADXRibbonGroup adxRibbonGroup2;
        private AddinExpress.MSO.ADXRibbonButton adxRibbonButton1;
        private AddinExpress.MSO.ADXRibbonButton btnNewContact;
    }
}

