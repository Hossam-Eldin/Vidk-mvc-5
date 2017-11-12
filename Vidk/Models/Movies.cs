using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using System.Web;

namespace Vidk.Models
{
    public class Movies
    {
        public int Id { get; set; }
        public string Name { get; set; }
        
         [Required]
         public Genre Genre { get; set; }
         public byte GenreId { get; set; }
         public DateTime DateAdded { get; set; }
         public DateTime ReleaseDate { get; set; }
         public byte NumberInStock { get; set; }
    }
}