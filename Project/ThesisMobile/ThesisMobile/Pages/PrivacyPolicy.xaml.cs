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
    public sealed partial class PrivacyPolicy : Page
    {
        public PrivacyPolicy()
        {
            this.InitializeComponent();
            Info.Text = @"
This Privacy Policy explains our policy regarding the collection and use of your information. As we update and expand our products, this policy may change, so please refer back to it periodically. By accessing our app or using our apps, you consent to our information practices. 

What information do we collect?
•When you opt to receive a push notification we collect anonymous information and your location so we can redirect notifications to your device.
•We collect anonomous information about how you use our apps.
What do we use your information for? 

Anonomous information that we collect from you during the use of our apps or app will be used in one of the following ways:
•To personalize your experience (your information helps us to better respond to your individual needs)
•To improve our app or apps (we continually strive to improve our app offerings based on the information and feedback we receive from you)
Your information, whether public or private, will not be sold, exchanged, transferred, or given to any other company for any reason whatsoever, without your consent, other than for the express purpose of delivering the purchased product or service requested.
Do we disclose any information to outside parties? 

We do not sell, trade, or otherwise transfer to outside parties your personally identifiable information. This does not include trusted third parties who assist us in operating our app, conducting our business, or servicing you, so long as those parties agree to keep this information confidential. We may also release your information when we believe release is appropriate to comply with the law, enforce our app policies, or protect ours or others rights, property, or safety. However, non-personally identifiable visitor information may be provided to other parties for marketing, advertising, or other uses.

Third party links

Occasionally, at our discretion, we may include or offer third party products or services on our app. These third party apps have separate and independent privacy policies. We therefore have no responsibility or liability for the content and activities of these linked apps. Nonetheless, we seek to protect the integrity of our app and welcome any feedback about these apps.

Childrens Online Privacy Protection Act Compliance 

We are in compliance with the requirements of COPPA (Childrens Online Privacy Protection Act), we do not collect any information from anyone under 13 years of age. Our app, products and services are all directed to people who are at least 13 years old or older.

Your Consent 

By using our app, you consent to our apps privacy policy.

Changes to our Privacy Policy 

If we decide to change our privacy policy, we will post those changes on this page, and/or update the Privacy Policy modification date below. 

This policy was last modified on 15/4/2013

Contacting Us 

If there are any questions regarding this privacy policy you may contact us using the information below. 

georgia@kalyva.com

";
        }
    }
}
