using SQLite;
using SqliteAssignment.Models;
using SQLiteNetExtensions.Attributes;
using System.Collections.Generic;

namespace sqliteLocalStorageAssignment.Models
{
    public class User
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string Bio { get; set; }

        [OneToMany(CascadeOperations = CascadeOperation.All)]
        public List<ShoppingCart> ShoppingCart { get; set; }

        public User()
        {
            ShoppingCart = new List<ShoppingCart>();
        }
    }
}
