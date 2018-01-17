using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System;

namespace Gummi_Bear_Kingdom.Models
{
    [Table("Products")]
    public class Product
    {
        public Product(int thisId, string thisName, int thisCost, string thisDescription)
        {
            ProductId = thisId;
            Name = thisName;
            Cost = thisCost;
            Description = thisDescription;
        }

        public Product()
        {
            
        }

        [Key]
        public int ProductId { get; set; }
        public string Name { get; set; }
        public int Cost { get; set; }
        public string Description { get; set; }
        public virtual ICollection<Review> Reviews { get; set; }

        public double GetAverage()
        {
            double totalRating = 0;
            double index = 0;
            foreach(var Review in Reviews)
            {
                totalRating = totalRating + Review.Rating;
                index++;
            }
            double result = totalRating / index;

            return Math.Round(result,2);
        }
    }
}
