using System;
using System.Collections.Generic;
using System.Linq;

using Foundation;
using UIKit;
using Microsoft.Azure.Engagement.Xamarin;

namespace XamarinAdvent2016.iOS
{
    // The UIApplicationDelegate for the application. This class is responsible for launching the 
    // User Interface of the application, as well as listening (and optionally responding) to 
    // application events from iOS.
    [Register("AppDelegate")]
    public partial class AppDelegate : global::Xamarin.Forms.Platform.iOS.FormsApplicationDelegate
    {

        [Obsolete("接続文字列は変更してください", false)]
        /// <summary>
        /// MobileEngagementの接続文字列
        /// </summary>
        private const string connectionString =
            "Endpoint=XamarinAdvent2016.device.mobileengagement.windows.net;SdkKey=******;AppId=******";

        //
        // This method is invoked when the application has loaded and is ready to run. In this 
        // method you should instantiate the window, load the UI into it and then make the window
        // visible.
        //
        // You have 17 seconds to return from this method, or iOS will terminate your application.
        //
        public override bool FinishedLaunching(UIApplication app, NSDictionary options)
        {

            //MobileEngagementとの接続初期化
            EngagementConfiguration config = new EngagementConfiguration
            {
                ConnectionString = connectionString,
                NotificationIcon = UIImage.FromBundle("push")
            };
            EngagementAgent.Init(config);


            if (UIDevice.CurrentDevice.CheckSystemVersion(8, 0))
            {
                var pushSettings = UIUserNotificationSettings.GetSettingsForTypes(
                    (UIUserNotificationType.Badge |
                        UIUserNotificationType.Sound |
                        UIUserNotificationType.Alert),
                    null);
                UIApplication.SharedApplication.RegisterUserNotificationSettings(pushSettings);
                UIApplication.SharedApplication.RegisterForRemoteNotifications();
            }
            else
            {
                UIApplication.SharedApplication.RegisterForRemoteNotificationTypes(
                    UIRemoteNotificationType.Badge |
                    UIRemoteNotificationType.Sound |
                    UIRemoteNotificationType.Alert);
            }


            global::Xamarin.Forms.Forms.Init();
            LoadApplication(new App());

            return base.FinishedLaunching(app, options);
        }

        public override void DidReceiveRemoteNotification(UIApplication application, NSDictionary userInfo, Action<UIBackgroundFetchResult> completionHandler)
        {
            //バッジナンバーを消す
            application.ApplicationIconBadgeNumber = 0;

            //起動中にPush通知された場合に画面下部に通知を表示する処理
            EngagementAgent.ApplicationDidReceiveRemoteNotification(userInfo, completionHandler);

        }
        public override void RegisteredForRemoteNotifications(UIApplication application, NSData deviceToken)
        {
            // Register device token on Engagement
            EngagementAgent.RegisterDeviceToken(deviceToken);
        }

        public override void FailedToRegisterForRemoteNotifications(UIApplication application, NSError error)
        {
            Console.WriteLine("Failed to register for remote notifications: Error '{0}'", error);
        }
    }
}
