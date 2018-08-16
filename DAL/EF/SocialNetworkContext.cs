using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace DAL.EF
{
    public class SocialNetworkContext: DbContext
    {
        static SocialNetworkContext()
        {
            Database.SetInitializer<SocialNetworkContext>(new MyContextInitializer());
        }

        public SocialNetworkContext(string connectionString)
            : base(connectionString)
        {

        }

        public DbSet<User> Users { get; set; }
        public DbSet<Message> Messages { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<ListContacts> ListsContacts { get; set; }
        public DbSet<FriendRequest> FriendRequests { get; set; }

        class MyContextInitializer : DropCreateDatabaseIfModelChanges<SocialNetworkContext>
        {
            protected override void Seed(SocialNetworkContext db)
            {
                db.Database.CreateIfNotExists();
                //User u1 = new User() { FirstName = "Аня", LastName = "Степанюк" ,/* Age = 19,*/
                //                       Email = "AnyaStepaniuk@gmail.com"/*, Password = "AnyaStepaniuk"*/};
                //User u2 = new User() { FirstName = "Іван", LastName = "Іванов", /*Age = 18,*/
                //                       Email = "IvanIvanov@gmail.com"/*, Password = "IvanIvanov"*/};
                //User u3 = new User() { FirstName = "Катя", LastName = "Васильева", /*Age = 15,*/
                //                       Email = "KatyaVasileva@gmail.com"/*, Password = "KatyaVasileva"*/};

                //db.Users.Add(u1);
                //db.Users.Add(u2);
                //db.Users.Add(u3);


                //Contact c1 = new Contact
                //{
                //    UserId = 2,
                //    FirstName = "Vasya",
                //    LastName = "Pupkin"
                //};
                //db.Contacts.Add(c1);

                //ListContacts l1 = new ListContacts() ;
                //l1.Friends.Add(c1);
                //db.ListsContacts.Add(l1);

                db.SaveChanges();
            }
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
           
        }
    }
}

