using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MSPROJECT_V1_.Model; //usermodel
using MSPROJECT_V1_.Repositories_DA_; //user repo
using PROJECT1.Service; //userservice

namespace PROJECT1.UI
{
    class CommonUI
    {
        
        private static UserService _userService = new UserService();



        public static void MainHeader()
        {
            Console.Clear();
            Console.WriteLine("|----------------------------------------------|");
            Console.WriteLine("|-------SPEECH  CLINIC MANAGEMENT SYSTEM-------|");
            Console.WriteLine("|----------------------------------------------|");
            Console.WriteLine("\n");
        }

        public static void PatientHeader()
        {
            
            Console.WriteLine("|----------------------------------------------|");
            Console.WriteLine("|-----------------PATIENT MENU-----------------|");
            Console.WriteLine("|----------------------------------------------|");
            Console.WriteLine("\n");
        }

        public static void AdminHeader()
        {
            
            Console.WriteLine("|----------------------------------------------|");
            Console.WriteLine("|------------------ADMIN MENU------------------|");
            Console.WriteLine("|----------------------------------------------|");
            Console.WriteLine("\n");
        }

        public static void TherapistHeader()
        {

            Console.WriteLine("|----------------------------------------------|");
            Console.WriteLine("|--------------THERAPIST MENU------------------|");
            Console.WriteLine("|----------------------------------------------|");
            Console.WriteLine("\n");
        }

        public static void ContinueMenu() 
        {
            Console.WriteLine("\nPress any key to continue...");
            Console.ReadKey();
        }

        public static UserModel CheckUserLogin(string username, string password)
        {
            return _userService.CheckLogin(username, password);
        }
    }
}
