namespace FleetManager.Controls
{
    partial class VehicleControl
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
            this.FIELD_NAME = new System.Windows.Forms.TextBox();
            this.FIELD_Brand = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.FIELD_TYPE = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.FIELD_LICENSE = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.CB_STATUS = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.FIELD_CARRYWEIGHT = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.btAccept = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(97, 54);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Name";
            // 
            // FIELD_NAME
            // 
            this.FIELD_NAME.Location = new System.Drawing.Point(147, 51);
            this.FIELD_NAME.Name = "FIELD_NAME";
            this.FIELD_NAME.Size = new System.Drawing.Size(262, 20);
            this.FIELD_NAME.TabIndex = 1;
            // 
            // FIELD_Brand
            // 
            this.FIELD_Brand.Location = new System.Drawing.Point(147, 86);
            this.FIELD_Brand.Name = "FIELD_Brand";
            this.FIELD_Brand.Size = new System.Drawing.Size(262, 20);
            this.FIELD_Brand.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(97, 89);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Brand";
            // 
            // FIELD_TYPE
            // 
            this.FIELD_TYPE.Location = new System.Drawing.Point(147, 121);
            this.FIELD_TYPE.Name = "FIELD_TYPE";
            this.FIELD_TYPE.Size = new System.Drawing.Size(262, 20);
            this.FIELD_TYPE.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(97, 124);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(31, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Type";
            // 
            // FIELD_LICENSE
            // 
            this.FIELD_LICENSE.Location = new System.Drawing.Point(147, 155);
            this.FIELD_LICENSE.Name = "FIELD_LICENSE";
            this.FIELD_LICENSE.Size = new System.Drawing.Size(262, 20);
            this.FIELD_LICENSE.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(97, 158);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(44, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "License";
            // 
            // CB_STATUS
            // 
            this.CB_STATUS.FormattingEnabled = true;
            this.CB_STATUS.Location = new System.Drawing.Point(147, 192);
            this.CB_STATUS.Name = "CB_STATUS";
            this.CB_STATUS.Size = new System.Drawing.Size(262, 21);
            this.CB_STATUS.TabIndex = 8;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(97, 195);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(37, 13);
            this.label5.TabIndex = 9;
            this.label5.Text = "Status";
            // 
            // FIELD_CARRYWEIGHT
            // 
            this.FIELD_CARRYWEIGHT.Location = new System.Drawing.Point(165, 228);
            this.FIELD_CARRYWEIGHT.Name = "FIELD_CARRYWEIGHT";
            this.FIELD_CARRYWEIGHT.Size = new System.Drawing.Size(244, 20);
            this.FIELD_CARRYWEIGHT.TabIndex = 11;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(97, 231);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(62, 13);
            this.label6.TabIndex = 10;
            this.label6.Text = "Carryweight";
            // 
            // btAccept
            // 
            this.btAccept.Location = new System.Drawing.Point(333, 311);
            this.btAccept.Name = "btAccept";
            this.btAccept.Size = new System.Drawing.Size(76, 44);
            this.btAccept.TabIndex = 12;
            this.btAccept.Text = "ACCEPT";
            this.btAccept.UseVisualStyleBackColor = true;
            this.btAccept.Click += new System.EventHandler(this.btAccept_Click);
            // 
            // AddVehicleControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btAccept);
            this.Controls.Add(this.FIELD_CARRYWEIGHT);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.CB_STATUS);
            this.Controls.Add(this.FIELD_LICENSE);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.FIELD_TYPE);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.FIELD_Brand);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.FIELD_NAME);
            this.Controls.Add(this.label1);
            this.Name = "AddVehicleControl";
            this.Size = new System.Drawing.Size(428, 366);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        public System.Windows.Forms.Button btAccept;
        public System.Windows.Forms.TextBox FIELD_NAME;
        public System.Windows.Forms.TextBox FIELD_Brand;
        public System.Windows.Forms.TextBox FIELD_TYPE;
        public System.Windows.Forms.TextBox FIELD_LICENSE;
        public System.Windows.Forms.ComboBox CB_STATUS;
        public System.Windows.Forms.TextBox FIELD_CARRYWEIGHT;
    }
}
