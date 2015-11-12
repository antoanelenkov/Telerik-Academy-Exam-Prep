using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetwork.Models
{
    public class FriendShip
    {
        public int FriendShipId { get; set; }

        [ForeignKey("UserProfileId")]
        public int RequesterId { get; set; }

        [Required]
        public UserProfile Requester { get; set; }

        [ForeignKey("UserProfileId")]
        public int RecieverId { get; set; }

        [Required]
        public UserProfile Reciever { get; set; }

        public DateTime ApprovedDate { get; set; }
        public bool IsApproved { get; set; }
    }
}
