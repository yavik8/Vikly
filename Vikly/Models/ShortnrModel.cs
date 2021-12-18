using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Vikly.Models
{
    public class ShortnrModel
    {
        [Required]     
        public string LongUrl { get; set; }
        [Required]
        [StringLength(20)]
        [Key]
        public string ShortUrl { get; set; }
       // public DateTime CreationTime { get; set; }
        public int NumberOfClicks { get; set; }
    }
}
