using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity;
using SampleTest3.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace SampleTest3.Data
{
    public class DataInitializer : DropCreateDatabaseAlways<ApplicationDbContext>
    {
        // TEST NOTE: Create the data initializer to create an author, 3 books that are written by that author
        //            and a test user with the admin role
        protected override void Seed(ApplicationDbContext context)
        {
            ApplicationUser user1 = new ApplicationUser
            {
                UserName = "test@test.ca",
                Email = "test@test.ca",
                DateOfBirth = new DateTime(2000, 1, 1)

            };

            UserStore<ApplicationUser> userStore = new UserStore<ApplicationUser>(context);
            UserManager<ApplicationUser> userManager = new UserManager<ApplicationUser>(userStore);

            IdentityRole role1 = new IdentityRole { Name = "Admin" };
            RoleStore<IdentityRole> roleStore = new RoleStore<IdentityRole>(context);
            RoleManager<IdentityRole> roleManager = new RoleManager<IdentityRole>(roleStore);

            roleManager.Create(role1);
            userManager.Create(user1, "testing1234");
            userManager.AddToRole(user1.Id, "Admin");

            Author a1 = new Author
            {
                Id = 1,
                Name = "Author1",
            };

            Book b1 = new Book
            {
                Id = 1,
                Title = "Oswald",
                Cost = 25.99,
                Author = a1
            };

            context.Books.Add(b1);
         //   user1.Books.Add(b1);

            context.Books.Add(new Book
            {
                Id = 2,
                Title = "Winne and Pooh",
                Cost = 30.00,
                Author = a1
            });

            context.Books.Add(new Book
            {
                Id = 3,
                Title = "Train and Friends",
                Cost = 19.99,
                Author = a1
            });
            base.Seed(context);
        }
    }
}