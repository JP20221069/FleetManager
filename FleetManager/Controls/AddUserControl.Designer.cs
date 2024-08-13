using Common.Localization;

namespace FleetManager.Controls
{
    partial class AddUserControl
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
            this.FIELD_USERNAME = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.FIELD_PASSWORD = new System.Windows.Forms.TextBox();
            this.CB_Role = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btAccept = new System.Windows.Forms.Button();
            this.chkActive = new System.Windows.Forms.CheckBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // FIELD_USERNAME
            // 
            this.FIELD_USERNAME.Location = new System.Drawing.Point(198, 103);
            this.FIELD_USERNAME.Name = "FIELD_USERNAME";
            this.FIELD_USERNAME.Size = new System.Drawing.Size(190, 20);
            this.FIELD_USERNAME.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(137, 106);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Username";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(139, 143);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Password";
            // 
            // FIELD_PASSWORD
            // 
            this.FIELD_PASSWORD.Location = new System.Drawing.Point(198, 140);
            this.FIELD_PASSWORD.Name = "FIELD_PASSWORD";
            this.FIELD_PASSWORD.Size = new System.Drawing.Size(190, 20);
            this.FIELD_PASSWORD.TabIndex = 3;
            // 
            // CB_Role
            // 
            this.CB_Role.FormattingEnabled = true;
         /*   this.CB_Role.Items.AddRange(new object[] {
            l.GetString("ENUM_USER"),
            l.GetString("ENUM_MOD"),
            l.GetString("ENUM_ADMIN")});*/
            this.CB_Role.Location = new System.Drawing.Point(198, 184);
            this.CB_Role.Name = "CB_Role";
            this.CB_Role.Size = new System.Drawing.Size(190, 21);
            this.CB_Role.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(139, 187);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(29, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Role";
            // 
            // btAccept
            // 
            this.btAccept.Location = new System.Drawing.Point(312, 291);
            this.btAccept.Name = "btAccept";
            this.btAccept.Size = new System.Drawing.Size(76, 44);
            this.btAccept.TabIndex = 6;
            this.btAccept.Text = "ACCEPT";
          //  this.btAccept.Text = l.GetString("ACCEPT");
            this.btAccept.UseVisualStyleBackColor = true;
            this.btAccept.Click += new System.EventHandler(this.btAccept_Click);
            // 
            // chkActive
            // 
            this.chkActive.AutoSize = true;
            this.chkActive.Location = new System.Drawing.Point(198, 222);
            this.chkActive.Name = "chkActive";
            this.chkActive.Size = new System.Drawing.Size(56, 17);
            this.chkActive.TabIndex = 7;
            this.chkActive.Text = "Active";
            this.chkActive.UseVisualStyleBackColor = true;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::FleetManager.Properties.Resources.user;
            this.pictureBox1.Location = new System.Drawing.Point(3, 13);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(128, 110);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBox1.TabIndex = 8;
            this.pictureBox1.TabStop = false;
            // 
            // AddUserControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.chkActive);
            this.Controls.Add(this.btAccept);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.CB_Role);
            this.Controls.Add(this.FIELD_PASSWORD);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.FIELD_USERNAME);
            this.Name = "AddUserControl";
            this.Size = new System.Drawing.Size(418, 357);
            this.Load += new System.EventHandler(this.AddUserControl_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        public System.Windows.Forms.ComboBox CB_Role;
        public System.Windows.Forms.Button btAccept;
        public System.Windows.Forms.TextBox FIELD_USERNAME;
        public System.Windows.Forms.TextBox FIELD_PASSWORD;
        private System.Windows.Forms.CheckBox chkActive;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}
