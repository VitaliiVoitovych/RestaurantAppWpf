using Microsoft.EntityFrameworkCore;
using Microsoft.Win32;
using RestaurantAppWpf.BL.EF;
using RestaurantAppWpf.BL.Models;
using RestaurantAppWpf.UI.Core;
using System;
using System.Collections.ObjectModel;
using System.IO;
using System.Windows.Media.Imaging;

namespace RestaurantAppWpf.UI.MVVM.ViewModel
{
    public class SettingViewModel : BaseViewModel
    {
        private OpenFileDialog openFileDialog = new OpenFileDialog()
        {
            Title = "Виберіть зображення",
            Filter = "All supported graphics|*.jpg;*.jpeg;*.png|" +
               "JPEG (*.jpg;*.jpeg)|*.jpg;*.jpeg|" +
               "Portable Network Graphic (*.png)|*.png"
        };
        private TypeDish typeDish;
        public TypeDish TypeDish
        {
            get => typeDish;
            set
            {
                typeDish = value;
            }
        }

        private Dish dish;
        public Dish Dish
        {
            get => dish;
            set
            {
                dish = value;
            }
        }

        public ObservableCollection<TypeDish> TypeDishes { get; }
        public RelayCommand AddTypeDishCommand { get; }
        public RelayCommand AddDishCommand { get; }
        public RelayCommand AddImage { get; }

        public SettingViewModel()
        {
            TypeDish = new TypeDish();
            Dish = new Dish();
            Db.TypeDishes.Load();
            TypeDishes = Db.TypeDishes.Local.ToObservableCollection();
            AddTypeDishCommand = new RelayCommand(() =>
            {
                Db.TypeDishes.Add(TypeDish);
                Db.SaveChanges();
            });
            AddDishCommand = new RelayCommand(() =>
            {
                Db.Dishes.Add(Dish);
                Db.SaveChanges();
            });
            AddImage = new RelayCommand(() =>
            {
                if (openFileDialog.ShowDialog() == true)
                {
                    var img = new BitmapImage(new Uri(openFileDialog.FileName));
                    byte[] data;
                    JpegBitmapEncoder encoder = new JpegBitmapEncoder();
                    encoder.Frames.Add(BitmapFrame.Create(img));
                    using (MemoryStream ms = new MemoryStream())
                    {
                        encoder.Save(ms);
                        data = ms.ToArray();
                    }
                    Dish.Image = data;
                }
            });
        }
    }
}
