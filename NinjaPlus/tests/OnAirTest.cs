using NUnit.Framework;
using NinjaPlus.Pages;
using NinjaPlus.Commom;

namespace NinjaPlus.Tests
{
    public class OnAirTest : BaseTest
    {


        [Test]
        [Category("Smoke")]
        [Category("Critical")]
        public void ShoudBeHaveTitle()
        {
            var loginPage = new LoginPage(Browser);

            loginPage.Load();
            Assert.AreEqual("Ninja+", Browser.Title);
           

        }


    }
}