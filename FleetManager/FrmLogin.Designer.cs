using System.Windows.Forms;

namespace FleetManager
{
    partial class FrmLogin
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmLogin));
            this.FIELD_USERNAME = new System.Windows.Forms.TextBox();
            this.FIELD_PASSWORD = new System.Windows.Forms.TextBox();
            this.BT_LOGIN = new System.Windows.Forms.Button();
            this.LB_USERNAME = new System.Windows.Forms.Label();
            this.LB_PASSWORD = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // FIELD_USERNAME
            // 
            this.FIELD_USERNAME.Location = new System.Drawing.Point(91, 87);
            this.FIELD_USERNAME.Name = "FIELD_USERNAME";
            this.FIELD_USERNAME.Size = new System.Drawing.Size(219, 20);
            this.FIELD_USERNAME.TabIndex = 0;
            // 
            // FIELD_PASSWORD
            // 
            this.FIELD_PASSWORD.Location = new System.Drawing.Point(91, 123);
            this.FIELD_PASSWORD.Name = "FIELD_PASSWORD";
            this.FIELD_PASSWORD.PasswordChar = '*';
            this.FIELD_PASSWORD.Size = new System.Drawing.Size(219, 20);
            this.FIELD_PASSWORD.TabIndex = 1;
            // 
            // BT_LOGIN
            // 
            this.BT_LOGIN.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BT_LOGIN.Location = new System.Drawing.Point(170, 217);
            this.BT_LOGIN.Name = "BT_LOGIN";
            this.BT_LOGIN.Size = new System.Drawing.Size(140, 54);
            this.BT_LOGIN.TabIndex = 2;
            this.BT_LOGIN.Text = "Login";
            this.BT_LOGIN.UseVisualStyleBackColor = true;
            this.BT_LOGIN.Click += new System.EventHandler(this.BT_LOGIN_Click);
            // 
            // LB_USERNAME
            // 
            this.LB_USERNAME.AutoSize = true;
            this.LB_USERNAME.Location = new System.Drawing.Point(12, 90);
            this.LB_USERNAME.Name = "LB_USERNAME";
            this.LB_USERNAME.Size = new System.Drawing.Size(55, 13);
            this.LB_USERNAME.TabIndex = 3;
            this.LB_USERNAME.Text = "Username";
            // 
            // LB_PASSWORD
            // 
            this.LB_PASSWORD.AutoSize = true;
            this.LB_PASSWORD.Location = new System.Drawing.Point(12, 126);
            this.LB_PASSWORD.Name = "LB_PASSWORD";
            this.LB_PASSWORD.Size = new System.Drawing.Size(53, 13);
            this.LB_PASSWORD.TabIndex = 4;
            this.LB_PASSWORD.Text = "Password";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::FleetManager.Properties.Resources.FleetManager_Icon;
            this.pictureBox1.Location = new System.Drawing.Point(15, 21);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(75, 51);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 5;
            this.pictureBox1.TabStop = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Tahoma", 18F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(96, 32);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(219, 29);
            this.label3.TabIndex = 6;
            this.label3.Text = "Fleet Manager 23";
            // 
            // FrmLogin
            // 
            this.AcceptButton = this.BT_LOGIN;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(322, 283);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.LB_PASSWORD);
            this.Controls.Add(this.LB_USERNAME);
            this.Controls.Add(this.BT_LOGIN);
            this.Controls.Add(this.FIELD_PASSWORD);
            this.Controls.Add(this.FIELD_USERNAME);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmLogin";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Text = "Fleet Manager - Login";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmLogin_FormClosing);
            this.Load += new System.EventHandler(this.FrmLogin_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        public TextBox FIELD_USERNAME;
        public TextBox FIELD_PASSWORD;
        private PictureBox pictureBox1;
        private Label label3;
        public Button BT_LOGIN;
        public Label LB_USERNAME;
        public Label LB_PASSWORD;
    }
}