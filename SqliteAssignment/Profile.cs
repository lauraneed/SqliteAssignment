using SQLiteNetExtensions.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SqliteAssignment.Models
{
    public class User
    {
       

            public int Id { get; set; }
            public string Name { get; set; }
            public string Surname { get; set; }
            public string Email { get; set; }
            public string Bio { get; set; }

            public User()
            {
                Id = 0; 
                Name = "";
                Surname = "";
                Email = "";
                Bio = "";
            }

        [OneToMany(CascadeOperations = CascadeOperation.All)]
        public List <ShoppingItem> ShoppingCart { get; set; }
        public string FirstName { get; internal set; }
    }


}

