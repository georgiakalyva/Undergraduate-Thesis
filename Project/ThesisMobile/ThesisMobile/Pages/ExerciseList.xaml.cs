using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using ThesisMobile.Data;
using ThesisMobile.DataModel;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace ThesisMobile
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class ExerciseList : Page
    {
        List<JExercise> Exercises = new List<JExercise>();
        public ExerciseList()
        {
            this.InitializeComponent();
            Initialize();
        }
        public async void Initialize()
        {
            try { 
            using (var db = SqliteDatabase.DBConnection)
            {
                var ExercisesJson = db.Table<Setting>().Where(x => x.ID == "Exercises").FirstOrDefault().Description;
                Exercises = JsonConvert.DeserializeObject<List<JExercise>>(ExercisesJson).ToList().ToList();
                ExerciseListView.ItemsSource = Exercises;
            }
            }
            catch (Exception)
            {
                var dialog = new MessageDialog("Something went wrong with our services. Please try again.");
                dialog.Commands.Add(new UICommand("OK"));
                await dialog.ShowAsync();
            }
        }
        private async void ItemClick_Click(object sender, RoutedEventArgs e)
        {
            try
            {

            JExercise Exercise = new JExercise();
            HyperlinkButton btn = (HyperlinkButton)sender;

            Exercise = Exercises.Where(x => x.ID == (int)btn.CommandParameter).FirstOrDefault();           
            
            this.Frame.Navigate(typeof(ExerciseDetails), Exercise);
            }
            catch (Exception)
            {
                var dialog = new MessageDialog("Something went wrong with our services. Please try again.");
                dialog.Commands.Add(new UICommand("OK"));
                await dialog.ShowAsync();
            }
        }
    }
}
