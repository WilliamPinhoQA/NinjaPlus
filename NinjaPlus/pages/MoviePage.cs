using Coypu;
using NinjaPlus.Models;
using System.Threading;
using System.Collections.Generic;
using OpenQA.Selenium;
using NUnit.Framework;
using System.Linq;

namespace NinjaPlus.Pages
{

    public class MoviePage
    {

        private readonly BrowserSession _browser;

        public MoviePage(BrowserSession browser)

        {
            _browser = browser;
        }




        public void Add()
        {
            _browser.FindCss(".movie-add").Click();
        }

        public void SelectStatus(string status)
        {
            _browser.FindCss("input[placeholder=Status]").Click();
            var option = _browser.FindCss("ul li span", text: status);
            option.Click();
        }

        public void SelectYear(string year)
        {
            // _browser.FillIn("year").With(year);
            // _browser.FindCss("input[name=year]").SendKeys(year);
            _browser.FindCss("input[placeholder*=lançamento]").SendKeys(year);
            // input placeholder não funciona com mais de uma palavra. ( Exemplo: ano do lançamento n vai, tem q usar só ano ou lançamento)
            // FillIn não funciona com input placeholder, apenas id e name
        }


        public void SelectReleaseDate(string releaseDate)
        {

            _browser.FindCss("input[name=release_date]").SendKeys(releaseDate);


        }
        public void SelectPlot(string plot)
        {

            _browser.FindCss("textarea[name=overview]").SendKeys(plot);

        }

        private void InputCast(List<string> cast)
        {

            var element = _browser.FindCss("input[placeholder$=ator]"); // busca apenas a ultima palavra do placeholder
            element.Click();
            //     _browser.FindCss("input[placeholder^=ator]").SendKeys(cast);  busca apenas a primeira palavra do placeholder
            //     _browser.FindCss("input[placeholder*=ator]").SendKeys(cast);  contains no placeholder
            foreach (var actor in cast)
            {
                element.SendKeys(actor);
                element.SendKeys(Keys.Tab);
                Thread.Sleep(500); // t thinking time
            }

        }

        public void InputImage(string img)
        {
            var jsScript = "document.getElementById('upcover').classList.remove('el-upload__input');";
            _browser.ExecuteScript(jsScript);
            _browser.FindCss("#upcover").SendKeys(img);

        }


        public void Save(MovieModel movie)
        {
            _browser.FillIn("title").With(movie.Title);
            SelectStatus(movie.Status);
            SelectYear(movie.Year);
            SelectPlot(movie.Plot);
            SelectReleaseDate(movie.ReleaseDate);
            InputCast(movie.Cast);
            InputImage(movie.Cover);
            _browser.ClickButton("Cadastrar");



            //  _browser.FindCss("input[name=title]").SendKeys(title);
        }

        public bool HasMovie(string title)
        {

            bool hasMovie = _browser.FindCss("table tbody tr", text: title, Options.First).Exists();
            return hasMovie;

        }

        public int CountMovie()
        {
           return _browser.FindAllCss("table tbody tr").Count();
        }

        public void Search(string value)
        {
            _browser.FindCss("input[placeholder^=Pesquisar]").FillInWith(value);
            ;
            _browser.FindId("search-movie").Click();
             Thread.Sleep(2000);
        }



    }
}