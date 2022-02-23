using Microsoft.EntityFrameworkCore;
using RestaurantAppWpf.BL.Models;
using RestaurantAppWpf.BL.Services;
using RestaurantAppWpf.UI.Core;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;

namespace RestaurantAppWpf.UI.MVVM.ViewModel
{
    public class LoginViewModel : BaseViewModel
    {
        public ObservableCollection<Customer> Customers { get; }
        private string password;
        public string Password
        {
            get => password;
            set
            {
                password = PasswordEncryptor.PasswordEncrypt(value);
                OnPropertyChanged();
            }
        }
        public RelayCommand RegistrationCommand { get; }
        public RelayCommand<Window> LoginCommand { get; }
        public LoginViewModel()
        {
            Db.Customers.Load();
            Customers = Db.Customers.Local.ToObservableCollection();
            RegistrationCommand = new RelayCommand(() =>
            {
                Customer.Password = Password;
                Db.Customers.Add(Customer);
                Db.SaveChanges();
            });
            LoginCommand = new RelayCommand<Window>((window) =>
            {
                Customer = Customers.SingleOrDefault(c => c.FirstName == Customer.FirstName &&
                                            c.LastName == Customer.LastName &&
                                            c.Password == Password);
                if (Customer != null)
                {
                    TableNumber = new Random(DateTime.Now.Millisecond).Next(1, 7);
                    window.Close();
                }
                else
                {
                    MessageBox.Show("Error");
                }
            });
        }
    }
}
