using RestaurantAppWpf.UI.Core;

namespace RestaurantAppWpf.UI.MVVM.ViewModel
{
    public class MainViewModel : ObservableObject
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
        public RelayCommand HomeCommand { get; }
        public RelayCommand MenuCommand { get; }

        public MainViewModel()
        {
            HomeVM = new HomeViewModel();
            MenuVM = new MenuViewModel();
            CurrentView = HomeVM;
            HomeCommand = new RelayCommand(() =>
            {
                CurrentView = HomeVM;
            });
            MenuCommand = new RelayCommand(() =>
            {
                CurrentView = MenuVM;
            });
        }
    }
}
