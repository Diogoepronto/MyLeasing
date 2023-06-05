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
                AddOwner("Courtney", "Kramer",         "3902 Douglas Dairy Road",   user);
                AddOwner("Luana",    "Silva Cardoso",  "Rua Heróis Ultramar 26",    user);
                AddOwner("Emily",    "Araujo Dias",    "R Cimo Vila 76",            user);
                AddOwner("Carlos",   "Barros Souza",   "R Miguel Bombarda 50",      user);
                AddOwner("Igor",     "Pereira Sousa",  "R Pescador Bacalhoeiro 35", user);
                AddOwner("Eduardo",  "Pinto Almeida",  "R Parque Gondarim 76",      user);
                AddOwner("Sarah",    "Melo Goncalves", "Rua Marco Simões 109",      user);
                AddOwner("Eduarda",  "Dias Costa",     "R Tradição 28",             user);
                AddOwner("Matheus",  "Martins Souza",  "R Poeta João Ruiz 88",      user);
                AddOwner("Diogo",    "Sousa Barbosa",  "R Outeirô 85",              user);

                await _context.SaveChangesAsync();
            }
        }

        private void AddOwner(string firstName, string lastName, string address, User user)
        {
            _context.Owners.Add(new Entities.Owner
            {
                Document = _random.Next(10000000, 99999999),
                FirstName = firstName,
                LastName = lastName,
                FixedPhone = _random.Next(800000000, 999999999).ToString(),
                CellPhone = _random.Next(800000000, 999999999).ToString(),
                Address = address,
                User = user
            });
        }
    }
}
