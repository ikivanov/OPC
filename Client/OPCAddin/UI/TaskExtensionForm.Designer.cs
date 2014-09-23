namespace OPCAddin.UI
{
    partial class TaskExtensionForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;
  
  
        /// <summary>
        /// Clean uppreparation[n++] = " any resources being used.
        /// </summary>
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (components != null)
                {
                    components.Dispose();
                }
            }
            base.Dispose(disposing);
        }
  
        #region Designer generated code
        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.lblProject = new System.Windows.Forms.Label();
            this.cboProjekt = new System.Windows.Forms.ComboBox();
            this.taskExtensionFormBindingSource = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.taskExtensionFormBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // lblProject
            // 
            this.lblProject.AutoSize = true;
            this.lblProject.Location = new System.Drawing.Point(33, 39);
            this.lblProject.Name = "lblProject";
            this.lblProject.Size = new System.Drawing.Size(65, 13);
            this.lblProject.TabIndex = 0;
            this.lblProject.Text = "OPC Projekt";
            // 
            // cboProjekt
            // 
            this.cboProjekt.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboProjekt.FormattingEnabled = true;
            this.cboProjekt.Location = new System.Drawing.Point(156, 36);
            this.cboProjekt.Name = "cboProjekt";
            this.cboProjekt.Size = new System.Drawing.Size(194, 21);
            this.cboProjekt.TabIndex = 1;
            // 
            // taskExtensionFormBindingSource
            // 
            this.taskExtensionFormBindingSource.DataSource = typeof(OPCAddin.UI.TaskExtensionForm);
            // 
            // TaskExtensionForm
            // 
            this.ClientSize = new System.Drawing.Size(541, 300);
            this.Controls.Add(this.cboProjekt);
            this.Controls.Add(this.lblProject);
            this.Location = new System.Drawing.Point(0, 0);
            this.Name = "TaskExtensionForm";
            this.Text = "Outlook Project Cloud";
            this.Load += new System.EventHandler(this.TaskExtensionForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.taskExtensionFormBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion

        private System.Windows.Forms.Label lblProject;
        private System.Windows.Forms.ComboBox cboProjekt;
        private System.Windows.Forms.BindingSource taskExtensionFormBindingSource;
    }
}
