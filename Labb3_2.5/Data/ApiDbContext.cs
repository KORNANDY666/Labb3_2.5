using Labb3_2._5.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace Labb3_2._5.Data
{
    public class ApiDbContext : DbContext
    {

        public ApiDbContext(DbContextOptions<ApiDbContext> options) : base(options)
        {
        }

        public DbSet<Person> persons { get; set; }
        public DbSet<Interest> Interests { get; set; }
        public DbSet<Link> Links { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Person>().HasData(
                new Person
                {
                    PersonId = 1,
                    Name = "Gösta Göstasson",
                    PhoneNumber = "1234567890"

                },
                new Person
                {
                    PersonId = 2,
                    Name = "Eva Evasson",
                    PhoneNumber = "9876543210"
                },
                new Person
                {
                    PersonId = 3,
                    Name = "Lennart Lennartsson",
                    PhoneNumber = "0918273645"
                },
                new Person
                {
                    PersonId = 4,
                    Name = "Lena Lenasson",
                    PhoneNumber = "1122334455"

                },
                new Person
                {
                    PersonId = 5,
                    Name = "Jesus Jesusson",
                    PhoneNumber = "99887766"

                });

            modelBuilder.Entity<Interest>().HasData(
                new Interest
                {
                    InterestId = 1,
                    Title = "Walking",
                    Description = "Walk in the woods",
                    FK_PersonId = 1

                },
                new Interest
                {
                    InterestId = 2,
                    Title = "Code",
                    Description = "Code C#",
                    FK_PersonId = 2
                },
                new Interest
                {
                    InterestId = 3,
                    Title = "Swiming",
                    Description = "Swim faster",
                    FK_PersonId = 3
                },
                new Interest
                {
                    InterestId = 4,
                    Title = "Running",
                    Description = "Marathon",
                    FK_PersonId = 4
                },
                new Interest
                {
                    InterestId = 5,
                    Title = "Garden Work",
                    Description = "Flowers in all colour",
                    FK_PersonId = 1

                });
            modelBuilder.Entity<Link>().HasData(
                new Link
                {
                    LinkId = 1,
                    Url = "Walk.com",
                    FK_InterestId = 1
                },
                new Link
                {
                    LinkId = 2,
                    Url = "CoDelike_a_pro.com",
                    FK_InterestId = 2
                },
                new Link
                {
                    LinkId = 3,
                    Url = "Swiming.com",
                    FK_InterestId = 3
                },
                new Link
                {
                    LinkId = 4,
                    Url = "Running.com",
                    FK_InterestId = 4
                },
                new Link
                {
                    LinkId = 5,
                    Url = "Flowers.uk.com",
                    FK_InterestId = 5

                });




        }
    }
}
