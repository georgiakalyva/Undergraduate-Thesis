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
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace ThesisMobile
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class ExerciseDetails : Page
    {
        JExercise Exercise = new JExercise();
        public ExerciseDetails()
        {
            this.InitializeComponent();
            // imageName.Source = new BitmapImage(new Uri("ms-appx:/path"));
        }

        protected async override void OnNavigatedTo(NavigationEventArgs e)
        {
            try { 
            if (e.Parameter is JExercise)
            {
                Exercise = e.Parameter as JExercise;
            }

            Title.Text = Exercise.ExerciseName;
            ImageGuide.Source = new BitmapImage(new Uri("ms-appx:/Assets/Exercises/"+Exercise.ExerciseImage));
            Description.Text = Exercise.ExerciseDescription;
            }
            catch (Exception)
            {
                var dialog = new MessageDialog("Something went wrong with our services. Please try again.");
                dialog.Commands.Add(new UICommand("OK"));
                await dialog.ShowAsync();
            }
            base.OnNavigatedTo(e);
        }
    }
}
