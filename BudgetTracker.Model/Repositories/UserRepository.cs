using BudgetTracker.Model.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace BudgetTracker.Model.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly BudgetTrackerDbContext _dbContext;
        public UserRepository(BudgetTrackerDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Add(User user)
        {
            throw new NotImplementedException();
        }

        public bool AuthenticateUser(NetworkCredential credential)
        {
            // Sprawdzamy, czy użytkownik o podanej nazwie istnieje w bazie
            var user = _dbContext.Users.SingleOrDefault(u => u.Username == credential.UserName);

            if (user == null)
            {
                // Jeśli użytkownik nie istnieje, zwracamy false
                return false;
            }

            // Sprawdzamy, czy hasło jest poprawne (tutaj używamy prostego porównania dla przykładu)
            // W prawdziwej aplikacji powinno się porównywać hasła za pomocą np. SHA-256 lub bcrypt
            if (user.PasswordHash == credential.Password)
            {
                // Jeśli hasło pasuje, zwracamy true
                return true;
            }

            // Jeśli hasło jest niepoprawne, zwracamy false
            return false;
        }

        public void Edit(User user)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<User> GetAll()
        {
            throw new NotImplementedException();
        }

        public User GetById(Guid id)
        {
            throw new NotImplementedException();
        }

        public User GetByUsername(string username)
        {
            throw new NotImplementedException();
        }

        public void Remove(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
