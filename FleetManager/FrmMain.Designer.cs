﻿namespace FleetManager
{
    partial class FrmMain
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmMain));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.programToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.preferencesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.languageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.englishENToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.srpskiSRToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.vehicleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.serviceToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.recordVehicleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newVehToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.alterVehToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.checkInToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.checkoutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.viewAllVehiclesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.userToolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.recordUserToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newUserToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.alterUserToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.viewAllToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.logOffToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.searchToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.userSearchToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.vehicleSearchToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.pnlMain = new System.Windows.Forms.Panel();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.menuStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.programToolStripMenuItem,
            this.vehicleToolStripMenuItem,
            this.userToolStripMenuItem2,
            this.searchToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.menuStrip1.Size = new System.Drawing.Size(800, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // programToolStripMenuItem
            // 
            this.programToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.helpToolStripMenuItem,
            this.aboutToolStripMenuItem,
            this.preferencesToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.programToolStripMenuItem.Name = "programToolStripMenuItem";
            this.programToolStripMenuItem.Size = new System.Drawing.Size(65, 20);
            this.programToolStripMenuItem.Text = "Program";
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.helpToolStripMenuItem.Text = "Help";
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.aboutToolStripMenuItem.Text = "About";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // preferencesToolStripMenuItem
            // 
            this.preferencesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.languageToolStripMenuItem});
            this.preferencesToolStripMenuItem.Name = "preferencesToolStripMenuItem";
            this.preferencesToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.preferencesToolStripMenuItem.Text = "Preferences";
            // 
            // languageToolStripMenuItem
            // 
            this.languageToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.englishENToolStripMenuItem,
            this.srpskiSRToolStripMenuItem});
            this.languageToolStripMenuItem.Name = "languageToolStripMenuItem";
            this.languageToolStripMenuItem.Size = new System.Drawing.Size(126, 22);
            this.languageToolStripMenuItem.Text = "Language";
            // 
            // englishENToolStripMenuItem
            // 
            this.englishENToolStripMenuItem.Name = "englishENToolStripMenuItem";
            this.englishENToolStripMenuItem.Size = new System.Drawing.Size(138, 22);
            this.englishENToolStripMenuItem.Text = "English (EN)";
            this.englishENToolStripMenuItem.Click += new System.EventHandler(this.englishENToolStripMenuItem_Click);
            // 
            // srpskiSRToolStripMenuItem
            // 
            this.srpskiSRToolStripMenuItem.Name = "srpskiSRToolStripMenuItem";
            this.srpskiSRToolStripMenuItem.Size = new System.Drawing.Size(138, 22);
            this.srpskiSRToolStripMenuItem.Text = "Srpski (SR)";
            this.srpskiSRToolStripMenuItem.Click += new System.EventHandler(this.srpskiSRToolStripMenuItem_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // vehicleToolStripMenuItem
            // 
            this.vehicleToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.serviceToolStripMenuItem,
            this.recordVehicleToolStripMenuItem,
            this.checkInToolStripMenuItem,
            this.checkoutToolStripMenuItem,
            this.viewAllVehiclesToolStripMenuItem});
            this.vehicleToolStripMenuItem.Name = "vehicleToolStripMenuItem";
            this.vehicleToolStripMenuItem.Size = new System.Drawing.Size(56, 20);
            this.vehicleToolStripMenuItem.Text = "Vehicle";
            // 
            // serviceToolStripMenuItem
            // 
            this.serviceToolStripMenuItem.Name = "serviceToolStripMenuItem";
            this.serviceToolStripMenuItem.Size = new System.Drawing.Size(130, 22);
            this.serviceToolStripMenuItem.Text = "Service";
            this.serviceToolStripMenuItem.Visible = false;
            this.serviceToolStripMenuItem.Click += new System.EventHandler(this.serviceToolStripMenuItem_Click);
            // 
            // recordVehicleToolStripMenuItem
            // 
            this.recordVehicleToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newVehToolStripMenuItem,
            this.alterVehToolStripMenuItem,
            this.deleteToolStripMenuItem});
            this.recordVehicleToolStripMenuItem.Name = "recordVehicleToolStripMenuItem";
            this.recordVehicleToolStripMenuItem.Size = new System.Drawing.Size(130, 22);
            this.recordVehicleToolStripMenuItem.Text = "Record";
            this.recordVehicleToolStripMenuItem.Visible = false;
            // 
            // newVehToolStripMenuItem
            // 
            this.newVehToolStripMenuItem.Name = "newVehToolStripMenuItem";
            this.newVehToolStripMenuItem.Size = new System.Drawing.Size(107, 22);
            this.newVehToolStripMenuItem.Text = "New...";
            this.newVehToolStripMenuItem.Visible = false;
            this.newVehToolStripMenuItem.Click += new System.EventHandler(this.newVehToolStripMenuItem_Click);
            // 
            // alterVehToolStripMenuItem
            // 
            this.alterVehToolStripMenuItem.Name = "alterVehToolStripMenuItem";
            this.alterVehToolStripMenuItem.Size = new System.Drawing.Size(107, 22);
            this.alterVehToolStripMenuItem.Text = "Alter";
            this.alterVehToolStripMenuItem.Visible = false;
            this.alterVehToolStripMenuItem.Click += new System.EventHandler(this.alterVehToolStripMenuItem_Click);
            // 
            // deleteToolStripMenuItem
            // 
            this.deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
            this.deleteToolStripMenuItem.Size = new System.Drawing.Size(107, 22);
            this.deleteToolStripMenuItem.Text = "Delete";
            this.deleteToolStripMenuItem.Visible = false;
            this.deleteToolStripMenuItem.Click += new System.EventHandler(this.deleteToolStripMenuItem_Click_1);
            // 
            // checkInToolStripMenuItem
            // 
            this.checkInToolStripMenuItem.Name = "checkInToolStripMenuItem";
            this.checkInToolStripMenuItem.Size = new System.Drawing.Size(130, 22);
            this.checkInToolStripMenuItem.Text = "Check- in";
            this.checkInToolStripMenuItem.Visible = false;
            this.checkInToolStripMenuItem.Click += new System.EventHandler(this.checkInToolStripMenuItem_Click);
            // 
            // checkoutToolStripMenuItem
            // 
            this.checkoutToolStripMenuItem.Name = "checkoutToolStripMenuItem";
            this.checkoutToolStripMenuItem.Size = new System.Drawing.Size(130, 22);
            this.checkoutToolStripMenuItem.Text = "Check-out";
            this.checkoutToolStripMenuItem.Visible = false;
            this.checkoutToolStripMenuItem.Click += new System.EventHandler(this.checkoutToolStripMenuItem_Click);
            // 
            // viewAllVehiclesToolStripMenuItem
            // 
            this.viewAllVehiclesToolStripMenuItem.Name = "viewAllVehiclesToolStripMenuItem";
            this.viewAllVehiclesToolStripMenuItem.Size = new System.Drawing.Size(130, 22);
            this.viewAllVehiclesToolStripMenuItem.Text = "View All";
            this.viewAllVehiclesToolStripMenuItem.Visible = false;
            this.viewAllVehiclesToolStripMenuItem.Click += new System.EventHandler(this.viewAllVehiclesToolStripMenuItem_Click);
            // 
            // userToolStripMenuItem2
            // 
            this.userToolStripMenuItem2.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.recordUserToolStripMenuItem,
            this.viewAllToolStripMenuItem,
            this.logOffToolStripMenuItem});
            this.userToolStripMenuItem2.Name = "userToolStripMenuItem2";
            this.userToolStripMenuItem2.Size = new System.Drawing.Size(42, 20);
            this.userToolStripMenuItem2.Text = "User";
            // 
            // recordUserToolStripMenuItem
            // 
            this.recordUserToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newUserToolStripMenuItem,
            this.alterUserToolStripMenuItem});
            this.recordUserToolStripMenuItem.Name = "recordUserToolStripMenuItem";
            this.recordUserToolStripMenuItem.Size = new System.Drawing.Size(116, 22);
            this.recordUserToolStripMenuItem.Text = "Record";
            this.recordUserToolStripMenuItem.Visible = false;
            // 
            // newUserToolStripMenuItem
            // 
            this.newUserToolStripMenuItem.Name = "newUserToolStripMenuItem";
            this.newUserToolStripMenuItem.Size = new System.Drawing.Size(107, 22);
            this.newUserToolStripMenuItem.Text = "New...";
            this.newUserToolStripMenuItem.Visible = false;
            this.newUserToolStripMenuItem.Click += new System.EventHandler(this.newUserToolStripMenuItem_Click);
            // 
            // alterUserToolStripMenuItem
            // 
            this.alterUserToolStripMenuItem.Name = "alterUserToolStripMenuItem";
            this.alterUserToolStripMenuItem.Size = new System.Drawing.Size(107, 22);
            this.alterUserToolStripMenuItem.Text = "Alter";
            this.alterUserToolStripMenuItem.Visible = false;
            this.alterUserToolStripMenuItem.Click += new System.EventHandler(this.alterUserToolStripMenuItem_Click);
            // 
            // viewAllToolStripMenuItem
            // 
            this.viewAllToolStripMenuItem.Name = "viewAllToolStripMenuItem";
            this.viewAllToolStripMenuItem.Size = new System.Drawing.Size(116, 22);
            this.viewAllToolStripMenuItem.Text = "View All";
            this.viewAllToolStripMenuItem.Visible = false;
            this.viewAllToolStripMenuItem.Click += new System.EventHandler(this.viewAllToolStripMenuItem_Click);
            // 
            // logOffToolStripMenuItem
            // 
            this.logOffToolStripMenuItem.Name = "logOffToolStripMenuItem";
            this.logOffToolStripMenuItem.Size = new System.Drawing.Size(116, 22);
            this.logOffToolStripMenuItem.Text = "Log off";
            this.logOffToolStripMenuItem.Click += new System.EventHandler(this.logOffToolStripMenuItem_Click);
            // 
            // searchToolStripMenuItem
            // 
            this.searchToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.userSearchToolStripMenuItem,
            this.vehicleSearchToolStripMenuItem});
            this.searchToolStripMenuItem.Name = "searchToolStripMenuItem";
            this.searchToolStripMenuItem.Size = new System.Drawing.Size(54, 20);
            this.searchToolStripMenuItem.Text = "Search";
            // 
            // userSearchToolStripMenuItem
            // 
            this.userSearchToolStripMenuItem.Name = "userSearchToolStripMenuItem";
            this.userSearchToolStripMenuItem.Size = new System.Drawing.Size(111, 22);
            this.userSearchToolStripMenuItem.Text = "User";
            this.userSearchToolStripMenuItem.Visible = false;
            this.userSearchToolStripMenuItem.Click += new System.EventHandler(this.userToolStripMenuItem_Click);
            // 
            // vehicleSearchToolStripMenuItem
            // 
            this.vehicleSearchToolStripMenuItem.Name = "vehicleSearchToolStripMenuItem";
            this.vehicleSearchToolStripMenuItem.Size = new System.Drawing.Size(111, 22);
            this.vehicleSearchToolStripMenuItem.Text = "Vehicle";
            this.vehicleSearchToolStripMenuItem.Visible = false;
            this.vehicleSearchToolStripMenuItem.Click += new System.EventHandler(this.vehicleToolStripMenuItem1_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1});
            this.statusStrip1.Location = new System.Drawing.Point(0, 428);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.ShowItemToolTips = true;
            this.statusStrip1.Size = new System.Drawing.Size(800, 22);
            this.statusStrip1.TabIndex = 1;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Image = global::FleetManager.Properties.Resources.tick;
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(16, 17);
            // 
            // pnlMain
            // 
            this.pnlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMain.Location = new System.Drawing.Point(0, 24);
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.Size = new System.Drawing.Size(800, 404);
            this.pnlMain.TabIndex = 2;
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.pnlMain);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "FrmMain";
            this.Text = "FrmMain";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmMain_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FrmMain_FormClosed);
            this.Load += new System.EventHandler(this.FrmMain_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        public System.Windows.Forms.MenuStrip menuStrip1;
        public System.Windows.Forms.ToolStripMenuItem vehicleToolStripMenuItem;
        public System.Windows.Forms.ToolStripMenuItem serviceToolStripMenuItem;
        public System.Windows.Forms.ToolStripMenuItem checkInToolStripMenuItem;
        public System.Windows.Forms.ToolStripMenuItem checkoutToolStripMenuItem;
        public System.Windows.Forms.ToolStripMenuItem viewAllVehiclesToolStripMenuItem;
        public System.Windows.Forms.ToolStripMenuItem recordVehicleToolStripMenuItem;
        public System.Windows.Forms.ToolStripMenuItem newVehToolStripMenuItem;
        public System.Windows.Forms.ToolStripMenuItem userToolStripMenuItem2;
        public System.Windows.Forms.ToolStripMenuItem recordUserToolStripMenuItem;
        public System.Windows.Forms.ToolStripMenuItem newUserToolStripMenuItem;
        public System.Windows.Forms.ToolStripMenuItem viewAllToolStripMenuItem;
        public System.Windows.Forms.ToolStripMenuItem programToolStripMenuItem;
        public System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        public System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        public System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        public System.Windows.Forms.ToolStripMenuItem logOffToolStripMenuItem;
        public System.Windows.Forms.Panel pnlMain;
        public System.Windows.Forms.ToolStripMenuItem userSearchToolStripMenuItem;
        public System.Windows.Forms.ToolStripMenuItem vehicleSearchToolStripMenuItem;
        private System.Windows.Forms.Timer timer1;
        public System.Windows.Forms.StatusStrip statusStrip1;
        public System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        public System.Windows.Forms.ToolStripMenuItem searchToolStripMenuItem;
        public System.Windows.Forms.ToolStripMenuItem alterVehToolStripMenuItem;
        public System.Windows.Forms.ToolStripMenuItem deleteToolStripMenuItem;
        public System.Windows.Forms.ToolStripMenuItem alterUserToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem englishENToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem srpskiSRToolStripMenuItem;
        public System.Windows.Forms.ToolStripMenuItem preferencesToolStripMenuItem;
        public System.Windows.Forms.ToolStripMenuItem languageToolStripMenuItem;
    }
}