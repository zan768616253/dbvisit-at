using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBVISIT_TEST.Pages
{
    internal class NewConfigurationPage
    {
        public static string PostgreButton = "css=.postgresql > span:nth-child(2)";
        public static string SelectPrimaryHost = "css=#pr-host > .field .w-100";
        public static string SelectPrimaryValue = "4nwj8utinjz8";
        public static string SelectStandbyValue = "1ublnc9vif9nl";
        public static string SelectManualPort = "css=#pr-cluster > .field .w-100";
        public static string SelectManualPortValue = "manual";
        public static string PortNnumerInput = "id=manual-port";
        public static string ConnectToClusterButton = "class=connect-to-cluster";
        public static string SelectStandByHost = "css=#st-host > .field .w-100";
        public static string UsernameInput = "id=cluster-auth-username";
        public static string PasswordsInput = "id=cluster-auth-password";
        public static string DbList = "id=db-list";
        public static string Configuration_Name = "name=configuration_name";
        public static string License_Key = "name=license_key";

        public static string CreatConfigurationButton = "css=.submit";

    }
}
