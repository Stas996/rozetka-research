namespace RozetkaResearch
{
    partial class MainForm
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
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.btnOpenXML = new System.Windows.Forms.Button();
            this.lblProcess = new System.Windows.Forms.Label();
            this.btnResearch = new System.Windows.Forms.Button();
            this.lblResearchStatus = new System.Windows.Forms.Label();
            this.btnReport = new System.Windows.Forms.Button();
            this.txtYmlUrl = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.chkFromDevice = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // openFileDialog
            // 
            this.openFileDialog.FileName = "openFileDialog";
            // 
            // btnOpenXML
            // 
            this.btnOpenXML.Location = new System.Drawing.Point(12, 105);
            this.btnOpenXML.Name = "btnOpenXML";
            this.btnOpenXML.Size = new System.Drawing.Size(74, 37);
            this.btnOpenXML.TabIndex = 0;
            this.btnOpenXML.Text = "Загрузить товары";
            this.btnOpenXML.UseVisualStyleBackColor = true;
            this.btnOpenXML.Click += new System.EventHandler(this.btnOpenXML_Click);
            // 
            // lblProcess
            // 
            this.lblProcess.AutoSize = true;
            this.lblProcess.Location = new System.Drawing.Point(198, 117);
            this.lblProcess.Name = "lblProcess";
            this.lblProcess.Size = new System.Drawing.Size(249, 13);
            this.lblProcess.TabIndex = 1;
            this.lblProcess.Text = "Загрузите YML файл товаров вашего магазина";
            // 
            // btnResearch
            // 
            this.btnResearch.Location = new System.Drawing.Point(12, 148);
            this.btnResearch.Name = "btnResearch";
            this.btnResearch.Size = new System.Drawing.Size(179, 35);
            this.btnResearch.TabIndex = 2;
            this.btnResearch.Text = "Поиск более дешевых товаров";
            this.btnResearch.UseVisualStyleBackColor = true;
            this.btnResearch.Click += new System.EventHandler(this.btnResearch_Click);
            // 
            // lblResearchStatus
            // 
            this.lblResearchStatus.AutoSize = true;
            this.lblResearchStatus.Location = new System.Drawing.Point(198, 159);
            this.lblResearchStatus.Name = "lblResearchStatus";
            this.lblResearchStatus.Size = new System.Drawing.Size(190, 13);
            this.lblResearchStatus.TabIndex = 3;
            this.lblResearchStatus.Text = "Идет поиск более дешевых товаров";
            this.lblResearchStatus.Click += new System.EventHandler(this.lblResearchStatus_Click);
            // 
            // btnReport
            // 
            this.btnReport.Location = new System.Drawing.Point(12, 200);
            this.btnReport.Name = "btnReport";
            this.btnReport.Size = new System.Drawing.Size(440, 39);
            this.btnReport.TabIndex = 4;
            this.btnReport.Text = "Получить отчет";
            this.btnReport.UseVisualStyleBackColor = true;
            this.btnReport.Click += new System.EventHandler(this.btnReport_Click);
            // 
            // txtYmlUrl
            // 
            this.txtYmlUrl.Location = new System.Drawing.Point(131, 76);
            this.txtYmlUrl.Name = "txtYmlUrl";
            this.txtYmlUrl.Size = new System.Drawing.Size(316, 20);
            this.txtYmlUrl.TabIndex = 5;
            this.txtYmlUrl.Text = "http://massage-shop.com.ua/attache/rozetka_wotags.yml ";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 79);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(118, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Ссылка на YML файл:";
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(12, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(440, 47);
            this.label2.TabIndex = 7;
            this.label2.Text = "Загрузите YML файл товаров вашего магазина (Укажите ссылку на него, либо загрузит" +
    "е с вашего компьютера)";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // chkFromDevice
            // 
            this.chkFromDevice.AutoSize = true;
            this.chkFromDevice.Location = new System.Drawing.Point(92, 116);
            this.chkFromDevice.Name = "chkFromDevice";
            this.chkFromDevice.Size = new System.Drawing.Size(99, 17);
            this.chkFromDevice.TabIndex = 8;
            this.chkFromDevice.Text = "С компьютера";
            this.chkFromDevice.UseVisualStyleBackColor = true;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(468, 247);
            this.Controls.Add(this.chkFromDevice);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtYmlUrl);
            this.Controls.Add(this.btnReport);
            this.Controls.Add(this.lblResearchStatus);
            this.Controls.Add(this.btnResearch);
            this.Controls.Add(this.lblProcess);
            this.Controls.Add(this.btnOpenXML);
            this.Name = "MainForm";
            this.Text = "Rozetka Research";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.Button btnOpenXML;
        private System.Windows.Forms.Label lblProcess;
        private System.Windows.Forms.Button btnResearch;
        private System.Windows.Forms.Label lblResearchStatus;
        private System.Windows.Forms.Button btnReport;
        private System.Windows.Forms.TextBox txtYmlUrl;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox chkFromDevice;
    }
}

