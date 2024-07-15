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

namespace WorkoutApp.Forms
{
    public partial class frmEditExercise : Form
    {
        frmAllExercises allExercisesForm;
        string selectedId;
        string selectedName;
        string selectedMusclePart;
        string selectedLink;
        public frmEditExercise()
        {
            InitializeComponent();
        }
        public frmEditExercise(string selectedId, string selectedName, string selectedMusclePart, string selectedLink, frmAllExercises allExercisesFormReference)
        {
            InitializeComponent();
            allExercisesForm = allExercisesFormReference;
            this.selectedId = selectedId;
            this.selectedName = selectedName;
            this.selectedMusclePart = selectedMusclePart;
            this.selectedLink = selectedLink;
        }
        private void frmEditExercise_Load(object sender, EventArgs e)
        {
            LoadTheTextBoxesWithData();
        }



        void LoadTheTextBoxesWithData()
        {
            txtId.Text = selectedId;
            txtName.Text = selectedName;
            txtMusclePart.Text = selectedMusclePart;
            txtLink.Text = selectedLink;
        }

        private void btnSaveChanges_Click(object sender, EventArgs e)
        {
            int idOfExercise = Convert.ToInt32(txtId.Text);
            string nameOfExercise = txtName.Text;
            string musclePart = txtMusclePart.Text;
            string link = txtLink.Text;

            DBAcessClass.UpdateExercise(idOfExercise, nameOfExercise, musclePart, link);
            allExercisesForm.EditExerciseInViewList(idOfExercise, nameOfExercise, musclePart, link);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmEditExercise_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
            else if (e.KeyCode == Keys.Enter)
            {
                btnSaveChanges.PerformClick();
            }
        }
    }
}
