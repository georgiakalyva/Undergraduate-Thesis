using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
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
    public sealed partial class ChallengeDays : Page
    {
        JChallenge challengeDay = new JChallenge();

        public ChallengeDays()
        {
            this.InitializeComponent();
            List<string> listaki = new List<string>();
            for (int i = 1; i <= 30; i++)
            {
                listaki.Add("Day " + i.ToString());
            }
            DaysListView.ItemsSource = listaki;

        }
        protected async override void OnNavigatedTo(NavigationEventArgs e)
        {
            try { 

            if (e.Parameter is JChallenge)
            {
                challengeDay =  e.Parameter as JChallenge;
            }

            Title.Text = challengeDay.ChallengeTitle;
        }
            catch (Exception)
            {
                var dialog = new MessageDialog("Something went wrong with our services. Please try again.");
                   dialog.Commands.Add(new UICommand("OK"));
                await dialog.ShowAsync();
    }
            base.OnNavigatedTo(e);
        }

        private async void ItemClick_Click(object sender, RoutedEventArgs e)
        {
            try { 
            HyperlinkButton btn = (HyperlinkButton)sender;
            int DayID = Convert.ToInt32(btn.Content.ToString().Replace("Day ", ""));

            JChallenge Challenge = new JChallenge()
            {
                ID = challengeDay.ID,
                ChallengeDescription = challengeDay.ChallengeDescription,
                ChallengeTitle = challengeDay.ChallengeTitle,
                ChallengeImage = challengeDay.ChallengeImage,
                ChallengeDayExersices = challengeDay.ChallengeDayExersices.Where(x=>x.DayID==DayID).ToList()                
            };

            this.Frame.Navigate(typeof(ChallengeDayExercise), Challenge);
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
