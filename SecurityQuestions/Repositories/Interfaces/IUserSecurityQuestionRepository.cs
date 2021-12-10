using System;
using System.Collections.Generic;
using System.Text;
using SecurityQuestions.Models;
namespace SecurityQuestions.Repositories.Interfaces
{
    public interface IUserSecurityQuestionRepository
    {
        IEnumerable<UserSecurityQuestion> GetAll();
        IEnumerable<UserSecurityQuestion> GetByUserID(int userID);
        UserSecurityQuestion GetByUserIDAndSecurityQuestionID(int userID,int securityQuestionID);
        void Insert(UserSecurityQuestion userSecurityQuestion);
        void Update(UserSecurityQuestion userSecurityQuestion);
        void Delete(int userSecurityQuestionID);
        void Save();
    }
}
