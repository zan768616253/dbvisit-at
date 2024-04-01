using AventStack.ExtentReports;
using AventStack.ExtentReports.Gherkin.Model;
using AventStack.ExtentReports.Reporter;

using DBVISIT_TEST.Core;
using DBVISIT_TEST.Pages;

using System.Reflection;

using TechTalk.SpecFlow;

namespace DBVISIT_TEST.Hooks
{
    [Binding]
    public sealed class MyHook
    {
        // For additional details on SpecFlow hooks see http://go.specflow.org/doc-hooks

        private static ExtentTest? feature;
        private static ExtentTest? scenario;
        private static ExtentReports? extent;


        [BeforeTestRun]
        public static void InitializeReport()
        {
            if (!Directory.Exists(CommonWeb.CurPath + "Reports"))
            {
                Directory.CreateDirectory(CommonWeb.CurPath + "Reports");
            }
            string reportFile = CommonWeb.GetCurrentDate() + "/" + CommonWeb.GetCurrentTime() + "/report.html";
            //Initialize Extent report before test starts
            var htmlReporter = new ExtentHtmlReporter(CommonWeb.CurPath + "Reports//" + reportFile);

            htmlReporter.LoadConfig(CommonWeb.CurPath + "Config/report-config.xml");
            extent = new ExtentReports();
            extent.AddSystemInfo("Browser", "Chrome");
            extent.AttachReporter(htmlReporter);

        }
        [BeforeFeature]
        public static void BeforeFeature(FeatureContext featureContext)
        {

            OperatingSystem os = Environment.OSVersion;
            //Create dynamic feature name
            if (extent != null)
                feature = extent.CreateTest<Feature>(featureContext.FeatureInfo.Title);
            feature?.AssignAuthor("Eric Wang");
            feature?.AssignDevice($"platform:{os.Platform}", $"version:{os.Version}");
            feature?.AssignCategory(featureContext.FeatureInfo.Title);
        }

        [BeforeScenario]
        public static void BeforeScenario(ScenarioContext scenarioContext)
        {
            //Create dynamic scenario name
            if (feature != null)
                scenario = feature.CreateNode<Scenario>(scenarioContext.ScenarioInfo.Title);
            //open browser and maximize window
            CommonWeb.Open("chrome", "https://172.23.118.186:4433");
            CommonWeb.MaxWindow();
            CommonWeb.Click("id=details-button");
            CommonWeb.Click("id=proceed-link");
        }

        [AfterStep]
        public static void InsertReportingSteps(ScenarioContext scenarioContext)
        {
            var stepType = ScenarioStepContext.Current.StepInfo.StepDefinitionType.ToString();

            if (scenarioContext.TestError == null)
            {
                if (scenario != null)
                    if (stepType == "Given")
                        scenario.CreateNode<Given>(ScenarioStepContext.Current.StepInfo.Text);
                    else if (stepType == "When")
                        scenario.CreateNode<When>(ScenarioStepContext.Current.StepInfo.Text);
                    else if (stepType == "Then")
                        scenario.CreateNode<Then>(ScenarioStepContext.Current.StepInfo.Text);
                    else if (stepType == "And")
                        scenario.CreateNode<And>(ScenarioStepContext.Current.StepInfo.Text);
            }
            //if scenario fails, add a screen shot to the report
            else if (scenarioContext.TestError != null)
            {
                if (scenario != null)
                    if (stepType == "Given")
                        scenario.CreateNode<Given>(ScenarioStepContext.Current.StepInfo.Text).Fail(scenarioContext.TestError.Message, MediaEntityBuilder.CreateScreenCaptureFromPath(CommonWeb.GetScreenShot("error")).Build());
                    else if (stepType == "When")
                        scenario.CreateNode<When>(ScenarioStepContext.Current.StepInfo.Text).Fail(scenarioContext.TestError.Message, MediaEntityBuilder.CreateScreenCaptureFromPath(CommonWeb.GetScreenShot("error")).Build());
                    else if (stepType == "Then")
                        scenario.CreateNode<Then>(ScenarioStepContext.Current.StepInfo.Text).Fail(scenarioContext.TestError.Message, MediaEntityBuilder.CreateScreenCaptureFromPath(CommonWeb.GetScreenShot("error")).Build());
                    else if (stepType == "And")
                        scenario.CreateNode<And>(ScenarioStepContext.Current.StepInfo.Text).Fail(scenarioContext.TestError.Message, MediaEntityBuilder.CreateScreenCaptureFromPath(CommonWeb.GetScreenShot("error")).Build());
            }            
        }
        /// <summary>
        /// After Scenario
        /// </summary>

        [AfterScenario]
        public static void AfterScenario()
        {
            bool hasConfiguration = false;
            try
            {
                hasConfiguration = CommonWeb.IsElementExist(MainPage.Dbname);
            }
            catch (Exception)
            {
                hasConfiguration = false;
            }

            if (hasConfiguration)
            {
                CommonWeb.Click(MainPage.ActionButton);
                CommonWeb.Click(MainPage.Remove);
                CommonWeb.Click(MainPage.Yes);

            }
            CommonWeb.ClearCookie();
            CommonWeb.Quit();
        }
        /// <summary>
        /// general report
        /// </summary>
        [AfterTestRun]
        public static void TearDownReport()
        {
            extent?.Flush();
        }
    }
}