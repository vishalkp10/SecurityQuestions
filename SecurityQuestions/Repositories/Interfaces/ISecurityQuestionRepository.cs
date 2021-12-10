using System;
using System.Collections.Generic;
using System.Text;
using SecurityQuestions.Models;
namespace SecurityQuestions.Repositories.Interfaces
{
    public interface ISecurityQuestionRepository
    {
        IEnumerable<SecurityQuestion> GetAll();
        SecurityQuestion GetById(int securityQuestionID);
        void Insert(SecurityQuestion securityQuestion);
        void Update(SecurityQuestion securityQuestion);
        void Delete(int securityQuestionID);
        void Save();
    }
}
