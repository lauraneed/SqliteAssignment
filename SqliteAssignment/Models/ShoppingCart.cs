using SQLite;
using SQLiteNetExtensions.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SqliteAssignment.Models
{
    public class ShoppingCart
    {
       
    
        
        
            [PrimaryKey, AutoIncrement]
            public int Id { get; set; }

            [ForeignKey(typeof(User))]
            public int UserId { get; set; }

            [ManyToOne]
            public User User { get; set; }

            [ForeignKey(typeof(ShoppingItem))]
            public int ItemId { get; set; }

            [ManyToOne]
            public ShoppingItem Item { get; set; }

            public int Quantity { get; set; }
        
    }



}

