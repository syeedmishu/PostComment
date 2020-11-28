﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace PostManagement.Models
{
    [Table("Rules")]
    public class Role
    {
        [Key]
        public int RodeID { get; set; }
        public string RoleName { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreationDate { get; set; }
        public int? ModifiedBy { get; set; }
        public DateTime? ModificationDate { get; set; }
        public bool ActiveStatus { get; set; }
        public virtual ICollection<User> Users { get; set; }
    }
}