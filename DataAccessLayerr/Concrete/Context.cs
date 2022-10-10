using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Text;

namespace DataAccessLayer.Concrete
{
   public class Context:DbContext
    {
        public DbSet<Admin> Admins { get; set; }
        public DbSet<Announcement> Announcements { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Content> Contents { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<ImageFile> ımageFiles { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Title> Titles { get; set; }
        public DbSet<Deliver> Delivers { get; set; }
       
    }
}
