using BudgetTracker.Model.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BudgetTracker.Model.Entities
{
    public class Expense
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public ExpenseCategory Category { get; set; }
        public User User { get; set; }
        public Guid UserId { get; set; }
    }
}
