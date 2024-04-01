using DBVISIT_TEST.Core;
using DBVISIT_TEST.Pages;

using NUnit.Framework;

using System;
using TechTalk.SpecFlow;

namespace DBVISIT_TEST.StepDefinitions
{
    [Binding]
    public class LoginStepDefinitions
    {
        [Given(@"I am on Dbvisit web")]
        public void GivenIAmOnDbvisitWeb()
        {
            //throw new PendingStepException();
        }

        [When(@"I input right (.*) and (.*)")]
        public void WhenIInputRightAdminAndAdmin(string username,string passwords)
        {
            CommonWeb.Type(LoginPage.UserNameInput, username);
            CommonWeb.Type(LoginPage.PassWordsInput, passwords);
            CommonWeb.Click(LoginPage.LoginButton);
        }


        [Then(@"I can login successfully")]
        public void ThenICanLoginSuccessfully()
        {
            Assert.IsTrue(CommonWeb.IsElementExist(MainPage.CurrentUser));
        }

        [When(@"I input unavailable (.*) and (.*)")]
        public void WhenIInputUnavailableAdminAnd(string username, string passwords)
        {
            CommonWeb.Type(LoginPage.UserNameInput, username);
            CommonWeb.Type(LoginPage.PassWordsInput, passwords);
            CommonWeb.Click(LoginPage.LoginButton);
        }

        [Then(@"I can not login and see a fail message")]
        public void ThenICanNotLoginAndSeeAFailMessage()
        {
            CommonWeb.IsElementExist(LoginPage.notice);
        }
    }
}
