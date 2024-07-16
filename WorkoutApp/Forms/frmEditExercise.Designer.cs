namespace WorkoutApp.Forms
{
    partial class frmEditExercise
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
            txtId = new TextBox();
            txtName = new TextBox();
            txtMusclePart = new TextBox();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            txtLink = new TextBox();
            btnSaveChanges = new Button();
            btnClose = new Button();
            SuspendLayout();
            // 
            // txtId
            // 
            txtId.Enabled = false;
            txtId.Location = new Point(225, 68);
            txtId.Name = "txtId";
            txtId.ReadOnly = true;
            txtId.Size = new Size(319, 23);
            txtId.TabIndex = 0;
            // 
            // txtName
            // 
            txtName.Location = new Point(225, 101);
            txtName.Name = "txtName";
            txtName.Size = new Size(319, 23);
            txtName.TabIndex = 1;
            // 
            // txtMusclePart
            // 
            txtMusclePart.Location = new Point(225, 136);
            txtMusclePart.Name = "txtMusclePart";
            txtMusclePart.Size = new Size(319, 23);
            txtMusclePart.TabIndex = 2;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(150, 71);
            label1.Name = "label1";
            label1.Size = new Size(20, 15);
            label1.TabIndex = 6;
            label1.Text = "Id:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(148, 109);
            label2.Name = "label2";
            label2.Size = new Size(39, 15);
            label2.TabIndex = 7;
            label2.Text = "Name";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(146, 144);
            label3.Name = "label3";
            label3.Size = new Size(69, 15);
            label3.TabIndex = 8;
            label3.Text = "Muscle part";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(150, 180);
            label4.Name = "label4";
            label4.Size = new Size(29, 15);
            label4.TabIndex = 9;
            label4.Text = "Link";
            // 
            // txtLink
            // 
            txtLink.Location = new Point(225, 172);
            txtLink.Name = "txtLink";
            txtLink.Size = new Size(319, 23);
            txtLink.TabIndex = 3;
            // 
            // btnSaveChanges
            // 
            btnSaveChanges.Location = new Point(225, 229);
            btnSaveChanges.Name = "btnSaveChanges";
            btnSaveChanges.Size = new Size(148, 23);
            btnSaveChanges.TabIndex = 4;
            btnSaveChanges.Text = "Save changes";
            btnSaveChanges.UseVisualStyleBackColor = true;
            btnSaveChanges.Click += btnSaveChanges_Click;
            // 
            // btnClose
            // 
            btnClose.Location = new Point(469, 229);
            btnClose.Name = "btnClose";
            btnClose.Size = new Size(75, 23);
            btnClose.TabIndex = 5;
            btnClose.Text = "Close";
            btnClose.UseVisualStyleBackColor = true;
            btnClose.Click += btnClose_Click;
            // 
            // frmEditExercise
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btnClose);
            Controls.Add(btnSaveChanges);
            Controls.Add(txtLink);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(txtMusclePart);
            Controls.Add(txtName);
            Controls.Add(txtId);
            KeyPreview = true;
            Name = "frmEditExercise";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Edit exercises";
            Load += frmEditExercise_Load;
            KeyDown += frmEditExercise_KeyDown;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtId;
        private TextBox txtName;
        private TextBox txtMusclePart;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private TextBox txtLink;
        private Button btnSaveChanges;
        private Button btnClose;
    }
}