using Common.Localization;

namespace FleetManager.Controls
{
    partial class CheckInControl
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
            this.btAccept = new System.Windows.Forms.Button();
            this.FIELD_FINISH = new System.Windows.Forms.TextBox();
            this.LABEL_FINISH = new System.Windows.Forms.Label();
            this.FIELD_START = new System.Windows.Forms.TextBox();
            this.LABEL_START = new System.Windows.Forms.Label();
            this.LABEL_NOTES = new System.Windows.Forms.Label();
            this.FIELD_NOTES = new System.Windows.Forms.TextBox();
            this.chkActive = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // btAccept
            // 
            this.btAccept.Location = new System.Drawing.Point(324, 264);
            this.btAccept.Name = "btAccept";
            this.btAccept.Size = new System.Drawing.Size(76, 44);
            this.btAccept.TabIndex = 25;
            this.btAccept.Text = "ACCEPT";
            this.btAccept.UseVisualStyleBackColor = true;
            this.btAccept.Click += new System.EventHandler(this.btAccept_Click);
            // 
            // FIELD_FINISH
            // 
            this.FIELD_FINISH.Location = new System.Drawing.Point(161, 83);
            this.FIELD_FINISH.Name = "FIELD_FINISH";
            this.FIELD_FINISH.Size = new System.Drawing.Size(239, 20);
            this.FIELD_FINISH.TabIndex = 16;
            // 
            // LABEL_FINISH
            // 
            this.LABEL_FINISH.AutoSize = true;
            this.LABEL_FINISH.Location = new System.Drawing.Point(88, 86);
            this.LABEL_FINISH.Name = "LABEL_FINISH";
            this.LABEL_FINISH.Size = new System.Drawing.Size(34, 13);
            this.LABEL_FINISH.TabIndex = 15;
            this.LABEL_FINISH.Text = "Finish";
            // 
            // FIELD_START
            // 
            this.FIELD_START.Location = new System.Drawing.Point(161, 48);
            this.FIELD_START.Name = "FIELD_START";
            this.FIELD_START.Size = new System.Drawing.Size(239, 20);
            this.FIELD_START.TabIndex = 14;
            // 
            // LABEL_START
            // 
            this.LABEL_START.AutoSize = true;
            this.LABEL_START.Location = new System.Drawing.Point(88, 51);
            this.LABEL_START.Name = "LABEL_START";
            this.LABEL_START.Size = new System.Drawing.Size(29, 13);
            this.LABEL_START.TabIndex = 13;
            this.LABEL_START.Text = "Start";
            // 
            // LABEL_NOTES
            // 
            this.LABEL_NOTES.AutoSize = true;
            this.LABEL_NOTES.Location = new System.Drawing.Point(88, 119);
            this.LABEL_NOTES.Name = "LABEL_NOTES";
            this.LABEL_NOTES.Size = new System.Drawing.Size(35, 13);
            this.LABEL_NOTES.TabIndex = 26;
            this.LABEL_NOTES.Text = "Notes";
            // 
            // FIELD_NOTES
            // 
            this.FIELD_NOTES.Location = new System.Drawing.Point(91, 139);
            this.FIELD_NOTES.Multiline = true;
            this.FIELD_NOTES.Name = "FIELD_NOTES";
            this.FIELD_NOTES.Size = new System.Drawing.Size(309, 119);
            this.FIELD_NOTES.TabIndex = 27;
            // 
            // chkActive
            // 
            this.chkActive.AutoSize = true;
            this.chkActive.Enabled = false;
            this.chkActive.Location = new System.Drawing.Point(91, 274);
            this.chkActive.Name = "chkActive";
            this.chkActive.Size = new System.Drawing.Size(56, 17);
            this.chkActive.TabIndex = 28;
            this.chkActive.Text = "Active";
            this.chkActive.UseVisualStyleBackColor = true;
            this.chkActive.Visible = false;
            // 
            // CheckInControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.chkActive);
            this.Controls.Add(this.FIELD_NOTES);
            this.Controls.Add(this.LABEL_NOTES);
            this.Controls.Add(this.btAccept);
            this.Controls.Add(this.FIELD_FINISH);
            this.Controls.Add(this.LABEL_FINISH);
            this.Controls.Add(this.FIELD_START);
            this.Controls.Add(this.LABEL_START);
            this.Name = "CheckInControl";
            this.Size = new System.Drawing.Size(476, 364);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.Button btAccept;
        public System.Windows.Forms.TextBox FIELD_FINISH;
        public System.Windows.Forms.TextBox FIELD_START;
        public System.Windows.Forms.TextBox FIELD_NOTES;
        public System.Windows.Forms.CheckBox chkActive;
        public System.Windows.Forms.Label LABEL_FINISH;
        public System.Windows.Forms.Label LABEL_START;
        public System.Windows.Forms.Label LABEL_NOTES;
    }
}
