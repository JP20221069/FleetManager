namespace FleetManager
{
    partial class FrmVehicles
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btShowAll = new System.Windows.Forms.Button();
            this.btAlter = new System.Windows.Forms.Button();
            this.btDelete = new System.Windows.Forms.Button();
            this.btSearch = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dgwVehicles = new System.Windows.Forms.DataGridView();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgwVehicles)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btShowAll);
            this.groupBox1.Controls.Add(this.btAlter);
            this.groupBox1.Controls.Add(this.btDelete);
            this.groupBox1.Controls.Add(this.btSearch);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(800, 100);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Controls";
            // 
            // btShowAll
            // 
            this.btShowAll.Location = new System.Drawing.Point(106, 19);
            this.btShowAll.Name = "btShowAll";
            this.btShowAll.Size = new System.Drawing.Size(88, 59);
            this.btShowAll.TabIndex = 3;
            this.btShowAll.Text = "Show All";
            this.btShowAll.UseVisualStyleBackColor = true;
            this.btShowAll.Click += new System.EventHandler(this.btShowAll_Click);
            // 
            // btAlter
            // 
            this.btAlter.Location = new System.Drawing.Point(294, 19);
            this.btAlter.Name = "btAlter";
            this.btAlter.Size = new System.Drawing.Size(88, 59);
            this.btAlter.TabIndex = 2;
            this.btAlter.Text = "Alter";
            this.btAlter.UseVisualStyleBackColor = true;
            this.btAlter.Click += new System.EventHandler(this.btAlter_Click);
            // 
            // btDelete
            // 
            this.btDelete.Location = new System.Drawing.Point(200, 19);
            this.btDelete.Name = "btDelete";
            this.btDelete.Size = new System.Drawing.Size(88, 59);
            this.btDelete.TabIndex = 1;
            this.btDelete.Text = "Delete";
            this.btDelete.UseVisualStyleBackColor = true;
            this.btDelete.Click += new System.EventHandler(this.btDelete_Click);
            // 
            // btSearch
            // 
            this.btSearch.Location = new System.Drawing.Point(12, 19);
            this.btSearch.Name = "btSearch";
            this.btSearch.Size = new System.Drawing.Size(88, 59);
            this.btSearch.TabIndex = 0;
            this.btSearch.Text = "Search";
            this.btSearch.UseVisualStyleBackColor = true;
            this.btSearch.Click += new System.EventHandler(this.btSearch_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.dgwVehicles);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(0, 100);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(800, 350);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "View";
            // 
            // dgwVehicles
            // 
            this.dgwVehicles.AllowUserToAddRows = false;
            this.dgwVehicles.AllowUserToDeleteRows = false;
            this.dgwVehicles.AllowUserToOrderColumns = true;
            this.dgwVehicles.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgwVehicles.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgwVehicles.Location = new System.Drawing.Point(3, 16);
            this.dgwVehicles.MultiSelect = false;
            this.dgwVehicles.Name = "dgwVehicles";
            this.dgwVehicles.ReadOnly = true;
            this.dgwVehicles.Size = new System.Drawing.Size(794, 331);
            this.dgwVehicles.TabIndex = 0;
            // 
            // FrmVehicles
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "FrmVehicles";
            this.Text = "Vehicles View";
            this.Load += new System.EventHandler(this.FrmVehicles_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgwVehicles)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btDelete;
        private System.Windows.Forms.Button btSearch;
        private System.Windows.Forms.Button btAlter;
        public System.Windows.Forms.DataGridView dgwVehicles;
        private System.Windows.Forms.Button btShowAll;
    }
}