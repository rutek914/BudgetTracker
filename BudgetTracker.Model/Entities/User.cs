using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BudgetTracker.Model.Entities
{
    public class User
    {
        public Guid Id { get; set; }
        public string Username { get; set; }
        public string? PasswordHash { get; set; }
        public string Email { get; set; }
        public List<Expense> Expenses { get; set; } = new List<Expense>();
    }
}
