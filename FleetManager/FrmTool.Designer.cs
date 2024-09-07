namespace FleetManager
{
    partial class FrmTool
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
            this.pnlTool = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // pnlTool
            // 
            this.pnlTool.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pnlTool.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlTool.Location = new System.Drawing.Point(0, 0);
            this.pnlTool.Name = "pnlTool";
            this.pnlTool.Size = new System.Drawing.Size(727, 488);
            this.pnlTool.TabIndex = 0;
            // 
            // FrmTool
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(727, 488);
            this.Controls.Add(this.pnlTool);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmTool";
            this.Text = "FrmTool";
            this.Load += new System.EventHandler(this.FrmTool_Load);
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.Panel pnlTool;
    }
}