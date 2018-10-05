using Microsoft.WindowsAzure.Messaging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using ThesisMobile.Data;
using ThesisMobile.DataModel;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

using Windows.Networking.PushNotifications;
using Windows.UI.Popups;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace ThesisMobile
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class Settings : Page
    {
        public Settings()
        {
            this.InitializeComponent();
            NotSwitch.Toggled += NotSwitch_Toggled;

        }

        private async void  NotSwitch_Toggled(object sender, RoutedEventArgs e)
        {
            ToggleSwitch toggleSwitch = sender as ToggleSwitch;
            if (toggleSwitch != null)
            {
                if (toggleSwitch.IsOn == true)
                {
                    try { 
                    var channel = await PushNotificationChannelManager.CreatePushNotificationChannelForApplicationAsync();

                    var hub = new NotificationHub("fitness30", "Endpoint=sb://fitness30notifications.servicebus.windows.net/;SharedAccessKeyName=DefaultListenSharedAccessSignature;SharedAccessKey=F02IprXDS3pZUimI9u8Nd2FSFWFTHVI4ypmWMTM2Zug=");
                    var result = await hub.RegisterNativeAsync(channel.Uri);
                    using (var db = SqliteDatabase.DBConnection)
                    {
                        var r = db.InsertOrReplace(new Setting() { ID = "Notifications", Description = true.ToString() });
                    }
                    }
                    catch (Exception)
                    {
                        var dialog = new MessageDialog("Something went wrong with our services. Please try again.");
                        dialog.Commands.Add(new UICommand("OK"));
                        await dialog.ShowAsync();
                    }
                }
                else
                {
                    try
                    {
                        
                    var channel = await PushNotificationChannelManager.CreatePushNotificationChannelForApplicationAsync();

                    var hub = new NotificationHub("fitness30", "Endpoint=sb://fitness30notifications.servicebus.windows.net/;SharedAccessKeyName=DefaultListenSharedAccessSignature;SharedAccessKey=F02IprXDS3pZUimI9u8Nd2FSFWFTHVI4ypmWMTM2Zug=");
                    await hub.UnregisterNativeAsync();
                    using (var db = SqliteDatabase.DBConnection)
                    {
                        var r = db.InsertOrReplace(new Setting() { ID = "Notifications", Description = false.ToString() });
                    }
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
    

        protected async override void OnNavigatedTo(NavigationEventArgs e)
        {
            try { 
            using (var db = SqliteDatabase.DBConnection)
            {
                bool NotificationsEnabled = Convert.ToBoolean(db.Table<Setting>().Where(x => x.ID == "Notifications").FirstOrDefault().Description);
                NotSwitch.IsOn = NotificationsEnabled;
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
    }
}
