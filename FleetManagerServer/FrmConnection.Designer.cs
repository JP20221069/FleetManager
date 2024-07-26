namespace FleetManagerServer
{
    partial class FrmConnection
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmConnection));
            this.label1 = new System.Windows.Forms.Label();
            this.FIELD_CONNECTION_STRING = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btTestConnection = new System.Windows.Forms.Button();
            this.btCopyCS = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.lblstatus = new System.Windows.Forms.Label();
            this.pbStatus = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbStatus)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(154, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(311, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "Current database connection settings";
            // 
            // FIELD_CONNECTION_STRING
            // 
            this.FIELD_CONNECTION_STRING.Location = new System.Drawing.Point(12, 178);
            this.FIELD_CONNECTION_STRING.Multiline = true;
            this.FIELD_CONNECTION_STRING.Name = "FIELD_CONNECTION_STRING";
            this.FIELD_CONNECTION_STRING.Size = new System.Drawing.Size(505, 215);
            this.FIELD_CONNECTION_STRING.TabIndex = 11;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 159);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(94, 13);
            this.label2.TabIndex = 9;
            this.label2.Text = "Connection String:";
            // 
            // btTestConnection
            // 
            this.btTestConnection.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btTestConnection.Location = new System.Drawing.Point(408, 106);
            this.btTestConnection.Name = "btTestConnection";
            this.btTestConnection.Size = new System.Drawing.Size(138, 64);
            this.btTestConnection.TabIndex = 14;
            this.btTestConnection.Text = "TEST CONNECTION";
            this.btTestConnection.UseVisualStyleBackColor = true;
            this.btTestConnection.Click += new System.EventHandler(this.btTestConnection_Click);
            // 
            // btCopyCS
            // 
            this.btCopyCS.BackgroundImage = global::FleetManagerServer.Properties.Resources.Copy;
            this.btCopyCS.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btCopyCS.Location = new System.Drawing.Point(523, 176);
            this.btCopyCS.Name = "btCopyCS";
            this.btCopyCS.Size = new System.Drawing.Size(23, 22);
            this.btCopyCS.TabIndex = 13;
            this.btCopyCS.UseVisualStyleBackColor = true;
            this.btCopyCS.Click += new System.EventHandler(this.btCopyCS_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::FleetManagerServer.Properties.Resources.data_yellow;
            this.pictureBox1.Location = new System.Drawing.Point(15, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(123, 124);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // lblstatus
            // 
            this.lblstatus.AutoSize = true;
            this.lblstatus.Location = new System.Drawing.Point(221, 114);
            this.lblstatus.Name = "lblstatus";
            this.lblstatus.Size = new System.Drawing.Size(10, 13);
            this.lblstatus.TabIndex = 15;
            this.lblstatus.Text = " ";
            // 
            // pbStatus
            // 
            this.pbStatus.Location = new System.Drawing.Point(336, 106);
            this.pbStatus.Name = "pbStatus";
            this.pbStatus.Size = new System.Drawing.Size(33, 30);
            this.pbStatus.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbStatus.TabIndex = 16;
            this.pbStatus.TabStop = false;
            // 
            // FrmConnection
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(558, 405);
            this.Controls.Add(this.pbStatus);
            this.Controls.Add(this.lblstatus);
            this.Controls.Add(this.btTestConnection);
            this.Controls.Add(this.btCopyCS);
            this.Controls.Add(this.FIELD_CONNECTION_STRING);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmConnection";
            this.Text = "Database Connection";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbStatus)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btCopyCS;
        public System.Windows.Forms.TextBox FIELD_CONNECTION_STRING;
        private System.Windows.Forms.Label label2;
        public System.Windows.Forms.Button btTestConnection;
        public System.Windows.Forms.Label lblstatus;
        public System.Windows.Forms.PictureBox pbStatus;
    }
}