using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Vidly.Models
{
    public class Rents
    {
        

        [Key]
        public int RentId { get; set; }

        [ForeignKey("CustomerId")]
        public Customer Customer { get; set; }

        public int CustomerId { get; set; }

        [ForeignKey("MovieId")]
        public Movie Movie { get; set; }

        public int MovieId { get; set; }

    }
}