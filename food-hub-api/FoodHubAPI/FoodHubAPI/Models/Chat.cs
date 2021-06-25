using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace FoodHubAPI.Models
{
    public class Chat
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string ConversationId { get; set; }
        [Required]
        [ForeignKey("UserFromFK")]
        public string FromUserId { get; set; }
        public User UserFromFK { get; set; }
        [Required]
        public string FromUserName { get; set; }
        [Required]
        public string ToUserId { get; set; }
        [Required]
        public string ToUserName { get; set; }
        [Required]
        public string Message { get; set; }
        [Required]
        public DateTime SentAt { get; set; }
        [Required]
        public bool Read { get; set; }
    }
}
