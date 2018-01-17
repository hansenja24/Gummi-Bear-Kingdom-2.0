using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Gummi_Bear_Kingdom.Models
{
    [Table("Reviews")]
    public class Review
    {
        public Review(int thisId, int thisRating, string thisComment)
        {
            ReviewId = thisId;
            Rating = thisRating;
            Comment = thisComment;
        }

        public Review()
        {

        }

        [Key]
        public int ReviewId { get; set; }
        public string Author { get; set; }
        public int Rating { get; set; }
        public string Comment { get; set; }
        public int ProductId { get; set; }
        public virtual Product Products { get; set; }


    }
}
