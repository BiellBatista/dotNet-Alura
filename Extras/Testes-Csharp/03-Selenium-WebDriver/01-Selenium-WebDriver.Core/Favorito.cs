﻿using System;
using System.Collections.Generic;
using System.Text;

namespace _01_Selenium_WebDriver.Core
{
    public class Favorito
    {
        public int IdLeilao { get; set; }
        public int IdInteressada { get; set; }
        public Leilao LeilaoFavorito { get; set; }
        public Interessada Seguidor { get; set; }
    }
}
