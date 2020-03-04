using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication2
{
    public class NetworkStatus
    {
        public NetworkStatus(String deviceId, String versions)
        {

            this.DeviceId = deviceId;
            this.Versions = versions;
        }
        public String DeviceId { get; set; }
        public String Versions { get; set; }
    }
}
