﻿namespace Valenwu
{
    partial class FormPatient
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
            this.add_new_patient = new System.Windows.Forms.Button();
            this.exit_patient_button = new System.Windows.Forms.Button();
            this.SearchBox = new System.Windows.Forms.TextBox();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.view_invoice = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.schedule_patient = new System.Windows.Forms.Button();
            this.delete_patient = new System.Windows.Forms.Button();
            this.edit_patient = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // add_new_patient
            // 
            this.add_new_patient.Location = new System.Drawing.Point(19, 344);
            this.add_new_patient.Name = "add_new_patient";
            this.add_new_patient.Size = new System.Drawing.Size(145, 56);
            this.add_new_patient.TabIndex = 0;
            this.add_new_patient.Text = "Add New Patient";
            this.add_new_patient.UseVisualStyleBackColor = true;
            this.add_new_patient.Click += new System.EventHandler(this.patient_button_Click);
            // 
            // exit_patient_button
            // 
            this.exit_patient_button.Location = new System.Drawing.Point(691, 344);
            this.exit_patient_button.Name = "exit_patient_button";
            this.exit_patient_button.Size = new System.Drawing.Size(145, 56);
            this.exit_patient_button.TabIndex = 1;
            this.exit_patient_button.Text = "Exit";
            this.exit_patient_button.UseVisualStyleBackColor = true;
            this.exit_patient_button.Click += new System.EventHandler(this.patient_button_Click);
            // 
            // SearchBox
            // 
            this.SearchBox.Location = new System.Drawing.Point(415, 26);
            this.SearchBox.Name = "SearchBox";
            this.SearchBox.Size = new System.Drawing.Size(421, 27);
            this.SearchBox.TabIndex = 2;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(19, 24);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(94, 29);
            this.button3.TabIndex = 4;
            this.button3.Text = "Last Name";
            this.button3.UseVisualStyleBackColor = true;
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(119, 24);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(94, 29);
            this.button4.TabIndex = 5;
            this.button4.Text = "P.H.N.";
            this.button4.UseVisualStyleBackColor = true;
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(219, 24);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(94, 29);
            this.button5.TabIndex = 6;
            this.button5.Text = "Phone";
            this.button5.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(19, 72);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(54, 20);
            this.label1.TabIndex = 7;
            this.label1.Text = "Patient";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(219, 72);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(94, 20);
            this.label2.TabIndex = 8;
            this.label2.Text = "Date of Birth";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(415, 72);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(50, 20);
            this.label3.TabIndex = 9;
            this.label3.Text = "Phone";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(565, 72);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(158, 20);
            this.label4.TabIndex = 10;
            this.label4.Text = "Person Health Number";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(353, 29);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(56, 20);
            this.label5.TabIndex = 11;
            this.label5.Text = "Search:";
            // 
            // view_invoice
            // 
            this.view_invoice.Location = new System.Drawing.Point(308, 344);
            this.view_invoice.Name = "view_invoice";
            this.view_invoice.Size = new System.Drawing.Size(134, 56);
            this.view_invoice.TabIndex = 0;
            this.view_invoice.Text = "View Invoice";
            this.view_invoice.UseVisualStyleBackColor = true;
            this.view_invoice.Click += new System.EventHandler(this.patient_button_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(19, 109);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 29;
            this.dataGridView1.Size = new System.Drawing.Size(817, 220);
            this.dataGridView1.TabIndex = 12;
            // 
            // schedule_patient
            // 
            this.schedule_patient.Location = new System.Drawing.Point(448, 344);
            this.schedule_patient.Name = "schedule_patient";
            this.schedule_patient.Size = new System.Drawing.Size(134, 56);
            this.schedule_patient.TabIndex = 14;
            this.schedule_patient.Text = "Schedule Patient";
            this.schedule_patient.UseVisualStyleBackColor = true;
            this.schedule_patient.Click += new System.EventHandler(this.patient_button_Click);
            // 
            // delete_patient
            // 
            this.delete_patient.Location = new System.Drawing.Point(240, 344);
            this.delete_patient.Name = "delete_patient";
            this.delete_patient.Size = new System.Drawing.Size(62, 56);
            this.delete_patient.TabIndex = 16;
            this.delete_patient.Text = "Delete";
            this.delete_patient.UseVisualStyleBackColor = true;
            this.delete_patient.Click += new System.EventHandler(this.patient_button_Click);
            // 
            // edit_patient
            // 
            this.edit_patient.Location = new System.Drawing.Point(170, 344);
            this.edit_patient.Name = "edit_patient";
            this.edit_patient.Size = new System.Drawing.Size(64, 56);
            this.edit_patient.TabIndex = 17;
            this.edit_patient.Text = "Edit";
            this.edit_patient.UseVisualStyleBackColor = true;
            this.edit_patient.Click += new System.EventHandler(this.patient_button_Click);
            // 
            // FormPatient
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(848, 412);
            this.Controls.Add(this.edit_patient);
            this.Controls.Add(this.delete_patient);
            this.Controls.Add(this.schedule_patient);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.view_invoice);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.SearchBox);
            this.Controls.Add(this.exit_patient_button);
            this.Controls.Add(this.add_new_patient);
            this.IsMdiContainer = true;
            this.Name = "FormPatient";
            this.Text = "FormPatient";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Button add_new_patient;
        private Button exit_patient_button;
        private TextBox textBox1;
        private Button button3;
        private Button button4;
        private Button button5;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Button view_invoice;
        private DataGridView dataGridView1;
        private Button schedule_patient;
        private Button delete_patient;
        private Button edit_patient;
        private TextBox SearchBox;
    }
}