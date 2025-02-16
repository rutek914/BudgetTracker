using BudgetTracker.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace BudgetTracker.Model.Repositories
{
    public interface IUserRepository
    {
        bool AuthenticateUser(NetworkCredential credential);
        void Add(User user);
        void Edit(User user);
        void Remove(Guid id);
        User GetById(Guid id);
        User GetByUsername(string username);
        IEnumerable<User> GetAll();
    }
}
