﻿namespace WorkoutApp.Forms
{
    partial class frmMakeTrainingPlan
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
            lblProfileName = new Label();
            cmbDayOfTheTraining = new ComboBox();
            btnCreateNewTrainingDay = new Button();
            lstBoxOfExercisesPerSelectedDay = new ListBox();
            lstExercises = new ListView();
            ExerciseId = new ColumnHeader();
            Name = new ColumnHeader();
            musclePart = new ColumnHeader();
            btnAddToTheTrainingDay = new Button();
            btnDeleteExerciseFromGivenDay = new Button();
            SuspendLayout();
            // 
            // lblProfileName
            // 
            lblProfileName.AutoSize = true;
            lblProfileName.Location = new Point(40, 9);
            lblProfileName.Name = "lblProfileName";
            lblProfileName.Size = new Size(76, 15);
            lblProfileName.TabIndex = 0;
            lblProfileName.Text = "Profile Name";
            // 
            // cmbDayOfTheTraining
            // 
            cmbDayOfTheTraining.FormattingEnabled = true;
            cmbDayOfTheTraining.Location = new Point(509, 50);
            cmbDayOfTheTraining.Name = "cmbDayOfTheTraining";
            cmbDayOfTheTraining.Size = new Size(199, 23);
            cmbDayOfTheTraining.TabIndex = 1;
            cmbDayOfTheTraining.SelectedIndexChanged += cmbDayOfTheTraining_SelectedIndexChanged;
            // 
            // btnCreateNewTrainingDay
            // 
            btnCreateNewTrainingDay.Location = new Point(301, 50);
            btnCreateNewTrainingDay.Name = "btnCreateNewTrainingDay";
            btnCreateNewTrainingDay.Size = new Size(191, 23);
            btnCreateNewTrainingDay.TabIndex = 2;
            btnCreateNewTrainingDay.Text = "Create new training day";
            btnCreateNewTrainingDay.UseVisualStyleBackColor = true;
            btnCreateNewTrainingDay.Click += btnCreateNewTrainingDay_Click;
            // 
            // lstBoxOfExercisesPerSelectedDay
            // 
            lstBoxOfExercisesPerSelectedDay.FormattingEnabled = true;
            lstBoxOfExercisesPerSelectedDay.ItemHeight = 15;
            lstBoxOfExercisesPerSelectedDay.Location = new Point(40, 105);
            lstBoxOfExercisesPerSelectedDay.Name = "lstBoxOfExercisesPerSelectedDay";
            lstBoxOfExercisesPerSelectedDay.Size = new Size(415, 574);
            lstBoxOfExercisesPerSelectedDay.TabIndex = 3;
            // 
            // lstExercises
            // 
            lstExercises.Columns.AddRange(new ColumnHeader[] { ExerciseId, Name, musclePart });
            lstExercises.FullRowSelect = true;
            lstExercises.Location = new Point(509, 105);
            lstExercises.Name = "lstExercises";
            lstExercises.Size = new Size(496, 576);
            lstExercises.TabIndex = 4;
            lstExercises.UseCompatibleStateImageBehavior = false;
            lstExercises.View = View.Details;
            lstExercises.SelectedIndexChanged += lstExercises_SelectedIndexChanged;
            // 
            // ExerciseId
            // 
            ExerciseId.Text = "Id";
            // 
            // Name
            // 
            Name.Text = "Name";
            Name.Width = 150;
            // 
            // musclePart
            // 
            musclePart.Text = "Muscle Part";
            musclePart.Width = 300;
            // 
            // btnAddToTheTrainingDay
            // 
            btnAddToTheTrainingDay.Location = new Point(509, 703);
            btnAddToTheTrainingDay.Name = "btnAddToTheTrainingDay";
            btnAddToTheTrainingDay.Size = new Size(496, 23);
            btnAddToTheTrainingDay.TabIndex = 5;
            btnAddToTheTrainingDay.Text = "Add exercise to the training day";
            btnAddToTheTrainingDay.UseVisualStyleBackColor = true;
            btnAddToTheTrainingDay.Click += btnAddToTheTrainingDay_Click;
            // 
            // btnDeleteExerciseFromGivenDay
            // 
            btnDeleteExerciseFromGivenDay.Location = new Point(40, 706);
            btnDeleteExerciseFromGivenDay.Name = "btnDeleteExerciseFromGivenDay";
            btnDeleteExerciseFromGivenDay.Size = new Size(415, 23);
            btnDeleteExerciseFromGivenDay.TabIndex = 6;
            btnDeleteExerciseFromGivenDay.Text = "Delete exercise from a day";
            btnDeleteExerciseFromGivenDay.UseVisualStyleBackColor = true;
            btnDeleteExerciseFromGivenDay.Click += btnDeleteExerciseFromGivenDay_Click;
            // 
            // frmMakeTrainingPlan
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1043, 748);
            Controls.Add(btnDeleteExerciseFromGivenDay);
            Controls.Add(btnAddToTheTrainingDay);
            Controls.Add(lstExercises);
            Controls.Add(lstBoxOfExercisesPerSelectedDay);
            Controls.Add(btnCreateNewTrainingDay);
            Controls.Add(cmbDayOfTheTraining);
            Controls.Add(lblProfileName);
            StartPosition = FormStartPosition.CenterScreen;
            Text = "frmMakeTrainingPlan";
            Load += frmMakeTrainingPlan_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblProfileName;
        private ComboBox cmbDayOfTheTraining;
        private Button btnCreateNewTrainingDay;
        private ListBox lstBoxOfExercisesPerSelectedDay;
        private ListView lstExercises;
        private ColumnHeader ExerciseId;
        private ColumnHeader Name;
        private ColumnHeader musclePart;
        private Button btnAddToTheTrainingDay;
        private Button btnDeleteExerciseFromGivenDay;
    }
}