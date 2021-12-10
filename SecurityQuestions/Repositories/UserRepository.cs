using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.EntityFrameworkCore;
using SecurityQuestions.Models;
using SecurityQuestions.Repositories.Interfaces;

namespace SecurityQuestions.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly EFContext _context;
        public UserRepository()
        {
            _context = new EFContext();
        }
        public UserRepository(EFContext context)
        {
            _context = context;
        }
        public IEnumerable<User> GetAll()
        {
            return _context.Users.ToList();
        }
        public User GetByName(string username)
        {
            return _context.Users.Where(u => u.Name == username).FirstOrDefault();
        }
        public void Insert(User user)
        {
            _context.Users.Add(user);
        }
        public void Update(User user)
        {
            _context.Entry(user).State = EntityState.Modified;
        }
        public void Delete(int userID)
        {
            User user = _context.Users.Find(userID);
            _context.Users.Remove(user);
        }
        public void Save()
        {
            _context.SaveChanges();
        }
        private bool disposed = false;
        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            this.disposed = true;
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
