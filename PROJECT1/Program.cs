using System;
using MSPROJECT_V1_.Model;
using PROJECT1.Service;
using PROJECT1.UI;

namespace PROJECT1
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                CommonUI.MainHeader();
                Console.WriteLine("1. LOGIN");
                Console.WriteLine("2. EXIT");
                Console.Write("CHOOSE OPTION: ");
                string choice = Console.ReadLine();

                if (choice == "2") break;

                if (choice == "1")
                {
                    UserModel user = null;

                    //3 login attempts
                    for (int idx = 1; idx <= 3; idx++)
                    {
                        
                        CommonUI.MainHeader();
                        Console.WriteLine($"LOGIN ATTEMPT: {idx} of 3");

                        Console.Write("ENTER USERNAME: ");
                        string username = Console.ReadLine();
                        Console.Write("ENTER PASSWORD: ");
                        string password = Console.ReadLine();

                        user = CommonUI.CheckUserLogin(username, password); // get this validated in user service

                        if (user != null)
                        {
                            break; //no more login attemptios
                        }
                        else
                        {
                            Console.WriteLine("\nINVALID CREDENTIALS!");
                            CommonUI.ContinueMenu();
                        }
                    }

                    //if no user still
                    if (user == null)
                    {
                        Console.WriteLine("RETURNING TO MAIN MENU.");
                        CommonUI.ContinueMenu();
                    }
                    else
                    {
                        //login matches
                        if (user.GetRole() == "ADMIN")
                        {
                            AdminUI admin = new AdminUI();
                            admin.ShowAdminMenu();
                        }
                        else if (user.GetRole() == "THERAPIST")
                        {
                            TherapistUI therapist = new TherapistUI();
                            therapist.TherapistMenu();
                        }
                        else if (user.GetRole() == "PATIENT")
                        {
                            PatientUI patient = new PatientUI(user.GetUsername()); //store name here before sending to PatientUI
                            patient.ShowPatientMenu();
                        }
                    }
                }
            }
        }
    }
}