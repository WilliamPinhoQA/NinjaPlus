using Coypu;
namespace NinjaPlus.Pages
{

    public class LoginPage
    {




        private readonly BrowserSession _browser;


        public void Load()
        {
            _browser.Visit("/login");
        }
        public LoginPage(BrowserSession browser)
        {
            _browser = browser;
        }

        public void With(string email, string password)
        {
            this.Load();
            _browser.FillIn("emailId").With(email); // Ordem fillIn id>name>label
            _browser.FillIn("password").With(password); // or via css when id don't exist / browser.FindCss("[placeholder=senha]").SendKeys("madoka123");
            _browser.ClickButton("Entrar");
        }

        public string AlertMessage()
        {
            return _browser.FindCss(".alert").Text;
        }
    }
}