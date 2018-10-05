using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
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
    public sealed partial class Disclaimer : Page
    {
        public Disclaimer()
        {
            this.InitializeComponent();
            Info.Text = @"You should consult your physician or other health care professional before starting this or any other fitness program to determine if it is right for your needs. This is particularly true if you (or your family) have a history of high blood pressure or heart disease, or if you have ever experienced chest pain when exercising or have experienced chest pain in the past month when not engaged in physical activity, smoke, have high cholesterol, are obese, or have a bone or joint problem that could be made worse by a change in physical activity. Do not start this fitness program if your physician or health care provider advises against it. If you experience faintness, dizziness, pain or shortness of breath at any time while exercising you should stop immediately.

This app offers health, fitness and nutritional information and is designed for educational purposes only. You should not rely on this information as a substitute for, nor does it replace, professional medical advice, diagnosis, or treatment. If you have any concerns or questions about your health, you should always consult with a physician or other health-care professional. Do not disregard, avoid or delay obtaining medical or health related advice from your health-care professional because of something you may have read on this app. The use of any information provided on this app is solely at your own risk. We assume no responsibility for personal injury or property damage sustained by or through the use of this product.

Some of the challenges are for people that are already fit, know how to execute the exercises in proper form and just need the extra challenge. In any case we recommend not to skip a warm up (such as running in place for 10 minutes) or a cool down (some light stretching) as it increases the risk of injury.";
        }
    }
}
