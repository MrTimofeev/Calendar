using System.Data.Entity;

namespace Calendar.Models
{
    public class UserContext : DbContext // Наследование всей необходимой логики от DbContext
    {
        public UserContext() : base("DB_reg")
        {

        }
        public DbSet<User> User { get; set; } // Таблица User
    }
   
}
