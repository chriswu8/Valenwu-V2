namespace Valenwu
{
    partial class FormServices
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
            this.addNewServiceButton = new System.Windows.Forms.Button();
            this.DeleteServiceButton = new System.Windows.Forms.Button();
            this.EditServiceButton = new System.Windows.Forms.Button();
            this.ExitServiceButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.dataGridViewServices = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewServices)).BeginInit();
            this.SuspendLayout();
            // 
            // addNewServiceButton
            // 
            this.addNewServiceButton.Location = new System.Drawing.Point(439, 33);
            this.addNewServiceButton.Name = "addNewServiceButton";
            this.addNewServiceButton.Size = new System.Drawing.Size(170, 35);
            this.addNewServiceButton.TabIndex = 1;
            this.addNewServiceButton.Text = "Add new service";
            this.addNewServiceButton.UseVisualStyleBackColor = true;
            this.addNewServiceButton.Click += new System.EventHandler(this.service_button_Click);
            // 
            // DeleteServiceButton
            // 
            this.DeleteServiceButton.Location = new System.Drawing.Point(439, 74);
            this.DeleteServiceButton.Name = "DeleteServiceButton";
            this.DeleteServiceButton.Size = new System.Drawing.Size(170, 35);
            this.DeleteServiceButton.TabIndex = 2;
            this.DeleteServiceButton.Text = "Delete existing service";
            this.DeleteServiceButton.UseVisualStyleBackColor = true;
            this.DeleteServiceButton.Click += new System.EventHandler(this.service_button_Click);
            // 
            // EditServiceButton
            // 
            this.EditServiceButton.Location = new System.Drawing.Point(439, 115);
            this.EditServiceButton.Name = "EditServiceButton";
            this.EditServiceButton.Size = new System.Drawing.Size(170, 35);
            this.EditServiceButton.TabIndex = 3;
            this.EditServiceButton.Text = "Edit existing service";
            this.EditServiceButton.UseVisualStyleBackColor = true;
            this.EditServiceButton.Click += new System.EventHandler(this.service_button_Click);
            // 
            // ExitServiceButton
            // 
            this.ExitServiceButton.Location = new System.Drawing.Point(439, 403);
            this.ExitServiceButton.Name = "ExitServiceButton";
            this.ExitServiceButton.Size = new System.Drawing.Size(170, 35);
            this.ExitServiceButton.TabIndex = 4;
            this.ExitServiceButton.Text = "Exit";
            this.ExitServiceButton.UseVisualStyleBackColor = true;
            this.ExitServiceButton.Click += new System.EventHandler(this.service_button_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(14, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 20);
            this.label1.TabIndex = 5;
            this.label1.Text = "Code";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(111, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(32, 20);
            this.label2.TabIndex = 6;
            this.label2.Text = "Fee";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(198, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(85, 20);
            this.label3.TabIndex = 7;
            this.label3.Text = "Description";
            // 
            // dataGridViewServices
            // 
            this.dataGridViewServices.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewServices.Location = new System.Drawing.Point(14, 33);
            this.dataGridViewServices.Name = "dataGridViewServices";
            this.dataGridViewServices.RowHeadersWidth = 51;
            this.dataGridViewServices.RowTemplate.Height = 29;
            this.dataGridViewServices.Size = new System.Drawing.Size(409, 405);
            this.dataGridViewServices.TabIndex = 8;
            this.dataGridViewServices.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewServices_CellDoubleClick);
            // 
            // FormServices
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(621, 454);
            this.Controls.Add(this.dataGridViewServices);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ExitServiceButton);
            this.Controls.Add(this.EditServiceButton);
            this.Controls.Add(this.DeleteServiceButton);
            this.Controls.Add(this.addNewServiceButton);
            this.Name = "FormServices";
            this.Text = "FormServices";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewServices)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private Button addNewServiceButton;
        private Button DeleteServiceButton;
        private Button EditServiceButton;
        private Button ExitServiceButton;
        private Label label1;
        private Label label2;
        private Label label3;
        private DataGridView dataGridViewServices;
    }
}