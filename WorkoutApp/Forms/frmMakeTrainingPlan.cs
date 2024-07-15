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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace WorkoutApp.Forms
{
    public partial class frmMakeTrainingPlan : Form
    {
        List<Exercises> listOfExercises = new();
        List<Exercises> listOfExercisesByProfileByDay = new();
        //private int selectedIndex1;
        Profile loggedProfile;
        private int selectedDay;
        int selectedExerciseIdToBeAddedToProfile;
        //public int selectedIndex
        //{
        //    get
        //    {

        //        return selectedIndex1;
        //    }

        //    set
        //    {
        //        selectedIndex1 = value;

        //    }
        //}
        public frmMakeTrainingPlan(Profile loggedProfile)
        {
            this.loggedProfile = loggedProfile;
            InitializeComponent();
            lblProfileName.Text = this.loggedProfile.ProfileName;
        }
        public frmMakeTrainingPlan()
        {
            InitializeComponent();
        }

        private void frmMakeTrainingPlan_Load(object sender, EventArgs e)
        {
            listOfExercises = DBAcessClass.LoadExercises();
            foreach (var exercise in listOfExercises)
            {
                var item = new ListViewItem(exercise.ExerciseId.ToString());
                item.SubItems.Add(exercise.NameOfExercise);
                item.SubItems.Add(exercise.TargetedMusclePart);
                item.SubItems.Add(exercise.LinkForVideo);
                item.Tag = exercise;
                lstExercises.Items.Add(item);
            }
            PopulateComboBox();

        }

        private void PopulateComboBox()
        {
            List<int> DaysList = DBAcessClass.RetrieveWorkoutNrDaysByProfile(loggedProfile.Id);
            foreach (var item in DaysList)
            {
                cmbDayOfTheTraining.Items.Add(item);
            }

        }

        private void btnCreateNewTrainingDay_Click(object sender, EventArgs e)
        {

            int biggestNrOfWorkoutDay = FindMaxValueInComboBox();
            cmbDayOfTheTraining.Items.Add(biggestNrOfWorkoutDay + 1);
            if (!DBAcessClass.CheckForExistanceOfWorkoutDay(biggestNrOfWorkoutDay + 1))
            {
                DBAcessClass.InsertNewWorkoutDay();
            }


        }

        private int FindMaxValueInComboBox()
        {
            int maxValue = int.MinValue;

            foreach (var item in cmbDayOfTheTraining.Items)
            {
                if (int.TryParse(item.ToString(), out int value))
                {
                    if (value > maxValue)
                    {
                        maxValue = value;
                    }
                }
            }

            return maxValue;
        }

        private void cmbDayOfTheTraining_SelectedIndexChanged(object sender, EventArgs e)
        {
            //it's working correctly
            FillTheListBoxWithExercisesByProfileByDay();
        }

        private void FillTheListBoxWithExercisesByProfileByDay()
        {
            if (cmbDayOfTheTraining.SelectedItem != null)
            {
                //first clear the listbox so no duplicates
                lstBoxOfExercisesPerSelectedDay.Items.Clear();
                selectedDay = (int)cmbDayOfTheTraining.SelectedItem;
                // MessageBox.Show($"Selected day: {selectedDay}");
                listOfExercisesByProfileByDay = DBAcessClass.LoadExercisesByProfileByDay(loggedProfile.Id, selectedDay);
                foreach (var exercise in listOfExercisesByProfileByDay)
                {
                    lstBoxOfExercisesPerSelectedDay.Items.Add(exercise.NameOfExercise);
                }
            }
        }

        private void btnAddToTheTrainingDay_Click(object sender, EventArgs e)
        {
            bool doesTheListNeedToRefresh = false;
            int idOfProfileExercises;

            //checking if selected exercise is already in ProfileExercises table if not add it
            if (selectedDay>=1)
            {
                if (DBAcessClass.CheckIfSpecificExerciseExistsInProfileExercises(loggedProfile.Id, selectedExerciseIdToBeAddedToProfile) == false)
                {
                    //if that profile DO NOT exists then add it to the ProfileExercisesTable:
                    DBAcessClass.AddExerciseToTheProfileExercisesTable(loggedProfile.Id, selectedExerciseIdToBeAddedToProfile);
                    doesTheListNeedToRefresh = true;
                }
                //sets the id of that exercise to a variable
                DBAcessClass.GetIdOfExerciseInProfileExercisesTable(loggedProfile.Id, selectedExerciseIdToBeAddedToProfile, out idOfProfileExercises);
                //check if selected exercise is already in a training day if not add it if yes display message
                if (DBAcessClass.CheckIfGivenExerciseExistsInWorkoutPlanTable(idOfProfileExercises, selectedDay) == false)
                {
                    DBAcessClass.AddSelectedExerciseWithSelectedDayToWorkoutPlanTable(idOfProfileExercises, selectedDay);
                    doesTheListNeedToRefresh = true;
                }
                else
                {
                    MessageBox.Show("Exercise already is assigned to this training day");
                }
            }
         
            //refresh the list of exercises on a given day
            if (doesTheListNeedToRefresh)
            {
                FillTheListBoxWithExercisesByProfileByDay();
            }

        }

        private void lstExercises_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstExercises.SelectedItems.Count > 0)
            {
                ListViewItem selectedItem = lstExercises.SelectedItems[0];
                string selectedId = selectedItem.SubItems[0].Text;

                if (Int32.TryParse(selectedId, out selectedExerciseIdToBeAddedToProfile))
                {
                    //MessageBox.Show($"Selected Exercise ID: {selectedExerciseIdToBeAddedToProfile}");
                }
                else
                {
                    MessageBox.Show("Invalid ID format.");
                }
            }
        }

        private void btnDeleteExerciseFromGivenDay_Click(object sender, EventArgs e)
        {
            string nameOfExercise=lstBoxOfExercisesPerSelectedDay.SelectedItem.ToString();          
            int idOfSelectedExerciseByDayByProfile = DBAcessClass.GetIdOfExerciseInProfileExercisesTableByName( loggedProfile.Id, nameOfExercise);
            if (idOfSelectedExerciseByDayByProfile>=1)
            {
                DBAcessClass.SelectedExerciseDeleteFromWorkoutPlanDay(idOfSelectedExerciseByDayByProfile, selectedDay);
                FillTheListBoxWithExercisesByProfileByDay();
            }
        }
    }
}
