using System;
using System.Collections.Generic;
using System.IO;
using SQLite;
using SqliteAssignment.Models;

namespace SqliteAssignment.Services
{
    public class ShoppingLocalDatabase
    {
        private readonly SQLiteConnection _dbConnection;

        public ShoppingLocalDatabase()
        {
            _dbConnection = new SQLiteConnection(GetDatabasePath());
            InitializeDatabase();
        }

        public string GetDatabasePath()
        {
            string filename = "Shoppingdata.db";
            string pathToDb = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
            return Path.Combine(pathToDb, filename);
        }

        private void InitializeDatabase()
        {
            try
            {
                _dbConnection.CreateTable<User>();
                _dbConnection.CreateTable<ShoppingItem>();
                SeedDatabase(Get_dbConnection());
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error initializing database: " + ex.Message);
                throw;
            }
        }

        private SQLiteConnection Get_dbConnection()
        {
            return _dbConnection;
        }

        private void SeedDatabase(SQLiteConnection _dbConnection)
        {
            try
            {
               // if (!_dbConnection.Table<User>().Any())
                {
                    var user = new User
                    {
                        Name = "Lauren",
                        Surname = "Petrus",
                        Email = "laurenleigh12@gmail.com",
                        Bio = "hectic"
                    };

                    
                    //_dbConnection.Insert(User);

                    
                    var items = new List<ShoppingItem>
                    {
                        new ShoppingItem { Name = "Grapes", Quantity = 30 },
                        new ShoppingItem { Name = "Strawberries", Quantity = 40 },
                        new ShoppingItem { Name = "Mango", Quantity = 50 },
                        new ShoppingItem { Name = "Apples", Quantity = 70 },
                        new ShoppingItem { Name = "Watermelon", Quantity = 40 },
                        new ShoppingItem { Name = "Cantelope", Quantity = 20 },
                        new ShoppingItem { Name = "Blueberries", Quantity = 80 },
                        new ShoppingItem { Name = "Lettuce", Quantity = 80 },
                        new ShoppingItem { Name = "Carrots", Quantity = 60 },
                        new ShoppingItem { Name = "Tomatoes", Quantity = 50 }
                    };
                    _dbConnection.InsertAll(items);

                    var fruitItems = new List<ShoppingItem>
                    {
                        items[1], // Strawberries
                        items[2], // Mango
                        items[2], // Mango 
                        items[3], // Apples
                        items[4],  // Watermelon
                        items [5], //carrots
                       items[6], //tomatoes

                    };

                    foreach (var fruitItem in fruitItems)
                    {
                        ShoppingCart newItem = new ShoppingCart
                        {
                            UserId = user.Id,
                            ItemId = fruitItem.Id,
                            Quantity = 1
                        };

                        //_dbConnection.Insert(newItem);
                    }

                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error seeding database: " + ex.Message);
                throw;
            }
        }

        public IEnumerable<ShoppingItem> GetAllShoppingItems()
        {
            yield return (ShoppingItem)_dbConnection.Table<ShoppingItem>();
        }
    }
}
