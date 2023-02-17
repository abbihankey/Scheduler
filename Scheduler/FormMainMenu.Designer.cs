
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
            this.panelMenu = new System.Windows.Forms.Panel();
            this.panelLogo = new System.Windows.Forms.Panel();
            this.buttonCalendar = new System.Windows.Forms.Button();
            this.panelMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelMenu
            // 
            this.panelMenu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(90)))), ((int)(((byte)(90)))));
            this.panelMenu.Controls.Add(this.buttonCalendar);
            this.panelMenu.Controls.Add(this.panelLogo);
            this.panelMenu.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelMenu.Location = new System.Drawing.Point(0, 0);
            this.panelMenu.Name = "panelMenu";
            this.panelMenu.Size = new System.Drawing.Size(220, 543);
            this.panelMenu.TabIndex = 0;
            // 
            // panelLogo
            // 
            this.panelLogo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(74)))), ((int)(((byte)(74)))), ((int)(((byte)(74)))));
            this.panelLogo.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelLogo.Location = new System.Drawing.Point(0, 0);
            this.panelLogo.Name = "panelLogo";
            this.panelLogo.Size = new System.Drawing.Size(220, 101);
            this.panelLogo.TabIndex = 1;
            // 
            // buttonCalendar
            // 
            this.buttonCalendar.Dock = System.Windows.Forms.DockStyle.Top;
            this.buttonCalendar.FlatAppearance.BorderSize = 0;
            this.buttonCalendar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonCalendar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.buttonCalendar.Image = global::Scheduler.Properties.Resources.calendar;
            this.buttonCalendar.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.buttonCalendar.Location = new System.Drawing.Point(0, 101);
            this.buttonCalendar.Name = "buttonCalendar";
            this.buttonCalendar.Size = new System.Drawing.Size(220, 101);
            this.buttonCalendar.TabIndex = 2;
            this.buttonCalendar.Text = "Calendar";
            this.buttonCalendar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.buttonCalendar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.buttonCalendar.UseVisualStyleBackColor = true;
            // 
            // FormMainMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1050, 543);
            this.Controls.Add(this.panelMenu);
            this.Name = "FormMainMenu";
            this.Text = "FormMainMenu";
            this.panelMenu.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelMenu;
        private System.Windows.Forms.Panel panelLogo;
        private System.Windows.Forms.Button buttonCalendar;
    }
}

