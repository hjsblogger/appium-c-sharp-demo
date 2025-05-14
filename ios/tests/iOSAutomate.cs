using System;
using System.Collections.Generic;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.iOS;
using OpenQA.Selenium.Support.UI;

/* For MSTest */
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CSharpAppiumNUnit
{
    [TestFixture]
    public class AppiumTest
    {
        private IOSDriver driver;

        public static readonly string? LT_USERNAME = Environment.GetEnvironmentVariable("LT_USERNAME");
        public static readonly string? LT_ACCESS_KEY = Environment.GetEnvironmentVariable("LT_ACCESS_KEY");
        public static readonly string? LT_APP = "proverbial-ios"; // LambdaTest app ID
        public static readonly string? LT_SERVER_URL = "https://mobile-hub.lambdatest.com/wd/hub";

        [SetUp]
        public void Setup()
        {
            try
            {
                // Initialize AppiumOptions with necessary capabilities
                var caps = new AppiumOptions();
                Dictionary<string, object> ltOptions = new Dictionary<string, object>();

                ltOptions.Add("username", LT_USERNAME!);
                ltOptions.Add("accessKey", LT_ACCESS_KEY!);
                ltOptions.Add("w3c", true);
                ltOptions.Add("platformName", "ios");
                ltOptions.Add("deviceName", "iPhone *");
                ltOptions.Add("platformVersion", "17");
                ltOptions.Add("isRealMobile", true);
                ltOptions.Add("name", "NUnit - CSharp Sample iOS");
                ltOptions.Add("build", "NUnit - CSharp Sample iOS");
                ltOptions.Add("app", LT_APP!);

                // LambdaTest-specific capabilities 
                caps.AddAdditionalAppiumOption("username", LT_USERNAME);
                caps.AddAdditionalAppiumOption("user", LT_USERNAME);
                caps.AddAdditionalAppiumOption("accessKey", LT_ACCESS_KEY);
                caps.AddAdditionalAppiumOption("isRealMobile", true);
                caps.AddAdditionalAppiumOption("w3c", true);
                caps.AddAdditionalAppiumOption("network", false);
                caps.AddAdditionalAppiumOption("project", "CSharp Sample Android");
                caps.AddAdditionalAppiumOption("build", "CSharp Sample Android");
                caps.AddAdditionalAppiumOption("name", "CSharp Sample Android");
                caps.AddAdditionalAppiumOption("appiumVersion", "2.15.0");
                caps.AddAdditionalAppiumOption("lt:options", ltOptions);

                // Initialize the AndroidDriver
                driver = new IOSDriver(new Uri(LT_SERVER_URL!), caps);
                driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Setup failed: {ex.Message}");
                throw;
            }
        }

        [Test]
        public void TestAppFeatures()
        {
            PerformTestActions(driver);
        }

        [TearDown]
        public void Cleanup()
        {
            Dispose();
        }

        public void Dispose()
        {
            driver?.Dispose();
        }

        private static void PerformTestActions(IOSDriver driver)
        {
            ClickElement(driver, MobileBy.Id("color"));
            ClickElement(driver, MobileBy.Id("Text"));
            ClickElement(driver, MobileBy.Id("toast"));
            ClickElement(driver, MobileBy.Id("notification"));
            ClickElement(driver, MobileBy.Id("geoLocation"));

            System.Threading.Thread.Sleep(5000);
            driver.Navigate().Back();

            /* This opens up an ad, so disabling it for now */
            /*
            ClickElement(driver, MobileBy.Id("speedTest"));
            System.Threading.Thread.Sleep(5000);
            driver.Navigate().Back();
            */

            ClickElement(driver, MobileBy.AccessibilityId("Browser"));
            ClickElement(driver, MobileBy.Id("url"));
            return;
        }

        private static void ClickElement(IOSDriver driver, By locator)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));
            IWebElement element = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(locator));
            element.Click();
        }
    }
}

namespace CSharpAppiumMSTest
{
    [TestClass]
    public class AppiumTest : IDisposable
    {
        private IOSDriver? driver;

        public static readonly string? LT_USERNAME = Environment.GetEnvironmentVariable("LT_USERNAME");
        public static readonly string? LT_ACCESS_KEY = Environment.GetEnvironmentVariable("LT_ACCESS_KEY");
        public static readonly string? LT_APP = "proverbial-ios"; // LambdaTest app ID
        public static readonly string? LT_SERVER_URL = "https://mobile-hub.lambdatest.com/wd/hub";

        [TestInitialize]
        public void Setup()
        {
            try
            {
                var caps = new AppiumOptions();
                Dictionary<string, object> ltOptions = new Dictionary<string, object>();

                ltOptions.Add("username", LT_USERNAME!);
                ltOptions.Add("accessKey", LT_ACCESS_KEY!);
                ltOptions.Add("w3c", true);
                ltOptions.Add("platformName", "ios");
                ltOptions.Add("deviceName", "iPhone *");
                ltOptions.Add("platformVersion", "17");
                ltOptions.Add("isRealMobile", true);
                ltOptions.Add("name", "MSTest - CSharp Sample iOS");
                ltOptions.Add("build", "MSTest - CSharp Sample iOS");
                ltOptions.Add("app", LT_APP!);

                /*
                caps.AddAdditionalAppiumOption("username", LT_USERNAME);
                caps.AddAdditionalAppiumOption("user", LT_USERNAME);
                caps.AddAdditionalAppiumOption("accessKey", LT_ACCESS_KEY);
                caps.AddAdditionalAppiumOption("isRealMobile", true);
                caps.AddAdditionalAppiumOption("w3c", true);
                caps.AddAdditionalAppiumOption("network", false);
                caps.AddAdditionalAppiumOption("project", "CSharp Sample Android");
                caps.AddAdditionalAppiumOption("build", "CSharp Sample Android");
                caps.AddAdditionalAppiumOption("name", "CSharp Sample Android");
                */
                caps.AddAdditionalAppiumOption("appiumVersion", "2.15.0");
                caps.AddAdditionalAppiumOption("lt:options", ltOptions);

                driver = new IOSDriver(new Uri(LT_SERVER_URL!), caps);
                driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Setup failed: {ex.Message}");
                throw;
            }
        }

        [TestMethod]
        public void TestAppFeatures()
        {
            if (driver != null)
            {
                PerformTestActions(driver);
            }
            else
            {
                Console.WriteLine("Driver is null. Cannot perform test actions.");
            }
        }

        [TestCleanup]
        public void Cleanup()
        {
            Dispose();
        }

        public void Dispose()
        {
            driver?.Dispose();
        }

        private static void PerformTestActions(IOSDriver driver)
        {
            ClickElement(driver, MobileBy.Id("color"));
            ClickElement(driver, MobileBy.Id("Text"));
            ClickElement(driver, MobileBy.Id("toast"));
            ClickElement(driver, MobileBy.Id("notification"));
            ClickElement(driver, MobileBy.Id("geoLocation"));

            System.Threading.Thread.Sleep(5000);
            driver.Navigate().Back();

            /*
            ClickElement(driver, MobileBy.Id("speedTest"));
            System.Threading.Thread.Sleep(5000);
            driver.Navigate().Back();
            */

            ClickElement(driver, MobileBy.AccessibilityId("Browser"));
            ClickElement(driver, MobileBy.Id("url"));
        }

        private static void ClickElement(IOSDriver driver, By locator)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));
            IWebElement element = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(locator));
            element.Click();
        }
    }
}