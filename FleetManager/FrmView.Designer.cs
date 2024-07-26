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
            this.tsbNew = new System.Windows.Forms.ToolStripButton();
            this.tsbAlter = new System.Windows.Forms.ToolStripButton();
            this.tsbInspect = new System.Windows.Forms.ToolStripButton();
            this.tsbDelete = new System.Windows.Forms.ToolStripButton();
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
            this.groupBox2.Location = new System.Drawing.Point(0, 32);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(800, 418);
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
            this.dgwView.Size = new System.Drawing.Size(794, 399);
            this.dgwView.TabIndex = 0;
            // 
            // toolStrip1
            // 
            this.toolStrip1.AutoSize = false;
            this.toolStrip1.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(18, 18);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbSearch,
            this.tsbShowAll,
            this.tsbNew,
            this.tsbAlter,
            this.tsbInspect,
            this.tsbDelete,
            this.tsbCheckin,
            this.tsbCheckout,
            this.tsbService});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.toolStrip1.Size = new System.Drawing.Size(800, 32);
            this.toolStrip1.TabIndex = 2;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // tsbSearch
            // 
            this.tsbSearch.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.tsbSearch.Image = ((System.Drawing.Image)(resources.GetObject("tsbSearch.Image")));
            this.tsbSearch.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbSearch.Name = "tsbSearch";
            this.tsbSearch.Size = new System.Drawing.Size(64, 29);
            this.tsbSearch.Text = "Search";
            this.tsbSearch.ToolTipText = "Search";
            this.tsbSearch.Visible = false;
            this.tsbSearch.Click += new System.EventHandler(this.tsbSearch_Click);
            // 
            // tsbShowAll
            // 
            this.tsbShowAll.Image = global::FleetManager.Properties.Resources.WMS_Playlist;
            this.tsbShowAll.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbShowAll.Name = "tsbShowAll";
            this.tsbShowAll.Size = new System.Drawing.Size(73, 29);
            this.tsbShowAll.Text = "Show all";
            this.tsbShowAll.Visible = false;
            // 
            // tsbNew
            // 
            this.tsbNew.Image = global::FleetManager.Properties.Resources.Single_Click;
            this.tsbNew.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbNew.Name = "tsbNew";
            this.tsbNew.Size = new System.Drawing.Size(53, 29);
            this.tsbNew.Text = "New";
            this.tsbNew.Visible = false;
            // 
            // tsbAlter
            // 
            this.tsbAlter.Image = global::FleetManager.Properties.Resources.Write_Files_to_Disc;
            this.tsbAlter.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbAlter.Name = "tsbAlter";
            this.tsbAlter.Size = new System.Drawing.Size(54, 29);
            this.tsbAlter.Text = "Alter";
            this.tsbAlter.ToolTipText = "Alter record";
            this.tsbAlter.Visible = false;
            // 
            // tsbInspect
            // 
            this.tsbInspect.Image = global::FleetManager.Properties.Resources.hand_properties_old_64;
            this.tsbInspect.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbInspect.Name = "tsbInspect";
            this.tsbInspect.Size = new System.Drawing.Size(79, 29);
            this.tsbInspect.Text = "Inspect ...";
            this.tsbInspect.Visible = false;
            // 
            // tsbDelete
            // 
            this.tsbDelete.Image = global::FleetManager.Properties.Resources.Delete;
            this.tsbDelete.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbDelete.Name = "tsbDelete";
            this.tsbDelete.Size = new System.Drawing.Size(62, 29);
            this.tsbDelete.Text = "Delete";
            this.tsbDelete.ToolTipText = "Delete";
            this.tsbDelete.Visible = false;
            // 
            // tsbCheckin
            // 
            this.tsbCheckin.Image = ((System.Drawing.Image)(resources.GetObject("tsbCheckin.Image")));
            this.tsbCheckin.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbCheckin.Name = "tsbCheckin";
            this.tsbCheckin.Size = new System.Drawing.Size(75, 29);
            this.tsbCheckin.Text = "Check in";
            this.tsbCheckin.ToolTipText = "Check in";
            this.tsbCheckin.Visible = false;
            // 
            // tsbCheckout
            // 
            this.tsbCheckout.Image = global::FleetManager.Properties.Resources.OE_Outbox;
            this.tsbCheckout.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbCheckout.Name = "tsbCheckout";
            this.tsbCheckout.Size = new System.Drawing.Size(83, 29);
            this.tsbCheckout.Text = "Check out";
            this.tsbCheckout.ToolTipText = "Check out";
            this.tsbCheckout.Visible = false;
            // 
            // tsbService
            // 
            this.tsbService.Image = global::FleetManager.Properties.Resources.Services;
            this.tsbService.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbService.Name = "tsbService";
            this.tsbService.Size = new System.Drawing.Size(66, 29);
            this.tsbService.Text = "Service";
            this.tsbService.ToolTipText = "Service";
            this.tsbService.Visible = false;
            // 
            // FrmView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.toolStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrmView";
            this.Text = "Vehicles View";
            this.Load += new System.EventHandler(this.FrmView_Load);
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgwView)).EndInit();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);

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
        public System.Windows.Forms.ToolStripButton tsbNew;
        public System.Windows.Forms.ToolStripButton tsbInspect;
    }
}