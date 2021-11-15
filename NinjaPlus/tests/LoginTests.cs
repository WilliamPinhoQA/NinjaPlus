
using System.Threading;
using NinjaPlus.Pages;
using NinjaPlus.Commom;
using NUnit.Framework;

namespace NinjaPlus.Tests
{
    public class LoginTests : BaseTest
    {

        private LoginPage _login;
        private SideBar _side;

        [SetUp]
        public void Start()
        {
            _login = new LoginPage(Browser);
            _side = new SideBar(Browser);
        }


        [Test]
        public void ShouldSeeLoggedUser()
        {

            _login.With("madoka32@ninjaplus.com", "madoka123");
            Assert.AreEqual("William", _side.LoggedUser());

        }

        [TestCase("madoka32@ninjaplus.com", "1", "Usuário e/ou senha inválidos")]
        [TestCase("1", "1", "Usuário e/ou senha inválidos")]
        [TestCase("", "madoka123", "Opps. Cadê o email?")]
        [TestCase("madoka32@ninjaplus.com", "", "Opps. Cadê a senha?")]
        
        public void ShouldSeeAlertMessage(string email, string pass, string expectedMessage)
        {


            _login.With(email, pass);
            Assert.AreEqual(expectedMessage, _login.AlertMessage());

        }

    }
}