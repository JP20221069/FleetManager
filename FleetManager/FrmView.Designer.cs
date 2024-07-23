namespace FleetManager
{
    partial class FrmView
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmView));
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dgwView = new System.Windows.Forms.DataGridView();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tsbSearch = new System.Windows.Forms.ToolStripButton();
            this.tsbShowAll = new System.Windows.Forms.ToolStripButton();
            this.tsbDelete = new System.Windows.Forms.ToolStripButton();
            this.tsbAlter = new System.Windows.Forms.ToolStripButton();
            this.tsbCheckin = new System.Windows.Forms.ToolStripButton();
            this.tsbCheckout = new System.Windows.Forms.ToolStripButton();
            this.tsbService = new System.Windows.Forms.ToolStripButton();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgwView)).BeginInit();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.dgwView);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(0, 25);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(800, 425);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "View";
            // 
            // dgwView
            // 
            this.dgwView.AllowUserToAddRows = false;
            this.dgwView.AllowUserToDeleteRows = false;
            this.dgwView.AllowUserToOrderColumns = true;
            this.dgwView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgwView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgwView.Location = new System.Drawing.Point(3, 16);
            this.dgwView.MultiSelect = false;
            this.dgwView.Name = "dgwView";
            this.dgwView.ReadOnly = true;
            this.dgwView.Size = new System.Drawing.Size(794, 406);
            this.dgwView.TabIndex = 0;
            // 
            // toolStrip1
            // 
            this.toolStrip1.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbSearch,
            this.tsbShowAll,
            this.tsbDelete,
            this.tsbAlter,
            this.tsbCheckin,
            this.tsbCheckout,
            this.tsbService});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.toolStrip1.Size = new System.Drawing.Size(800, 25);
            this.toolStrip1.TabIndex = 2;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // tsbSearch
            // 
            this.tsbSearch.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbSearch.Image = ((System.Drawing.Image)(resources.GetObject("tsbSearch.Image")));
            this.tsbSearch.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbSearch.Name = "tsbSearch";
            this.tsbSearch.Size = new System.Drawing.Size(23, 22);
            this.tsbSearch.Text = "toolStripButton1";
            this.tsbSearch.ToolTipText = "Search";
            this.tsbSearch.Visible = false;
            this.tsbSearch.Click += new System.EventHandler(this.tsbSearch_Click);
            // 
            // tsbShowAll
            // 
            this.tsbShowAll.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbShowAll.Image = global::FleetManager.Properties.Resources.WMS_Playlist;
            this.tsbShowAll.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbShowAll.Name = "tsbShowAll";
            this.tsbShowAll.Size = new System.Drawing.Size(23, 22);
            this.tsbShowAll.Text = "toolStripButton2";
            this.tsbShowAll.Visible = false;
            this.tsbShowAll.Click += new System.EventHandler(this.tsbShowAll_Click);
            // 
            // tsbDelete
            // 
            this.tsbDelete.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbDelete.Image = global::FleetManager.Properties.Resources.Delete;
            this.tsbDelete.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbDelete.Name = "tsbDelete";
            this.tsbDelete.Size = new System.Drawing.Size(23, 22);
            this.tsbDelete.Text = "toolStripButton3";
            this.tsbDelete.ToolTipText = "Delete";
            this.tsbDelete.Visible = false;
            this.tsbDelete.Click += new System.EventHandler(this.tsbDelete_Click);
            // 
            // tsbAlter
            // 
            this.tsbAlter.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbAlter.Image = global::FleetManager.Properties.Resources.Write_Files_to_Disc;
            this.tsbAlter.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbAlter.Name = "tsbAlter";
            this.tsbAlter.Size = new System.Drawing.Size(23, 22);
            this.tsbAlter.Text = "toolStripButton4";
            this.tsbAlter.ToolTipText = "Alter record";
            this.tsbAlter.Visible = false;
            // 
            // tsbCheckin
            // 
            this.tsbCheckin.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbCheckin.Image = ((System.Drawing.Image)(resources.GetObject("tsbCheckin.Image")));
            this.tsbCheckin.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbCheckin.Name = "tsbCheckin";
            this.tsbCheckin.Size = new System.Drawing.Size(23, 22);
            this.tsbCheckin.Text = "toolStripButton5";
            this.tsbCheckin.ToolTipText = "Check in";
            this.tsbCheckin.Visible = false;
            this.tsbCheckin.Click += new System.EventHandler(this.tsbCheckin_Click);
            // 
            // tsbCheckout
            // 
            this.tsbCheckout.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbCheckout.Image = global::FleetManager.Properties.Resources.OE_Outbox;
            this.tsbCheckout.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbCheckout.Name = "tsbCheckout";
            this.tsbCheckout.Size = new System.Drawing.Size(23, 22);
            this.tsbCheckout.Text = "toolStripButton6";
            this.tsbCheckout.ToolTipText = "Check out";
            this.tsbCheckout.Visible = false;
            this.tsbCheckout.Click += new System.EventHandler(this.tsbCheckout_Click);
            // 
            // tsbService
            // 
            this.tsbService.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbService.Image = global::FleetManager.Properties.Resources.Services;
            this.tsbService.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbService.Name = "tsbService";
            this.tsbService.Size = new System.Drawing.Size(23, 22);
            this.tsbService.Text = "toolStripButton1";
            this.tsbService.ToolTipText = "Service";
            this.tsbService.Visible = false;
            this.tsbService.Click += new System.EventHandler(this.tsbService_Click);
            // 
            // FrmView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.toolStrip1);
            this.Name = "FrmView";
            this.Text = "Vehicles View";
            this.Load += new System.EventHandler(this.FrmView_Load);
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgwView)).EndInit();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.GroupBox groupBox2;
        public System.Windows.Forms.DataGridView dgwView;
        public System.Windows.Forms.ToolStrip toolStrip1;
        public System.Windows.Forms.ToolStripButton tsbSearch;
        public System.Windows.Forms.ToolStripButton tsbShowAll;
        public System.Windows.Forms.ToolStripButton tsbDelete;
        public System.Windows.Forms.ToolStripButton tsbAlter;
        public System.Windows.Forms.ToolStripButton tsbCheckin;
        public System.Windows.Forms.ToolStripButton tsbCheckout;
        public System.Windows.Forms.ToolStripButton tsbService;
    }
}