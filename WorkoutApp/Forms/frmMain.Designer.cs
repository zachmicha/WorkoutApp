namespace WorkoutApp
{
    partial class frmMain
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            btnMakeTrainingPlan = new Button();
            button2 = new Button();
            button3 = new Button();
            pictureBox1 = new PictureBox();
            lblLoggedProfile = new Label();
            label1 = new Label();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // btnMakeTrainingPlan
            // 
            btnMakeTrainingPlan.Location = new Point(451, 612);
            btnMakeTrainingPlan.Name = "btnMakeTrainingPlan";
            btnMakeTrainingPlan.Size = new Size(210, 135);
            btnMakeTrainingPlan.TabIndex = 0;
            btnMakeTrainingPlan.Text = "Make a training plan";
            btnMakeTrainingPlan.UseVisualStyleBackColor = true;
            btnMakeTrainingPlan.Click += btnMakeTrainingPlan_Click;
            // 
            // button2
            // 
            button2.Location = new Point(725, 612);
            button2.Name = "button2";
            button2.Size = new Size(210, 135);
            button2.TabIndex = 1;
            button2.Text = "Workout session";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // button3
            // 
            button3.Location = new Point(176, 612);
            button3.Name = "button3";
            button3.Size = new Size(210, 135);
            button3.TabIndex = 2;
            button3.Text = "Add/Edit exercises";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(176, 21);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(759, 572);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 3;
            pictureBox1.TabStop = false;
            // 
            // lblLoggedProfile
            // 
            lblLoggedProfile.AutoSize = true;
            lblLoggedProfile.ForeColor = Color.LimeGreen;
            lblLoggedProfile.Location = new Point(958, 102);
            lblLoggedProfile.Name = "lblLoggedProfile";
            lblLoggedProfile.Size = new Size(38, 15);
            lblLoggedProfile.TabIndex = 4;
            lblLoggedProfile.Text = "label1";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 238);
            label1.Location = new Point(958, 69);
            label1.Name = "label1";
            label1.Size = new Size(114, 21);
            label1.TabIndex = 5;
            label1.Text = "Logged Profile:";
            // 
            // frmMain
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(1184, 761);
            Controls.Add(label1);
            Controls.Add(lblLoggedProfile);
            Controls.Add(pictureBox1);
            Controls.Add(button3);
            Controls.Add(button2);
            Controls.Add(btnMakeTrainingPlan);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            KeyPreview = true;
            Name = "frmMain";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Workout App";
            FormClosing += frmMain_FormClosing;
            KeyDown += frmMain_KeyDown;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnMakeTrainingPlan;
        private Button button2;
        private Button button3;
        private PictureBox pictureBox1;
        private Label lblLoggedProfile;
        private Label label1;
    }
}
