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
            this.btnCallService = new AddinExpress.MSO.ADXRibbonButton(this.components);
            // 
            // opcRibbonTab
            // 
            this.opcRibbonTab.Caption = "OPC";
            this.opcRibbonTab.Controls.Add(this.adxRibbonGroup1);
            this.opcRibbonTab.Id = "adxRibbonTab_c02fca88250b44da9f36b9f16705c503";
            this.opcRibbonTab.Ribbons = ((AddinExpress.MSO.ADXRibbons)((AddinExpress.MSO.ADXRibbons.msrOutlookTask | AddinExpress.MSO.ADXRibbons.msrOutlookExplorer)));
            // 
            // adxRibbonGroup1
            // 
            this.adxRibbonGroup1.Caption = "adxRibbonGroup1";
            this.adxRibbonGroup1.Controls.Add(this.btnCallService);
            this.adxRibbonGroup1.Id = "adxRibbonGroup_95f1f164a1ca42d8b76f69e909d9ac61";
            this.adxRibbonGroup1.ImageTransparentColor = System.Drawing.Color.Transparent;
            this.adxRibbonGroup1.Ribbons = ((AddinExpress.MSO.ADXRibbons)((AddinExpress.MSO.ADXRibbons.msrOutlookTask | AddinExpress.MSO.ADXRibbons.msrOutlookExplorer)));
            // 
            // btnCallService
            // 
            this.btnCallService.Caption = "Call Service";
            this.btnCallService.Id = "adxRibbonButton_8b37be3448a14ba59dd3d8ceb5fd2bff";
            this.btnCallService.ImageTransparentColor = System.Drawing.Color.Transparent;
            this.btnCallService.Ribbons = ((AddinExpress.MSO.ADXRibbons)((AddinExpress.MSO.ADXRibbons.msrOutlookTask | AddinExpress.MSO.ADXRibbons.msrOutlookExplorer)));
            this.btnCallService.Size = AddinExpress.MSO.ADXRibbonXControlSize.Large;
            this.btnCallService.OnClick += new AddinExpress.MSO.ADXRibbonOnAction_EventHandler(this.btnCallService_OnClick);
            // 
            // AddinModule
            // 
            this.AddinName = "OPCAddin";
            this.SupportedApps = AddinExpress.MSO.ADXOfficeHostApp.ohaOutlook;

        }
        #endregion

        private AddinExpress.MSO.ADXRibbonTab opcRibbonTab;
        private AddinExpress.MSO.ADXRibbonGroup adxRibbonGroup1;
        private AddinExpress.MSO.ADXRibbonButton btnCallService;
    }
}

