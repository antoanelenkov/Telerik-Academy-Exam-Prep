namespace SocialNetwork.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class UserProfile
    {
        private ICollection<Image> images;
        private ICollection<Post> posts;
        private ICollection<Message> messages;
        //private ICollection<FriendShip> friendships;

        public UserProfile()
        {
            this.images = new HashSet<Image>();
            this.posts = new HashSet<Post>();
            this.messages = new HashSet<Message>();
           // this.friendships = new HashSet<FriendShip>();
        }

        public int UserProfileId { get; set; }

        [MinLength(4)]
        [MaxLength(20)]
        [Required]
       // [Index(IsUnique = true)] cant find it in namespace
        public string UserName { get; set; }

        [MinLength(2)]
        [MaxLength(50)]
        public string FirstName { get; set; }

        [MinLength(2)]
        [MaxLength(50)]
        public string LastName { get; set; }

        public DateTime RegistrationDate { get; set; }

        public virtual ICollection<Image> Images
        {
            get { return this.images; }
            set { this.images = value; }
        }

        public virtual ICollection<Post> Posts
        {
            get { return this.posts; }
            set { this.posts = value; }
        }

        public virtual ICollection<Message> Messages
        {
            get { return this.messages; }
            set { this.messages = value; }
        }

        //public virtual ICollection<FriendShip> Friendships
        //{
        //    get { return this.friendships; }
        //    set { this.friendships = value; }
        //}
    }
}
