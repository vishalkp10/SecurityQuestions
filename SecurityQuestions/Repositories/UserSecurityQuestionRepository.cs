using System;
using System.Collections.Generic;
using System.Text;
using SecurityQuestions.Models;
using Microsoft.EntityFrameworkCore;
using SecurityQuestions.Models;
using SecurityQuestions.Repositories.Interfaces;
using System.Linq;

namespace SecurityQuestions.Repositories
{
    public class UserSecurityQuestionRepository:IUserSecurityQuestionRepository
    {
        private readonly EFContext _context;
        public UserSecurityQuestionRepository()
        {
            _context = new EFContext();
        }
        public UserSecurityQuestionRepository(EFContext context)
        {
            _context = context;
        }
        public IEnumerable<UserSecurityQuestion> GetAll()
        {
            return _context.UserSecurityQuestions.ToList();
        }
        public IEnumerable<UserSecurityQuestion> GetByUserID(int userID)
        {
            return _context.UserSecurityQuestions.Where(usq => usq.UserID == userID).ToList();
        }
        public UserSecurityQuestion GetByUserIDAndSecurityQuestionID(int userID, int securityQuestionID)
        {
            return _context.UserSecurityQuestions.Where(usq => usq.UserID == userID && usq.SecurityQuestionID == securityQuestionID).FirstOrDefault();
        }
        public void Insert(UserSecurityQuestion userSecurityQuestion)
        {
            _context.UserSecurityQuestions.Add(userSecurityQuestion);
        }
        public void Update(UserSecurityQuestion userSecurityQuestion)
        {
            _context.Entry(userSecurityQuestion).State = EntityState.Modified;
        }
        public void Delete(int userSecurityQuestionID)
        {
            UserSecurityQuestion userSecurityQuestion = _context.UserSecurityQuestions.Find(userSecurityQuestionID);
            _context.UserSecurityQuestions.Remove(userSecurityQuestion);
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
