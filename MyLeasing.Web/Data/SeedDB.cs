using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;
using System;
using System.Linq;

namespace MyLeasing.Web.Data
{
    public class SeedDB
    {
        private readonly DataContext _context;
        private Random _random;

        public SeedDB(DataContext context)
        {
            _context = context;
            _random = new Random();
        }

        public async Task SeedAsync()
        {
            await _context.Database.EnsureCreatedAsync();

            if (!_context.Owners.Any())
            {
                AddOwner("Courtney", "Kramer", "3902 Douglas Dairy Road");
                AddOwner("Luana", "Silva Cardoso", "Rua Heróis Ultramar 26");
                AddOwner("Emily", "Araujo Dias", "R Cimo Vila 76");
                AddOwner("Carlos", "Barros Souza", "R Miguel Bombarda 50");
                AddOwner("Igor", "Pereira Sousa", "R Pescador Bacalhoeiro 35");
                AddOwner("Eduardo", "Pinto Almeida", "R Parque Gondarim 76");
                AddOwner("Sarah", "Melo Goncalves", "Rua Marco Simões 109");
                AddOwner("Eduarda", "Dias Costa", "R Tradição 28");
                AddOwner("Matheus", "Martins Souza", "R Poeta João Ruiz 88");
                AddOwner("Diogo", "Sousa Barbosa", "R Outeirô 85");

                await _context.SaveChangesAsync();
            }
        }

        private void AddOwner(string firstName, string lastName, string address)
        {
            _context.Owners.Add(new Entities.Owner
            {
                Document = _random.Next(10000000, 99999999),
                FirstName = firstName,
                LastName = lastName,
                FixedPhone = _random.Next(800000000, 999999999).ToString(),
                CellPhone= _random.Next(800000000, 999999999).ToString(),
                Address = address
            });
        }
    }
}
