using SpaUserControl.Domain.Contracts.Repositories;
using SpaUserControl.Domain.Models;
using SpaUserControl.Infraestruture.Data;
using System;
using System.Data.Entity;
using System.Linq;

namespace SpaUserControl.Infraestruture.Repositories
{
    public class UserRepository : IUserRepository
    {
        //private AppDataContext _context = new AppDataContext();
        private AppDataContext _context;

        #region Ctor

        public UserRepository(AppDataContext context)
        {
            this._context = context;
        }

        #endregion

        public User Get(Guid id)
        {
           return _context.Users.Where(x => x.Id == id).FirstOrDefault();
        }

        public User Get(string email)
        {
            return _context.Users.Where(x => x.Email.ToLower() == email.ToLower()).FirstOrDefault();
        }

        public void Create(User user)
        {
            _context.Users.Add(user);
            _context.SaveChanges();
        }        

        public void Update(User user)
        {
            _context.Entry<User>(user).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public void Delete(User user)
        {
            _context.Users.Remove(user);
            _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
