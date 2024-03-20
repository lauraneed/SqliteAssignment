using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Windows.Input;
using Microsoft.Maui.Controls;
using SqliteAssignment;
using SqliteAssignment.Models;
using SqliteAssignment.Services;

namespace ShoppingLocalMaui
{
    public partial class MainPage : ContentPage, INotifyPropertyChanged
    {
        private readonly ShoppingLocalDatabase _database;
        private User _currentUser;

        public User CurrentUser
        {
            get => _currentUser;
            set
            {
                _currentUser = value;
                OnPropertyChanged(nameof(CurrentUser));
            }
        }

        public ObservableCollection<ShoppingItem> ShoppingItems { get; set; }

        public MainPage()
        {
            InitializeComponent();

            _database = new ShoppingLocalDatabase();

            ShoppingItems = new ObservableCollection<ShoppingItem>((IEnumerable<ShoppingItem>)_database.GetAllShoppingItems());

            BindingContext = this;
        }

        private void AddToCartClicked(object sender, EventArgs e)
        {
            if (sender is Button button && button.BindingContext is ShoppingItem item)
            {
                // Check if current user and their shopping cart are valid
                if (_currentUser == null || _currentUser.ShoppingCart == null)
                {
                    DisplayAlert("Error", "User or shopping cart not initialized.", "OK");
                    return;
                }

                // Check if item already exists in cart
                if (_currentUser.ShoppingCart.Any(i => i.Id == item.Id))
                {
                    DisplayAlert("Error", "Item already exists in the cart.", "OK");
                    return;
                }

                // Check if quantity exceeds stock level
                if (item.Quantity <= 0)
                {
                    DisplayAlert("Error", "Item is out of stock.", "OK");
                    return;
                }

                // Add item to cart
                _currentUser.ShoppingCart.Add(item);
                DisplayAlert("Item Added", $"{item.Name} added to your shopping cart.", "OK");
            }
        }

        private void RemoveFromCartClicked(object sender, EventArgs e)
        {
            if (sender is Button button && button.BindingContext is ShoppingItem item)
            {
                // Check if current user and their shopping cart are valid
                if (_currentUser == null || _currentUser.ShoppingCart == null)
                {
                    DisplayAlert("Error", "User or shopping cart not initialized.", "OK");
                    return;
                }

                // Check if item exists in cart
                var existingItem = _currentUser.ShoppingCart.FirstOrDefault(i => i.Id == item.Id);
                if (existingItem != null)
                {
                    _currentUser.ShoppingCart.Remove(existingItem);
                    DisplayAlert("Item Removed", $"{item.Name} removed from your shopping cart.", "OK");
                }
                else
                {
                    DisplayAlert("Error", "Item not found in the cart.", "OK");
                }
            }
        }
    }
}



