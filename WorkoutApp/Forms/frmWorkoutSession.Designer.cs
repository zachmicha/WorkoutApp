namespace WorkoutApp.Forms
{
    partial class frmWorkoutSession
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
            cmbDayOfTheTraining = new ComboBox();
            label1 = new Label();
            txtExerciseName = new TextBox();
            txtMusclePart = new TextBox();
            txtReps = new TextBox();
            txtSets = new TextBox();
            txtWeight = new TextBox();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
            webBrowserControl = new Microsoft.Web.WebView2.WinForms.WebView2();
            lstBoxOfExercisesPerSelectedDay = new ListBox();
            lblLoggedProfile = new Label();
            btnUpdate = new Button();
            ((System.ComponentModel.ISupportInitialize)webBrowserControl).BeginInit();
            SuspendLayout();
            // 
            // cmbDayOfTheTraining
            // 
            cmbDayOfTheTraining.FormattingEnabled = true;
            cmbDayOfTheTraining.Location = new Point(202, 27);
            cmbDayOfTheTraining.Name = "cmbDayOfTheTraining";
            cmbDayOfTheTraining.Size = new Size(306, 23);
            cmbDayOfTheTraining.TabIndex = 0;
            cmbDayOfTheTraining.SelectedIndexChanged += cmbDayOfTheTraining_SelectedIndexChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(129, 27);
            label1.Name = "label1";
            label1.Size = new Size(60, 15);
            label1.TabIndex = 1;
            label1.Text = "Select day";
            // 
            // txtExerciseName
            // 
            txtExerciseName.Location = new Point(202, 111);
            txtExerciseName.Name = "txtExerciseName";
            txtExerciseName.ReadOnly = true;
            txtExerciseName.Size = new Size(266, 23);
            txtExerciseName.TabIndex = 2;
            // 
            // txtMusclePart
            // 
            txtMusclePart.Location = new Point(202, 149);
            txtMusclePart.Name = "txtMusclePart";
            txtMusclePart.ReadOnly = true;
            txtMusclePart.Size = new Size(266, 23);
            txtMusclePart.TabIndex = 3;
            // 
            // txtReps
            // 
            txtReps.Location = new Point(202, 188);
            txtReps.Name = "txtReps";
            txtReps.Size = new Size(266, 23);
            txtReps.TabIndex = 4;
            // 
            // txtSets
            // 
            txtSets.Location = new Point(202, 230);
            txtSets.Name = "txtSets";
            txtSets.Size = new Size(266, 23);
            txtSets.TabIndex = 5;
            // 
            // txtWeight
            // 
            txtWeight.Location = new Point(202, 271);
            txtWeight.Name = "txtWeight";
            txtWeight.Size = new Size(266, 23);
            txtWeight.TabIndex = 6;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(129, 119);
            label2.Name = "label2";
            label2.Size = new Size(39, 15);
            label2.TabIndex = 7;
            label2.Text = "Name";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(129, 157);
            label3.Name = "label3";
            label3.Size = new Size(69, 15);
            label3.TabIndex = 8;
            label3.Text = "Muscle part";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(129, 196);
            label4.Name = "label4";
            label4.Size = new Size(32, 15);
            label4.TabIndex = 9;
            label4.Text = "Reps";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(129, 238);
            label5.Name = "label5";
            label5.Size = new Size(28, 15);
            label5.TabIndex = 10;
            label5.Text = "Sets";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(129, 279);
            label6.Name = "label6";
            label6.Size = new Size(45, 15);
            label6.TabIndex = 11;
            label6.Text = "Weight";
            // 
            // webBrowserControl
            // 
            webBrowserControl.AllowExternalDrop = true;
            webBrowserControl.CreationProperties = null;
            webBrowserControl.DefaultBackgroundColor = Color.White;
            webBrowserControl.Location = new Point(805, 85);
            webBrowserControl.Name = "webBrowserControl";
            webBrowserControl.Size = new Size(551, 333);
            webBrowserControl.TabIndex = 12;
            webBrowserControl.ZoomFactor = 1D;
            // 
            // lstBoxOfExercisesPerSelectedDay
            // 
            lstBoxOfExercisesPerSelectedDay.FormattingEnabled = true;
            lstBoxOfExercisesPerSelectedDay.ItemHeight = 15;
            lstBoxOfExercisesPerSelectedDay.Location = new Point(93, 349);
            lstBoxOfExercisesPerSelectedDay.Name = "lstBoxOfExercisesPerSelectedDay";
            lstBoxOfExercisesPerSelectedDay.Size = new Size(415, 364);
            lstBoxOfExercisesPerSelectedDay.TabIndex = 13;
            lstBoxOfExercisesPerSelectedDay.SelectedIndexChanged += lstBoxOfExercisesPerSelectedDay_SelectedIndexChanged;
            // 
            // lblLoggedProfile
            // 
            lblLoggedProfile.AutoSize = true;
            lblLoggedProfile.Location = new Point(610, 27);
            lblLoggedProfile.Name = "lblLoggedProfile";
            lblLoggedProfile.Size = new Size(94, 15);
            lblLoggedProfile.TabIndex = 14;
            lblLoggedProfile.Text = "lblLoggedProfile";
            // 
            // btnUpdate
            // 
            btnUpdate.Location = new Point(515, 111);
            btnUpdate.Name = "btnUpdate";
            btnUpdate.Size = new Size(138, 183);
            btnUpdate.TabIndex = 15;
            btnUpdate.Text = "Update";
            btnUpdate.UseVisualStyleBackColor = true;
            btnUpdate.Click += btnUpdate_Click;
            // 
            // frmWorkoutSession
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1389, 746);
            Controls.Add(btnUpdate);
            Controls.Add(lblLoggedProfile);
            Controls.Add(lstBoxOfExercisesPerSelectedDay);
            Controls.Add(webBrowserControl);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(txtWeight);
            Controls.Add(txtSets);
            Controls.Add(txtReps);
            Controls.Add(txtMusclePart);
            Controls.Add(txtExerciseName);
            Controls.Add(label1);
            Controls.Add(cmbDayOfTheTraining);
            Name = "frmWorkoutSession";
            Text = "frmWorkoutSession";
            Load += frmWorkoutSession_Load;
            ((System.ComponentModel.ISupportInitialize)webBrowserControl).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ComboBox cmbDayOfTheTraining;
        private Label label1;
        private TextBox txtExerciseName;
        private TextBox txtMusclePart;
        private TextBox txtReps;
        private TextBox txtSets;
        private TextBox txtWeight;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label6;
        private Microsoft.Web.WebView2.WinForms.WebView2 webBrowserControl;
        private ListBox lstBoxOfExercisesPerSelectedDay;
        private Label lblLoggedProfile;
        private Button btnUpdate;
    }
}