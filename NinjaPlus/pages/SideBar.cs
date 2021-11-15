using Coypu;
namespace NinjaPlus.Pages
{

    public class SideBar
    {
        private readonly BrowserSession _browser;

        public SideBar(BrowserSession browser)
        {
            _browser = browser;
        }

        public string LoggedUser()
        {
            return _browser.FindCss(".user .info span").Text;
        }
    
}
}