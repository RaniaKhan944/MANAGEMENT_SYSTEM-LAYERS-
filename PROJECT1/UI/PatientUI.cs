using System;
using System.Collections.Generic;
using MSPROJECT_V1_.Model;
using PROJECT1.Service;

namespace PROJECT1.UI
{
    class PatientUI
    {
        private PatientServices _patientService = new PatientServices();
        private PatientModel Patient_Profile; //save patient data here

        //store this object once and use it
        public PatientUI(string username)
        {
            Patient_Profile = _patientService.FindPatientByName(username);
        }

        public void ShowPatientMenu()
        {
            while (true)
            {
                CommonUI.MainHeader();
                CommonUI.PatientHeader();

                Console.WriteLine("WELCOME" + Patient_Profile.GetName());
                Console.WriteLine("1. VIEW PROFILE");
                Console.WriteLine("2. VIEW SCHEDULE");
                Console.WriteLine("3. LOGOUT");
                Console.Write("OPTION: ");
                string option = Console.ReadLine();

                if (option == "1")
                {
                    //just show our object
                    Console.WriteLine($"NAME: {Patient_Profile.GetName()}");
                    Console.WriteLine($"AGE: {Patient_Profile.GetAge()}");
                    Console.WriteLine($"DIAGNOSIS: {Patient_Profile.GetDiagnosis()}");
                    Console.WriteLine($"FEE: Rs. {Patient_Profile.GetFee()}");
                    CommonUI.ContinueMenu();
                }
                else if (option == "2")
                {
                    //showing only schedule data from the object
                    Console.WriteLine($"YOUR SCHEDULE: {Patient_Profile.GetSchedule()}");
                    CommonUI.ContinueMenu();
                }
                else if (option == "3")
                {
                    break;
                }
            }
        }
    }
}