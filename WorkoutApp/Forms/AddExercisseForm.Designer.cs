namespace WorkoutApp
{
    partial class AddExercisseForm
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
            txtMusclePart = new TextBox();
            txtName = new TextBox();
            txtLink = new TextBox();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            btnAddNewExercise = new Button();
            btnCancel = new Button();
            label4 = new Label();
            SuspendLayout();
            // 
            // txtMusclePart
            // 
            txtMusclePart.Location = new Point(238, 92);
            txtMusclePart.Name = "txtMusclePart";
            txtMusclePart.Size = new Size(346, 23);
            txtMusclePart.TabIndex = 1;
            // 
            // txtName
            // 
            txtName.Location = new Point(238, 62);
            txtName.Name = "txtName";
            txtName.Size = new Size(346, 23);
            txtName.TabIndex = 0;
            // 
            // txtLink
            // 
            txtLink.Location = new Point(238, 122);
            txtLink.Name = "txtLink";
            txtLink.Size = new Size(346, 23);
            txtLink.TabIndex = 2;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(70, 66);
            label1.Name = "label1";
            label1.Size = new Size(39, 15);
            label1.TabIndex = 8;
            label1.Text = "Name";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(70, 96);
            label2.Name = "label2";
            label2.Size = new Size(117, 15);
            label2.TabIndex = 9;
            label2.Text = "Targeted muscle part";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(70, 126);
            label3.Name = "label3";
            label3.Size = new Size(29, 15);
            label3.TabIndex = 10;
            label3.Text = "Link";
            // 
            // btnAddNewExercise
            // 
            btnAddNewExercise.Location = new Point(70, 192);
            btnAddNewExercise.Name = "btnAddNewExercise";
            btnAddNewExercise.Size = new Size(255, 63);
            btnAddNewExercise.TabIndex = 3;
            btnAddNewExercise.Text = "Add new exercise";
            btnAddNewExercise.UseVisualStyleBackColor = true;
            btnAddNewExercise.Click += btnSave_Click;
            // 
            // btnCancel
            // 
            btnCancel.Location = new Point(329, 192);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(255, 63);
            btnCancel.TabIndex = 4;
            btnCancel.Text = "Cancel";
            btnCancel.UseVisualStyleBackColor = true;
            btnCancel.Click += btnCancel_Click;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.ForeColor = Color.Red;
            label4.Location = new Point(238, 148);
            label4.Name = "label4";
            label4.Size = new Size(317, 15);
            label4.TabIndex = 18;
            label4.Text = "Link have to be <href> link from youtube to work correctly";
            // 
            // AddExercisseForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(693, 357);
            Controls.Add(label4);
            Controls.Add(btnCancel);
            Controls.Add(btnAddNewExercise);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(txtLink);
            Controls.Add(txtName);
            Controls.Add(txtMusclePart);
            KeyPreview = true;
            Name = "AddExercisseForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Add Exercise";
            Load += AddExercisseForm_Load;
            KeyDown += AddExercisseForm_KeyDown;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtMusclePart;
        private TextBox txtName;
        private TextBox txtLink;
        private Label label1;
        private Label label2;
        private Label label3;
        private Button btnAddNewExercise;
        private Button btnCancel;
        private Label label4;
    }
}