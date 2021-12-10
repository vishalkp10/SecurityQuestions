using System;
using System.Collections.Generic;
using System.Text;
using SecurityQuestions.Models;
namespace SecurityQuestions.Repositories.Interfaces
{
    public interface IUserRepository
    {
        IEnumerable<User> GetAll();
        User GetByName(string username);
        void Insert(User user);
        void Update(User user);
        void Delete(int userID);
        void Save();
    }
}
