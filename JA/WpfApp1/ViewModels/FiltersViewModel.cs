using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows.Input;

namespace JA.Classes
{
    public class FiltersViewModel : INotifyPropertyChanged
    {
        public List<Country> Countries { get; } = Enum.GetValues(typeof(Country)).Cast<Country>().ToList();

        public List<string> ExperienceLevels { get; } = new List<string>
        {
            "Без опыта",
            "1-3 года",
            "3-6 лет",
            "Более 6 лет"
        };

        private string _selectedCountry;
        public string SelectedCountry
        {
            get => _selectedCountry;
            set
            {
                _selectedCountry = value;
                OnPropertyChanged(nameof(SelectedCountry));
            }
        }

        private string _selectedExperience;
        public string SelectedExperience
        {
            get => _selectedExperience;
            set
            {
                _selectedExperience = value;
                OnPropertyChanged(nameof(SelectedExperience));
            }
        }

        private string _minSalary;
        public string MinSalary
        {
            get => _minSalary;
            set
            {
                _minSalary = value;
                OnPropertyChanged(nameof(MinSalary));
            }
        }

        public ICommand ApplyFiltersCommand { get; }
        public ICommand ResetFiltersCommand { get; }

        public event Action<FiltersViewModel> FiltersApplied;

        public FiltersViewModel()
        {
            ApplyFiltersCommand = new RelayCommand(() =>
            {
                FiltersApplied?.Invoke(this);
            });

            ResetFiltersCommand = new RelayCommand(ResetFilters);
        }

        public void ResetFilters()
        {
            SelectedCountry = default;
            SelectedExperience = null;
            MinSalary = null;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}