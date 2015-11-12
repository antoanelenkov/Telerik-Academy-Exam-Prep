using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetwork.Models
{
    public class Message
    {
        public int MessageId { get; set; }

        public virtual int AuthorId { get; set; }
        public virtual UserProfile Author { get; set; }

        [Required]
        public string Content { get; set; }

        public DateTime RecievedDate { get; set; }

        public DateTime SeenDate { get; set; }
    }
}
