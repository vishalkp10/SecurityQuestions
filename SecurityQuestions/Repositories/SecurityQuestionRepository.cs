using Microsoft.EntityFrameworkCore;
using SecurityQuestions.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SecurityQuestions.Repositories.Interfaces;
namespace SecurityQuestions.Repositories
{
    public class SecurityQuestionRepository: ISecurityQuestionRepository
    {
        private readonly EFContext _context;
        public SecurityQuestionRepository()
        {
            _context = new EFContext();
        }
        public SecurityQuestionRepository(EFContext context)
        {
            _context = context;
        }
        public IEnumerable<SecurityQuestion> GetAll()
        {
            return _context.SecurityQuestions.ToList();
        }
        public SecurityQuestion GetById(int securityQuestionID)
        {
            return _context.SecurityQuestions.Find(securityQuestionID);
        }
        public void Insert(SecurityQuestion securityQuestion)
        {
            _context.SecurityQuestions.Add(securityQuestion);
        }
        public void Update(SecurityQuestion securityQuestion)
        {
            _context.Entry(securityQuestion).State = EntityState.Modified;
        }
        public void Delete(int securityQuestionID)
        {
            SecurityQuestion securityQuestion = _context.SecurityQuestions.Find(securityQuestionID);
            _context.SecurityQuestions.Remove(securityQuestion);
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
