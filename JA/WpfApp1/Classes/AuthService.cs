using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JA.Classes
{
    class AuthService
    {
        private readonly AplicationContext _db;
        private User? _currentUser;

        public AuthService(AplicationContext db)
        {
            _db = db;
        }

        public bool IsLoggedIn => _currentUser != null;
        public User? CurrentUser => _currentUser;

        public bool Login(string username, string password)
        {
            var user = _db.Users.FirstOrDefault(u => u.login == username);

            if (user != null && password == user.password)
            {
                _currentUser = user;
                return true;
            }

            return false;
        }

        public void Logout()
        {
            _currentUser = null;
        }
    }
}
