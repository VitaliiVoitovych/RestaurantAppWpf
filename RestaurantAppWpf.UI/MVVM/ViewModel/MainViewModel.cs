using RestaurantAppWpf.BL.EF;
using RestaurantAppWpf.UI.Core;
using System.Windows;

namespace RestaurantAppWpf.UI.MVVM.ViewModel
{
    public class MainViewModel : BaseViewModel
    {
        private object currentView;
        public object CurrentView
        {
            get => currentView;
            set
            {
                currentView = value;
                OnPropertyChanged();
            }
        }

        public HomeViewModel HomeVM { get; }
        public MenuViewModel MenuVM { get; }
        public SettingViewModel SettingVM { get; }
        public RelayCommand HomeCommand { get; }
        public RelayCommand MenuCommand { get; }
        public RelayCommand SettingCommand { get; }
        public RelayCommand<Window> CloseCommand { get; }
        public RelayCommand<Window> MinimizeCommand { get; }

        public MainViewModel()
        {
            HomeVM = new HomeViewModel();
            MenuVM = new MenuViewModel();
            SettingVM = new SettingViewModel();
            CurrentView = HomeVM;
            HomeCommand = new RelayCommand(() => CurrentView = HomeVM);
            MenuCommand = new RelayCommand(() => CurrentView = MenuVM);
            SettingCommand = new RelayCommand(() =>  CurrentView = SettingVM);
            CloseCommand = new RelayCommand<Window>((window) => window.Close());
            MinimizeCommand = new RelayCommand<Window>((window) => 
                window.WindowState = WindowState.Minimized);
        }
    }
}
