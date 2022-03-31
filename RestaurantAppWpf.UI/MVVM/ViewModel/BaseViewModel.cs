﻿using RestaurantAppWpf.BL.EF;
using RestaurantAppWpf.BL.Models;
using RestaurantAppWpf.UI.Core;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;

namespace RestaurantAppWpf.UI.MVVM.ViewModel
{
    public abstract class BaseViewModel : ObservableObject
    {
        public RestaurantAppDbContext Db { get; set; } = new RestaurantAppDbContext();
        public RelayCommand<Window> CloseCommand { get; }
        public RelayCommand<Window> MinimizeCommand { get; }
        private static int tableNumber;
        public int TableNumber
        {
            get => tableNumber;
            set
            {
                tableNumber = value;
                OnPropertyChanged();
            }
        }

        private static Order order = new Order();
        public Order Order
        {
            get => order;
            set
            {
                order = value;
                OnPropertyChanged();
            }
        }

        private static Customer customer;
        public Customer Customer
        {
            get => customer;
            set
            {
                customer = value;
                OnPropertyChanged();
            }
        }
        public BaseViewModel()
        {
            CloseCommand = new RelayCommand<Window>((window) =>
            {
                Db.Cart.RemoveRange(Db.Cart.ToList());
                Db.SaveChanges();
                window.Close();
            });
            MinimizeCommand = new RelayCommand<Window>((window) =>
                window.WindowState = WindowState.Minimized);
        }
    }
}
