
namespace Scheduler
{
    partial class FormDashboard
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
            this.dataGridViewUserAppointments = new System.Windows.Forms.DataGridView();
            this.labelUpcomingApps = new System.Windows.Forms.Label();
            this.buttonSearch = new System.Windows.Forms.Button();
            this.textBoxSearch = new System.Windows.Forms.TextBox();
            this.buttonSearchCustSched = new System.Windows.Forms.Button();
            this.textBoxSearchCust = new System.Windows.Forms.TextBox();
            this.dataGridViewCustomerSchedules = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.buttonSearchByMonth = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.dataGridViewType = new System.Windows.Forms.DataGridView();
            this.comboBoxMonth = new System.Windows.Forms.ComboBox();
            this.dataGridView15Min = new System.Windows.Forms.DataGridView();
            this.label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewUserAppointments)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewCustomerSchedules)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewType)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView15Min)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridViewUserAppointments
            // 
            this.dataGridViewUserAppointments.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewUserAppointments.Location = new System.Drawing.Point(12, 55);
            this.dataGridViewUserAppointments.Name = "dataGridViewUserAppointments";
            this.dataGridViewUserAppointments.Size = new System.Drawing.Size(444, 231);
            this.dataGridViewUserAppointments.TabIndex = 0;
            this.dataGridViewUserAppointments.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dataGridViewUserAppointments_CellFormatting);
            // 
            // labelUpcomingApps
            // 
            this.labelUpcomingApps.AutoSize = true;
            this.labelUpcomingApps.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelUpcomingApps.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.labelUpcomingApps.Location = new System.Drawing.Point(8, 32);
            this.labelUpcomingApps.Name = "labelUpcomingApps";
            this.labelUpcomingApps.Size = new System.Drawing.Size(165, 20);
            this.labelUpcomingApps.TabIndex = 1;
            this.labelUpcomingApps.Text = "Consultant Schedules";
            // 
            // buttonSearch
            // 
            this.buttonSearch.Location = new System.Drawing.Point(381, 288);
            this.buttonSearch.Name = "buttonSearch";
            this.buttonSearch.Size = new System.Drawing.Size(75, 23);
            this.buttonSearch.TabIndex = 26;
            this.buttonSearch.Text = "Search";
            this.buttonSearch.UseVisualStyleBackColor = true;
            this.buttonSearch.Click += new System.EventHandler(this.buttonSearch_Click);
            // 
            // textBoxSearch
            // 
            this.textBoxSearch.Location = new System.Drawing.Point(224, 290);
            this.textBoxSearch.Name = "textBoxSearch";
            this.textBoxSearch.Size = new System.Drawing.Size(151, 20);
            this.textBoxSearch.TabIndex = 25;
            this.textBoxSearch.Text = "Search by userID";
            // 
            // buttonSearchCustSched
            // 
            this.buttonSearchCustSched.Location = new System.Drawing.Point(381, 592);
            this.buttonSearchCustSched.Name = "buttonSearchCustSched";
            this.buttonSearchCustSched.Size = new System.Drawing.Size(75, 23);
            this.buttonSearchCustSched.TabIndex = 29;
            this.buttonSearchCustSched.Text = "Search";
            this.buttonSearchCustSched.UseVisualStyleBackColor = true;
            this.buttonSearchCustSched.Click += new System.EventHandler(this.buttonSearchCustSched_Click);
            // 
            // textBoxSearchCust
            // 
            this.textBoxSearchCust.Location = new System.Drawing.Point(224, 595);
            this.textBoxSearchCust.Name = "textBoxSearchCust";
            this.textBoxSearchCust.Size = new System.Drawing.Size(151, 20);
            this.textBoxSearchCust.TabIndex = 28;
            this.textBoxSearchCust.Text = "Search by customerID";
            // 
            // dataGridViewCustomerSchedules
            // 
            this.dataGridViewCustomerSchedules.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewCustomerSchedules.Location = new System.Drawing.Point(12, 355);
            this.dataGridViewCustomerSchedules.Name = "dataGridViewCustomerSchedules";
            this.dataGridViewCustomerSchedules.Size = new System.Drawing.Size(444, 231);
            this.dataGridViewCustomerSchedules.TabIndex = 27;
            this.dataGridViewCustomerSchedules.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dataGridViewCustomerSchedules_CellFormatting);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.label1.Location = new System.Drawing.Point(8, 332);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(157, 20);
            this.label1.TabIndex = 30;
            this.label1.Text = "Customer Schedules";
            // 
            // buttonSearchByMonth
            // 
            this.buttonSearchByMonth.Location = new System.Drawing.Point(859, 592);
            this.buttonSearchByMonth.Name = "buttonSearchByMonth";
            this.buttonSearchByMonth.Size = new System.Drawing.Size(75, 23);
            this.buttonSearchByMonth.TabIndex = 34;
            this.buttonSearchByMonth.Text = "Search";
            this.buttonSearchByMonth.UseVisualStyleBackColor = true;
            this.buttonSearchByMonth.Click += new System.EventHandler(this.buttonSearchByMonth_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.label2.Location = new System.Drawing.Point(486, 332);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(122, 20);
            this.label2.TabIndex = 32;
            this.label2.Text = "Types By Month";
            // 
            // dataGridViewType
            // 
            this.dataGridViewType.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewType.Location = new System.Drawing.Point(490, 355);
            this.dataGridViewType.Name = "dataGridViewType";
            this.dataGridViewType.Size = new System.Drawing.Size(444, 231);
            this.dataGridViewType.TabIndex = 31;
            this.dataGridViewType.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dataGridViewType_CellFormatting);
            // 
            // comboBoxMonth
            // 
            this.comboBoxMonth.FormattingEnabled = true;
            this.comboBoxMonth.Items.AddRange(new object[] {
            "January",
            "February",
            "March",
            "April",
            "May",
            "June",
            "July",
            "August",
            "September",
            "October",
            "November",
            "December"});
            this.comboBoxMonth.Location = new System.Drawing.Point(756, 594);
            this.comboBoxMonth.Name = "comboBoxMonth";
            this.comboBoxMonth.Size = new System.Drawing.Size(97, 21);
            this.comboBoxMonth.TabIndex = 35;
            // 
            // dataGridView15Min
            // 
            this.dataGridView15Min.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView15Min.Location = new System.Drawing.Point(490, 55);
            this.dataGridView15Min.Name = "dataGridView15Min";
            this.dataGridView15Min.Size = new System.Drawing.Size(444, 231);
            this.dataGridView15Min.TabIndex = 36;
            this.dataGridView15Min.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dataGridView15Min_CellFormatting);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.label3.Location = new System.Drawing.Point(486, 32);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(204, 20);
            this.label3.TabIndex = 37;
            this.label3.Text = "Meetings Within 15 Minutes";
            // 
            // FormDashboard
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(90)))), ((int)(((byte)(90)))));
            this.ClientSize = new System.Drawing.Size(1169, 682);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.dataGridView15Min);
            this.Controls.Add(this.comboBoxMonth);
            this.Controls.Add(this.buttonSearchByMonth);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dataGridViewType);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.buttonSearchCustSched);
            this.Controls.Add(this.textBoxSearchCust);
            this.Controls.Add(this.dataGridViewCustomerSchedules);
            this.Controls.Add(this.buttonSearch);
            this.Controls.Add(this.textBoxSearch);
            this.Controls.Add(this.labelUpcomingApps);
            this.Controls.Add(this.dataGridViewUserAppointments);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormDashboard";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewUserAppointments)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewCustomerSchedules)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewType)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView15Min)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridViewUserAppointments;
        private System.Windows.Forms.Label labelUpcomingApps;
        private System.Windows.Forms.Button buttonSearch;
        private System.Windows.Forms.TextBox textBoxSearch;
        private System.Windows.Forms.Button buttonSearchCustSched;
        private System.Windows.Forms.TextBox textBoxSearchCust;
        private System.Windows.Forms.DataGridView dataGridViewCustomerSchedules;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonSearchByMonth;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView dataGridViewType;
        private System.Windows.Forms.ComboBox comboBoxMonth;
        private System.Windows.Forms.DataGridView dataGridView15Min;
        private System.Windows.Forms.Label label3;
    }
}