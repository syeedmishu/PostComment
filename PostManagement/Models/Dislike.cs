using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace PostManagement.Models
{
    [Table("Dislikes")]
   
    public class Dislike
    {    [Key]
        public int DislikeID { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreationDate { get; set; }
        public int CommentID { get; set; }
        public virtual Comment Comment { get; set; }

    }
}