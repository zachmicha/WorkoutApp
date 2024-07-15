using WorkoutApp.Classes;
using WorkoutApp.Forms;

namespace WorkoutApp
{
    public partial class frmMain : Form
    {
        Profile loggedProfile;
        public frmMain(Profile loggedProfile)
        {
            InitializeComponent();
            this.loggedProfile = loggedProfile;
            lblLoggedProfile.Text = this.loggedProfile.ProfileName;
        }
        public frmMain()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            frmAllExercises frmAddEditExercises = new frmAllExercises();
            frmAddEditExercises.ShowDialog();
        }

        private void btnMakeTrainingPlan_Click(object sender, EventArgs e)
        {
            frmMakeTrainingPlan frm = new frmMakeTrainingPlan(loggedProfile);
            frm.ShowDialog();

        }

        private void frmMain_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close(); // Close the form when Esc is pressed
                Application.Exit();
            }
        }

        private void frmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            frmWorkoutSession frm = new(loggedProfile);
            frm.ShowDialog();
        }
    }
}
