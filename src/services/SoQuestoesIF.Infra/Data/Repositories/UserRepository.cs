using Microsoft.EntityFrameworkCore;
using SoQuestoesIF.Domain.Entities;
using SoQuestoesIF.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoQuestoesIF.Infra.Data.Repositories
{
    public class UserRepository : IUserRepository
    {
        // Implmentações específicas para User

        private readonly AppDbContext _context;
        public UserRepository(AppDbContext context)
        {
            _context = context;
        }                                  
        public async Task<User> GetByIdAsync(Guid id)
        {            
            return await _context.Users.FindAsync(id);
            // return await _context.Users.FindAsync(x => x.Id == id);
        }
        public async Task<User> GetByEmailAsync(string email)
        {
            return await _context.Users
                 .FirstOrDefaultAsync(u => u.Email.ToLower() == email.ToLower());
        }        
        public async Task<IEnumerable<User>> GetAllAsync()
        {
            return await _context.Users.ToListAsync();
        }
        public async Task AddAsync(User user)
        {
            await _context.Users.AddAsync(user);
        }
        public void Update(User user)
        {
            _context.Users.Update(user);
        }
        public void Delete(User user)
        {
            _context.Users.Remove(user);
        }

        //public async Task<User> GetUserAsync(Guid id)
        //{
        //    return await _context.Users.FindAsync(id);
        //}
    }
}
