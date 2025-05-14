using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JA.Classes
{
    public class PersonalData : INotifyPropertyChanged
    {
        public int Id { get; set; }
        private string? _firstName { get; set; }
        public string? FirstName
        {
            get => _firstName;
            set
            {
                _firstName = value;
                OnPropertyChanged(nameof(FirstName));
            }
        }
        private string? _lastName {  get; set; }
        public string? LastName
        {
            get => _lastName;
            set
            {
                _lastName = value;
                OnPropertyChanged(nameof(LastName));
            }
        }
        private string? _email { get; set; }
        public string? Email
        {
            get => _email;
            set
            {
                _email = value;
                OnPropertyChanged(nameof(Email));
            }
        }
        private string? _age { get; set; }
        public string? Age
        {
            get => _age;
            set
            {
                _age = value;
                OnPropertyChanged(nameof(Age));
            }
        }
        private string? _country { get; set; }
        public string? Country
        {
            get => _country;
            set
            {
                _country = value;
                OnPropertyChanged(nameof(Country));
            }
        }
        private string? _about { get; set; }
        public string? About
        {
            get => _about;
            set
            {
                _about = value;
                OnPropertyChanged(nameof(About));
            }
        }
        private string? _education { get; set; }
        public string? Education
        {
            get => _education;
            set
            {
                _education = value;
                OnPropertyChanged(nameof(Education));
            }
        }
        private byte[]? _photo { get; set; }
        public byte[]? Photo
        {
            get => _photo;
            set
            {
                _photo = value;
                OnPropertyChanged(nameof(Photo));
            }
        }
        private string? _speciality { get; set; }
        public string? Speciality
        {
            get => _speciality;
            set
            {
                _speciality = value;
                OnPropertyChanged(nameof(Speciality));
            }
        }

        public PersonalData(int id) { Id = id; }

        public event PropertyChangedEventHandler? PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

    }


}
