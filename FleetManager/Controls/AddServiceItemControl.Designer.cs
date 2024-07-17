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
            this.label4 = new System.Windows.Forms.Label();
            this.CB_SERVICE = new System.Windows.Forms.ComboBox();
            this.btAdd = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.FIELD_DESCRIPTION = new System.Windows.Forms.TextBox();
            this.FIELD_NAME = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(20, 30);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(43, 13);
            this.label4.TabIndex = 16;
            this.label4.Text = "Service";
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
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 58);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(60, 13);
            this.label2.TabIndex = 13;
            this.label2.Text = "Description";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(28, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 12;
            this.label1.Text = "Name";
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
            this.Controls.Add(this.label4);
            this.Controls.Add(this.CB_SERVICE);
            this.Controls.Add(this.btAdd);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.FIELD_DESCRIPTION);
            this.Controls.Add(this.FIELD_NAME);
            this.Name = "AddServiceItemControl";
            this.Size = new System.Drawing.Size(434, 154);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        public System.Windows.Forms.ComboBox CB_SERVICE;
        public System.Windows.Forms.Button btAdd;
        public System.Windows.Forms.TextBox FIELD_DESCRIPTION;
        public System.Windows.Forms.TextBox FIELD_NAME;
    }
}
