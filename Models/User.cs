using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;

namespace Calendar.Models

{
    public class User // создание таблицы User 
    {
        [Key] public int UserId { get; set; }
        public string Name { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
    }
    public class User_event // создание таблицы User 
    {
        [Key] public int EventId { get; set; }
        public int User_Id { get; set; }
        public string Name_event { get; set; }
        public string Event_Description { get; set; }
        public string HasCome { get; set; }
        public string Event_date { get; set; } 

    }
}
