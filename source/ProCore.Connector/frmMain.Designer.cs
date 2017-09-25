namespace ProCore.Connector
{
    partial class frmMain
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
            this.lstViewEndPoints = new System.Windows.Forms.ListView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.txtDataEndPoint = new System.Windows.Forms.TextBox();
            this.lblDataEndPoint = new System.Windows.Forms.Label();
            this.txtBaseUrl = new System.Windows.Forms.TextBox();
            this.lblUrl = new System.Windows.Forms.Label();
            this.btnQuery = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lstViewEndPoints
            // 
            this.lstViewEndPoints.Location = new System.Drawing.Point(3, 12);
            this.lstViewEndPoints.Name = "lstViewEndPoints";
            this.lstViewEndPoints.Size = new System.Drawing.Size(165, 428);
            this.lstViewEndPoints.TabIndex = 0;
            this.lstViewEndPoints.UseCompatibleStateImageBehavior = false;
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.txtDataEndPoint);
            this.panel1.Controls.Add(this.lblDataEndPoint);
            this.panel1.Controls.Add(this.txtBaseUrl);
            this.panel1.Controls.Add(this.lblUrl);
            this.panel1.Location = new System.Drawing.Point(175, 13);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(456, 124);
            this.panel1.TabIndex = 1;
            // 
            // txtDataEndPoint
            // 
            this.txtDataEndPoint.Location = new System.Drawing.Point(57, 37);
            this.txtDataEndPoint.Name = "txtDataEndPoint";
            this.txtDataEndPoint.Size = new System.Drawing.Size(391, 20);
            this.txtDataEndPoint.TabIndex = 3;
            // 
            // lblDataEndPoint
            // 
            this.lblDataEndPoint.AutoSize = true;
            this.lblDataEndPoint.Location = new System.Drawing.Point(3, 37);
            this.lblDataEndPoint.Name = "lblDataEndPoint";
            this.lblDataEndPoint.Size = new System.Drawing.Size(49, 13);
            this.lblDataEndPoint.TabIndex = 2;
            this.lblDataEndPoint.Text = "Endpoint";
            // 
            // txtBaseUrl
            // 
            this.txtBaseUrl.Location = new System.Drawing.Point(57, 11);
            this.txtBaseUrl.Name = "txtBaseUrl";
            this.txtBaseUrl.Size = new System.Drawing.Size(391, 20);
            this.txtBaseUrl.TabIndex = 1;
            this.txtBaseUrl.Text = "https://app.procore.com/";
            // 
            // lblUrl
            // 
            this.lblUrl.AutoSize = true;
            this.lblUrl.Location = new System.Drawing.Point(3, 11);
            this.lblUrl.Name = "lblUrl";
            this.lblUrl.Size = new System.Drawing.Size(47, 13);
            this.lblUrl.TabIndex = 0;
            this.lblUrl.Text = "Base Url";
            // 
            // btnQuery
            // 
            this.btnQuery.Location = new System.Drawing.Point(515, 178);
            this.btnQuery.Name = "btnQuery";
            this.btnQuery.Size = new System.Drawing.Size(75, 23);
            this.btnQuery.TabIndex = 2;
            this.btnQuery.Text = "Query";
            this.btnQuery.UseVisualStyleBackColor = true;
            this.btnQuery.Click += new System.EventHandler(this.btnQuery_Click);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(636, 444);
            this.Controls.Add(this.btnQuery);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.lstViewEndPoints);
            this.Name = "frmMain";
            this.Text = "ProCore API Connector";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView lstViewEndPoints;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox txtBaseUrl;
        private System.Windows.Forms.Label lblUrl;
        private System.Windows.Forms.TextBox txtDataEndPoint;
        private System.Windows.Forms.Label lblDataEndPoint;
        private System.Windows.Forms.Button btnQuery;
    }
}

