using System;
using JA.Classes;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JA.ViewModels
{
    class MainViewModel : INotifyPropertyChanged
    {
        private readonly AuthService _AuthService;

        public event PropertyChangedEventHandler? PropertyChanged;

        public bool IsLoggedIn => _AuthService.IsLoggedIn;
        public User? CurrentUser => _AuthService.CurrentUser;

        public MainViewModel(AuthService authService) {
            _AuthService = authService;

        }

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

    }
}
