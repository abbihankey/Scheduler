
namespace Scheduler
{
    partial class FormMainMenu
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMainMenu));
            this.panelMenu = new System.Windows.Forms.Panel();
            this.buttonCustomers = new System.Windows.Forms.Button();
            this.buttonAppointments = new System.Windows.Forms.Button();
            this.buttonCalendar = new System.Windows.Forms.Button();
            this.buttonDashboard = new System.Windows.Forms.Button();
            this.panelLogo = new System.Windows.Forms.Panel();
            this.panelTitleBar = new System.Windows.Forms.Panel();
            this.labelTitle = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.toolStripTextBox1 = new System.Windows.Forms.ToolStripTextBox();
            this.panelMenu.SuspendLayout();
            this.panelTitleBar.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelMenu
            // 
            this.panelMenu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(90)))), ((int)(((byte)(90)))));
            this.panelMenu.Controls.Add(this.buttonCustomers);
            this.panelMenu.Controls.Add(this.buttonAppointments);
            this.panelMenu.Controls.Add(this.buttonCalendar);
            this.panelMenu.Controls.Add(this.buttonDashboard);
            this.panelMenu.Controls.Add(this.panelLogo);
            this.panelMenu.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelMenu.Location = new System.Drawing.Point(0, 0);
            this.panelMenu.Name = "panelMenu";
            this.panelMenu.Size = new System.Drawing.Size(152, 735);
            this.panelMenu.TabIndex = 0;
            // 
            // buttonCustomers
            // 
            this.buttonCustomers.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonCustomers.Dock = System.Windows.Forms.DockStyle.Top;
            this.buttonCustomers.FlatAppearance.BorderSize = 0;
            this.buttonCustomers.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonCustomers.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonCustomers.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.buttonCustomers.Image = global::Scheduler.Properties.Resources.customers;
            this.buttonCustomers.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.buttonCustomers.Location = new System.Drawing.Point(0, 366);
            this.buttonCustomers.Name = "buttonCustomers";
            this.buttonCustomers.Padding = new System.Windows.Forms.Padding(0, 10, 0, 0);
            this.buttonCustomers.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.buttonCustomers.Size = new System.Drawing.Size(152, 100);
            this.buttonCustomers.TabIndex = 6;
            this.buttonCustomers.Text = "Customers";
            this.buttonCustomers.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.buttonCustomers.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.buttonCustomers.UseCompatibleTextRendering = true;
            this.buttonCustomers.UseVisualStyleBackColor = true;
            this.buttonCustomers.Click += new System.EventHandler(this.buttonCustomers_Click);
            // 
            // buttonAppointments
            // 
            this.buttonAppointments.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonAppointments.Dock = System.Windows.Forms.DockStyle.Top;
            this.buttonAppointments.FlatAppearance.BorderSize = 0;
            this.buttonAppointments.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonAppointments.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonAppointments.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.buttonAppointments.Image = global::Scheduler.Properties.Resources.appointment;
            this.buttonAppointments.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.buttonAppointments.Location = new System.Drawing.Point(0, 266);
            this.buttonAppointments.Name = "buttonAppointments";
            this.buttonAppointments.Padding = new System.Windows.Forms.Padding(0, 10, 0, 0);
            this.buttonAppointments.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.buttonAppointments.Size = new System.Drawing.Size(152, 100);
            this.buttonAppointments.TabIndex = 5;
            this.buttonAppointments.Text = "Appointments";
            this.buttonAppointments.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.buttonAppointments.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.buttonAppointments.UseCompatibleTextRendering = true;
            this.buttonAppointments.UseVisualStyleBackColor = true;
            this.buttonAppointments.Click += new System.EventHandler(this.buttonAppointments_Click);
            // 
            // buttonCalendar
            // 
            this.buttonCalendar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonCalendar.Dock = System.Windows.Forms.DockStyle.Top;
            this.buttonCalendar.FlatAppearance.BorderSize = 0;
            this.buttonCalendar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonCalendar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonCalendar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.buttonCalendar.Image = global::Scheduler.Properties.Resources.calendar;
            this.buttonCalendar.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.buttonCalendar.Location = new System.Drawing.Point(0, 166);
            this.buttonCalendar.Name = "buttonCalendar";
            this.buttonCalendar.Padding = new System.Windows.Forms.Padding(0, 10, 0, 0);
            this.buttonCalendar.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.buttonCalendar.Size = new System.Drawing.Size(152, 100);
            this.buttonCalendar.TabIndex = 4;
            this.buttonCalendar.Text = "Calendar";
            this.buttonCalendar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.buttonCalendar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.buttonCalendar.UseCompatibleTextRendering = true;
            this.buttonCalendar.UseVisualStyleBackColor = true;
            this.buttonCalendar.Click += new System.EventHandler(this.buttonCalendar_Click);
            // 
            // buttonDashboard
            // 
            this.buttonDashboard.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonDashboard.Dock = System.Windows.Forms.DockStyle.Top;
            this.buttonDashboard.FlatAppearance.BorderSize = 0;
            this.buttonDashboard.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonDashboard.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonDashboard.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.buttonDashboard.Image = global::Scheduler.Properties.Resources.report;
            this.buttonDashboard.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.buttonDashboard.Location = new System.Drawing.Point(0, 66);
            this.buttonDashboard.Name = "buttonDashboard";
            this.buttonDashboard.Padding = new System.Windows.Forms.Padding(0, 10, 0, 0);
            this.buttonDashboard.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.buttonDashboard.Size = new System.Drawing.Size(152, 100);
            this.buttonDashboard.TabIndex = 3;
            this.buttonDashboard.Text = "Dashboard";
            this.buttonDashboard.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.buttonDashboard.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.buttonDashboard.UseCompatibleTextRendering = true;
            this.buttonDashboard.UseVisualStyleBackColor = true;
            this.buttonDashboard.Click += new System.EventHandler(this.buttonDashboard_Click);
            // 
            // panelLogo
            // 
            this.panelLogo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(163)))), ((int)(((byte)(228)))));
            this.panelLogo.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelLogo.Location = new System.Drawing.Point(0, 0);
            this.panelLogo.Name = "panelLogo";
            this.panelLogo.Size = new System.Drawing.Size(152, 66);
            this.panelLogo.TabIndex = 1;
            // 
            // panelTitleBar
            // 
            this.panelTitleBar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(163)))), ((int)(((byte)(228)))));
            this.panelTitleBar.Controls.Add(this.labelTitle);
            this.panelTitleBar.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTitleBar.Location = new System.Drawing.Point(152, 0);
            this.panelTitleBar.Name = "panelTitleBar";
            this.panelTitleBar.Size = new System.Drawing.Size(936, 66);
            this.panelTitleBar.TabIndex = 1;
            // 
            // labelTitle
            // 
            this.labelTitle.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.labelTitle.BackColor = System.Drawing.Color.Transparent;
            this.labelTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.labelTitle.Location = new System.Drawing.Point(-168, 0);
            this.labelTitle.Name = "labelTitle";
            this.labelTitle.Size = new System.Drawing.Size(1121, 66);
            this.labelTitle.TabIndex = 0;
            this.labelTitle.Text = "DASHBOARD";
            this.labelTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Enabled = false;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripTextBox1});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1121, 27);
            this.menuStrip1.TabIndex = 3;
            this.menuStrip1.Text = "menuStrip1";
            this.menuStrip1.Visible = false;
            // 
            // toolStripTextBox1
            // 
            this.toolStripTextBox1.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.toolStripTextBox1.Name = "toolStripTextBox1";
            this.toolStripTextBox1.Size = new System.Drawing.Size(100, 23);
            // 
            // FormMainMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1088, 735);
            this.Controls.Add(this.panelTitleBar);
            this.Controls.Add(this.panelMenu);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "FormMainMenu";
            this.Text = "FormMainMenu";
            this.panelMenu.ResumeLayout(false);
            this.panelTitleBar.ResumeLayout(false);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panelMenu;
        private System.Windows.Forms.Button buttonCustomers;
        private System.Windows.Forms.Button buttonAppointments;
        private System.Windows.Forms.Button buttonCalendar;
        private System.Windows.Forms.Button buttonDashboard;
        private System.Windows.Forms.Panel panelTitleBar;
        private System.Windows.Forms.Label labelTitle;
        private System.Windows.Forms.Panel panelLogo;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripTextBox toolStripTextBox1;
    }
}

