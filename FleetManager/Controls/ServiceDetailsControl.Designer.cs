using Common.Localization;

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
            this.components = new System.ComponentModel.Container();
            this.LABEL_DATE = new System.Windows.Forms.Label();
            this.DP_Date = new System.Windows.Forms.DateTimePicker();
            this.LABEL_NOTES = new System.Windows.Forms.Label();
            this.FIELD_NOTES = new System.Windows.Forms.TextBox();
            this.btAccept = new System.Windows.Forms.Button();
            this.btServiceItems = new System.Windows.Forms.Button();
            this.ttServiceItems = new System.Windows.Forms.ToolTip(this.components);
            this.SuspendLayout();
            // 
            // LABEL_DATE
            // 
            this.LABEL_DATE.AutoSize = true;
            this.LABEL_DATE.Location = new System.Drawing.Point(4, 29);
            this.LABEL_DATE.Name = "LABEL_DATE";
            this.LABEL_DATE.Size = new System.Drawing.Size(30, 13);
            this.LABEL_DATE.TabIndex = 15;
            this.LABEL_DATE.Text = "Date";
            // 
            // DP_Date
            // 
            this.DP_Date.Location = new System.Drawing.Point(40, 29);
            this.DP_Date.Name = "DP_Date";
            this.DP_Date.Size = new System.Drawing.Size(376, 20);
            this.DP_Date.TabIndex = 14;
            // 
            // LABEL_NOTES
            // 
            this.LABEL_NOTES.AutoSize = true;
            this.LABEL_NOTES.Location = new System.Drawing.Point(4, 64);
            this.LABEL_NOTES.Name = "LABEL_NOTES";
            this.LABEL_NOTES.Size = new System.Drawing.Size(35, 13);
            this.LABEL_NOTES.TabIndex = 13;
            this.LABEL_NOTES.Text = "Notes";
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
            this.btAccept.Text = "ACCEPT";
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
            this.Controls.Add(this.LABEL_DATE);
            this.Controls.Add(this.DP_Date);
            this.Controls.Add(this.LABEL_NOTES);
            this.Controls.Add(this.FIELD_NOTES);
            this.Name = "ServiceDetailsControl";
            this.Size = new System.Drawing.Size(423, 351);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.Label LABEL_DATE;
        public System.Windows.Forms.DateTimePicker DP_Date;
        public System.Windows.Forms.Label LABEL_NOTES;
        public System.Windows.Forms.TextBox FIELD_NOTES;
        public System.Windows.Forms.Button btAccept;
        public System.Windows.Forms.Button btServiceItems;
        public System.Windows.Forms.ToolTip ttServiceItems;
    }
}
