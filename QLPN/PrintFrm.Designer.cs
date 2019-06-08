namespace QLPN
{
    partial class PrintFrm
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
            this.Header = new System.Windows.Forms.TextBox();
            this.prisonListReportViewer = new Microsoft.Reporting.WinForms.ReportViewer();
            this.SuspendLayout();
            // 
            // Header
            // 
            this.Header.BackColor = System.Drawing.SystemColors.Control;
            this.Header.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.Header.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Header.Enabled = false;
            this.Header.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Header.ForeColor = System.Drawing.Color.DimGray;
            this.Header.Location = new System.Drawing.Point(0, 0);
            this.Header.Name = "Header";
            this.Header.Size = new System.Drawing.Size(809, 31);
            this.Header.TabIndex = 8;
            this.Header.Text = "In thông tin phạm nhân";
            this.Header.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // prisonListReportViewer
            // 
            this.prisonListReportViewer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.prisonListReportViewer.LocalReport.ReportEmbeddedResource = "QLPN.Report.prisonListReport.rdlc";
            this.prisonListReportViewer.Location = new System.Drawing.Point(0, 0);
            this.prisonListReportViewer.Name = "prisonListReportViewer";
            this.prisonListReportViewer.ServerReport.BearerToken = null;
            this.prisonListReportViewer.Size = new System.Drawing.Size(809, 655);
            this.prisonListReportViewer.TabIndex = 9;
            // 
            // PrintFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.ClientSize = new System.Drawing.Size(809, 655);
            this.Controls.Add(this.prisonListReportViewer);
            this.Controls.Add(this.Header);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.Name = "PrintFrm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "In thông tin phạm nhân";
            this.Load += new System.EventHandler(this.PrintFrm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox Header;
        private Microsoft.Reporting.WinForms.ReportViewer prisonListReportViewer;
    }
}