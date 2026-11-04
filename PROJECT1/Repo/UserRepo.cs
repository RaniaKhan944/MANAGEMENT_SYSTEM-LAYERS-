using System;
using System.Collections.Generic;
using System.IO;
using MSPROJECT_V1_.Model;

namespace MSPROJECT_V1_.Repositories_DA_
{
    class UserRepo
    {
        
        private readonly string _filepath = "D:\\UET\\SEMESTER 2\\OOP\\LAB\\PROJECT1\\Users.txt";

        public List<UserModel> LoadUserFile()
        {
            List<UserModel> _users = new List<UserModel>();
            if (File.Exists(_filepath))
            {
                using (StreamReader reader = new StreamReader(_filepath))
                {
                    string line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        string[] parts = line.Split(',');

                        string Username = parts[0];
                        string Password = parts[1];
                        string Role = parts[2];
                        UserModel user = new UserModel(Username, Password, Role);
                        _users.Add(user);
                    }
                }
            }
            return _users;
        }

        //this goes in service logic

    }
}
