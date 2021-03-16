using System;
using System.Collections.Generic;
using System.Text;

namespace Automotive3S.Models
{
    public class PartGallery
    {
        public int Id { get; set; }
        public int BookId { get; set; }
        public string Name { get; set; }
        public string URL { get; set; }

        public AutoPart AutoPart { get; set; }
    }
}
