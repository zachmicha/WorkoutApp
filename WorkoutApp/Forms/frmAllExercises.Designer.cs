using WorkoutApp.Classes;

namespace WorkoutApp
{
    partial class frmAllExercises
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
            components = new System.ComponentModel.Container();
            exercisesBindingSource = new BindingSource(components);
            exercisesBindingSource1 = new BindingSource(components);
            lstExercises = new ListView();
            ExerciseId = new ColumnHeader();
            Name = new ColumnHeader();
            musclePart = new ColumnHeader();
            videoLink = new ColumnHeader();
            btnAddExercise = new Button();
            btnDeleteExercise = new Button();
            btnEditExercise = new Button();
            webBrowserControl = new Microsoft.Web.WebView2.WinForms.WebView2();
            ((System.ComponentModel.ISupportInitialize)exercisesBindingSource).BeginInit();
            ((System.ComponentModel.ISupportInitialize)exercisesBindingSource1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)webBrowserControl).BeginInit();
            SuspendLayout();
            // 
            // exercisesBindingSource
            // 
            exercisesBindingSource.DataSource = typeof(Exercises);
            // 
            // exercisesBindingSource1
            // 
            exercisesBindingSource1.DataSource = typeof(Exercises);
            // 
            // lstExercises
            // 
            lstExercises.Columns.AddRange(new ColumnHeader[] { ExerciseId, Name, musclePart, videoLink });
            lstExercises.FullRowSelect = true;
            lstExercises.Location = new Point(589, 66);
            lstExercises.Name = "lstExercises";
            lstExercises.Size = new Size(1027, 716);
            lstExercises.TabIndex = 0;
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
            Name.Width = 100;
            // 
            // musclePart
            // 
            musclePart.Text = "Muscle Part";
            musclePart.Width = 100;
            // 
            // videoLink
            // 
            videoLink.Text = "Link";
            videoLink.Width = 250;
            // 
            // btnAddExercise
            // 
            btnAddExercise.Location = new Point(110, 107);
            btnAddExercise.Name = "btnAddExercise";
            btnAddExercise.Size = new Size(411, 82);
            btnAddExercise.TabIndex = 1;
            btnAddExercise.Text = "Add";
            btnAddExercise.UseVisualStyleBackColor = true;
            btnAddExercise.Click += btnAddExercise_Click;
            // 
            // btnDeleteExercise
            // 
            btnDeleteExercise.Location = new Point(110, 208);
            btnDeleteExercise.Name = "btnDeleteExercise";
            btnDeleteExercise.Size = new Size(411, 82);
            btnDeleteExercise.TabIndex = 2;
            btnDeleteExercise.Text = "Delete";
            btnDeleteExercise.UseVisualStyleBackColor = true;
            btnDeleteExercise.Click += btnDeleteExercise_Click;
            // 
            // btnEditExercise
            // 
            btnEditExercise.Location = new Point(110, 313);
            btnEditExercise.Name = "btnEditExercise";
            btnEditExercise.Size = new Size(411, 82);
            btnEditExercise.TabIndex = 3;
            btnEditExercise.Text = "Edit";
            btnEditExercise.UseVisualStyleBackColor = true;
            btnEditExercise.Click += btnEditExercise_Click;
            // 
            // webBrowserControl
            // 
            webBrowserControl.AllowExternalDrop = true;
            webBrowserControl.CreationProperties = null;
            webBrowserControl.DefaultBackgroundColor = Color.White;
            webBrowserControl.Location = new Point(22, 449);
            webBrowserControl.Name = "webBrowserControl";
            webBrowserControl.Size = new Size(551, 333);
            webBrowserControl.TabIndex = 4;
            webBrowserControl.ZoomFactor = 1D;
            // 
            // frmAllExercises
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1650, 840);
            Controls.Add(webBrowserControl);
            Controls.Add(btnEditExercise);
            Controls.Add(btnDeleteExercise);
            Controls.Add(btnAddExercise);
            Controls.Add(lstExercises);
            KeyPreview = true;
            StartPosition = FormStartPosition.CenterScreen;
            Load += frmAllExercises_Load;
            KeyDown += frmAllExercises_KeyDown;
            ((System.ComponentModel.ISupportInitialize)exercisesBindingSource).EndInit();
            ((System.ComponentModel.ISupportInitialize)exercisesBindingSource1).EndInit();
            ((System.ComponentModel.ISupportInitialize)webBrowserControl).EndInit();
            ResumeLayout(false);
        }



        #endregion
        private BindingSource exercisesBindingSource;
        private BindingSource exercisesBindingSource1;
        private ListView lstExercises;
        private ColumnHeader ExerciseId;
        private ColumnHeader Name;
        private ColumnHeader musclePart;
        private ColumnHeader videoLink;
        private Button btnAddExercise;
        private Button btnDeleteExercise;
        private Button btnEditExercise;
        private Microsoft.Web.WebView2.WinForms.WebView2 webBrowserControl;
    }
}