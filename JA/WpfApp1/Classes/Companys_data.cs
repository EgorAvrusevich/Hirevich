using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JA.Classes
{

    public class Companys_data : INotifyPropertyChanged
    {
        public int Id {  get; set; }
        private string? _discription {  get; set; }
        public string? Discription
        {
            get => _discription;
            set
            {
                _discription = value;
                OnPropertyChanged(nameof(Discription));
            }
        }
        private string? _email {  get; set; }
        public string? Email
        {
            get => _email;
            set
            {
                _email = value;
                OnPropertyChanged(nameof(Email));
            }
        }
        private string? _name {  get; set; }
        public string? Name
        {
            get => _name;
            set
            {
                _name = value;
                OnPropertyChanged(nameof(Name));
            }
        }
        private byte[]? _logo {  get; set; }

        public byte[]? Logo
        {
            get => _logo;
            set
            {
                _logo = value;
                OnPropertyChanged(nameof(Logo));
            }
        }

        public Companys_data() { }
        public Companys_data(int id) { Id = id; }
        public Companys_data( string name, string discption, string email, byte[] logo) { 
            Name = name; 
            Discription = discption;
            Email = email;
            Logo = logo;
        }

        public event PropertyChangedEventHandler? PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
