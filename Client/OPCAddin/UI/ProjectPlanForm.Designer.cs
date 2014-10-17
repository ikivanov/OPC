namespace OPCAddin.UI
{
    partial class ProjectPlanForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.ribbonControl1 = new DevExpress.XtraBars.Ribbon.RibbonControl();
            this.btnSaveAndClose = new DevExpress.XtraBars.BarButtonItem();
            this.btnSave = new DevExpress.XtraBars.BarButtonItem();
            this.ribbonPage1 = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.ribbonPageGroup1 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl1)).BeginInit();
            this.SuspendLayout();
            // 
            // ribbonControl1
            // 
            this.ribbonControl1.ExpandCollapseItem.Id = 0;
            this.ribbonControl1.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.ribbonControl1.ExpandCollapseItem,
            this.btnSaveAndClose,
            this.btnSave});
            this.ribbonControl1.Location = new System.Drawing.Point(0, 0);
            this.ribbonControl1.MaxItemId = 3;
            this.ribbonControl1.Name = "ribbonControl1";
            this.ribbonControl1.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[] {
            this.ribbonPage1});
            this.ribbonControl1.Size = new System.Drawing.Size(671, 142);
            // 
            // btnSaveAndClose
            // 
            this.btnSaveAndClose.Caption = "Speichern && Schließen";
            this.btnSaveAndClose.Id = 1;
            this.btnSaveAndClose.LargeGlyph = global::OPCAddin.Properties.Resources.SaveAndClose;
            this.btnSaveAndClose.Name = "btnSaveAndClose";
            this.btnSaveAndClose.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            this.btnSaveAndClose.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnSaveAndClose_ItemClick);
            // 
            // btnSave
            // 
            this.btnSave.Caption = "Speichern";
            this.btnSave.Id = 2;
            this.btnSave.LargeGlyph = global::OPCAddin.Properties.Resources.Save;
            this.btnSave.Name = "btnSave";
            this.btnSave.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            this.btnSave.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnSave_ItemClick);
            // 
            // ribbonPage1
            // 
            this.ribbonPage1.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.ribbonPageGroup1});
            this.ribbonPage1.Name = "ribbonPage1";
            this.ribbonPage1.Text = "Projekt";
            // 
            // ribbonPageGroup1
            // 
            this.ribbonPageGroup1.ItemLinks.Add(this.btnSaveAndClose);
            this.ribbonPageGroup1.ItemLinks.Add(this.btnSave);
            this.ribbonPageGroup1.Name = "ribbonPageGroup1";
            this.ribbonPageGroup1.Text = "Aktionen";
            // 
            // ProjectPlanForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(671, 453);
            this.Controls.Add(this.ribbonControl1);
            this.Name = "ProjectPlanForm";
            this.Text = "GanttDiagram";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.GanttDiagramForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraBars.Ribbon.RibbonControl ribbonControl1;
        private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPage1;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup1;
        private DevExpress.XtraBars.BarButtonItem btnSaveAndClose;
        private DevExpress.XtraBars.BarButtonItem btnSave;

    }
}