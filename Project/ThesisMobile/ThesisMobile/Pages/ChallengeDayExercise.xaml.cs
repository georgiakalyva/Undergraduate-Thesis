using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using ThesisMobile.DataModel;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI;
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
    public sealed partial class ChallengeDayExercise : Page
    {

        JChallenge challengeDay = new JChallenge();

        public ChallengeDayExercise()
        {
            this.InitializeComponent();
        }
        protected async override void OnNavigatedTo(NavigationEventArgs e)
        {
            try
            {

            
            if (e.Parameter is JChallenge)
            {
                challengeDay = e.Parameter as JChallenge;
            }
            Title.Text = challengeDay.ChallengeTitle;
            SubTitle.Text = "Day "+challengeDay.ChallengeDayExersices.First().DayID.ToString();
            foreach (var item in challengeDay.ChallengeDayExersices.ToList())
            {
                TextBlock textblock = new TextBlock()
                {
                    HorizontalAlignment = HorizontalAlignment.Center,
                    VerticalAlignment = VerticalAlignment.Center,
                    FontSize = 24,
                    Text = item.Exercise.ExerciseName.ToString() + ":  " + item.Repeats + " " + (RepeatTypes)item.RepeatType + " x" + item.RepeatCircuit,
                    Foreground = new SolidColorBrush(Color.FromArgb(255, 255, 255, 255))
                };
                ExerciseStack.Children.Add(textblock);
            }
            }
            catch (Exception)
            {
                var dialog = new MessageDialog("Something went wrong with our services. Please try again.");
                dialog.Commands.Add(new UICommand("OK"));
                await dialog.ShowAsync();
            }
            base.OnNavigatedTo(e);
        }
        enum RepeatTypes {Reps = 1, Seconds, Minutes };
    }
}
