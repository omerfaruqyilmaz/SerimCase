using Microsoft.EntityFrameworkCore;
using SerimCase.DataAccess.Concrete;
using SerimCase.Entities.Concrete;
using SerimCase.Entities.Enum;

namespace SerimCase.DataAccess.Seed
{
    public static class DataSeeder
    {

        public static void SeedData(this IApplicationBuilder app)
        {
            IServiceScope scope = app.ApplicationServices.CreateScope();
            ProjectDbContext _context = scope.ServiceProvider.GetService<ProjectDbContext>();

            _context.Database.Migrate();

            if (!_context.Customers.Any())
            {
                var customers = new List<Customer>
                {
                    new Customer
                    {
                        Name = "Ahmet",
                        SurName = "Yılmaz",
                        PhoneNumber = "5551234567",
                        Email = "ahmet.yilmaz@example.com",
                        BirthDay = new DateTime(1985, 3, 15),
                        Gender = Gender.Erkek,
                        CreatedAt = DateTime.Now,
                        IsStatus = true
                    },
                    new Customer
                    {
                        Name = "Ayşe",
                        SurName = "Demir",
                        PhoneNumber = "5552345678",
                        Email = "ayse.demir@example.com",
                        BirthDay = new DateTime(1990, 5, 20),
                        Gender = Gender.Kadın,
                        CreatedAt = DateTime.Now,
                        IsStatus = true
                    },
                    new Customer
                    {
                        Name = "Mehmet",
                        SurName = "Kaya",
                        PhoneNumber = "5553456789",
                        Email = "mehmet.kaya@example.com",
                        BirthDay = new DateTime(1982, 8, 10),
                        Gender = Gender.Erkek,
                        CreatedAt = DateTime.Now,
                        IsStatus = true
                    },
                    new Customer
                    {
                        Name = "Fatma",
                        SurName = "Şahin",
                        PhoneNumber = "5554567890",
                        Email = "fatma.sahin@example.com",
                        BirthDay = new DateTime(1988, 11, 25),
                        Gender = Gender.Kadın,
                        CreatedAt = DateTime.Now,
                        IsStatus = true
                    },
                    new Customer
                    {
                        Name = "Mustafa",
                        SurName = "Arslan",
                        PhoneNumber = "5555678901",
                        Email = "mustafa.arslan@example.com",
                        BirthDay = new DateTime(1975, 9, 5),
                        Gender = Gender.Erkek,
                        CreatedAt = DateTime.Now,
                        IsStatus = true
                    },
                    new Customer
                    {
                        Name = "Hatice",
                        SurName = "Koç",
                        PhoneNumber = "5556789012",
                        Email = "hatice.koc@example.com",
                        BirthDay = new DateTime(1986, 7, 12),
                        Gender = Gender.Kadın,
                        CreatedAt = DateTime.Now,
                        IsStatus = true
                    },
                    new Customer
                    {
                        Name = "Ali",
                        SurName = "Turan",
                        PhoneNumber = "5557890123",
                        Email = "ali.turan@example.com",
                        BirthDay = new DateTime(1995, 4, 18),
                        Gender = Gender.Erkek,
                        CreatedAt = DateTime.Now,
                        IsStatus = true
                    },
                    new Customer
                    {
                        Name = "Zeynep",
                        SurName = "Aydın",
                        PhoneNumber = "5558901234",
                        Email = "zeynep.aydin@example.com",
                        BirthDay = new DateTime(1989, 12, 8),
                        Gender = Gender.Kadın,
                        CreatedAt = DateTime.Now,
                        IsStatus = true
                    },
                    new Customer
                    {
                        Name = "Cem",
                        SurName = "Çelik",
                        PhoneNumber = "5559012345",
                        Email = "cem.celik@example.com",
                        BirthDay = new DateTime(1980, 6, 30),
                        Gender = Gender.Erkek,
                        CreatedAt = DateTime.Now,
                        IsStatus = true
                    },
                    new Customer
                    {
                        Name = "Gülay",
                        SurName = "Güler",
                        PhoneNumber = "5550123456",
                        Email = "gulay.guler@example.com",
                        BirthDay = new DateTime(1983, 2, 3),
                        Gender = Gender.Kadın,
                        CreatedAt = DateTime.Now,
                        IsStatus = true
                    }
                };

                _context.Customers.AddRange(customers);
                _context.SaveChanges();
            }
        }
    }

}
