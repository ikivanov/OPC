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
            // 
            // opcRibbonTab
            // 
            this.opcRibbonTab.Caption = "OPC";
            this.opcRibbonTab.Id = "adxRibbonTab_c02fca88250b44da9f36b9f16705c503";
            this.opcRibbonTab.Ribbons = ((AddinExpress.MSO.ADXRibbons)((AddinExpress.MSO.ADXRibbons.msrOutlookTask | AddinExpress.MSO.ADXRibbons.msrOutlookExplorer)));
            // 
            // AddinModule
            // 
            this.AddinName = "OPCAddin";
            this.SupportedApps = AddinExpress.MSO.ADXOfficeHostApp.ohaOutlook;

        }
        #endregion

        private AddinExpress.MSO.ADXRibbonTab opcRibbonTab;
    }
}

