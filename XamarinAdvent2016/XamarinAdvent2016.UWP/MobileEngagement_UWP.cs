using Microsoft.Azure.Engagement;
using System.Collections.Generic;
using Xamarin.Forms;
using XamarinAdvent2016.UWP;

[assembly: Dependency(typeof(MobileEngagement_UWP))]
namespace XamarinAdvent2016.UWP
{
    public class MobileEngagement_UWP : IMobileEngagement
    {
        public MobileEngagement_UWP() { }

        public void StartActivity(string pageName, Dictionary<string, string> extra = null)
        {
            EngagementAgent.Instance.StartActivity(pageName, dictionaryConverter(extra));
        }

        public void SendEvent(string eventName, Dictionary<string, string> extra = null)
        {
            EngagementAgent.Instance.SendEvent(eventName, dictionaryConverter(extra));
        }

        public void SendError(string errorName, Dictionary<string, string> extra = null)
        {
            EngagementAgent.Instance.SendError(errorName, dictionaryConverter(extra));

        }

        public void SendAppInfo(Dictionary<string, string> appInfo)
        {
            EngagementAgent.Instance.SendAppInfo(dictionaryConverter(appInfo));
        }

        /// <summary>
        /// Dictionary<string, string>をDictionary<object, object>に変換
        /// </summary>
        /// <param name="extra">変換前(Dictionary<object, object>)</param>
        /// <returns>変換後(Dictionary<object, object>)</returns>
        private Dictionary<object, object> dictionaryConverter(Dictionary<string, string> appInfo = null)
        {
            var sendInfo = new Dictionary<object, object>();
            if (appInfo != null)
            {
                foreach (var info in appInfo)
                {
                    sendInfo.Add(info.Key, info.Value);
                }
            }
            else
            {
                sendInfo = null;
            }
            return sendInfo;
        }
    }
}
