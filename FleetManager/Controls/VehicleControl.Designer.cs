using Common.Localization;

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
            this.components = new System.ComponentModel.Container();
            this.LABEL_NAME = new System.Windows.Forms.Label();
            this.FIELD_NAME = new System.Windows.Forms.TextBox();
            this.FIELD_Brand = new System.Windows.Forms.TextBox();
            this.LABEL_BRAND = new System.Windows.Forms.Label();
            this.FIELD_TYPE = new System.Windows.Forms.TextBox();
            this.LABEL_TYPE = new System.Windows.Forms.Label();
            this.FIELD_LICENSE = new System.Windows.Forms.TextBox();
            this.LABEL_LICENSE = new System.Windows.Forms.Label();
            this.CB_STATUS = new System.Windows.Forms.ComboBox();
            this.LABEL_STATUS = new System.Windows.Forms.Label();
            this.FIELD_CARRYWEIGHT = new System.Windows.Forms.TextBox();
            this.LABEL_CARRYWEIGHT = new System.Windows.Forms.Label();
            this.btAccept = new System.Windows.Forms.Button();
            this.btViewCheckins = new System.Windows.Forms.Button();
            this.btViewServicings = new System.Windows.Forms.Button();
            this.ttService = new System.Windows.Forms.ToolTip(this.components);
            this.ttCheckins = new System.Windows.Forms.ToolTip(this.components);
            this.SuspendLayout();
            // 
            // LABEL_NAME
            // 
            this.LABEL_NAME.AutoSize = true;
            this.LABEL_NAME.Location = new System.Drawing.Point(97, 54);
            this.LABEL_NAME.Name = "LABEL_NAME";
            this.LABEL_NAME.Size = new System.Drawing.Size(35, 13);
            this.LABEL_NAME.TabIndex = 0;
            this.LABEL_NAME.Text = "Name";
            // 
            // FIELD_NAME
            // 
            this.FIELD_NAME.Location = new System.Drawing.Point(177, 51);
            this.FIELD_NAME.Name = "FIELD_NAME";
            this.FIELD_NAME.Size = new System.Drawing.Size(232, 20);
            this.FIELD_NAME.TabIndex = 1;
            // 
            // FIELD_Brand
            // 
            this.FIELD_Brand.Location = new System.Drawing.Point(177, 86);
            this.FIELD_Brand.Name = "FIELD_Brand";
            this.FIELD_Brand.Size = new System.Drawing.Size(232, 20);
            this.FIELD_Brand.TabIndex = 3;
            // 
            // LABEL_BRAND
            // 
            this.LABEL_BRAND.AutoSize = true;
            this.LABEL_BRAND.Location = new System.Drawing.Point(97, 89);
            this.LABEL_BRAND.Name = "LABEL_BRAND";
            this.LABEL_BRAND.Size = new System.Drawing.Size(35, 13);
            this.LABEL_BRAND.TabIndex = 2;
            this.LABEL_BRAND.Text = "Brand";
            // 
            // FIELD_TYPE
            // 
            this.FIELD_TYPE.Location = new System.Drawing.Point(177, 121);
            this.FIELD_TYPE.Name = "FIELD_TYPE";
            this.FIELD_TYPE.Size = new System.Drawing.Size(232, 20);
            this.FIELD_TYPE.TabIndex = 5;
            // 
            // LABEL_TYPE
            // 
            this.LABEL_TYPE.AutoSize = true;
            this.LABEL_TYPE.Location = new System.Drawing.Point(97, 124);
            this.LABEL_TYPE.Name = "LABEL_TYPE";
            this.LABEL_TYPE.Size = new System.Drawing.Size(31, 13);
            this.LABEL_TYPE.TabIndex = 4;
            this.LABEL_TYPE.Text = "Type";
            // 
            // FIELD_LICENSE
            // 
            this.FIELD_LICENSE.Location = new System.Drawing.Point(177, 155);
            this.FIELD_LICENSE.Name = "FIELD_LICENSE";
            this.FIELD_LICENSE.Size = new System.Drawing.Size(232, 20);
            this.FIELD_LICENSE.TabIndex = 7;
            // 
            // LABEL_LICENSE
            // 
            this.LABEL_LICENSE.AutoSize = true;
            this.LABEL_LICENSE.Location = new System.Drawing.Point(97, 158);
            this.LABEL_LICENSE.Name = "LABEL_LICENSE";
            this.LABEL_LICENSE.Size = new System.Drawing.Size(44, 13);
            this.LABEL_LICENSE.TabIndex = 6;
            this.LABEL_LICENSE.Text = "License";
            // 
            // CB_STATUS
            // 
            this.CB_STATUS.FormattingEnabled = true;
            this.CB_STATUS.Location = new System.Drawing.Point(177, 192);
            this.CB_STATUS.Name = "CB_STATUS";
            this.CB_STATUS.Size = new System.Drawing.Size(232, 21);
            this.CB_STATUS.TabIndex = 8;
            // 
            // LABEL_STATUS
            // 
            this.LABEL_STATUS.AutoSize = true;
            this.LABEL_STATUS.Location = new System.Drawing.Point(97, 195);
            this.LABEL_STATUS.Name = "LABEL_STATUS";
            this.LABEL_STATUS.Size = new System.Drawing.Size(37, 13);
            this.LABEL_STATUS.TabIndex = 9;
            this.LABEL_STATUS.Text = "Status";
            // 
            // FIELD_CARRYWEIGHT
            // 
            this.FIELD_CARRYWEIGHT.Location = new System.Drawing.Point(165, 228);
            this.FIELD_CARRYWEIGHT.Name = "FIELD_CARRYWEIGHT";
            this.FIELD_CARRYWEIGHT.Size = new System.Drawing.Size(244, 20);
            this.FIELD_CARRYWEIGHT.TabIndex = 11;
            // 
            // LABEL_CARRYWEIGHT
            // 
            this.LABEL_CARRYWEIGHT.AutoSize = true;
            this.LABEL_CARRYWEIGHT.Location = new System.Drawing.Point(97, 231);
            this.LABEL_CARRYWEIGHT.Name = "LABEL_CARRYWEIGHT";
            this.LABEL_CARRYWEIGHT.Size = new System.Drawing.Size(62, 13);
            this.LABEL_CARRYWEIGHT.TabIndex = 10;
            this.LABEL_CARRYWEIGHT.Text = "Carryweight";
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
            // btViewCheckins
            // 
            this.btViewCheckins.Image = global::FleetManager.Properties.Resources.address_book_0;
            this.btViewCheckins.Location = new System.Drawing.Point(165, 261);
            this.btViewCheckins.Name = "btViewCheckins";
            this.btViewCheckins.Size = new System.Drawing.Size(41, 38);
            this.btViewCheckins.TabIndex = 14;
            this.btViewCheckins.UseVisualStyleBackColor = true;
            this.btViewCheckins.Visible = false;
            // 
            // btViewServicings
            // 
            this.btViewServicings.Image = global::FleetManager.Properties.Resources.gears_tweakui_b;
            this.btViewServicings.Location = new System.Drawing.Point(100, 261);
            this.btViewServicings.Name = "btViewServicings";
            this.btViewServicings.Size = new System.Drawing.Size(41, 38);
            this.btViewServicings.TabIndex = 13;
            this.btViewServicings.UseVisualStyleBackColor = true;
            this.btViewServicings.Visible = false;
            // 
            // VehicleControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btViewCheckins);
            this.Controls.Add(this.btViewServicings);
            this.Controls.Add(this.btAccept);
            this.Controls.Add(this.FIELD_CARRYWEIGHT);
            this.Controls.Add(this.LABEL_CARRYWEIGHT);
            this.Controls.Add(this.LABEL_STATUS);
            this.Controls.Add(this.CB_STATUS);
            this.Controls.Add(this.FIELD_LICENSE);
            this.Controls.Add(this.LABEL_LICENSE);
            this.Controls.Add(this.FIELD_TYPE);
            this.Controls.Add(this.LABEL_TYPE);
            this.Controls.Add(this.FIELD_Brand);
            this.Controls.Add(this.LABEL_BRAND);
            this.Controls.Add(this.FIELD_NAME);
            this.Controls.Add(this.LABEL_NAME);
            this.Name = "VehicleControl";
            this.Size = new System.Drawing.Size(428, 366);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        public System.Windows.Forms.Button btAccept;
        public System.Windows.Forms.TextBox FIELD_NAME;
        public System.Windows.Forms.TextBox FIELD_Brand;
        public System.Windows.Forms.TextBox FIELD_TYPE;
        public System.Windows.Forms.TextBox FIELD_LICENSE;
        public System.Windows.Forms.ComboBox CB_STATUS;
        public System.Windows.Forms.TextBox FIELD_CARRYWEIGHT;
        public System.Windows.Forms.Button btViewServicings;
        public System.Windows.Forms.Button btViewCheckins;
        public System.Windows.Forms.Label LABEL_NAME;
        public System.Windows.Forms.Label LABEL_BRAND;
        public System.Windows.Forms.Label LABEL_TYPE;
        public System.Windows.Forms.Label LABEL_LICENSE;
        public System.Windows.Forms.Label LABEL_STATUS;
        public System.Windows.Forms.Label LABEL_CARRYWEIGHT;
        public System.Windows.Forms.ToolTip ttService;
        public System.Windows.Forms.ToolTip ttCheckins;
    }
}
