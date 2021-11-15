using System;
using System.IO;
using Coypu;
using Coypu.Drivers.Selenium;
using Microsoft.Extensions.Configuration;
using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;

namespace NinjaPlus.Commom
{
    public class BaseTest
    {

        // public = propriedade é acessada por qualquer código ou projeto // começa com letra minuscula
        //private =  propriedade só pode ser acessada pela classe que ela está // começa com _++Letra maiscula
        //protected = só por ser acessada por ela ou por um filho herdado // começa com letra maiscula

        protected BrowserSession Browser;
        [SetUp]
        public void Setup()
        {
            var config = new ConfigurationBuilder()
                .AddJsonFile("config.json")
                .Build();


            var sessionConfig = new SessionConfiguration
            {

                AppHost = "http://ninjaplus-web:5000",
                Port = 5000,
                SSL = false,
                Driver = typeof(SeleniumWebDriver),
                Timeout = TimeSpan.FromSeconds(10),



            };
            if (config["browser"].Equals("chrome"))
            {
                sessionConfig.Browser = Coypu.Drivers.Browser.Chrome;
                var chromeOptions = new ChromeOptions();
                chromeOptions.AddArguments("headless");
            }
            if (config["browser"].Equals("firefox"))
            {
                sessionConfig.Browser = Coypu.Drivers.Browser.Firefox;
            }
            if (config["browser"].Equals("opera"))
            {
                sessionConfig.Browser = Coypu.Drivers.Browser.Opera;
            }


            Browser = new BrowserSession(sessionConfig);


             Browser.MaximiseWindow();
        }

        public void TakeScreenshot()
        {
            var shotPath = Environment.CurrentDirectory + "\\screenshots\\";
            var resultId = TestContext.CurrentContext.Test.ID;

            if (!Directory.Exists(shotPath))
            {
                Directory.CreateDirectory(shotPath);
            }

            var screenshot = $"{shotPath}\\{resultId}.png";

            Browser.SaveScreenshot(screenshot);
            TestContext.AddTestAttachment(screenshot);
        }

        public string CoverPath()
        {
            var outputPath = Environment.CurrentDirectory;
            var coverPath = outputPath + "\\img\\";
            return coverPath;
        }

        [TearDown]
        public void Finish()
        {

            try
            {
                TakeScreenshot();
            }
            catch (Exception e)
            {
                Console.WriteLine("Erro during screenshot,");
                throw new Exception(e.Message);
            }
            finally
            {
                Browser.Dispose();
            }

        }

    }
}