using System;
using System.Collections.Generic;
using MSPROJECT_V1_.Model;
using MSPROJECT_V1_.Repositories_DA_;

namespace PROJECT1.Service
{
    class UserService
    {
        private UserRepo _userRepo = new UserRepo(); 

        public UserModel CheckLogin(string username, string password) 
        {
            List<UserModel> users = _userRepo.LoadUserFile();

            foreach (UserModel u in users)
            {
                if (u.GetUsername() == username && u.GetPassword() == password)
                {
                    return u;
                }
            }
            return null;
        }
    }
}