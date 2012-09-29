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
            this.label2.Size = new System.Drawing.Size(639, 40);
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
            // mainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DarkGray;
            this.ClientSize = new System.Drawing.Size(664, 525);
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
    }
}