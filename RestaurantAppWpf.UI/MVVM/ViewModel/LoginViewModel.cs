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
        private Customer loginCustomer;
        public Customer LoginCustomer
        {
            get => loginCustomer;
            set
            {
                loginCustomer = value;
                OnPropertyChanged();
            }
        }
        private string password;
        public string Password
        {
            get => password;
            set
            {
                password = value;
            }
        }
        public RelayCommand RegistrationCommand { get; }
        public RelayCommand<Window> LoginCommand { get; }
        public LoginViewModel()
        {
            Db.Customers.Load();
            LoginCustomer = new Customer();
            Customers = Db.Customers.Local.ToObservableCollection();
            RegistrationCommand = new RelayCommand(() =>
            {
                LoginCustomer.Password = PasswordEncryptor.PasswordEncrypt(Password);
                Customer = Customers.SingleOrDefault(c => c.FirstName == LoginCustomer.FirstName &&
                                            c.LastName == LoginCustomer.LastName &&
                                            c.Password == PasswordEncryptor.PasswordEncrypt(Password));
                if (Customer != null)
                {
                    MessageBox.Show("Такий користувач вже зареєстрований");
                }
                else
                {
                    Db.Customers.Add(LoginCustomer);
                    Db.SaveChanges();
                }
            });
            LoginCommand = new RelayCommand<Window>((window) =>
            {
                Customer = Customers.SingleOrDefault(c => c.FirstName == LoginCustomer.FirstName &&
                                            c.LastName == LoginCustomer.LastName &&
                                            c.Password == PasswordEncryptor.PasswordEncrypt(Password));
                if (Customer != null)
                {
                    TableNumber = new Random().Next(1, 7);
                    window.DialogResult = true;
                    window.Close();
                }
                else
                {
                    MessageBox.Show("Такого користувача ще не зареєстровано");
                }
            });
        }
    }
}
