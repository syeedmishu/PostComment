using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.DirectoryServices.AccountManagement;
using System.Linq;
using System.Web;

namespace PostManagement.Models
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext() : base("name=PostConnection")
        {
            base.Configuration.ProxyCreationEnabled = false;
        }

        public DbSet<Role> Roles { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Like> Likes { get; set; }
        public DbSet<Dislike> Dislikes { get; set; }

    }
}