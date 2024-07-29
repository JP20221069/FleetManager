namespace FleetManager.Controls
{
    partial class ServiceDetailsControl
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
            this.label1 = new System.Windows.Forms.Label();
            this.DP_Date = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.FIELD_NOTES = new System.Windows.Forms.TextBox();
            this.btAccept = new System.Windows.Forms.Button();
            this.btServiceItems = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(4, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(30, 13);
            this.label1.TabIndex = 15;
            this.label1.Text = "Date";
            // 
            // DP_Date
            // 
            this.DP_Date.Location = new System.Drawing.Point(40, 29);
            this.DP_Date.Name = "DP_Date";
            this.DP_Date.Size = new System.Drawing.Size(376, 20);
            this.DP_Date.TabIndex = 14;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(4, 64);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(35, 13);
            this.label3.TabIndex = 13;
            this.label3.Text = "Notes";
            // 
            // FIELD_NOTES
            // 
            this.FIELD_NOTES.Location = new System.Drawing.Point(7, 80);
            this.FIELD_NOTES.Multiline = true;
            this.FIELD_NOTES.Name = "FIELD_NOTES";
            this.FIELD_NOTES.Size = new System.Drawing.Size(412, 210);
            this.FIELD_NOTES.TabIndex = 12;
            // 
            // btAccept
            // 
            this.btAccept.Location = new System.Drawing.Point(340, 296);
            this.btAccept.Name = "btAccept";
            this.btAccept.Size = new System.Drawing.Size(76, 44);
            this.btAccept.TabIndex = 16;
            this.btAccept.Text = "CLOSE";
            this.btAccept.UseVisualStyleBackColor = true;
            // 
            // btServiceItems
            // 
            this.btServiceItems.Image = global::FleetManager.Properties.Resources.registration_1;
            this.btServiceItems.Location = new System.Drawing.Point(7, 296);
            this.btServiceItems.Name = "btServiceItems";
            this.btServiceItems.Size = new System.Drawing.Size(34, 29);
            this.btServiceItems.TabIndex = 17;
            this.btServiceItems.UseVisualStyleBackColor = true;
            // 
            // ServiceDetailsControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btServiceItems);
            this.Controls.Add(this.btAccept);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.DP_Date);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.FIELD_NOTES);
            this.Name = "ServiceDetailsControl";
            this.Size = new System.Drawing.Size(423, 351);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.Label label1;
        public System.Windows.Forms.DateTimePicker DP_Date;
        public System.Windows.Forms.Label label3;
        public System.Windows.Forms.TextBox FIELD_NOTES;
        public System.Windows.Forms.Button btAccept;
        public System.Windows.Forms.Button btServiceItems;
    }
}
