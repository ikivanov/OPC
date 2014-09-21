namespace OPCAddin.UI
{
    partial class ProjectItemForm
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
            this.barButtonItem1 = new DevExpress.XtraBars.BarButtonItem();
            this.btnSaveAndClose = new DevExpress.XtraBars.BarButtonItem();
            this.btnDelete = new DevExpress.XtraBars.BarButtonItem();
            this.btnGantt = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem5 = new DevExpress.XtraBars.BarButtonItem();
            this.btnDocuments = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem2 = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem3 = new DevExpress.XtraBars.BarButtonItem();
            this.ribbonPage1 = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.ribbonPageGroup1 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPageGroup2 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPageGroup3 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.label10 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.cboCategory = new System.Windows.Forms.ComboBox();
            this.label11 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.label9 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.rtbDescription = new System.Windows.Forms.RichTextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.dtpEnd = new System.Windows.Forms.DateTimePicker();
            this.txtInternalCode = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.dtpStart = new System.Windows.Forms.DateTimePicker();
            this.button1 = new System.Windows.Forms.Button();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.txtProjectName = new System.Windows.Forms.TextBox();
            this.cboProjectManager = new System.Windows.Forms.ComboBox();
            this.lbTeamMembers = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnSave = new DevExpress.XtraBars.BarButtonItem();
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl1)).BeginInit();
            this.SuspendLayout();
            // 
            // ribbonControl1
            // 
            this.ribbonControl1.ExpandCollapseItem.Id = 0;
            this.ribbonControl1.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.ribbonControl1.ExpandCollapseItem,
            this.barButtonItem1,
            this.btnSaveAndClose,
            this.btnDelete,
            this.btnGantt,
            this.barButtonItem5,
            this.btnDocuments,
            this.barButtonItem2,
            this.barButtonItem3,
            this.btnSave});
            this.ribbonControl1.Location = new System.Drawing.Point(0, 0);
            this.ribbonControl1.MaxItemId = 17;
            this.ribbonControl1.Name = "ribbonControl1";
            this.ribbonControl1.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[] {
            this.ribbonPage1});
            this.ribbonControl1.Size = new System.Drawing.Size(778, 142);
            this.ribbonControl1.Click += new System.EventHandler(this.ribbonControl1_Click);
            // 
            // barButtonItem1
            // 
            this.barButtonItem1.Caption = "Speichern && Schließen";
            this.barButtonItem1.CategoryGuid = new System.Guid("6ffddb2b-9015-4d97-a4c1-91613e0ef537");
            this.barButtonItem1.Id = 1;
            this.barButtonItem1.Name = "barButtonItem1";
            // 
            // btnSaveAndClose
            // 
            this.btnSaveAndClose.Caption = "Speichern && Schließen";
            this.btnSaveAndClose.Id = 3;
            this.btnSaveAndClose.Name = "btnSaveAndClose";
            this.btnSaveAndClose.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            this.btnSaveAndClose.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnSaveAndClose_ItemClick);
            // 
            // btnDelete
            // 
            this.btnDelete.Caption = "Löschen";
            this.btnDelete.Id = 4;
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            this.btnDelete.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnDelete_ItemClick);
            // 
            // btnGantt
            // 
            this.btnGantt.Caption = "Ganttdiagramme";
            this.btnGantt.Id = 7;
            this.btnGantt.Name = "btnGantt";
            this.btnGantt.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            // 
            // barButtonItem5
            // 
            this.barButtonItem5.Caption = "Dokumente";
            this.barButtonItem5.CategoryGuid = new System.Guid("6ffddb2b-9015-4d97-a4c1-91613e0ef537");
            this.barButtonItem5.Id = 8;
            this.barButtonItem5.Name = "barButtonItem5";
            // 
            // btnDocuments
            // 
            this.btnDocuments.Caption = "Dokumentverwaltung";
            this.btnDocuments.Id = 9;
            this.btnDocuments.Name = "btnDocuments";
            this.btnDocuments.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            // 
            // barButtonItem2
            // 
            this.barButtonItem2.Caption = "Aufgabe erzeugen";
            this.barButtonItem2.CategoryGuid = new System.Guid("6ffddb2b-9015-4d97-a4c1-91613e0ef537");
            this.barButtonItem2.Id = 14;
            this.barButtonItem2.Name = "barButtonItem2";
            this.barButtonItem2.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            // 
            // barButtonItem3
            // 
            this.barButtonItem3.Caption = "Neues Dokument";
            this.barButtonItem3.CategoryGuid = new System.Guid("6ffddb2b-9015-4d97-a4c1-91613e0ef537");
            this.barButtonItem3.Id = 15;
            this.barButtonItem3.Name = "barButtonItem3";
            this.barButtonItem3.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            // 
            // ribbonPage1
            // 
            this.ribbonPage1.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.ribbonPageGroup1,
            this.ribbonPageGroup2,
            this.ribbonPageGroup3});
            this.ribbonPage1.Name = "ribbonPage1";
            this.ribbonPage1.Text = "Projekt";
            // 
            // ribbonPageGroup1
            // 
            this.ribbonPageGroup1.ItemLinks.Add(this.btnSaveAndClose);
            this.ribbonPageGroup1.ItemLinks.Add(this.btnSave);
            this.ribbonPageGroup1.ItemLinks.Add(this.btnDelete);
            this.ribbonPageGroup1.Name = "ribbonPageGroup1";
            this.ribbonPageGroup1.Text = "Aktionen";
            // 
            // ribbonPageGroup2
            // 
            this.ribbonPageGroup2.ItemLinks.Add(this.barButtonItem2);
            this.ribbonPageGroup2.ItemLinks.Add(this.btnGantt);
            this.ribbonPageGroup2.Name = "ribbonPageGroup2";
            this.ribbonPageGroup2.Text = "Projekt Verwalten";
            // 
            // ribbonPageGroup3
            // 
            this.ribbonPageGroup3.ItemLinks.Add(this.barButtonItem3);
            this.ribbonPageGroup3.ItemLinks.Add(this.btnDocuments);
            this.ribbonPageGroup3.Name = "ribbonPageGroup3";
            this.ribbonPageGroup3.Text = "Dokumente";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(14, 425);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(61, 13);
            this.label10.TabIndex = 48;
            this.label10.Text = "Verbindung";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.ForeColor = System.Drawing.Color.Red;
            this.label12.Location = new System.Drawing.Point(292, 214);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(49, 13);
            this.label12.TabIndex = 47;
            this.label12.Text = "(fake list)";
            // 
            // cboCategory
            // 
            this.cboCategory.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboCategory.FormattingEnabled = true;
            this.cboCategory.Items.AddRange(new object[] {
            "Kategorie 1",
            "Kategorie 2",
            "Kategorie 3"});
            this.cboCategory.Location = new System.Drawing.Point(101, 211);
            this.cboCategory.Name = "cboCategory";
            this.cboCategory.Size = new System.Drawing.Size(185, 21);
            this.cboCategory.TabIndex = 46;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(14, 215);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(52, 13);
            this.label11.TabIndex = 45;
            this.label11.Text = "Kategorie";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(712, 189);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(33, 23);
            this.button2.TabIndex = 44;
            this.button2.Text = "-";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.ForeColor = System.Drawing.Color.Red;
            this.label9.Location = new System.Drawing.Point(663, 158);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(49, 13);
            this.label9.TabIndex = 43;
            this.label9.Text = "(fake list)";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.Color.Red;
            this.label4.Location = new System.Drawing.Point(669, 219);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(49, 13);
            this.label4.TabIndex = 34;
            this.label4.Text = "(fake list)";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(371, 189);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(82, 13);
            this.label8.TabIndex = 42;
            this.label8.Text = "Team Mitglieder";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(371, 159);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(62, 13);
            this.label7.TabIndex = 41;
            this.label7.Text = "Projektleiter";
            // 
            // rtbDescription
            // 
            this.rtbDescription.Location = new System.Drawing.Point(101, 338);
            this.rtbDescription.Name = "rtbDescription";
            this.rtbDescription.Size = new System.Drawing.Size(185, 78);
            this.rtbDescription.TabIndex = 40;
            this.rtbDescription.Text = "";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(13, 305);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(32, 13);
            this.label6.TabIndex = 39;
            this.label6.Text = "Ende";
            // 
            // dtpEnd
            // 
            this.dtpEnd.Location = new System.Drawing.Point(101, 299);
            this.dtpEnd.Name = "dtpEnd";
            this.dtpEnd.Size = new System.Drawing.Size(185, 20);
            this.dtpEnd.TabIndex = 38;
            this.dtpEnd.Value = new System.DateTime(2014, 9, 21, 0, 0, 0, 0);
            // 
            // txtInternalCode
            // 
            this.txtInternalCode.Location = new System.Drawing.Point(101, 182);
            this.txtInternalCode.Name = "txtInternalCode";
            this.txtInternalCode.Size = new System.Drawing.Size(185, 20);
            this.txtInternalCode.TabIndex = 37;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(14, 185);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(71, 13);
            this.label5.TabIndex = 36;
            this.label5.Text = "Interner Code";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 279);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(29, 13);
            this.label3.TabIndex = 35;
            this.label3.Text = "Start";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(14, 338);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(72, 13);
            this.label2.TabIndex = 33;
            this.label2.Text = "Beschreibung";
            // 
            // dtpStart
            // 
            this.dtpStart.Location = new System.Drawing.Point(101, 273);
            this.dtpStart.Name = "dtpStart";
            this.dtpStart.Size = new System.Drawing.Size(185, 20);
            this.dtpStart.TabIndex = 32;
            this.dtpStart.Value = new System.DateTime(2014, 9, 21, 16, 10, 36, 0);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(673, 189);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(33, 23);
            this.button1.TabIndex = 31;
            this.button1.Text = "+";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(101, 425);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(52, 17);
            this.checkBox1.TabIndex = 30;
            this.checkBox1.Text = "Kubis";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // txtProjectName
            // 
            this.txtProjectName.Location = new System.Drawing.Point(101, 156);
            this.txtProjectName.Name = "txtProjectName";
            this.txtProjectName.Size = new System.Drawing.Size(185, 20);
            this.txtProjectName.TabIndex = 29;
            // 
            // cboProjectManager
            // 
            this.cboProjectManager.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboProjectManager.FormattingEnabled = true;
            this.cboProjectManager.Location = new System.Drawing.Point(473, 155);
            this.cboProjectManager.Name = "cboProjectManager";
            this.cboProjectManager.Size = new System.Drawing.Size(185, 21);
            this.cboProjectManager.TabIndex = 28;
            // 
            // lbTeamMembers
            // 
            this.lbTeamMembers.FormattingEnabled = true;
            this.lbTeamMembers.Location = new System.Drawing.Point(473, 189);
            this.lbTeamMembers.Name = "lbTeamMembers";
            this.lbTeamMembers.Size = new System.Drawing.Size(185, 121);
            this.lbTeamMembers.TabIndex = 27;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(14, 159);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(66, 13);
            this.label1.TabIndex = 26;
            this.label1.Text = "Projektname";
            // 
            // btnSave
            // 
            this.btnSave.Caption = "Speichern";
            this.btnSave.CategoryGuid = new System.Guid("6ffddb2b-9015-4d97-a4c1-91613e0ef537");
            this.btnSave.Id = 16;
            this.btnSave.Name = "btnSave";
            this.btnSave.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            this.btnSave.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnSave_ItemClick);
            // 
            // ProjectItemForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(778, 465);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.cboCategory);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.rtbDescription);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.dtpEnd);
            this.Controls.Add(this.txtInternalCode);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dtpStart);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.txtProjectName);
            this.Controls.Add(this.cboProjectManager);
            this.Controls.Add(this.lbTeamMembers);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ribbonControl1);
            this.Name = "ProjectItemForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Projekt";
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraBars.Ribbon.RibbonControl ribbonControl1;
        private DevExpress.XtraBars.BarButtonItem barButtonItem1;
        private DevExpress.XtraBars.BarButtonItem btnSaveAndClose;
        private DevExpress.XtraBars.BarButtonItem btnDelete;
        private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPage1;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup1;
        private DevExpress.XtraBars.BarButtonItem btnGantt;
        private DevExpress.XtraBars.BarButtonItem barButtonItem5;
        private DevExpress.XtraBars.BarButtonItem btnDocuments;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup2;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup3;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.ComboBox cboCategory;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.RichTextBox rtbDescription;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DateTimePicker dtpEnd;
        private System.Windows.Forms.TextBox txtInternalCode;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dtpStart;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.TextBox txtProjectName;
        private System.Windows.Forms.ComboBox cboProjectManager;
        private System.Windows.Forms.ListBox lbTeamMembers;
        private System.Windows.Forms.Label label1;
        private DevExpress.XtraBars.BarButtonItem barButtonItem2;
        private DevExpress.XtraBars.BarButtonItem barButtonItem3;
        private DevExpress.XtraBars.BarButtonItem btnSave;
    }
}