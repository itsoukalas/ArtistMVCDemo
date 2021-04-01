using ArtistMVCDemo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ArtistMVCDemo.ViewModels
{
    public class SongFormViewModel
    {
        public List<Album> Albums { get; set; }
        public Song song { get; set; }
    }
}