using Android.App;
using Android.Content.PM;
using Android.OS;
using Microsoft.Azure.Engagement.Xamarin;
using System;

namespace XamarinAdvent2016.Droid
{
    [Activity(Label = "XamarinAdvent2016", Icon = "@drawable/icon", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        [Obsolete("接続文字列は変更してください", false)]
        /// <summary>
        /// MobileEngagementの接続文字列
        /// </summary>
        private const string connectionString =
            "Endpoint=XamarinAdvent2016.device.mobileengagement.windows.net;SdkKey=******;AppId=******";

        protected override void OnCreate(Bundle bundle)
        {
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

            base.OnCreate(bundle);

            global::Xamarin.Forms.Forms.Init(this, bundle);
            LoadApplication(new App());

            //Mobile Engagement の初期化
            EngagementConfiguration engagementConfiguration = new EngagementConfiguration();

            //ME接続先
            engagementConfiguration.ConnectionString = connectionString;

            EngagementAgent.Init(engagementConfiguration);
        }

        protected override void OnResume()
        {
            //Mobile Engagement リアルタイム監視の開始
            EngagementAgent.StartActivity(EngagementAgentUtils.BuildEngagementActivityName(Java.Lang.Class.FromType(this.GetType())), null);
            base.OnResume();
        }

        protected override void OnPause()
        {
            //Mobile Engagement リアルタイム監視の終了
            EngagementAgent.EndActivity();
            base.OnPause();
        }

    }
}

