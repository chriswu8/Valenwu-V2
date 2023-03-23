namespace Valenwu
{
    partial class FormEOD
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.formEOD_datagridview = new System.Windows.Forms.DataGridView();
            this.label7 = new System.Windows.Forms.Label();
            this.formEOD_total_revenue = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.formEOD_datagridview)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(35, 73);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(42, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Time";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(151, 73);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(47, 20);
            this.label2.TabIndex = 1;
            this.label2.Text = "Client";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(384, 73);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(56, 20);
            this.label3.TabIndex = 2;
            this.label3.Text = "Service";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label4.Location = new System.Drawing.Point(207, 9);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(214, 32);
            this.label4.TabIndex = 3;
            this.label4.Text = "End-of-Day Report";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(538, 73);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(62, 20);
            this.label5.TabIndex = 4;
            this.label5.Text = "Amount";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(35, 93);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(567, 20);
            this.label6.TabIndex = 5;
            this.label6.Text = "_________________________________________________________________________________" +
    "____________";
            // 
            // formEOD_datagridview
            // 
            this.formEOD_datagridview.BackgroundColor = System.Drawing.SystemColors.ControlLight;
            this.formEOD_datagridview.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.formEOD_datagridview.Location = new System.Drawing.Point(41, 132);
            this.formEOD_datagridview.Name = "formEOD_datagridview";
            this.formEOD_datagridview.RowHeadersWidth = 51;
            this.formEOD_datagridview.RowTemplate.Height = 29;
            this.formEOD_datagridview.Size = new System.Drawing.Size(559, 500);
            this.formEOD_datagridview.TabIndex = 6;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label7.Location = new System.Drawing.Point(361, 649);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(132, 28);
            this.label7.TabIndex = 7;
            this.label7.Text = "Total revenue:";
            // 
            // formEOD_total_revenue
            // 
            this.formEOD_total_revenue.AutoSize = true;
            this.formEOD_total_revenue.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.formEOD_total_revenue.Location = new System.Drawing.Point(537, 649);
            this.formEOD_total_revenue.Name = "formEOD_total_revenue";
            this.formEOD_total_revenue.Size = new System.Drawing.Size(65, 28);
            this.formEOD_total_revenue.TabIndex = 8;
            this.formEOD_total_revenue.Text = "$ 0.00";

            // 
            // FormEOD
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ClientSize = new System.Drawing.Size(648, 704);
            this.Controls.Add(this.formEOD_total_revenue);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.formEOD_datagridview);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "FormEOD";
            this.Text = "FormEOD";
            ((System.ComponentModel.ISupportInitialize)(this.formEOD_datagridview)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label6;
        private DataGridView formEOD_datagridview;
        private Label label7;
        private Label formEOD_total_revenue;
    }
}