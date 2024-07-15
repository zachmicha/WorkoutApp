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
    public partial class AddExercisseForm : Form
    {
        frmAllExercises allExercisesForm;
        public AddExercisseForm(frmAllExercises allExercisesForm)
        {
            InitializeComponent();
            this.allExercisesForm = allExercisesForm;
        }

        private void AddExercisseForm_Load(object sender, EventArgs e)
        {

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            CheckIfFilledForm();
        }

        private void CheckIfFilledForm()
        {
            string errorMessage = "";

            string NameOfExercise = txtName.Text;
            string TargetedMusclePart = txtMusclePart.Text;
            string LinkForVideo = txtLink.Text;


            List<string> allFields = new List<string>{
                NameOfExercise, TargetedMusclePart, LinkForVideo};

            errorMessage += CheckForEmpty(allFields, errorMessage);
            //errorMessage += CheckForDecimalType(decimalStrings, errorMessage);

            if (errorMessage != "")
            {
                MessageBox.Show(errorMessage, "Error");
            }
            else if (errorMessage == "")
            {
                int newExerciseId = DBAcessClass.AddNewExerciseToTotalExercises(NameOfExercise, TargetedMusclePart, LinkForVideo);
                allExercisesForm.AddExerciseToListView(newExerciseId, NameOfExercise, TargetedMusclePart, LinkForVideo);
            }

        }

        //private string CheckForDecimalType(List<string> decimalStrings, string errorMessage)
        //{
        //    bool canBeDecimal=true;
        //    foreach (var item in decimalStrings)
        //    {
        //        canBeDecimal= Decimal.TryParse(item,out _);
        //    }
        //    if (canBeDecimal==false)
        //    {
        //       errorMessage += "Check fields that require numbers \n";
        //    }
        //    return errorMessage;
        //}

        private string CheckForEmpty(List<string> allFields, string errorMessage)
        {
            bool isAnyEmpty = false;
            foreach (string field in allFields)
            {
                if (field == "")
                {
                    isAnyEmpty = true;
                }
            }

            if (isAnyEmpty == true) { return errorMessage += "Check empty fields \n"; }
            return "";

        }

        private void AddExercisseForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                btnCancel.PerformClick();
            }
            else if (e.KeyCode == Keys.Enter)
            {
                btnAddNewExercise.PerformClick();
            }
            
        }
    }
}
