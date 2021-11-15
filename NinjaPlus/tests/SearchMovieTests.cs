
using NinjaPlus.Commom;
using NinjaPlus.Lib;
using NinjaPlus.Pages;
using NUnit.Framework;

namespace NinjaPlus.Tests
{

    public class SearchMovieTests : BaseTest
    {
        private LoginPage _login;
        private MoviePage _movie;

        [SetUp]
        public void Before()

        {
            _login = new LoginPage(Browser);
            _movie = new MoviePage(Browser);
            _login.With("madoka32@ninjaplus.com", "madoka123");
            Database.InsertMovies();
            
        }

        [Test]
        [TestCase("Coringa", 1)]
        [TestCase("Batman", 2)]
        [TestCase("Geass", 0)]
        [Category("Click")]
        public void ShouldFindUniqueMovie(string moviename, int quantity)
        {
            _movie.Search(moviename);
            //moviename = "NicoNicoNIII";
            if (quantity > 0)
            {
                Assert.That(_movie.HasMovie(moviename), $"Search error movie {moviename}, please check");

             //   Browser.HasNoContent("Puxa! não encontramos nada aqui :(");
            }
            else
            {
                string msgerror = Browser.FindCss(".card-body .alert-dark span").Text;
                Assert.False(_movie.HasMovie(moviename), $"Search error movie {moviename}, please check");
                Assert.AreEqual("Puxa! não encontramos nada aqui :(", msgerror);
            }
            
            Assert.AreEqual(quantity, _movie.CountMovie());
        }

}
}