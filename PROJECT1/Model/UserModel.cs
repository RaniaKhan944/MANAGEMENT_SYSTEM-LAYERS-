using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSPROJECT_V1_.Model
{
    class UserModel
    {
        private string Username;
        private string Password;
        private string Role;

        public UserModel(string username, string password, string role)
        {
            this.Username = username;
            this.Password = password;
            this.Role = role;
        }
        public string GetUsername() { return this.Username; }
        public string GetPassword() { return this.Password; }
        public string GetRole() { return this.Role; }

        public override string ToString()
        {
            return $"{GetUsername()},{GetPassword()},{GetRole()}";
        }
    }
}
