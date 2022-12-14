using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Vidly.Models
{
    public class Movie
    {
        [Key]
        public int Id { set; get; }

        [Required]
        [StringLength(255)]
        public string Name { set; get; }

       
        public Genre Genre { get; set; }
        [Required]
        public byte GenreId { get; set; }

        public DateTime DateAdded { get; set; }

        public DateTime ReleaseDate { get; set; }
        [Range(0,22)]
        public byte NumberInStock { get; set; }

         public List<Rents> Rents { get; set; }

    }
}