using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace PostManagement.Models
{
    [Table("Users")]
    [Serializable]
    [DataContract(IsReference = true)]
    public class User
    {
        [Key]
        public int UserID { get; set; }
        public string UserName { get; set; }
        public string EmailAddress { get; set; }
        public string ContactNo { get; set; }
        public string Address { get; set; }
        public DateTime DateOfBirth { get; set; }
        public int RoleID { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreattionDate { get; set; }
        public int ModifiedBy { get; set; }
        public DateTime ModiticationDate { get; set; }
        public bool ActiveStaus { get; set; }
        public virtual Role Role { get; set; }
        public  virtual ICollection<Post> Posts { get; set; }

    }
}