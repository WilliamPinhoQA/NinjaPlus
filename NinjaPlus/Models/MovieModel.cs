
using System;
using System.Collections.Generic;

namespace NinjaPlus.Models{


    public class MovieModel{
        public string Title {get;set;}

        public string Status {get;set;}

        public string Year {get;set;}

        public string ReleaseDate {get;set;}

        public List<string> Cast = new List<string>();

        public string Plot {get;set;}

        public string Cover {get;set;}


    }
}