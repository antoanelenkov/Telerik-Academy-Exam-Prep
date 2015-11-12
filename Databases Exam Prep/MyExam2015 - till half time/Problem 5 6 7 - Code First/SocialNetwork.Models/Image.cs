using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetwork.Models
{
    public class Image
    {
        public int ImageId { get; set; }

        public string Url { get; set; }

        [MaxLength(4)]
        [Required]
        public string Extension { get; set; }

        public virtual int UserProfileId { get; set; }

        public virtual UserProfile UserProfile { get; set; }
    }
}
