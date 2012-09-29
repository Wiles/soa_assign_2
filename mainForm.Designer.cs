namespace soa_assign_II
{
    partial class mainForm
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
            this.cmboBoxServiceList = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cmboBoxMethodList = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.parameterPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.btnEngageService = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.txtResult = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // cmboBoxServiceList
            // 
            this.cmboBoxServiceList.FormattingEnabled = true;
            this.cmboBoxServiceList.Location = new System.Drawing.Point(12, 69);
            this.cmboBoxServiceList.Name = "cmboBoxServiceList";
            this.cmboBoxServiceList.Size = new System.Drawing.Size(217, 21);
            this.cmboBoxServiceList.TabIndex = 0;
            this.cmboBoxServiceList.SelectedIndexChanged += new System.EventHandler(this.cmboBoxServiceList_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 53);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(216, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Select a Service from the dropdown below...";
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(13, 13);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(434, 40);
            this.label2.TabIndex = 2;
            this.label2.Text = "Service Exposer";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // cmboBoxMethodList
            // 
            this.cmboBoxMethodList.FormattingEnabled = true;
            this.cmboBoxMethodList.Location = new System.Drawing.Point(12, 113);
            this.cmboBoxMethodList.Name = "cmboBoxMethodList";
            this.cmboBoxMethodList.Size = new System.Drawing.Size(217, 21);
            this.cmboBoxMethodList.TabIndex = 3;
            this.cmboBoxMethodList.SelectedIndexChanged += new System.EventHandler(this.cmboBoxMethodList_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 97);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(216, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Select a Method from the dropdown below...";
            // 
            // parameterPanel
            // 
            this.parameterPanel.Location = new System.Drawing.Point(12, 140);
            this.parameterPanel.Name = "parameterPanel";
            this.parameterPanel.Size = new System.Drawing.Size(217, 236);
            this.parameterPanel.TabIndex = 6;
            // 
            // btnEngageService
            // 
            this.btnEngageService.Location = new System.Drawing.Point(12, 390);
            this.btnEngageService.Name = "btnEngageService";
            this.btnEngageService.Size = new System.Drawing.Size(217, 23);
            this.btnEngageService.TabIndex = 7;
            this.btnEngageService.Text = "Activate Service";
            this.btnEngageService.UseVisualStyleBackColor = true;
            this.btnEngageService.Click += new System.EventHandler(this.btnEngageService_Click);
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(238, 121);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(209, 13);
            this.label4.TabIndex = 9;
            this.label4.Text = "Result of Query:";
            this.label4.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // txtResult
            // 
            this.txtResult.Location = new System.Drawing.Point(241, 140);
            this.txtResult.Multiline = true;
            this.txtResult.Name = "txtResult";
            this.txtResult.Size = new System.Drawing.Size(206, 236);
            this.txtResult.TabIndex = 10;
            // 
            // mainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DarkGray;
            this.ClientSize = new System.Drawing.Size(459, 425);
            this.Controls.Add(this.txtResult);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btnEngageService);
            this.Controls.Add(this.parameterPanel);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cmboBoxMethodList);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cmboBoxServiceList);
            this.Name = "mainForm";
            this.Text = "Service Exposer";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cmboBoxServiceList;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmboBoxMethodList;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.FlowLayoutPanel parameterPanel;
        private System.Windows.Forms.Button btnEngageService;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtResult;
    }
}