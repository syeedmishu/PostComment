using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace PostManagement.Models
{
    [Table("Posts")]
    
    public class Post
    {
        [Key]
        public int PostID { get; set; }
        public string PostTitle { get; set; }
        public string PostDescription { get; set; }
        public DateTime CreationDate { get; set; }
        public int CreatedBy { get; set; }
        public DateTime? ModificationDate { get; set; }
        public int? ModifiedBy { get; set; }
        public bool ActiveStatus { get; set; }
        public virtual User User { get; set; }
        public virtual ICollection<Comment> Comments { get; set; }
        public List<Comment> CommentList { get; set; }
        [NotMapped]
        public string UserName { get; set; }
        [NotMapped]
        public string TotalComment { get; set; }
        [NotMapped]
        public string FormattedDate { get; set; }

    }
}