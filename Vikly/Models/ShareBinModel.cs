using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Vikly.Models
{
    public class ShareBinModel
    {
        [Required]
        public string ShareBinCode { get; set; }
        [Required]
        public string ShareBinTitle { get; set; }
        [Required]
        [StringLength(20)]
        [Key]
        public string ShareBinKey { get; set; }
        //public DateTime CreationTime { get; set; }
        public int NumberOfClicks { get; set; }   
    }
}
