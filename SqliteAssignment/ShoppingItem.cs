using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SqliteAssignment
{
    public class ShoppingItem
    {
        [PrimaryKey, AutoIncrement]

        public int Id { get; set; }
        public required string Name { get; set; }

        public int Quantity { get; set; }


    }
}
