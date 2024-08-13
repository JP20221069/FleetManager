namespace FleetManager.Controls
{
    partial class AddServiceItemControl
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.LABEL_SERVICE = new System.Windows.Forms.Label();
            this.CB_SERVICE = new System.Windows.Forms.ComboBox();
            this.btAdd = new System.Windows.Forms.Button();
            this.LABEL_DESCRIPTION = new System.Windows.Forms.Label();
            this.LABEL_NAME = new System.Windows.Forms.Label();
            this.FIELD_DESCRIPTION = new System.Windows.Forms.TextBox();
            this.FIELD_NAME = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // LABEL_SERVICE
            // 
            this.LABEL_SERVICE.AutoSize = true;
            this.LABEL_SERVICE.Location = new System.Drawing.Point(20, 30);
            this.LABEL_SERVICE.Name = "LABEL_SERVICE";
            this.LABEL_SERVICE.Size = new System.Drawing.Size(43, 13);
            this.LABEL_SERVICE.TabIndex = 16;
            this.LABEL_SERVICE.Text = "Service";
            // 
            // CB_SERVICE
            // 
            this.CB_SERVICE.FormattingEnabled = true;
            this.CB_SERVICE.Location = new System.Drawing.Point(69, 27);
            this.CB_SERVICE.Name = "CB_SERVICE";
            this.CB_SERVICE.Size = new System.Drawing.Size(256, 21);
            this.CB_SERVICE.TabIndex = 15;
            // 
            // btAdd
            // 
            this.btAdd.Location = new System.Drawing.Point(331, 26);
            this.btAdd.Name = "btAdd";
            this.btAdd.Size = new System.Drawing.Size(75, 23);
            this.btAdd.TabIndex = 14;
            this.btAdd.Text = "ADD";
            this.btAdd.UseVisualStyleBackColor = true;
            this.btAdd.Click += new System.EventHandler(this.button1_Click);
            // 
            // LABEL_DESCRIPTION
            // 
            this.LABEL_DESCRIPTION.AutoSize = true;
            this.LABEL_DESCRIPTION.Location = new System.Drawing.Point(3, 58);
            this.LABEL_DESCRIPTION.Name = "LABEL_DESCRIPTION";
            this.LABEL_DESCRIPTION.Size = new System.Drawing.Size(60, 13);
            this.LABEL_DESCRIPTION.TabIndex = 13;
            this.LABEL_DESCRIPTION.Text = "Description";
            // 
            // LABEL_NAME
            // 
            this.LABEL_NAME.AutoSize = true;
            this.LABEL_NAME.Location = new System.Drawing.Point(28, 6);
            this.LABEL_NAME.Name = "LABEL_NAME";
            this.LABEL_NAME.Size = new System.Drawing.Size(35, 13);
            this.LABEL_NAME.TabIndex = 12;
            this.LABEL_NAME.Text = "Name";
            // 
            // FIELD_DESCRIPTION
            // 
            this.FIELD_DESCRIPTION.Location = new System.Drawing.Point(69, 55);
            this.FIELD_DESCRIPTION.Multiline = true;
            this.FIELD_DESCRIPTION.Name = "FIELD_DESCRIPTION";
            this.FIELD_DESCRIPTION.Size = new System.Drawing.Size(350, 77);
            this.FIELD_DESCRIPTION.TabIndex = 11;
            // 
            // FIELD_NAME
            // 
            this.FIELD_NAME.Location = new System.Drawing.Point(69, 3);
            this.FIELD_NAME.Name = "FIELD_NAME";
            this.FIELD_NAME.Size = new System.Drawing.Size(256, 20);
            this.FIELD_NAME.TabIndex = 10;
            // 
            // AddServiceItemControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.LABEL_SERVICE);
            this.Controls.Add(this.CB_SERVICE);
            this.Controls.Add(this.btAdd);
            this.Controls.Add(this.LABEL_DESCRIPTION);
            this.Controls.Add(this.LABEL_NAME);
            this.Controls.Add(this.FIELD_DESCRIPTION);
            this.Controls.Add(this.FIELD_NAME);
            this.Name = "AddServiceItemControl";
            this.Size = new System.Drawing.Size(434, 154);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        public System.Windows.Forms.ComboBox CB_SERVICE;
        public System.Windows.Forms.Button btAdd;
        public System.Windows.Forms.TextBox FIELD_DESCRIPTION;
        public System.Windows.Forms.TextBox FIELD_NAME;
        public System.Windows.Forms.Label LABEL_SERVICE;
        public System.Windows.Forms.Label LABEL_DESCRIPTION;
        public System.Windows.Forms.Label LABEL_NAME;
    }
}
