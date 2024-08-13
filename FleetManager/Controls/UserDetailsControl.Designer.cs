using Common.Localization;

namespace FleetManager.Controls
{
    partial class UserDetailsControl
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
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.chkActive = new System.Windows.Forms.CheckBox();
            this.btAccept = new System.Windows.Forms.Button();
            this.LABEL_ROLE = new System.Windows.Forms.Label();
            this.CB_Role = new System.Windows.Forms.ComboBox();
            this.FIELD_PASSWORD = new System.Windows.Forms.TextBox();
            this.LABEL_PASSWORD = new System.Windows.Forms.Label();
            this.LABEL_USERNAME = new System.Windows.Forms.Label();
            this.FIELD_USERNAME = new System.Windows.Forms.TextBox();
            this.chkLoggedin = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::FleetManager.Properties.Resources.user;
            this.pictureBox1.Location = new System.Drawing.Point(3, 3);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(93, 110);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBox1.TabIndex = 17;
            this.pictureBox1.TabStop = false;
            // 
            // chkActive
            // 
            this.chkActive.AutoSize = true;
            this.chkActive.Location = new System.Drawing.Point(198, 212);
            this.chkActive.Name = "chkActive";
            this.chkActive.Size = new System.Drawing.Size(56, 17);
            this.chkActive.TabIndex = 16;
            this.chkActive.Text = "Active";
            this.chkActive.UseVisualStyleBackColor = true;
            // 
            // btAccept
            // 
            this.btAccept.Location = new System.Drawing.Point(312, 281);
            this.btAccept.Name = "btAccept";
            this.btAccept.Size = new System.Drawing.Size(76, 44);
            this.btAccept.TabIndex = 15;
            this.btAccept.Text = "Accept";
            this.btAccept.UseVisualStyleBackColor = true;
            // 
            // LABEL_ROLE
            // 
            this.LABEL_ROLE.AutoSize = true;
            this.LABEL_ROLE.Location = new System.Drawing.Point(115, 177);
            this.LABEL_ROLE.Name = "LABEL_ROLE";
            this.LABEL_ROLE.Size = new System.Drawing.Size(29, 13);
            this.LABEL_ROLE.TabIndex = 14;
            this.LABEL_ROLE.Text = "Role";
            // 
            // CB_Role
            // 
            this.CB_Role.FormattingEnabled = true;
            this.CB_Role.Location = new System.Drawing.Point(198, 174);
            this.CB_Role.Name = "CB_Role";
            this.CB_Role.Size = new System.Drawing.Size(190, 21);
            this.CB_Role.TabIndex = 13;
            // 
            // FIELD_PASSWORD
            // 
            this.FIELD_PASSWORD.Location = new System.Drawing.Point(198, 130);
            this.FIELD_PASSWORD.Name = "FIELD_PASSWORD";
            this.FIELD_PASSWORD.Size = new System.Drawing.Size(190, 20);
            this.FIELD_PASSWORD.TabIndex = 12;
            // 
            // LABEL_PASSWORD
            // 
            this.LABEL_PASSWORD.AutoSize = true;
            this.LABEL_PASSWORD.Location = new System.Drawing.Point(113, 133);
            this.LABEL_PASSWORD.Name = "LABEL_PASSWORD";
            this.LABEL_PASSWORD.Size = new System.Drawing.Size(53, 13);
            this.LABEL_PASSWORD.TabIndex = 11;
            this.LABEL_PASSWORD.Text = "Password";
            // 
            // LABEL_USERNAME
            // 
            this.LABEL_USERNAME.AutoSize = true;
            this.LABEL_USERNAME.Location = new System.Drawing.Point(113, 96);
            this.LABEL_USERNAME.Name = "LABEL_USERNAME";
            this.LABEL_USERNAME.Size = new System.Drawing.Size(55, 13);
            this.LABEL_USERNAME.TabIndex = 10;
            this.LABEL_USERNAME.Text = "Username";
            // 
            // FIELD_USERNAME
            // 
            this.FIELD_USERNAME.Location = new System.Drawing.Point(198, 93);
            this.FIELD_USERNAME.Name = "FIELD_USERNAME";
            this.FIELD_USERNAME.Size = new System.Drawing.Size(190, 20);
            this.FIELD_USERNAME.TabIndex = 9;
            // 
            // chkLoggedin
            // 
            this.chkLoggedin.AutoSize = true;
            this.chkLoggedin.Enabled = false;
            this.chkLoggedin.Location = new System.Drawing.Point(312, 212);
            this.chkLoggedin.Name = "chkLoggedin";
            this.chkLoggedin.Size = new System.Drawing.Size(73, 17);
            this.chkLoggedin.TabIndex = 18;
            this.chkLoggedin.Text = "Logged in";
            this.chkLoggedin.UseVisualStyleBackColor = true;
            // 
            // UserDetailsControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.chkLoggedin);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.chkActive);
            this.Controls.Add(this.btAccept);
            this.Controls.Add(this.LABEL_ROLE);
            this.Controls.Add(this.CB_Role);
            this.Controls.Add(this.FIELD_PASSWORD);
            this.Controls.Add(this.LABEL_PASSWORD);
            this.Controls.Add(this.LABEL_USERNAME);
            this.Controls.Add(this.FIELD_USERNAME);
            this.Name = "UserDetailsControl";
            this.Size = new System.Drawing.Size(399, 336);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        public System.Windows.Forms.CheckBox chkActive;
        public System.Windows.Forms.Button btAccept;
        public System.Windows.Forms.ComboBox CB_Role;
        public System.Windows.Forms.TextBox FIELD_PASSWORD;
        public System.Windows.Forms.TextBox FIELD_USERNAME;
        public System.Windows.Forms.CheckBox chkLoggedin;
        public System.Windows.Forms.Label LABEL_PASSWORD;
        public System.Windows.Forms.Label LABEL_ROLE;
        public System.Windows.Forms.Label LABEL_USERNAME;
    }
}
