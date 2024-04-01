using DBVISIT_TEST.Hooks;

using log4net;
using log4net.Config;

using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Safari;
using OpenQA.Selenium.Support.UI;

using SeleniumExtras.WaitHelpers;

using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace DBVISIT_TEST.Core
{
    internal class CommonWeb
    {
        public static string CurPath = new DirectoryInfo("../../../").FullName;

        public static IWebDriver? driver;

        private static int timeout = 2;

        /// <summary>
        /// Initialize log
        /// </summary>
        /// <returns></returns>
        public static ILog Log()
        {
            System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);
            var logCfg = new FileInfo(CurPath + "Config/log4net.config");
            XmlConfigurator.ConfigureAndWatch(logCfg);

            return LogManager.GetLogger(MethodBase.GetCurrentMethod()?.DeclaringType);
        }


        /// <summary>
        /// open different browser and navigate to url
        /// </summary>
        /// <param name="browserType"></param>
        /// <param name="url"></param>
        public static void Open(string browserType, string url)
        {
            Log().Info(string.Format("Open Browser: {0}", url));
            if (browserType.ToLower() == "chrome")
            {
                driver = new ChromeDriver(CurPath + "Drivers/");
                driver.Navigate().GoToUrl(url);
            }
            else if (browserType.ToLower() == "firefox")
            {
                driver = new FirefoxDriver();
                driver.Navigate().GoToUrl(url);

            }
            else if (browserType.ToLower() == "ie")
            {
                driver = new InternetExplorerDriver();
                driver.Navigate().GoToUrl(url);
            }
            else if (browserType.ToLower() == "safari")
            {
                driver = new SafariDriver();
                driver.Navigate().GoToUrl(url);
            }
            else if (browserType.ToLower() == "edge")
            {
                driver = new EdgeDriver();
                driver.Navigate().GoToUrl(url);
            }
            if (driver != null)
                driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(timeout);
        }

        /// <summary>
        /// Find element by different ways
        /// </summary>
        /// <param name="xpath"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public static IWebElement GetElement(string xpath)
        {
            if (!xpath.Contains("="))
            {
                throw new Exception("Positioning syntax errors, lack of '='.");
            }

            var by = xpath.Split('=')[0].ToLower();
            var value = xpath.Split('=')[1];
            WaitElement(xpath);
            if (driver != null)
            {
                if (by.Equals("id"))
                {
                    return driver.FindElement(By.Id(value));
                }

                if (by.Equals("name"))
                {
                    return driver.FindElement(By.Name(value));
                }
                if (by.Equals("class") || by.Equals("classname"))
                {
                    return driver.FindElement(By.ClassName(value));
                }

                if (by.Equals("linktext") || by.Equals("link"))
                {
                    return driver.FindElement(By.LinkText(value));
                }
                if (by.Equals("xpath"))
                {
                    return driver.FindElement(By.XPath(value));
                }

                if (by.Equals("css") || by.Equals("cssselector"))
                {
                    return driver.FindElement(By.CssSelector(value));
                }
                else
                {
                    throw new Exception("Please enter the correct targeting elements,'id','name','class','xpath','css'.");
                }
            }
            else
            {
                throw new Exception("driver is null");
            }
        }
        /// <summary>
        /// Explict wait element by different ways
        /// </summary>
        /// <param name="xpath"></param>
        /// <exception cref="Exception"></exception>
        public static void WaitElement(string xpath)
        {
            if (!xpath.Contains("="))
            {
                throw new Exception("Positioning syntax errors, lack of '='.");
            }

            var by = xpath.Split('=')[0].ToLower();
            var value = xpath.Split('=')[1];

            if (by.Equals("id"))
            {
                var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeout));
                wait.Until(ExpectedConditions.ElementIsVisible(By.Id(value)));
            }
            else if (by.Equals("name"))
            {
                var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeout));
                wait.Until(ExpectedConditions.ElementIsVisible(By.Name(value)));
            }
            else if (by.Equals("class") || by.Equals("classname"))
            {
                var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeout));
                wait.Until(ExpectedConditions.ElementIsVisible(By.ClassName(value)));
            }
            else if (by.Equals("link") || by.Equals("linktext"))
            {
                var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeout));
                wait.Until(ExpectedConditions.ElementIsVisible(By.LinkText(value)));
            }
            else if (by.Equals("xpath"))
            {
                var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeout));
                wait.Until(ExpectedConditions.ElementIsVisible(By.XPath(value)));
            }
            else if (by.Equals("css") || by.Equals("cssselector"))
            {
                var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeout));
                wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector(value)));
            }
            else
            {
                throw new Exception("Please enter the correct targeting elements,'id','name','class','xpath','css'.");
            }
        }
        /// <summary>
        /// Wait element clickable by different ways
        /// </summary>
        /// <param name="xpath"></param>
        /// <exception cref="Exception"></exception>
        public static void WaitElementClickable(string xpath)
        {
            if (!xpath.Contains("="))
            {
                throw new Exception("Positioning syntax errors, lack of '='.");
            }

            var by = xpath.Split('=')[0].ToLower();
            var value = xpath.Split('=')[1];

            if (by.Equals("id"))
            {
                var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeout));
                wait.Until(ExpectedConditions.ElementToBeClickable(By.Id(value)));
            }
            else if (by.Equals("name"))
            {
                var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeout));
                wait.Until(ExpectedConditions.ElementToBeClickable(By.Name(value)));
            }
            else if (by.Equals("class") || by.Equals("classname"))
            {
                var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeout));
                wait.Until(ExpectedConditions.ElementToBeClickable(By.ClassName(value)));
            }
            else if (by.Equals("link") || by.Equals("linktext"))
            {
                var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeout));
                wait.Until(ExpectedConditions.ElementToBeClickable(By.LinkText(value)));
            }
            else if (by.Equals("xpath"))
            {
                var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeout));
                wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath(value)));
            }
            else if (by.Equals("css") || by.Equals("cssselector"))
            {
                var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeout));
                wait.Until(ExpectedConditions.ElementToBeClickable(By.CssSelector(value)));
            }
            else
            {
                throw new Exception("Please enter the correct targeting elements,'id','name','class','xpath','css'.");
            }
        }
        /// <summary>
        /// Clear cookies
        /// </summary>
        public static void ClearCookie()
        {
            driver?.Manage().Cookies.DeleteAllCookies();
        }

        /// <summary>
        /// Take a screenshot
        /// </summary>
        /// <param name="filename"></param>
        /// <returns></returns>
        public static string GetScreenShot(string filename)
        {
            string screenshotPath = CurPath + "Screenshots/" + DateTime.Now.ToString("hh_mm_ss_tt_dddd_dd-MM-yyyy_") + filename + ".png";
            if (!Directory.Exists(CurPath + "Screenshots"))
            {
                Directory.CreateDirectory(CurPath + "Screenshots");
            }
            if (driver != null)
                ((ITakesScreenshot)driver).GetScreenshot().SaveAsFile(screenshotPath,
                ScreenshotImageFormat.Png);
            Log().Info("Get Screenshot");
            return screenshotPath;
        }
        /// <summary>
        /// Set window size
        /// </summary>
        /// <param name="wide"></param>
        /// <param name="high"></param>
        public static void SetWindowSize(int wide, int high)
        {
            if (driver != null)
                driver.Manage().Window.Size = new Size(wide, high);
            Log().Info(string.Format("Set Window's wide is: {0}, high is : {1}", wide, high));
        }
        /// <summary>
        /// Get window size
        /// </summary>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public static int[] GetWindowSize()
        {
            if (driver != null)
            {
                int wide = driver.Manage().Window.Size.Width;
                int high = driver.Manage().Window.Size.Height;
                Log().Info(string.Format("The Window's wide is: {0},high is: {1}", wide, high));
                return new int[] { wide, high };
            }
            else
            {
                throw new Exception("driver is null");
            }
        }
        /// <summary>
        /// Max window size
        /// </summary>
        public static void MaxWindow()
        {
            driver?.Manage().Window.Maximize();
            Log().Info("Set max window");
        }
        /// <summary>
        /// Forward browser
        /// </summary>
        public static void Forward()
        {
            driver?.Navigate().Forward();
            Log().Info("Forward browser");
        }
        /// <summary>
        /// Back browser
        /// </summary>
        public static void Back()
        {
            driver?.Navigate().Back();
            Log().Info("Back browser");
        }
        /// <summary>
        /// Close the window
        /// </summary>

        public static void Close()
        {
            driver?.Close();
            Log().Info("Close the window");
        }
        /// <summary>
        /// Quit the browser
        /// </summary>
        public static void Quit()
        {
            driver?.Quit();
            Log().Info("Quit the browser");
        }
        /// <summary>
        /// Click element
        /// </summary>
        /// <param name="xpath"></param>

        public static void Click(string xpath)
        {
            //WaitElementClickable(xpath);
            GetElement(xpath).Click();
            Log().Info($"Click element:{xpath}");
        }
        /// <summary>
        /// DoubleClick the element
        /// </summary>
        /// <param name="xpath"></param>

        public static void DoubleClick(string xpath)
        {
            Log().Info("Double click the element");
            WaitElement(xpath);
            Actions actions = new Actions(driver);
            actions.DoubleClick(GetElement(xpath)).Perform();
        }
        /// <summary>
        /// Type the element
        /// </summary>
        /// <param name="xpath"></param>
        /// <param name="text"></param>

        public static void Type(string xpath, string text)
        {
            WaitElement(xpath);
            GetElement(xpath).Clear();
            GetElement(xpath).Click();
            GetElement(xpath).SendKeys(text);
            Log().Info(string.Format("Type the element with: {0}", text));
        }

        /// <summary>
        /// Clear input
        /// </summary>
        /// <param name="xpath"></param>
        public static void Clear(string xpath)
        {
            GetElement(xpath).Clear();
            Log().Info($"Clear the element: {xpath}");
        }
        /// <summary>
        /// RightClick
        /// </summary>
        /// <param name="xpath"></param>
        public static void RightClick(string xpath)
        {
            WaitElement(xpath);
            Actions action = new Actions(driver);
            action.ContextClick(GetElement(xpath)).Perform();
            Log().Info($"Right click the element: {xpath}");
        }
        /// <summary>
        /// Click and Hold
        /// </summary>
        /// <param name="xpath"></param>

        public static void ClickAndHold(string xpath)
        {
            WaitElement(xpath);
            var action = new Actions(driver);
            action.ClickAndHold(GetElement(xpath)).Perform();
            Log().Info("Click and Hold the element");
        }
        /// <summary>
        /// Mouse Click
        /// </summary>
        /// <param name="xpath"></param>
        public static void MouseClick(string xpath)
        {
            WaitElement(xpath);
            Actions action = new Actions(driver);
            action.Click(GetElement(xpath)).Perform();
            Log().Info("Click the element");
        }
        /// <summary>
        /// Drag and Drop
        /// </summary>
        /// <param name="elXpath"></param>
        /// <param name="taXpath"></param>
        public static void DragAndDrop(string elXpath, string taXpath)
        {
            WaitElement(elXpath);
            WaitElement(taXpath);
            var action = new Actions(driver);
            action.DragAndDrop(GetElement(elXpath), GetElement(taXpath)).Perform();
            Log().Info($"Drag and Drop from element({elXpath}) to element({taXpath})");
        }
        /// <summary>
        /// Select Value
        /// </summary>
        /// <param name="xpath"></param>
        /// <param name="value"></param>
        public static void SelectValue(string xpath, string value)
        {
            WaitElement(xpath);
            var select = new SelectElement(GetElement(xpath));
            select.SelectByValue(value);
            Log().Info(string.Format("Select by value: {0}", value));
        }
        /// <summary>
        /// Scroll to presence
        /// </summary>
        /// <param name="xpath"></param>
        /// <exception cref="Exception"></exception>
        public static void ScrolltoPresence(string xpath)
        {
            IWebElement element = GetElement(xpath);
            if (driver != null)
            {
                IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
                js?.ExecuteScript("arguments[0].scrollIntoView(true);", element);
            }
            else
            {
                throw new Exception("driver is null");
            }
            //根据定位的元素放在页面顶端                                                                            
            // js.ExecuteScript("arguments[0].scrollIntoView(false);", element);
            //根据定位的元素放在页面底端
        }
        /// <summary>
        /// Scroll to bottom
        /// </summary>
        /// <exception cref="Exception"></exception>
        public static void ScrolltoBottom()
        {
            if (driver != null)
            {
                IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
                js?.ExecuteScript("window.scrollTo(0,document.body.scrollHeight)");
            }
            else
            {
                throw new Exception("driver is null");
            }
        }
        /// <summary>
        /// Scroll to top
        /// </summary>
        /// <exception cref="Exception"></exception>

        public static void ScrolltoTop()
        {
            if (driver != null)
            {
                IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
                js?.ExecuteScript("window.scrollTo(document.body.scrollHeight,0)");
            }
            else
            {
                throw new Exception("driver is null");
            }
        }
        /// <summary>
        /// Refresh the page
        /// </summary>
        public static void Refresh()
        {
            driver?.Navigate().Refresh();
            Log().Info("Fresh website");
        }
        /// <summary>
        /// enter to frame
        /// </summary>
        /// <param name="xpath"></param>

        public static void EnterFrame(string xpath)
        {
            WaitElement(xpath);
            driver?.SwitchTo().Frame(GetElement(xpath));
            Log().Info("Enter to frame");
        }
        /// <summary>
        /// leave frame
        /// </summary>

        public static void LeaveFrame()
        {
            driver?.SwitchTo().DefaultContent();
            Log().Info("leave frame");
        }
        /// <summary>
        /// wait page
        /// </summary>
        /// <exception cref="InvalidOperationException"></exception>

        public static void WaitPage()
        {
            if (driver != null)
            {
                driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(timeout);
            }
            else { throw new InvalidOperationException(); }
        }
        /// <summary>
        /// get text of element
        /// </summary>
        /// <param name="xpath"></param>
        /// <returns></returns>

        public static string GetText(string xpath)
        {
            WaitElement(xpath);
            string text = GetElement(xpath).Text;
            Log().Info(string.Format("The elements' text is : {0}", text));
            return text;
        }
        /// <summary>
        /// get placeholder of element
        /// </summary>
        /// <param name="xpath"></param>
        /// <returns></returns>

        public static string GetPlaceholder(string xpath)
        {
            WaitElement(xpath);
            string placeholder = GetElement(xpath).GetAttribute("placeholder");
            Log().Info(string.Format("The elements' placeholder is : {0}", placeholder));
            return placeholder;
        }
        /// <summary>
        /// get title of page
        /// </summary>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>

        public static string GetTitle()
        {
            if (driver != null)
            {
                WaitPage();
                string title = driver.Title;
                Log().Info(string.Format("The title is : {0}", title));
                return title;
            }
            else
            {
                throw new Exception("driver is null");
            }
        }
        /// <summary>
        /// get current url of page
        /// </summary>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public static string GetCurrentUrl()
        {
            if (driver != null)
            {
                WaitPage();
                string url = driver.Url;
                Log().Info(string.Format("The windows' url is : {0}", url));
                return url;
            }
            else
            {
                throw new Exception("driver is null");
            }
        }
        /// <summary>
        /// get attribute of element
        /// </summary>
        /// <param name="xpath"></param>
        /// <param name="attribute"></param>
        /// <returns></returns>

        public static string GetAttribute(string xpath, string attribute)
        {
            string at = GetElement(xpath).GetAttribute(attribute);
            Log().Info(string.Format("The element' {0} is :  {1}", attribute, at));
            return at;
        }
        /// <summary>
        /// accept alter
        /// </summary>
        /// <exception cref="Exception"></exception>

        public static void AcceptAlter()
        {
            if (driver != null)
            {
                driver.SwitchTo().Alert().Accept();
                Log().Info(string.Format("Accept the alter"));
            }
            else
            {
                throw new Exception("driver is null");
            }


        }
        /// <summary>
        /// dismiss alter
        /// </summary>
        public static void DismissAlter()
        {
            driver?.SwitchTo().Alert().Dismiss();
            Log().Info("Dismiss the alter");
        }
        /// <summary>
        /// verify if element is displayed
        /// </summary>
        /// <param name="xpath"></param>
        /// <returns></returns>
        public static bool IsElementExist(string xpath)
        {

            return GetElement(xpath).Displayed;

        }
        /// <summary>
        /// get current full time
        /// </summary>
        /// <returns></returns>
        public static string GetCurrentFullTime()
        {
            Console.WriteLine(DateTime.Now.ToString("hh_mm_ss_tt_dddd_MM-dd-yyyy"));
            return DateTime.Now.ToString("hh_mm_ss_tt_dddd_yyyy-MM-dd");
        }
        /// <summary>
        /// get current date
        /// </summary>
        /// <returns></returns>
        public static string GetCurrentDate()
        {
            Console.WriteLine(DateTime.Now.ToString("MM-dd-yyyy-dddd"));
            return DateTime.Now.ToString("MM-dd-yyyy-dddd");
        }
        /// <summary>
        /// get current time
        /// </summary>
        /// <returns></returns>
        public static string GetCurrentTime()
        {
            Console.WriteLine(DateTime.Now.ToString("hh_mm_ss_tt"));
            return DateTime.Now.ToString("hh_mm_ss_tt");
        }
        /// <summary>
        /// get random number
        /// </summary>
        /// <param name="length"></param>
        /// <returns></returns>

        public static String GetRandomNumber(int length)
        {
            string buffer = "0123456789";// 随机字符中也可以为汉字（任何）
            StringBuilder sb = new StringBuilder();
            Random r = new Random();
            int range = buffer.Length;
            for (int i = 0; i < length; i++)
            {
                sb.Append(buffer.Substring(r.Next(range), 1));
            }
            return sb.ToString();
        }
        /// <summary>
        /// get random string
        /// </summary>
        /// <param name="length"></param>
        /// <returns></returns>

        public static string GetRandomString(int length)
        {
            string str = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz";
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < length; i++)
            {
                sb.Append(str[new Random(Guid.NewGuid().GetHashCode()).Next(0, str.Length - 1)]);
            }
            return sb.ToString();
        }
        /// <summary>
        /// get random string and number
        /// </summary>
        /// <param name="length"></param>
        /// <returns></returns>

        public static String GetRandom(int length)
        {
            string code = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            Random rand = new Random();
            char[] result = new char[length];
            string? r = null;
            Regex digit = new Regex("\\d");
            Regex letter = new Regex("[a-zA-Z]");
            do
            {
                for (int i = 0; i < length; i++)
                    result[i] = code[rand.Next(0, code.Length)];
                r = new String(result);
            } while (!(digit.IsMatch(r) && letter.IsMatch(r)));

            return r;
        }
        /// <summary>
        /// Type enter
        /// </summary>
        /// <param name="xpath"></param>
        public static void TypeEnter(string xpath)
        {
            GetElement(xpath).SendKeys(Keys.Enter);
        }
    }
}