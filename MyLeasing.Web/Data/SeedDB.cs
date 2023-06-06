using Microsoft.AspNetCore.Identity;
using MyLeasing.Web.Data.Entities;
using MyLeasing.Web.Helpers;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace MyLeasing.Web.Data
{
    public class SeedDB
    {
        private readonly DataContext _context;
        private readonly IUserHelper _userHelper;
        private Random _random;

        public SeedDB(DataContext context, IUserHelper userHelper)
        {
            _context = context;
            _userHelper = userHelper;
            _random = new Random();
        }

        public async Task SeedAsync()
        {
            await _context.Database.EnsureCreatedAsync();

            var user = await _userHelper.GetUserByEmailAsync("bta.diogo@gmail.com");
            if (user == null)
            {
                user = new User
                {
                    Document = "13491319706",
                    FirstName = "Diogo",
                    LastName = "Alves",
                    Address = "Rua qualquer, lote ¼",
                    Email = "bta.diogo@gmail.com",
                    UserName = "bta.diogo@gmail.com",
                    PhoneNumber = "1234567890"
                };

                var result = await _userHelper.AddUserAsync(user, "123456");

                if (result != IdentityResult.Success)
                {
                    throw new InvalidOperationException("Could not create the user in seeder");
                }
            }


            if (!_context.Owners.Any())
            {
                AddOwner("Carlos",   "Barros Souza",   "R Miguel Bombarda 50",      "~/images/owners/1.jpg",  user);
                AddOwner("Igor",     "Pereira Sousa",  "R Pescador Bacalhoeiro 35", "~/images/owners/2.jpg",  user);
                AddOwner("Eduardo",  "Pinto Almeida",  "R Parque Gondarim 76",      "~/images/owners/3.jpg",  user);
                AddOwner("Matheus",  "Martins Souza",  "R Poeta João Ruiz 88",      "~/images/owners/4.jpg",  user);
                AddOwner("Diogo",    "Sousa Barbosa",  "R Outeirô 85",              "~/images/owners/5.jpg",  user);
                AddOwner("Courtney", "Kramer",         "3902 Douglas Dairy Road",   "~/images/owners/6.jpg",  user);
                AddOwner("Luana",    "Silva Cardoso",  "Rua Heróis Ultramar 26",    "~/images/owners/7.jpg",  user);
                AddOwner("Emily",    "Araujo Dias",    "R Cimo Vila 76",            "~/images/owners/8.jpg",  user);
                AddOwner("Sarah",    "Melo Goncalves", "Rua Marco Simões 109",      "~/images/owners/9.jpg",  user);
                AddOwner("Eduarda",  "Dias Costa",     "R Tradição 28",             "~/images/owners/10.jpg", user);

                await _context.SaveChangesAsync();
            }

            if (!_context.Lessees.Any())
            {
                AddLessee("Pedro",  "Ferreira Gomes",   "R Riamar 50",       "~/images/lessees/1.jpg", user);
                AddLessee("Tomás",  "Martins Souza",    "Rua Longuinha 116", "~/images/lessees/2.jpg", user);
                AddLessee("Martim", "Santos Barbosa",   "R Cimo Vila 76",    "~/images/lessees/3.jpg", user);
                AddLessee("Laura",  "Correia Pinto",    "Quinta Lama 39",    "~/images/lessees/4.jpg", user);
                AddLessee("Bianca", "Ferreira Azevedo", "R Armazéns 97",     "~/images/lessees/5.jpg", user);                

                await _context.SaveChangesAsync();
            }
        }

        private void AddOwner(string firstName, string lastName, string address, string photoUrl, User user)
        {
            _context.Owners.Add(new Entities.Owner
            {
                Document = _random.Next(10000000, 99999999),
                FirstName = firstName,
                LastName = lastName,
                FixedPhone = _random.Next(800000000, 999999999).ToString(),
                CellPhone = _random.Next(800000000, 999999999).ToString(),
                Address = address,
                PhotoUrl = photoUrl,
                User = user
            });
        }

        private void AddLessee(string firstName, string lastName, string address, string photoUrl, User user)
        {
            _context.Lessees.Add(new Entities.Lessee
            {
                Document = _random.Next(10000000, 99999999),
                FirstName = firstName,
                LastName = lastName,
                FixedPhone = _random.Next(800000000, 999999999).ToString(),
                CellPhone = _random.Next(800000000, 999999999).ToString(),
                Address = address,
                PhotoUrl = photoUrl,
                User = user
            });
        }
    }
}
