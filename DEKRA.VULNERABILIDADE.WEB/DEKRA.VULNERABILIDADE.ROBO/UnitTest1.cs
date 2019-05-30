using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace DEKRA.VULNERABILIDADE.ROBO
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            IWebDriver driver;
            driver = new ChromeDriver(@"c:\users\paulo.natale\documents\visual studio 2013\Projects\CheckAuto.WebTest\CheckAuto.WebTest\Drivers\Chrome\");
            driver.Navigate().GoToUrl("http://hml.checkauto.com.br/Recall/Admin/Login");
            driver.Manage().Window.Maximize();

        }
    }
}
