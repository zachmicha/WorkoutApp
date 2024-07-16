using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WorkoutApp.Classes;

namespace WorkoutApp
{
    public partial class LoginForm : Form
    {
        Profile loggedProfile = new();
        public LoginForm()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtProfileName.Text;
            string password = txtProfilePassword.Text;

            if (DBAcessClass.IsLoginValid(username, password, loggedProfile))
            {
                MessageBox.Show("Login successful");               
                frmMain newMainForm = new frmMain(loggedProfile);

                this.Close();
                newMainForm.Show();
                

            }
            else
            {
                MessageBox.Show("Wrong username or password");
            }

        }

        private void btnCreateAccount_Click(object sender, EventArgs e)
        {
            string username = txtProfileName.Text;
            string password = txtProfilePassword.Text;
            if (DBAcessClass.CreateAccount(username, password))
            {
                MessageBox.Show("Account was created");
            }
            else
            {
                MessageBox.Show("Something went wrong");
            }
        }

        private void LoginForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close(); // Close the form when Esc is pressed
                Application.Exit();
            }
            else if (e.KeyCode == Keys.Enter)
            {
                // Trigger the click event of the Login button when Enter is pressed
                btnLogin.PerformClick();
            }
        }
    }
}
