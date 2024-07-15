using Microsoft.Web.WebView2.Core;
using Microsoft.Web.WebView2.WinForms;
using Microsoft.Web.WebView2.Wpf;
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
using WorkoutApp.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace WorkoutApp
{
    public partial class frmAllExercises : Form
    {

        frmAllExercises thisForm;
        List<Exercises> listOfExercises = new();
        private int selectedIndex1;

        int selectedIndex
        {
            get
            {
               
                return selectedIndex1;
            }

            set
            {
                selectedIndex1 = value;               
            }
        }
        public frmAllExercises()
        {
            InitializeComponent();
            InitilizeWebView2();
            thisForm = this;
        }
        private async Task InitilizeWebView2()
        {           
            await webBrowserControl.EnsureCoreWebView2Async(null);
        }
        private async void frmAllExercises_Load(object sender, EventArgs e)
        {
            LoadExercisesToTheListView();
            
        }

     

        private void btnDeleteExercise_Click(object sender, EventArgs e)
        {
            ListViewItem selectedItem = lstExercises.SelectedItems[0];
            string selectedId = selectedItem.SubItems[0].Text;
            DBAcessClass.DeleteAtSpecifiedId(Convert.ToInt32(selectedId));
            lstExercises.Items.Remove(selectedItem);
        }

        private void btnAddExercise_Click(object sender, EventArgs e)
        {
            AddExercisseForm frm = new AddExercisseForm(thisForm);
            frm.ShowDialog();
        }

        private void btnEditExercise_Click(object sender, EventArgs e)
        {
            try
            {
                if (lstExercises.SelectedItems.Count > 0)
                {
                    ListViewItem selectedItem = lstExercises.SelectedItems[0];

                string selectedId = selectedItem.SubItems[0].Text;
                string selectedName = selectedItem.SubItems[1].Text;
                string selectedMusclePart = selectedItem.SubItems[2].Text;
                string selectedLink = selectedItem.SubItems[3].Text;
                
                    var editExercisesForm = new frmEditExercise(selectedId, selectedName, selectedMusclePart, selectedLink, thisForm);
                    editExercisesForm.ShowDialog();
                }
                else
                {
                    MessageBox.Show("Select item from the list that you want to edit first");
                }
            }
            catch (Exception)
            {
                MessageBox.Show("There was some error");                
            }
           
          
        }

       
        private void lstExercises_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstExercises.SelectedItems.Count > 0)
            {
                ListViewItem selectedItem = lstExercises.SelectedItems[0];

                string selectedId = selectedItem.SubItems[0].Text;
                string selectedName = selectedItem.SubItems[1].Text;
                string selectedMusclePart = selectedItem.SubItems[2].Text;
                string selectedLink = selectedItem.SubItems[3].Text;

                selectedIndex = Int32.Parse(selectedId);

                //MessageBox.Show("Selected items are: \n"+selectedId+ $"\n {selectedName} \n {selectedMusclePart} \n {selectedLink}");

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
                {selectedLink}
            </body>
            </html>";
                webBrowserControl.CoreWebView2.NavigateToString(html);


            }
        }


        #region GeneralUsabilityMethods
        private void LoadExercisesToTheListView()
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
        }
        public void AddExerciseToListView(int exerciseId, string nameOfExercise, string targetedMusclePart, string linkForVideo)
        {
            var item = new ListViewItem(exerciseId.ToString());
            item.SubItems.Add(nameOfExercise);
            item.SubItems.Add(targetedMusclePart);
            item.SubItems.Add(linkForVideo);
            item.Tag = new { ExerciseId = exerciseId, NameOfExercise = nameOfExercise, TargetedMusclePart = targetedMusclePart, LinkForVideo = linkForVideo };
            lstExercises.Items.Add(item);
        }
        public void EditExerciseInViewList(int exerciseId, string nameOfExercise, string targetedMusclePart, string linkForVideo)
        {
            
            foreach (ListViewItem item in lstExercises.Items)
            {
                if (item.Text==exerciseId.ToString())
                {
                    item.SubItems[1].Text = nameOfExercise;
                    item.SubItems[2].Text = targetedMusclePart;
                    item.SubItems[3].Text = linkForVideo;
                    item.Tag = new
                    {
                        ExerciseId = exerciseId,
                        NameOfExercise = nameOfExercise,
                        TargetedMusclePart = targetedMusclePart,
                        LinkForVideo = linkForVideo
                    };

                    return;
                }
            }
        }

        private void frmAllExercises_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }

        #endregion
    }
}
