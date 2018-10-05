using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using ThesisMobile.Data;
using ThesisMobile.DataModel;
using Windows.ApplicationModel;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Networking.Connectivity;
using Windows.Storage;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace ThesisMobile
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        List<JCategory> Categories = new List<JCategory>();

        public MainPage()
        {
            this.InitializeComponent();         
            
        }
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            
            base.OnNavigatedTo(e);
            InitializePivot();
        }
        

        public async void InitializePivot()
        {
            try { 
            using (var db = SqliteDatabase.DBConnection)
            {
                string CategoriesJson = db.Table<Setting>().Where(x=>x.ID == "Challenges").FirstOrDefault().Description;
                 Categories = JsonConvert.DeserializeObject<List<JCategory>>(CategoriesJson).ToList().Where(x=>x.CategoryName!= "Exercises").ToList();
                CategoryPivot.ItemsSource = Categories;
            }
            }
            catch (Exception)
            {
                var dialog = new MessageDialog("Something went wrong with our services. Please try again.");
                dialog.Commands.Add(new UICommand("OK"));
                await dialog.ShowAsync();
            }
        }

        private void AboutButton_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(AboutPage));
        }
        private void Settings_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(Settings));
        }

        private async void ItemClick_Click(object sender, RoutedEventArgs e)
        {
            try { 
            JChallenge Challenge = new JChallenge();
            HyperlinkButton btn = (HyperlinkButton)sender;

            foreach (var Category in Categories)
            {
                Challenge = Category.Challenges.Where(x => x.ID == (int)btn.CommandParameter).FirstOrDefault();
                if (Challenge!=null)
                {
                    break;
                }
            }

            this.Frame.Navigate(typeof(ChallengeDays), Challenge);
            }
            catch (Exception)
            {
                var dialog = new MessageDialog("Something went wrong with our services. Please try again.");
                dialog.Commands.Add(new UICommand("OK"));
                await dialog.ShowAsync();
            }
        }

        private void Exercises_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(ExerciseList));
        }

        private async void Sync_Click(object sender, RoutedEventArgs e)
        {
            SyncText.Visibility = Visibility.Visible;
            SyncBar.Visibility = Visibility.Visible;
            var connectionProfile = NetworkInformation.GetInternetConnectionProfile();
            if (connectionProfile.GetNetworkConnectivityLevel() == NetworkConnectivityLevel.InternetAccess)
            {
                try { 
                string GetChallenges = "";
                string GetExercises = "";

                 GetChallenges = await Request.GetChallenges();
                 GetExercises = await Request.GetExercises();
                if (GetChallenges!="")
                {
                    using (var db = SqliteDatabase.DBConnection)
                    {
                        var r = db.InsertOrReplace(new Setting() { ID = "ChallengesB", Description = GetChallenges });
                    }
                }
                if (GetExercises != "")
                {
                    using (var db = SqliteDatabase.DBConnection)
                    {
                        var r = db.InsertOrReplace(new Setting() { ID = "ExercisesB", Description = GetExercises });
                    }
                }
                }
                catch (Exception)
                {
                    var dialog = new MessageDialog("Something went wrong with our services. Please try again.");
                    dialog.Commands.Add(new UICommand("OK"));
                    await dialog.ShowAsync();
                }
                SyncText.Visibility = Visibility.Collapsed;
                SyncBar.Visibility = Visibility.Collapsed;
            }
            else
            {
                MessageDialog showDialog = new MessageDialog("Internet Access is required to sync data. Please connect to a network and try again.", "No Internet Connection");
                showDialog.Commands.Add(new UICommand("OK")
                {
                    Id = 0
                });
                showDialog.CancelCommandIndex = 0;
                var result = await showDialog.ShowAsync();
            }
        }
    }
}
