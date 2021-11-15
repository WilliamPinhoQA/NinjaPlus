using NUnit.Framework;
using NinjaPlus.Commom;
using NinjaPlus.Pages;
using System.Threading;
using NinjaPlus.Models;
using System;
using NinjaPlus.Lib;

namespace NinjaPlus.Tests
{

    public class SaveMovieTest : BaseTest
    {


        private LoginPage _login;
        private MoviePage _movieteste;



        [SetUp]
        public void Before()

        {
            _login = new LoginPage(Browser);
            _movie = new MoviePage(Browser);
            _login.With("madoka32@ninjaplus.com", "madoka123");
        }


        [TestCase("Seishun Buta Yarou wa Bunny Girl Senpai no Yume wo Minai", "Disponível", "2018", "04/10/2018", "Sakurajima Mei", "Azusaga Sakuta", "Azusaga Kaede",
         "Um anime muito melhor que monogatari.", "cover bg.jpg")]
        [TestCase("Mahou Shoujo Madoka★Magica Movie 4: Walpurgis no Kaiten", "Em breve", "2022", "02/02/2022","Akemi, Homura", "Kaname, Madoka", "Sakura, Kyouko",
         "Mahou Shoujo Madoka★Magica Movie 3: Hangyaku no Monogatari follows Homura in her struggle to uncover the painful truth behind the mysterious circumstances.", "cover madoka.jpg")]
        //  [TestCase("Perfect Blue","Pré-venda","1998")]
        [Category("add")]
        public void ShouldSaveMovie(string title, string status, string year, string releaseDate, string actor1, string actor2, string actor3, string plot, string img)
        //  string releasedate, string cast , string cover
        {



            var movieData = new MovieModel()
            {

                Title = title,
                Status = status,
                Year = year,
                ReleaseDate = releaseDate,
                Cast = { actor1, actor2, actor3 },
                Plot = plot,
                Cover = CoverPath() + img


            };
            Database.RemoveByTitle(title);
            /*    movieData.Title = title ;
                movieData.Status = status; */
            _movie.Add();
            _movie.Save(movieData);
            //  movieData.Title = "madoka favela cria";

            Assert.That(_movie.HasMovie(movieData.Title),
            $"Movie {movieData.Title} Registration error, please check");

        }
    }



}