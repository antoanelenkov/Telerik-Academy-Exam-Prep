using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetwork.Models
{
    public class Post
    {
        private ICollection<UserProfile> users;

        public Post()
        {
            this.users = new HashSet<UserProfile>();
        }


        public int PostId { get; set; }

        [MinLength(10)]
        [Required]
        public string Content { get; set; }

        public DateTime PostingDate { get; set; }

        public virtual ICollection<UserProfile> Users
        {
            get { return this.users; }
            set { this.users = value; }
        }
    }
}
