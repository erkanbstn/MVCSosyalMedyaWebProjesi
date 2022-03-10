using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Concrete
{
    public class Context: DbContext
    {
        public DbSet<Activity> Activities { get; set; }
        public DbSet<Contact> Contacts{ get; set; }
        public DbSet<Group> Groups{ get; set; }
        public DbSet<Media> Medias { get; set; }
        public DbSet<People>Peoples { get; set; }
        public DbSet<School>Schools { get; set; }
        public DbSet<SchoolPart> SchoolParts { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<Message> Messages { get; set; }
        public DbSet<ImageFile> ImageFiles { get; set; }
        public DbSet<Admin> Admins { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<FriendRequest> FriendRequests { get; set; }

    }
}
