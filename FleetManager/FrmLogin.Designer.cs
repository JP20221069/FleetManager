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
            this.FIELD_USERNAME = new System.Windows.Forms.TextBox();
            this.FIELD_PASSWORD = new System.Windows.Forms.TextBox();
            this.BT_LOGIN = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // FIELD_USERNAME
            // 
            this.FIELD_USERNAME.Location = new System.Drawing.Point(73, 58);
            this.FIELD_USERNAME.Name = "FIELD_USERNAME";
            this.FIELD_USERNAME.Size = new System.Drawing.Size(237, 20);
            this.FIELD_USERNAME.TabIndex = 0;
            // 
            // FIELD_PASSWORD
            // 
            this.FIELD_PASSWORD.Location = new System.Drawing.Point(73, 94);
            this.FIELD_PASSWORD.Name = "FIELD_PASSWORD";
            this.FIELD_PASSWORD.Size = new System.Drawing.Size(237, 20);
            this.FIELD_PASSWORD.TabIndex = 1;
            // 
            // BT_LOGIN
            // 
            this.BT_LOGIN.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BT_LOGIN.Location = new System.Drawing.Point(192, 217);
            this.BT_LOGIN.Name = "BT_LOGIN";
            this.BT_LOGIN.Size = new System.Drawing.Size(118, 54);
            this.BT_LOGIN.TabIndex = 2;
            this.BT_LOGIN.Text = "Login";
            this.BT_LOGIN.UseVisualStyleBackColor = true;
            this.BT_LOGIN.Click += new System.EventHandler(this.BT_LOGIN_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 61);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Username";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 97);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Password";
            // 
            // FrmLogin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(322, 283);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.BT_LOGIN);
            this.Controls.Add(this.FIELD_PASSWORD);
            this.Controls.Add(this.FIELD_USERNAME);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmLogin";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Text = "Fleet Manager - Login";
            this.Load += new System.EventHandler(this.FrmLogin_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button BT_LOGIN;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        public TextBox FIELD_USERNAME;
        public TextBox FIELD_PASSWORD;
    }
}