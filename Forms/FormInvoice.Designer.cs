namespace Valenwu
{
    partial class FormInvoice
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.ExitInvoiceButton = new System.Windows.Forms.Button();
            this.ClearInvoicesButton = new System.Windows.Forms.Button();
            this.TakeAPaymentButton = new System.Windows.Forms.Button();
            this.NewInvoiceButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.formInvoice_richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.formInvoice_dataGridView = new System.Windows.Forms.DataGridView();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.formInvoice_dataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ControlLight;
            this.panel1.Controls.Add(this.ExitInvoiceButton);
            this.panel1.Controls.Add(this.ClearInvoicesButton);
            this.panel1.Controls.Add(this.TakeAPaymentButton);
            this.panel1.Controls.Add(this.NewInvoiceButton);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.formInvoice_richTextBox1);
            this.panel1.Location = new System.Drawing.Point(445, 17);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(288, 364);
            this.panel1.TabIndex = 0;
            // 
            // ExitInvoiceButton
            // 
            this.ExitInvoiceButton.Location = new System.Drawing.Point(175, 313);
            this.ExitInvoiceButton.Name = "ExitInvoiceButton";
            this.ExitInvoiceButton.Size = new System.Drawing.Size(96, 39);
            this.ExitInvoiceButton.TabIndex = 5;
            this.ExitInvoiceButton.Text = "Exit";
            this.ExitInvoiceButton.UseVisualStyleBackColor = true;
            this.ExitInvoiceButton.Click += new System.EventHandler(this.invoice_button_Click);
            // 
            // ClearInvoicesButton
            // 
            this.ClearInvoicesButton.Location = new System.Drawing.Point(17, 102);
            this.ClearInvoicesButton.Name = "ClearInvoicesButton";
            this.ClearInvoicesButton.Size = new System.Drawing.Size(254, 37);
            this.ClearInvoicesButton.TabIndex = 4;
            this.ClearInvoicesButton.Text = "Clear Invoices";
            this.ClearInvoicesButton.UseVisualStyleBackColor = true;
            this.ClearInvoicesButton.Click += new System.EventHandler(this.invoice_button_Click);
            // 
            // TakeAPaymentButton
            // 
            this.TakeAPaymentButton.Location = new System.Drawing.Point(17, 59);
            this.TakeAPaymentButton.Name = "TakeAPaymentButton";
            this.TakeAPaymentButton.Size = new System.Drawing.Size(254, 37);
            this.TakeAPaymentButton.TabIndex = 3;
            this.TakeAPaymentButton.Text = "Take a payment";
            this.TakeAPaymentButton.UseVisualStyleBackColor = true;
            this.TakeAPaymentButton.Click += new System.EventHandler(this.invoice_button_Click);
            // 
            // NewInvoiceButton
            // 
            this.NewInvoiceButton.Location = new System.Drawing.Point(18, 16);
            this.NewInvoiceButton.Name = "NewInvoiceButton";
            this.NewInvoiceButton.Size = new System.Drawing.Size(254, 37);
            this.NewInvoiceButton.TabIndex = 2;
            this.NewInvoiceButton.Text = "Make a new invoice";
            this.NewInvoiceButton.UseVisualStyleBackColor = true;
            this.NewInvoiceButton.Click += new System.EventHandler(this.invoice_button_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(18, 174);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(119, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "Patient\'s Balance";
            // 
            // formInvoice_richTextBox1
            // 
            this.formInvoice_richTextBox1.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.formInvoice_richTextBox1.Location = new System.Drawing.Point(17, 203);
            this.formInvoice_richTextBox1.Name = "formInvoice_richTextBox1";
            this.formInvoice_richTextBox1.ReadOnly = true;
            this.formInvoice_richTextBox1.Size = new System.Drawing.Size(255, 90);
            this.formInvoice_richTextBox1.TabIndex = 0;
            this.formInvoice_richTextBox1.Text = "";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Cornsilk;
            this.label2.Location = new System.Drawing.Point(14, 17);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(0, 20);
            this.label2.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(146, 17);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(113, 20);
            this.label3.TabIndex = 3;
            this.label3.Text = "Service/Product";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(14, 17);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(54, 20);
            this.label4.TabIndex = 4;
            this.label4.Text = "Patient";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(334, 17);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(93, 20);
            this.label5.TabIndex = 5;
            this.label5.Text = "Amount Due";
            // 
            // formInvoice_dataGridView
            // 
            this.formInvoice_dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.formInvoice_dataGridView.Location = new System.Drawing.Point(12, 51);
            this.formInvoice_dataGridView.Name = "formInvoice_dataGridView";
            this.formInvoice_dataGridView.RowHeadersWidth = 51;
            this.formInvoice_dataGridView.RowTemplate.Height = 29;
            this.formInvoice_dataGridView.Size = new System.Drawing.Size(415, 330);
            this.formInvoice_dataGridView.TabIndex = 6;
            // 
            // FormInvoice
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(748, 404);
            this.Controls.Add(this.formInvoice_dataGridView);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.panel1);
            this.Name = "FormInvoice";
            this.Text = "FormInvoice";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.formInvoice_dataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Panel panel1;
        private Button ClearInvoicesButton;
        private Button TakeAPaymentButton;
        private Button NewInvoiceButton;
        private Label label1;
        private RichTextBox formInvoice_richTextBox1;
        private Button ExitInvoiceButton;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private DataGridView formInvoice_dataGridView;
    }
}