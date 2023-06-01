using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MyLeasing.Web.Data.Entities;

namespace MyLeasing.Web.Data
{
    public class Repository : IRepository
    {
        private readonly DataContext _context;

        public Repository(DataContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Gets All owners
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Owner> GetOwners()
        {
            return _context.Owners.OrderBy(o => o.FirstName);
        }

        /// <summary>
        /// Gets a specific owner by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Owner GetOwner(int id)
        {
            return _context.Owners.Find(id);
        }

        /// <summary>
        /// Add an owner to the DB
        /// </summary>
        /// <param name="owner"></param>
        public void AddOwner(Owner owner)
        {
            _context.Owners.Add(owner);
        }

        /// <summary>
        /// Updates a specific owner on the DB
        /// </summary>
        /// <param name="owner"></param>
        public void UpdateOwner(Owner owner)
        {
            _context.Owners.Update(owner);
        }

        /// <summary>
        /// Removes a specific owner from the DB
        /// </summary>
        /// <param name="owner"></param>
        public void RemoveOwner(Owner owner)
        {
            _context.Owners.Remove(owner);
        }

        /// <summary>
        /// Saves changes to the DB
        /// </summary>
        /// <returns></returns>
        public async Task<bool> SaveAllAsync()
        {
            return await _context.SaveChangesAsync() > 0;
        }

        /// <summary>
        /// Checks if an owner exists in the DB
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool OwnerExists(int id)
        {
            return _context.Owners.Any(o => o.Id == id);
        }
    }
}
