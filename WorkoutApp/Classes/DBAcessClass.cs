using Dapper;
using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace WorkoutApp.Classes
{
    public class DBAcessClass
    {
        //public static string CheckAllProfiles()
        //{
        //    string profiles = "";

        //    using (var connection = new SqliteConnection(LoadConnectionString()))
        //    {
        //        connection.Open();
        //        var command = connection.CreateCommand();
        //        command.CommandText =
        //        command.CommandText= @"SELECT * FROM Profile";
        //        using (var reader = command.ExecuteReader())
        //        {
        //            while (reader.Read())
        //            {
        //                profiles += reader.GetString(1) + "\n";
        //            }
        //        }
        //    }
        //    return profiles;
        //}
        public static bool IsLoginValid(string userName, string password, Profile loggedProfile)
        {
            bool isValid=false;
            using (var connection = new SqliteConnection(LoadConnectionString()))
            {
                connection.Open();
                string query =
                    @"SELECT COUNT(1) FROM profile WHERE Name=@userName AND password=@password";
               using( SqliteCommand command=new SqliteCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@userName", userName);
                    command.Parameters.AddWithValue("@password", password);
                    int count = Convert.ToInt32(command.ExecuteScalar());
                    isValid = (count > 0);
                    if (isValid==true)
                    {
                        string detailsQuery =
                @"SELECT Id, Name FROM profile WHERE Name=@userName AND password=@password";
                        using (SqliteCommand detailsCommand = new SqliteCommand(detailsQuery, connection))
                        {
                            detailsCommand.Parameters.AddWithValue("@userName", userName);
                            detailsCommand.Parameters.AddWithValue("@password", password);
                            using (var reader = detailsCommand.ExecuteReader())
                            {
                                while (reader.Read())
                                {
                                    loggedProfile.Id = reader.GetInt32(0);
                                    loggedProfile.ProfileName = reader.GetString(1);
                                    loggedProfile.ProfilePassword = "Secret hehe";
                                }
                            }
                        }
                       
                    }
                }
            }
            return isValid;
        }

        public static bool CreateAccount(string username, string password)
        {
            bool isCreated = false;

            using (var connection = new SqliteConnection(LoadConnectionString()))
            {
                connection.Open();

                // Check if the username already exists
                string checkQuery = "SELECT COUNT(1) FROM Profile WHERE Name=@username";
                using (SqliteCommand checkCommand = new SqliteCommand(checkQuery, connection))
                {
                    checkCommand.Parameters.AddWithValue("@username", username);
                    int userExists = Convert.ToInt32(checkCommand.ExecuteScalar());

                    if (userExists > 0)
                    {
                        // Username already exists
                        return false;
                    }
                }

                // Insert the new account into the profile table
                string insertQuery = "INSERT INTO Profile (Name, password) VALUES (@username, @password)";
                using (SqliteCommand insertCommand = new SqliteCommand(insertQuery, connection))
                {
                    insertCommand.Parameters.AddWithValue("@username", username);
                    insertCommand.Parameters.AddWithValue("@password", password);

                    int rowsAffected = insertCommand.ExecuteNonQuery();
                    isCreated = (rowsAffected > 0);
                }
            }

            return isCreated;
        }

        public static List<Exercises> LoadExercises()
        {
            List<Exercises> exercisesList = new List<Exercises>();
            using (var connection = new SqliteConnection(LoadConnectionString()))
            {
                connection.Open();
                var command = connection.CreateCommand();
                command.CommandText =
                    @"
                        SELECT * FROM Exercises
                     ";
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var exercise = new Exercises
                        {
                            ExerciseId = reader.GetInt32(0),
                            NameOfExercise = reader.GetString(1),
                            TargetedMusclePart = reader.GetString(2),
                            LinkForVideo = reader.GetString(3)
                        };
                        exercisesList.Add(exercise);
                    }
                }
                return exercisesList;
            }
        }

        public static void SaveExercises(Exercises exercises)
        {
            using (IDbConnection cnn = new SqliteConnection(LoadConnectionString()))
            {
                cnn.Execute("insert into Exercises" +
                    " (NameOfExercise,TargetedMusclePart,LinkForVideo,CurrentReps,CurrentSets,FutureReps,CurrentWeight,FutureWeight)" +
                    " values (@NameOfExercise,@TargetedMusclePart,@LinkForVideo,@CurrentReps,@CurrentSets,@FutureReps,@CurrentWeight,@FutureWeight)"
                    , exercises);
            }
        }
        private static string LoadConnectionString(string id = "Default")
        {
            return ConfigurationManager.ConnectionStrings[id].ConnectionString;
        }

        internal static void DeleteAtSpecifiedId(int selectedIdOfExercise)
        {         
            
            using (SqliteConnection cnn = new SqliteConnection(LoadConnectionString()))
            {              
                cnn.Open();
                string query = "DELETE FROM exercises WHERE ExerciseId = @SelectedExerciseId;";
                SqliteCommand command = new SqliteCommand(query,cnn);
                command.Parameters.AddWithValue("@SelectedExerciseId", selectedIdOfExercise);
                command.ExecuteNonQuery();

            }
        }

        internal static int AddNewExerciseToTotalExercises(string nameOfExercise, string targetedMusclePart, string linkForVideo)
        {
            using (SqliteConnection cnn = new SqliteConnection(LoadConnectionString()))
            {
                cnn.Open();
                string query = "INSERT INTO Exercises (NameOfExercise, TargetedMusclePart, LinkForVideo) VALUES (@NameOfExercise, @TargetedMusclePart, @LinkForVideo);";
                SqliteCommand command = new SqliteCommand(query, cnn);
                command.Parameters.AddWithValue("@NameOfExercise", nameOfExercise);
                command.Parameters.AddWithValue("@TargetedMusclePart", targetedMusclePart);
                command.Parameters.AddWithValue("@LinkForVideo", linkForVideo);
                command.ExecuteNonQuery();

                using (SqliteCommand newCommand = new("SELECT ExerciseId FROM Exercises WHERE NameOfExercise= @newExerciseName", cnn))
                {
                    newCommand.Parameters.AddWithValue("@newExerciseName", nameOfExercise);
                   Int64 idOfNewExercise= (Int64) newCommand.ExecuteScalar();
                    return Convert.ToInt32(idOfNewExercise);
                }
            }
        }

        internal static void UpdateExercise(int idOfExercise, string nameOfExercise, string musclePart, string link)
        {

            using (SqliteConnection cnn = new SqliteConnection(LoadConnectionString()))
            {
                cnn.Open();
                string query = "UPDATE Exercises SET NameOfExercise=@nameOfExercise , TargetedMusclePart=@musclePart , LinkForVideo=@link WHERE ExerciseId=@exerciseId";
                SqliteCommand command = new SqliteCommand(query, cnn);
                command.Parameters.AddWithValue("@nameOfExercise", nameOfExercise);
                command.Parameters.AddWithValue("@musclePart", musclePart);
                command.Parameters.AddWithValue("@link", link);
                command.Parameters.AddWithValue("@exerciseId", idOfExercise);
                int rowsAffected=command.ExecuteNonQuery();

                if (rowsAffected>0)
                {
                    MessageBox.Show("Exerccise updated, rows affected:"+rowsAffected);
                }
                else
                {
                    MessageBox.Show("Exercise was not found");
                }
            }

        }

        public static List<int> RetrieveWorkoutNrDaysByProfile(int loggedProfileId)
        {
            string query = @"SELECT DISTINCT NrOfTheWorkoutDay
                            FROM WorkoutPlanTable
                            JOIN WorkoutDaysTable ON WorkoutDaysTable.NrOfTheDay = WorkoutPlanTable.NrOfTheWorkoutDay
                            JOIN ProfileExercises ON ProfileExercises.Id = WorkoutPlanTable.ExerciseIdByProfile
                            WHERE ProfileExercises.ProfileId=@IdOfLoggedProfile;";

            List<int> nrOfDays = new ();
            using (var connection = new SqliteConnection(LoadConnectionString()))
            {
                connection.Open();
                var command = connection.CreateCommand();
                command.CommandText = query;
                command.Parameters.AddWithValue("@IdOfLoggedProfile",loggedProfileId);
                    
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        nrOfDays.Add(reader.GetInt32(0));
                    }
                }
               
            }
            return nrOfDays;
        }

        public static bool CheckForExistanceOfWorkoutDay(int biggestNrOfWorkoutDay)
        {
            
            string query = "SELECT NrOfTheDay from WorkoutDaysTable;";
            List<int> nrOfTotalDays = new();
            using (var connection = new SqliteConnection(LoadConnectionString()))
            {
                connection.Open();
                var command = connection.CreateCommand();
                command.CommandText = query;
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        nrOfTotalDays.Add(reader.GetInt32(0));
                    }
                }
            }
            bool isTheBiggestDayFromComboBoxInDB = nrOfTotalDays.Contains(biggestNrOfWorkoutDay);
            
            return isTheBiggestDayFromComboBoxInDB;
        }

       public static void InsertNewWorkoutDay()
        {
            string query2 = "INSERT INTO WorkoutDaysTable DEFAULT VALUES;";
            using (var connection = new SqliteConnection(LoadConnectionString()))
            {
                connection.Open();
                var command = connection.CreateCommand();
                command.CommandText = query2;
                command.ExecuteNonQuery();
                MessageBox.Show("Created new day in database");                
            }
        }

         public static List<Exercises> LoadExercisesByProfileByDay(int loggedProfileId, int selectedDay)
        {
            List<Exercises> ListOfExercisesByProfileByDay = new();
            string query = @"SELECT Exercises.NameOfExercise FROM ProfileExercises
                            JOIN Exercises ON ProfileExercises.ExercisesId = Exercises.ExerciseId
                            JOIN WorkoutPlanTable ON ProfileExercises.Id = WorkoutPlanTable.ExerciseIdByProfile
                            WHERE NrOfTheWorkoutDay=@SelectedDay AND ProfileId=@LoggedProfileId;";
            using (var connection = new SqliteConnection(LoadConnectionString()))
            {
                var command = new SqliteCommand(query, connection);
                command.Parameters.AddWithValue("@SelectedDay", selectedDay);
                command.Parameters.AddWithValue("@LoggedProfileId", loggedProfileId);
                connection.Open();
                using (var reader=command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var exercise = new Exercises
                        {                           
                            NameOfExercise = reader.GetString(0),        
                        };
                        ListOfExercisesByProfileByDay.Add(exercise);
                    }
                }
                
            }
            return ListOfExercisesByProfileByDay;
        }
        /// <summary>
        /// This method creates new entry in ProfilesExercises table 
        /// (first check with if statement and CheckIfSpecificExerciseExistsInProfileExercises method) to avoid potential errors with inserting new row
        /// (it has to be unique pair key with profileId and exerciseId)
        /// </summary>
        /// <param name="loggedProfileId"> Pass logged profile id</param>
        /// <param name="selectedExerciseIdToBeAddedToProfile"> Pass id of exercise that's gonna be added</param>
        internal static void AddExerciseToTheProfileExercisesTable(int loggedProfileId, int selectedExerciseIdToBeAddedToProfile)
        {
            
            
                string query2 = "INSERT INTO ProfileExercises (ProfileId, ExercisesId) VALUES (@ProfileId, @ExerciseId);";
                using (var connection = new SqliteConnection(LoadConnectionString()))
                {
                    connection.Open();
                    var command = connection.CreateCommand();
                    command.CommandText = query2;
                    command.Parameters.AddWithValue("@ProfileId", loggedProfileId);
                    command.Parameters.AddWithValue("@ExerciseId", selectedExerciseIdToBeAddedToProfile);
                    command.ExecuteNonQuery();
                }
        }
        internal static void GetIdOfExerciseInProfileExercisesTable(int loggedProfileId, int selectedExerciseIdToBeAddedToProfile, out int idOfAddedProfileExercises)
        {
            idOfAddedProfileExercises = -1;
            string readIdOfProfileExercise = @"SELECT Id FROM ProfileExercises
                                               WHERE ProfileId=@LoggedProfile AND ExercisesId=@CreatedExerciseId;";
            using (var connection = new SqliteConnection(LoadConnectionString()))
            {
                var command = new SqliteCommand(readIdOfProfileExercise, connection);
                command.Parameters.AddWithValue("@LoggedProfile", loggedProfileId);
                command.Parameters.AddWithValue("@CreatedExerciseId", selectedExerciseIdToBeAddedToProfile);
                connection.Open();
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        idOfAddedProfileExercises = reader.GetInt32(0);
                    }
                }
            }
        }
        /// <summary>
        /// Use this method to add entry to WorkoutPlanTable, it takes Id that is out parameter 
        /// from GetIdOfExerciseInProfileExercisesTable and selectedDay from combo box
        /// </summary>
        /// <param name="idOfProfileExercises"> Pass out parameter from GetIdOfExerciseInProfileExercisesTable</param>
        /// <param name="selectedDay"> Pass selected day as int (combo box)</param>      
        internal static void AddSelectedExerciseWithSelectedDayToWorkoutPlanTable(int idOfProfileExercises, int selectedDay)
        {
            //first check if idOfProfileExercises1 exists in a given day and if it doesn't then execute the query if it does, show a message
           
                string query = @"INSERT INTO WorkoutPlanTable (NrOfTheWorkoutDay,ExerciseIdByProfile) VALUES(@selectedDay,@ProfileExercisesId);";
                if (idOfProfileExercises >= 1)
                {
                    using (var connection = new SqliteConnection(LoadConnectionString()))
                    {
                        var command = new SqliteCommand(query, connection);
                        command.Parameters.AddWithValue("@selectedDay", selectedDay);
                        command.Parameters.AddWithValue("@ProfileExercisesId", idOfProfileExercises);
                        connection.Open();
                        command.ExecuteNonQuery();
                    }
                }
            
            
          
          
        }
        /// <summary>
        /// Use this method to check if exercise exists within ProfileExercises table on a currently logged in profile 
        /// </summary>
        /// <param name="profileId"> Logged profile id </param>
        /// <param name="exerciseId"> Selected exercise id </param>
        /// <returns></returns>
       public static bool CheckIfSpecificExerciseExistsInProfileExercises(int profileId, int exerciseId)
        {
            
            long countOfSelectedItem=-1;
            string query = @"SELECT COUNT(Id) FROM ProfileExercises
                            WHERE ProfileId=@ProfileId AND ExercisesId=@ExerciseId ;";
            using (var connection = new SqliteConnection(LoadConnectionString()))
            {
                var command = new SqliteCommand(query, connection);
                
                command.Parameters.AddWithValue("@ProfileId", profileId);
                command.Parameters.AddWithValue("@ExerciseId", exerciseId);
                connection.Open();
                countOfSelectedItem = (Int64)command.ExecuteScalar();
              
            }
            if (countOfSelectedItem >= 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Use this method to check if given exercise already exists in a given day
        /// </summary>
        /// <param name="profileExercisesId">Pass parameter that is ID of exercise from ProfileExercises table</param>
        /// <param name="selectedDay">PAass int of selected day (combo box)</param>
        /// <returns></returns>
        public static bool CheckIfGivenExerciseExistsInWorkoutPlanTable(int profileExercisesId, int selectedDay)
        {
            
            long countOfSelectedItem;
            string query = @"SELECT COUNT(ExerciseIdByProfile) from WorkoutPlanTable
                             WHERE ExerciseIdByProfile=@ProfileExercisesId AND NrOfTheWorkoutDay=@SelectedDay;";
            using (var connection = new SqliteConnection(LoadConnectionString()))
            {
                var command = new SqliteCommand(query, connection);
                command.Parameters.AddWithValue("@ProfileExercisesId", profileExercisesId);
                command.Parameters.AddWithValue("@SelectedDay", selectedDay);
                connection.Open();
                countOfSelectedItem = (Int64)command.ExecuteScalar();

            }
            if (countOfSelectedItem >= 1)
            {
                return true;
            }
           
                return false;
            
        }

        internal static void SelectedExerciseDeleteFromWorkoutPlanDay(int idOfProfileExercises, int selectedDay)
        {
            // it delets entry in a WorkoutPlanDay table with id and selected day attributes

            using (SqliteConnection cnn = new SqliteConnection(LoadConnectionString()))
            {
                cnn.Open();
                string query = "DELETE FROM WorkoutPlanTable WHERE ExerciseIdByProfile = @SelectedExerciseId AND NrOfTheWorkoutDay=@selectedDay;";                
                SqliteCommand command = new SqliteCommand(query, cnn);
                command.Parameters.AddWithValue("@SelectedExerciseId", idOfProfileExercises);
                command.Parameters.AddWithValue("@selectedDay", selectedDay);
                command.ExecuteNonQuery();
                MessageBox.Show("Deleted exercise from a workout day");
            }
        }
        /// <summary>
        /// Use this method  to get Id of Exercise in ProfileExercises by providing logged profile id, and name of exercise
        /// </summary>
        /// <param name="loggedProfileId"></param>
        /// <param name="nameOfExercise"></param>
        /// <returns></returns>
        internal static int GetIdOfExerciseInProfileExercisesTableByName(int loggedProfileId, string? nameOfExercise)
        {     
            int idOfProfileExercises=-1;
            string readIdOfProfileExercise = @"SELECT Id FROM ProfileExercises
                                               JOIN Exercises ON ProfileExercises.ExercisesId=Exercises.ExerciseId
                                               WHERE ProfileId=@LoggedProfile AND Exercises.NameOfExercise=@ExerciseName;";
            using (var connection = new SqliteConnection(LoadConnectionString()))
            {
                var command = new SqliteCommand(readIdOfProfileExercise, connection);
                command.Parameters.AddWithValue("@LoggedProfile", loggedProfileId);
                command.Parameters.AddWithValue("@ExerciseName", nameOfExercise);
                connection.Open();
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        idOfProfileExercises = reader.GetInt32(0);
                    }
                }
            }
            return idOfProfileExercises;
        }

        internal static string GetLinkForVideo(int idOfSelectedExerciseByDayByProfile)
        {
            string linkForVideo = "";
            string query = @"SELECT LinkForVideo from ProfileExercises
                            JOIN Exercises ON Exercises.ExerciseId=ProfileExercises.ExercisesId
                            WHERE ProfileExercises.Id=@ProfileExercisesId;";
            using (var connection = new SqliteConnection(LoadConnectionString()))
            {
                var command = new SqliteCommand(query, connection);
                command.Parameters.AddWithValue("@ProfileExercisesId",idOfSelectedExerciseByDayByProfile);
                connection.Open();
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        linkForVideo = reader.GetString(0);
                    }
                }
            }
            return linkForVideo;
        }

        internal static Exercises ReadRepsSetsWeightNameTargetByProfileExerciseId(int idOfSelectedExerciseByDayByProfile)
        {
            Exercises exercise = new();
            string query = @"SELECT NameOfExercise,TargetedMusclePart,Reps,Sets,Weight from ProfileExercises
                            JOIN Exercises ON Exercises.ExerciseId=ProfileExercises.ExercisesId
                            WHERE ProfileExercises.Id=@ProfileExerciseId;";
            using (var connection = new SqliteConnection(LoadConnectionString()))
            {
                var command = new SqliteCommand(query, connection);
                command.Parameters.AddWithValue("@ProfileExerciseId", idOfSelectedExerciseByDayByProfile);
                connection.Open();
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                         exercise = new Exercises
                        {
                             NameOfExercise = reader.IsDBNull(0) ? null : reader.GetString(0),
                             TargetedMusclePart = reader.IsDBNull(1) ? null : reader.GetString(1),
                             Reps = reader.IsDBNull(2) ? (int?)null : reader.GetInt32(2),
                             Sets = reader.IsDBNull(3) ? (int?)null : reader.GetInt32(3),
                             Weight = reader.IsDBNull(4) ? (int?)null : reader.GetInt32(4)
                         };
                    }
                }
            }
            return exercise;
        }

        internal static void UpdateGivenExerciseValuesOnLoggedProfile(int loggedProfileId, int idOfSelectedExerciseByDayByProfile, int reps, int sets, int weight)
        {
            string query = @"UPDATE ProfileExercises
                            SET Reps = @Reps,
                             Sets = @Sets,
                             Weight = @Weight
                            WHERE Id = @ProfileExerciseId;";
            using (var connection = new SqliteConnection(LoadConnectionString()))
            {
                var command = new SqliteCommand(query, connection);
                command.Parameters.AddWithValue("@ProfileExerciseId", idOfSelectedExerciseByDayByProfile);
                command.Parameters.AddWithValue("@Reps", reps);
                command.Parameters.AddWithValue("@Sets", sets);
                command.Parameters.AddWithValue("@Weight",weight);

                connection.Open();
                command.ExecuteNonQuery();
                MessageBox.Show("Updated values for exercises");
            }
        }
    }
}
