namespace Valenwu
{
    partial class FormConfirmAppointment
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
            this.formConfirmAppt_date = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.formConfirmAppt_save = new System.Windows.Forms.Button();
            this.formConfirmAppt_cancel = new System.Windows.Forms.Button();
            this.FeeTextbox = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.formConfirmAppt_time = new System.Windows.Forms.DateTimePicker();
            this.formConfirmAppointment_exam_drop_down = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // formConfirmAppt_date
            // 
            this.formConfirmAppt_date.Location = new System.Drawing.Point(86, 37);
            this.formConfirmAppt_date.Name = "formConfirmAppt_date";
            this.formConfirmAppt_date.Size = new System.Drawing.Size(190, 27);
            this.formConfirmAppt_date.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(39, 37);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 20);
            this.label1.TabIndex = 2;
            this.label1.Text = "Date";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(38, 81);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(42, 20);
            this.label2.TabIndex = 3;
            this.label2.Text = "Time";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(322, 42);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(45, 20);
            this.label3.TabIndex = 4;
            this.label3.Text = "Exam";
            // 
            // formConfirmAppt_save
            // 
            this.formConfirmAppt_save.Location = new System.Drawing.Point(329, 142);
            this.formConfirmAppt_save.Name = "formConfirmAppt_save";
            this.formConfirmAppt_save.Size = new System.Drawing.Size(94, 29);
            this.formConfirmAppt_save.TabIndex = 6;
            this.formConfirmAppt_save.Text = "Save";
            this.formConfirmAppt_save.UseVisualStyleBackColor = true;
            this.formConfirmAppt_save.Click += new System.EventHandler(this.formConfirmAppt_save_Click);
            // 
            // formConfirmAppt_cancel
            // 
            this.formConfirmAppt_cancel.Location = new System.Drawing.Point(429, 142);
            this.formConfirmAppt_cancel.Name = "formConfirmAppt_cancel";
            this.formConfirmAppt_cancel.Size = new System.Drawing.Size(94, 29);
            this.formConfirmAppt_cancel.TabIndex = 7;
            this.formConfirmAppt_cancel.Text = "Cancel";
            this.formConfirmAppt_cancel.UseVisualStyleBackColor = true;
            this.formConfirmAppt_cancel.Click += new System.EventHandler(this.formConfirmAppt_save_Click);
            // 
            // FeeTextbox
            // 
            this.FeeTextbox.Location = new System.Drawing.Point(374, 74);
            this.FeeTextbox.Name = "FeeTextbox";
            this.FeeTextbox.ReadOnly = true;
            this.FeeTextbox.Size = new System.Drawing.Size(149, 27);
            this.FeeTextbox.TabIndex = 9;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(335, 74);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(32, 20);
            this.label4.TabIndex = 8;
            this.label4.Text = "Fee";
            // 
            // formConfirmAppt_time
            // 
            this.formConfirmAppt_time.Location = new System.Drawing.Point(86, 76);
            this.formConfirmAppt_time.Name = "formConfirmAppt_time";
            this.formConfirmAppt_time.Size = new System.Drawing.Size(190, 27);
            this.formConfirmAppt_time.TabIndex = 10;
            // 
            // formConfirmAppointment_exam_drop_down
            // 
            this.formConfirmAppointment_exam_drop_down.FormattingEnabled = true;
            this.formConfirmAppointment_exam_drop_down.Location = new System.Drawing.Point(374, 40);
            this.formConfirmAppointment_exam_drop_down.Name = "formConfirmAppointment_exam_drop_down";
            this.formConfirmAppointment_exam_drop_down.Size = new System.Drawing.Size(151, 28);
            this.formConfirmAppointment_exam_drop_down.TabIndex = 11;
            this.formConfirmAppointment_exam_drop_down.SelectedIndexChanged += new System.EventHandler(this.formConfirmAppointment_exam_drop_down_SelectedIndexChanged);
            // 
            // FormConfirmAppointment
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(575, 195);
            this.Controls.Add(this.formConfirmAppointment_exam_drop_down);
            this.Controls.Add(this.formConfirmAppt_time);
            this.Controls.Add(this.FeeTextbox);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.formConfirmAppt_cancel);
            this.Controls.Add(this.formConfirmAppt_save);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.formConfirmAppt_date);
            this.Name = "FormConfirmAppointment";
            this.Text = "FormConfirmAppointment";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private DateTimePicker formConfirmAppt_date;
        private Label label1;
        private Label label2;
        private Label label3;
        private Button formConfirmAppt_save;
        private Button formConfirmAppt_cancel;
        private TextBox FeeTextbox;
        private Label label4;
        private DateTimePicker formConfirmAppt_time;
        private ComboBox formConfirmAppointment_exam_drop_down;
    }
}