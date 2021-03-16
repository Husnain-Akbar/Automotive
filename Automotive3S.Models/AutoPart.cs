using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Automotive3S.Models
{
    public class AutoPart
    {
        public int Id { get; set; }
        [Required]
        public int CategoryId { get; set; }

        [ForeignKey("CategoryId")]
        public virtual Category Category { get; set; }

        [Required]
        public int SubCategoryId { get; set; }

        [ForeignKey("SubCategoryId")]
        public virtual SubCategory SubCategory { get; set; }
 
        public string Description { get; set; }
        
        public string SellerComments { get; set; }

        public string MainImageUrl { get; set; }

        public ICollection<PartGallery> PartGallery { get; set; }
    }
}
