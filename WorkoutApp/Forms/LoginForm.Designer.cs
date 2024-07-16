namespace WorkoutApp
{
    partial class LoginForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LoginForm));
            label1 = new Label();
            label2 = new Label();
            txtProfileName = new TextBox();
            txtProfilePassword = new TextBox();
            label3 = new Label();
            pictureBox1 = new PictureBox();
            btnLogin = new Button();
            btnCreateAccount = new Button();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(340, 515);
            label1.Name = "label1";
            label1.Size = new Size(79, 15);
            label1.TabIndex = 5;
            label1.Text = "Profile Name:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(359, 551);
            label2.Name = "label2";
            label2.Size = new Size(60, 15);
            label2.TabIndex = 6;
            label2.Text = "Password:";
            // 
            // txtProfileName
            // 
            txtProfileName.Location = new Point(425, 507);
            txtProfileName.Name = "txtProfileName";
            txtProfileName.Size = new Size(219, 23);
            txtProfileName.TabIndex = 0;
            // 
            // txtProfilePassword
            // 
            txtProfilePassword.Location = new Point(425, 543);
            txtProfilePassword.Name = "txtProfilePassword";
            txtProfilePassword.Size = new Size(219, 23);
            txtProfilePassword.TabIndex = 1;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Verdana", 20.25F, FontStyle.Bold, GraphicsUnit.Point, 238);
            label3.Location = new Point(477, 456);
            label3.Name = "label3";
            label3.Size = new Size(97, 32);
            label3.TabIndex = 7;
            label3.Text = "Login";
            // 
            // pictureBox1
            // 
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(299, 12);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(410, 407);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 5;
            pictureBox1.TabStop = false;
            // 
            // btnLogin
            // 
            btnLogin.BackColor = SystemColors.Control;
            btnLogin.Font = new Font("Segoe UI", 10F);
            btnLogin.ForeColor = Color.Black;
            btnLogin.Location = new Point(514, 581);
            btnLogin.Name = "btnLogin";
            btnLogin.Size = new Size(130, 39);
            btnLogin.TabIndex = 2;
            btnLogin.Text = "Login";
            btnLogin.UseVisualStyleBackColor = false;
            btnLogin.Click += btnLogin_Click;
            // 
            // btnCreateAccount
            // 
            btnCreateAccount.BackColor = SystemColors.InfoText;
            btnCreateAccount.FlatAppearance.BorderSize = 0;
            btnCreateAccount.ForeColor = Color.YellowGreen;
            btnCreateAccount.Location = new Point(359, 581);
            btnCreateAccount.Name = "btnCreateAccount";
            btnCreateAccount.Size = new Size(149, 39);
            btnCreateAccount.TabIndex = 3;
            btnCreateAccount.Text = "Create account";
            btnCreateAccount.UseVisualStyleBackColor = false;
            btnCreateAccount.Click += btnCreateAccount_Click;
            // 
            // LoginForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1073, 698);
            ControlBox = false;
            Controls.Add(btnCreateAccount);
            Controls.Add(btnLogin);
            Controls.Add(pictureBox1);
            Controls.Add(label3);
            Controls.Add(txtProfilePassword);
            Controls.Add(txtProfileName);
            Controls.Add(label2);
            Controls.Add(label1);
            KeyPreview = true;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "LoginForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Workout App";
            KeyDown += LoginForm_KeyDown;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private TextBox txtProfileName;
        private TextBox txtProfilePassword;
        private Label label3;
        private PictureBox pictureBox1;
        private Button btnLogin;
        private Button btnCreateAccount;
    }
}