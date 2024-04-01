using DBVISIT_TEST.Core;
using DBVISIT_TEST.Pages;

using NUnit.Framework;

using System;
using TechTalk.SpecFlow;

namespace DBVISIT_TEST.StepDefinitions
{
    [Binding]
    public class NewConfiguration_PostgresDatabaseStepDefinitions
    {
        [Given(@"I login Dbvisit system and go in New Configuration menu")]
        public void GivenILoginDbvisitSystemAndGoInNewConfigurationMenu()
        {
            CommonWeb.Type(LoginPage.UserNameInput, "admin");
            CommonWeb.Type(LoginPage.PassWordsInput, "admin");
            CommonWeb.Click(LoginPage.LoginButton);
            
        }

        [When(@"I select primary host")]
        public void WhenISelectPrimaryHost()
        {
       
            CommonWeb.Click(NewConfigurationPage.PostgreButton);
            CommonWeb.SelectValue(NewConfigurationPage.SelectPrimaryHost, NewConfigurationPage.SelectPrimaryValue);
        }

        [When(@"I select manual input port")]
        public void WhenIManualInputPort()
        {
            CommonWeb.SelectValue(NewConfigurationPage.SelectManualPort, NewConfigurationPage.SelectManualPortValue);
            CommonWeb.Type(NewConfigurationPage.PortNnumerInput, "5432");
            CommonWeb.Click(NewConfigurationPage.ConnectToClusterButton);
        }

        [When(@"I input database (.*) and (.*) and click connect button")]
        public void WhenIInputDatabasePostgresAndPgAndClickConnectButton(string username,string passwords)
        {
            CommonWeb.Type(NewConfigurationPage.UsernameInput, username);
            CommonWeb.Type(NewConfigurationPage.PasswordsInput, passwords);
            CommonWeb.Click(NewConfigurationPage.ConnectToClusterButton);
        }

        [Then(@"I can config primary host")]
        public void ThenICanConfigPrimaryHost()
        {
            Assert.True(CommonWeb.IsElementExist(NewConfigurationPage.DbList));
        }

        [When(@"I select standby host")]
        public void WhenISelectStandbyHost()
        {
            CommonWeb.SelectValue(NewConfigurationPage.SelectStandByHost, NewConfigurationPage.SelectStandbyValue);
        }

        [When(@"I type (.*) and (.*)")]
        public void WhenITypeYuAndJozaaai_U_Ijlsb_Ubmecoyv_Qicwi(string configuration_name, string license_key)
        {
            CommonWeb.Type(NewConfigurationPage.Configuration_Name, configuration_name);
            CommonWeb.Type(NewConfigurationPage.License_Key, license_key);
        }

        [When(@"I click create button")]
        public void WhenIClickCreateButton()
        {
            CommonWeb.Click(NewConfigurationPage.CreatConfigurationButton);
        }

        [Then(@"I can see the database")]
        public void ThenICanSeeTheDatabase()
        {
            Assert.True(CommonWeb.IsElementExist(MainPage.Dbname));
        }
    }
}
