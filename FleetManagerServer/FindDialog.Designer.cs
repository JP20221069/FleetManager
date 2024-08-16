namespace FleetManagerServer
{
    partial class FindDialog
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
            this.FIELD_FIND = new System.Windows.Forms.TextBox();
            this.btFindNext = new System.Windows.Forms.Button();
            this.LABEL_FIND = new System.Windows.Forms.Label();
            this.btCancel = new System.Windows.Forms.Button();
            this.gbDirection = new System.Windows.Forms.GroupBox();
            this.rbDown = new System.Windows.Forms.RadioButton();
            this.rbUp = new System.Windows.Forms.RadioButton();
            this.chkWrapAround = new System.Windows.Forms.CheckBox();
            this.chkMatchCase = new System.Windows.Forms.CheckBox();
            this.gbDirection.SuspendLayout();
            this.SuspendLayout();
            // 
            // FIELD_FIND
            // 
            this.FIELD_FIND.Location = new System.Drawing.Point(74, 12);
            this.FIELD_FIND.Name = "FIELD_FIND";
            this.FIELD_FIND.Size = new System.Drawing.Size(218, 20);
            this.FIELD_FIND.TabIndex = 0;
            this.FIELD_FIND.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // btFindNext
            // 
            this.btFindNext.Enabled = false;
            this.btFindNext.Location = new System.Drawing.Point(298, 10);
            this.btFindNext.Name = "btFindNext";
            this.btFindNext.Size = new System.Drawing.Size(75, 22);
            this.btFindNext.TabIndex = 1;
            this.btFindNext.Text = "Find Next";
            this.btFindNext.UseVisualStyleBackColor = true;
            // 
            // LABEL_FIND
            // 
            this.LABEL_FIND.AutoSize = true;
            this.LABEL_FIND.Location = new System.Drawing.Point(12, 15);
            this.LABEL_FIND.Name = "LABEL_FIND";
            this.LABEL_FIND.Size = new System.Drawing.Size(56, 13);
            this.LABEL_FIND.TabIndex = 2;
            this.LABEL_FIND.Text = "Find what:";
            // 
            // btCancel
            // 
            this.btCancel.Location = new System.Drawing.Point(298, 38);
            this.btCancel.Name = "btCancel";
            this.btCancel.Size = new System.Drawing.Size(75, 22);
            this.btCancel.TabIndex = 3;
            this.btCancel.Text = "Cancel";
            this.btCancel.UseVisualStyleBackColor = true;
            this.btCancel.Click += new System.EventHandler(this.btCancel_Click);
            // 
            // gbDirection
            // 
            this.gbDirection.Controls.Add(this.rbDown);
            this.gbDirection.Controls.Add(this.rbUp);
            this.gbDirection.Location = new System.Drawing.Point(178, 38);
            this.gbDirection.Name = "gbDirection";
            this.gbDirection.Size = new System.Drawing.Size(114, 48);
            this.gbDirection.TabIndex = 4;
            this.gbDirection.TabStop = false;
            this.gbDirection.Text = "Direction";
            // 
            // rbDown
            // 
            this.rbDown.AutoSize = true;
            this.rbDown.Checked = true;
            this.rbDown.Location = new System.Drawing.Point(55, 20);
            this.rbDown.Name = "rbDown";
            this.rbDown.Size = new System.Drawing.Size(53, 17);
            this.rbDown.TabIndex = 1;
            this.rbDown.TabStop = true;
            this.rbDown.Text = "Down";
            this.rbDown.UseVisualStyleBackColor = true;
            // 
            // rbUp
            // 
            this.rbUp.AutoSize = true;
            this.rbUp.Location = new System.Drawing.Point(7, 20);
            this.rbUp.Name = "rbUp";
            this.rbUp.Size = new System.Drawing.Size(39, 17);
            this.rbUp.TabIndex = 0;
            this.rbUp.Text = "Up";
            this.rbUp.UseVisualStyleBackColor = true;
            // 
            // chkWrapAround
            // 
            this.chkWrapAround.AutoSize = true;
            this.chkWrapAround.Location = new System.Drawing.Point(12, 89);
            this.chkWrapAround.Name = "chkWrapAround";
            this.chkWrapAround.Size = new System.Drawing.Size(88, 17);
            this.chkWrapAround.TabIndex = 5;
            this.chkWrapAround.Text = "Wrap around";
            this.chkWrapAround.UseVisualStyleBackColor = true;
            // 
            // chkMatchCase
            // 
            this.chkMatchCase.AutoSize = true;
            this.chkMatchCase.Location = new System.Drawing.Point(12, 66);
            this.chkMatchCase.Name = "chkMatchCase";
            this.chkMatchCase.Size = new System.Drawing.Size(82, 17);
            this.chkMatchCase.TabIndex = 6;
            this.chkMatchCase.Text = "Match case";
            this.chkMatchCase.UseVisualStyleBackColor = true;
            // 
            // FindDialog
            // 
            this.AcceptButton = this.btFindNext;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btCancel;
            this.ClientSize = new System.Drawing.Size(385, 118);
            this.Controls.Add(this.chkMatchCase);
            this.Controls.Add(this.chkWrapAround);
            this.Controls.Add(this.gbDirection);
            this.Controls.Add(this.btCancel);
            this.Controls.Add(this.LABEL_FIND);
            this.Controls.Add(this.btFindNext);
            this.Controls.Add(this.FIELD_FIND);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FindDialog";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Text = "Find";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FindDialog_FormClosed);
            this.Load += new System.EventHandler(this.FindDialog_Load);
            this.gbDirection.ResumeLayout(false);
            this.gbDirection.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label LABEL_FIND;
        public System.Windows.Forms.GroupBox gbDirection;
        public System.Windows.Forms.TextBox FIELD_FIND;
        public System.Windows.Forms.Button btFindNext;
        public System.Windows.Forms.Button btCancel;
        public System.Windows.Forms.RadioButton rbDown;
        public System.Windows.Forms.RadioButton rbUp;
        public System.Windows.Forms.CheckBox chkWrapAround;
        public System.Windows.Forms.CheckBox chkMatchCase;
    }
}