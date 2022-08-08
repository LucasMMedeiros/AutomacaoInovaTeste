using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium.Android;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Remote;

namespace PrimeiroProjeto
{
    class Comandos
    {

        #region Browser

        public static IWebDriver getBrowserLocal(IWebDriver driver, String browser)
        {
            switch (browser)
            {
                case "Internet Explorer":
                    driver = new InternetExplorerDriver();
                    driver.Manage().Window.Maximize();
                    break;
                case "Chrome":
                    driver = new ChromeDriver();
                    driver.Manage().Window.Maximize();
                    break;
                default:
                    driver = new FirefoxDriver();
                    driver.Manage().Window.Maximize();
                    break;                    
            }
            return driver;
        }

        public static IWebDriver getBrowserRemote(IWebDriver driver, String browser, String uri)
        {
            switch (browser)
            {
                case "Internet Explorer":
                    InternetExplorerOptions cap_ie = new InternetExplorerOptions();
                    driver = new RemoteWebDriver(new Uri(uri), cap_ie);                    
                    driver.Manage().Window.Maximize();
                    break;
                case "Chrome":
                    ChromeOptions cap_chrome = new ChromeOptions();
                    driver = new RemoteWebDriver(new Uri(uri), cap_chrome);                    
                    driver.Manage().Window.Maximize();
                    break;
                default:
                    FirefoxOptions cap_firefox = new FirefoxOptions();
                    driver = new RemoteWebDriver(new Uri(uri), cap_firefox);                    
                    driver.Manage().Window.Maximize();
                    break;
            }
            return driver;
        }

        public static IWebDriver getBrowserMobile(IWebDriver driver, String platform, String deviceName, String browserName, String uri)
        {
            switch (platform)
            {
                case "Android":
                    DesiredCapabilities cap_android = new DesiredCapabilities();
                    cap_android.SetCapability("deviceName", deviceName);
                    cap_android.SetCapability("browsweName",browserName);
                    driver = new AndroidDriver<IWebElement>(new Uri(uri),cap_android);
                    break;
               
                default:
                    DesiredCapabilities cap_default = new DesiredCapabilities();
                    cap_default.SetCapability("deviceName", deviceName);
                    cap_default.SetCapability("browsweName", browserName);
                    driver = new AndroidDriver<IWebElement>(new Uri(uri), cap_default);
                    break;
            }
            return driver;
        }
        #endregion

        #region Scripts

            public static void executeJavascript(IWebDriver driver, String script)
        {
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            js.ExecuteScript(script);
        }

        #endregion

        public static void esperarCarregamento(IWebDriver driver)
        {
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
        }
    }
}
