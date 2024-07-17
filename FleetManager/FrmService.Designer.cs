namespace FleetManager
{
    partial class FrmService
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
            this.LBX_ServiceItems = new System.Windows.Forms.ListBox();
            this.FIELD_NOTES = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btPlus = new System.Windows.Forms.Button();
            this.btMinus = new System.Windows.Forms.Button();
            this.DP_Date = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.btConfirm = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // LBX_ServiceItems
            // 
            this.LBX_ServiceItems.FormattingEnabled = true;
            this.LBX_ServiceItems.Location = new System.Drawing.Point(443, 12);
            this.LBX_ServiceItems.Name = "LBX_ServiceItems";
            this.LBX_ServiceItems.Size = new System.Drawing.Size(345, 316);
            this.LBX_ServiceItems.TabIndex = 0;
            // 
            // FIELD_NOTES
            // 
            this.FIELD_NOTES.Location = new System.Drawing.Point(15, 118);
            this.FIELD_NOTES.Multiline = true;
            this.FIELD_NOTES.Name = "FIELD_NOTES";
            this.FIELD_NOTES.Size = new System.Drawing.Size(412, 210);
            this.FIELD_NOTES.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 102);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(35, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Notes";
            // 
            // btPlus
            // 
            this.btPlus.Location = new System.Drawing.Point(713, 334);
            this.btPlus.Name = "btPlus";
            this.btPlus.Size = new System.Drawing.Size(75, 47);
            this.btPlus.TabIndex = 8;
            this.btPlus.Text = "+";
            this.btPlus.UseVisualStyleBackColor = true;
            this.btPlus.Click += new System.EventHandler(this.btPlus_Click);
            // 
            // btMinus
            // 
            this.btMinus.Location = new System.Drawing.Point(632, 334);
            this.btMinus.Name = "btMinus";
            this.btMinus.Size = new System.Drawing.Size(75, 47);
            this.btMinus.TabIndex = 9;
            this.btMinus.Text = "-";
            this.btMinus.UseVisualStyleBackColor = true;
            this.btMinus.Click += new System.EventHandler(this.btMinus_Click);
            // 
            // DP_Date
            // 
            this.DP_Date.Location = new System.Drawing.Point(48, 35);
            this.DP_Date.Name = "DP_Date";
            this.DP_Date.Size = new System.Drawing.Size(376, 20);
            this.DP_Date.TabIndex = 10;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 35);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(30, 13);
            this.label1.TabIndex = 11;
            this.label1.Text = "Date";
            // 
            // btConfirm
            // 
            this.btConfirm.Location = new System.Drawing.Point(632, 454);
            this.btConfirm.Name = "btConfirm";
            this.btConfirm.Size = new System.Drawing.Size(156, 47);
            this.btConfirm.TabIndex = 12;
            this.btConfirm.Text = "CONFIRM";
            this.btConfirm.UseVisualStyleBackColor = true;
            this.btConfirm.Click += new System.EventHandler(this.btConfirm_Click);
            // 
            // FrmService
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 513);
            this.Controls.Add(this.btConfirm);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.DP_Date);
            this.Controls.Add(this.btMinus);
            this.Controls.Add(this.btPlus);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.FIELD_NOTES);
            this.Controls.Add(this.LBX_ServiceItems);
            this.Name = "FrmService";
            this.Text = "Service";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.ListBox LBX_ServiceItems;
        public System.Windows.Forms.TextBox FIELD_NOTES;
        public System.Windows.Forms.Label label3;
        public System.Windows.Forms.Button btPlus;
        public System.Windows.Forms.Button btMinus;
        public System.Windows.Forms.DateTimePicker DP_Date;
        public System.Windows.Forms.Label label1;
        public System.Windows.Forms.Button btConfirm;
    }
}