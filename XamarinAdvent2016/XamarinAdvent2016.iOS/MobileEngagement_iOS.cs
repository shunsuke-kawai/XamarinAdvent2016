using Microsoft.Azure.Engagement.Xamarin;
using System.Collections.Generic;
using Xamarin.Forms;
using XamarinAdvent2016.iOS;

[assembly: Dependency(typeof(MobileEngagement_iOS))]

namespace XamarinAdvent2016.iOS
{
    public class MobileEngagement_iOS : IMobileEngagement
    {
        public MobileEngagement_iOS() { }

        public void StartActivity(string pageName, Dictionary<string, string> extra = null)
        {
            EngagementAgent.StartActivity(pageName, extra);
        }
        public void SendEvent(string eventName, Dictionary<string, string> extra = null)
        {
            EngagementAgent.SendEvent(eventName, extra);
        }

        public void SendError(string errorName, Dictionary<string, string> extra = null)
        {
            EngagementAgent.SendError(errorName, extra);
        }

        public void SendAppInfo(Dictionary<string, string> appInfo)
        {
            EngagementAgent.SendAppInfo(appInfo);
        }
    }
}
