using System.Data.Entity;

namespace Calendar.Models
{
    public class UserContext : DbContext // Наследование всей необходимой логики от DbContext
    {
        public UserContext() : base("DB_reg") // вытаскиваем строку подключения из config
        {

        }
        public DbSet<User> User { get; set; } // Таблица User
        public DbSet<User_event> User_event { get; set; } // Таблица User_event
    }

}
