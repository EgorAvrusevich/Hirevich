using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JA.Classes
{

    internal class Companys_data : INotifyPropertyChanged
    {
        public int Id {  get; set; }
        public string? Name {  get; set; }
        public string? Discription {  get; set; }
        public string? Email {  get; set; }
        public byte[]? Logo {  get; set; }

        public Companys_data() { }
        public Companys_data(int id) { Id = id; }
        public Companys_data( string name, string discption, string email, byte[] logo) { 
            Name = name; 
            Discription = discption;
            Email = email;
            Logo = logo;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
