using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ArtistMVCDemo.Models
{
    public class Song
    {
        public int ID{ get; set; }
        [Required(ErrorMessage = "FirstName is required")]
        [StringLength(60, MinimumLength = 3)]
        public string Title{ get; set; }

        public string Youtube { get; set; }

        public int AlbumId { get; set; }
        public Album album { get; set; }
    }
}