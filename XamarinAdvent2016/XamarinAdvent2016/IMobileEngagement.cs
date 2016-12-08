using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XamarinAdvent2016
{
    public interface IMobileEngagement
    {
        void StartActivity(string pageName, Dictionary<string, string> extra = null);
        void SendEvent(string eventName, Dictionary<string, string> extra = null);
        void SendError(string eventName, Dictionary<string, string> extra = null);
        void SendAppInfo(Dictionary<string, string> appInfo);
    }
}
