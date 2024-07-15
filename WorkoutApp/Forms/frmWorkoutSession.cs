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
    public partial class frmWorkoutSession : Form
    {
        private List<Exercises> listOfExercises;
        Profile loggedProfile;
        private int selectedDay;
        List<Exercises> listOfExercisesByProfileByDay = new();
        public frmWorkoutSession(Profile loggedProfile)
        {
            this.loggedProfile = loggedProfile;
            InitializeComponent();
            InitilizeWebView2();
        }

        public int selectedIndex { get; private set; }

        private async Task InitilizeWebView2()
        {
            await webBrowserControl.EnsureCoreWebView2Async(null);
        }

        //TO DO: add code so it loads links to the webview item
        private void lstBoxOfExercisesPerSelectedDay_SelectedIndexChanged(object sender, EventArgs e)
        {
            string nameOfExercise="";
            //getting name of exercise and finding id of it in ProfileExercises table
            if (lstBoxOfExercisesPerSelectedDay.SelectedItem !=null)
            {
                 nameOfExercise = lstBoxOfExercisesPerSelectedDay.SelectedItem.ToString();
            }
            
            if (nameOfExercise != "")
            {
                int idOfSelectedExerciseByDayByProfile = DBAcessClass.GetIdOfExerciseInProfileExercisesTableByName(loggedProfile.Id, nameOfExercise);
                //after that we need query that will take that data and in joined table from ProfileExercises will find link and display it
                string linkForVideo = DBAcessClass.GetLinkForVideo(idOfSelectedExerciseByDayByProfile);
                string html = $@"
            <html>
            <head>
                <style>
                    body, html {{
                        margin: 0;
                        padding: 0;
                        width: 100%;
                        height: 100%;
                        overflow: hidden;
                    }}
                    iframe {{
                        width: 100%;
                        height: 100%;
                        border: none;
                    }}
                </style>
            </head>
            <body>
                {linkForVideo}
            </body>
            </html>";
                if (linkForVideo != "")
                {
                    webBrowserControl.CoreWebView2.NavigateToString(html);
                }
                //TO DO: Populate all the text fields with data
                Exercises exercise = DBAcessClass.ReadRepsSetsWeightNameTargetByProfileExerciseId(idOfSelectedExerciseByDayByProfile);
                txtExerciseName.Text = exercise.NameOfExercise;
                txtMusclePart.Text = exercise.TargetedMusclePart;
                txtReps.Text = exercise.Reps.ToString();
                txtSets.Text = exercise.Sets.ToString();
                txtWeight.Text = exercise.Weight.ToString();
            }
            else
            {
                MessageBox.Show("Select exercise first");
            }
        }



        private void PopulateComboBox()
        {
            List<int> DaysList = DBAcessClass.RetrieveWorkoutNrDaysByProfile(loggedProfile.Id);
            foreach (var item in DaysList)
            {
                cmbDayOfTheTraining.Items.Add(item);
            }

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

        private void frmWorkoutSession_Load(object sender, EventArgs e)
        {
            listOfExercises = DBAcessClass.LoadExercises();
            lblLoggedProfile.Text = loggedProfile.ProfileName;
            PopulateComboBox();

        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            string nameOfExercise = "";
            if (lstBoxOfExercisesPerSelectedDay.SelectedItem != null)
            {
                nameOfExercise = lstBoxOfExercisesPerSelectedDay.SelectedItem.ToString();
            }
            
            int idOfSelectedExerciseByDayByProfile = DBAcessClass.GetIdOfExerciseInProfileExercisesTableByName(loggedProfile.Id, nameOfExercise);
            //To DO Update exercise values on Reps Sets Weight on a given profile
            if (nameOfExercise!="")
            {
                bool isNumericValue = false;
                int reps=0;
                int sets=0;
                int weight=0;
                isNumericValue = int.TryParse(txtReps.Text, out reps) &&
                                 int.TryParse(txtSets.Text, out sets) &&
                                 int.TryParse(txtWeight.Text, out weight);

                if (isNumericValue==true)
                {
                    DBAcessClass.UpdateGivenExerciseValuesOnLoggedProfile(loggedProfile.Id, idOfSelectedExerciseByDayByProfile,reps,sets,weight);
                }
                else
                {
                    MessageBox.Show("Make sure values for reps, sets and weight are numeric");
                }
                
            }
           
        }
    }
}
