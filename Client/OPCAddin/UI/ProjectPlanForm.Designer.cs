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
            this.panel1 = new System.Windows.Forms.Panel();
            this.exg2antt1 = new exontrol.EXG2ANTTLib.exg2antt();
            this.panel2 = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl1)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
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
            this.btnSaveAndClose.Name = "btnSaveAndClose";
            this.btnSaveAndClose.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            this.btnSaveAndClose.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnSaveAndClose_ItemClick);
            // 
            // btnSave
            // 
            this.btnSave.Caption = "Speichern";
            this.btnSave.Id = 2;
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
            // panel1
            // 
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.exg2antt1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 142);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(671, 311);
            this.panel1.TabIndex = 2;
            // 
            // exg2antt1
            // 
            this.exg2antt1.BackColorAlternate = System.Drawing.Color.Black;
            this.exg2antt1.BackColorHeader = System.Drawing.SystemColors.Control;
            this.exg2antt1.BackColorHeader32 = -2147483633;
            this.exg2antt1.BackColorLevelHeader = System.Drawing.SystemColors.Control;
            this.exg2antt1.BackColorLock = System.Drawing.SystemColors.Window;
            this.exg2antt1.BackColorSortBar = System.Drawing.SystemColors.ControlDark;
            this.exg2antt1.BackColorSortBar32 = -2147483632;
            this.exg2antt1.BackColorSortBarCaption = System.Drawing.SystemColors.Control;
            this.exg2antt1.BackColorSortBarCaption32 = -2147483633;
            this.exg2antt1.CauseValidateValue = exontrol.EXG2ANTTLib.ValidateValueType.exNoValidate;
            this.exg2antt1.DataMember = null;
            this.exg2antt1.DataSource = null;
            this.exg2antt1.DefaultItemHeight = 18;
            this.exg2antt1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.exg2antt1.FilterBarBackColor = System.Drawing.SystemColors.Control;
            this.exg2antt1.FilterBarBackColor32 = -2147483633;
            this.exg2antt1.FilterBarForeColor = System.Drawing.SystemColors.WindowText;
            this.exg2antt1.ForeColorHeader = System.Drawing.SystemColors.WindowText;
            this.exg2antt1.ForeColorLock = System.Drawing.SystemColors.WindowText;
            this.exg2antt1.ForeColorSortBar = System.Drawing.SystemColors.ControlDark;
            this.exg2antt1.GridLineColor = System.Drawing.SystemColors.ControlDark;
            this.exg2antt1.HotBackColor = System.Drawing.SystemColors.Window;
            this.exg2antt1.HotBackColor32 = -2147483643;
            this.exg2antt1.HotForeColor = System.Drawing.SystemColors.WindowText;
            this.exg2antt1.HyperLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(101)))), ((int)(((byte)(255)))));
            this.exg2antt1.Location = new System.Drawing.Point(0, 0);
            this.exg2antt1.MarkSearchColumn = false;
            this.exg2antt1.Name = "exg2antt1";
            this.exg2antt1.PictureLevelHeader = null;
            this.exg2antt1.SelBackColor = System.Drawing.SystemColors.Highlight;
            this.exg2antt1.SelBackColor32 = -2147483635;
            this.exg2antt1.SelForeColor = System.Drawing.SystemColors.HighlightText;
            this.exg2antt1.SingleSort = false;
            this.exg2antt1.Size = new System.Drawing.Size(671, 311);
            this.exg2antt1.TabIndex = 1;
            this.exg2antt1.TooltipCellsColor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(101)))), ((int)(((byte)(255)))));
            this.exg2antt1.HistogramBoundsChanged += new exontrol.EXG2ANTTLib.exg2antt.HistogramBoundsChangedEventHandler(this.exg2antt1_HistogramBoundsChanged);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.button1);
            this.panel2.Controls.Add(this.radioButton2);
            this.panel2.Controls.Add(this.radioButton1);
            this.panel2.Location = new System.Drawing.Point(250, 136);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(171, 39);
            this.panel2.TabIndex = 3;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(79, 8);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(54, 23);
            this.button1.TabIndex = 2;
            this.button1.Text = "Color";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.Location = new System.Drawing.Point(5, 19);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(68, 17);
            this.radioButton2.TabIndex = 1;
            this.radioButton2.TabStop = true;
            this.radioButton2.Text = "Overload";
            this.radioButton2.UseVisualStyleBackColor = true;
            this.radioButton2.CheckedChanged += new System.EventHandler(this.radioButton2_CheckedChanged);
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Location = new System.Drawing.Point(5, 3);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(71, 17);
            this.radioButton1.TabIndex = 0;
            this.radioButton1.TabStop = true;
            this.radioButton1.Text = "Allocation";
            this.radioButton1.UseVisualStyleBackColor = true;
            // 
            // GanttDiagramForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(671, 453);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.ribbonControl1);
            this.Name = "GanttDiagramForm";
            this.Text = "GanttDiagram";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.GanttDiagramForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraBars.Ribbon.RibbonControl ribbonControl1;
        private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPage1;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup1;
        private System.Windows.Forms.Panel panel1;
        private exontrol.EXG2ANTTLib.exg2antt exg2antt1;
        private DevExpress.XtraBars.BarButtonItem btnSaveAndClose;
        private DevExpress.XtraBars.BarButtonItem btnSave;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.RadioButton radioButton2;
        private System.Windows.Forms.RadioButton radioButton1;

    }
}