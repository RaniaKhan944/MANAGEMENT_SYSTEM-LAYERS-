using System;
using System.Collections.Generic;
using MSPROJECT_V1_.Model; //patientmodel
using PROJECT1.Service; //patientservice
using  PROJECT1.UI;

namespace PROJECT1.UI
{
    class AdminUI
    {
        private PatientServices _patientService = new PatientServices();

        public void ShowAdminMenu()
        {
            while (true)
            {
                CommonUI.MainHeader();
                CommonUI.AdminHeader();
                
                Console.WriteLine("1. SHOW ALL PATIENTS");
                Console.WriteLine("2. ADD PATIENT");
                Console.WriteLine("3. SEARCH PATIENT");
                Console.WriteLine("4. DELETE PATIENT");
                Console.WriteLine("5. LOGOUT");
                Console.Write("CHOOSE OPTION: ");

                string option = Console.ReadLine();

                if (option == "1")
                {
                    ShowAllPatients();
                }
                else if (option == "2")
                {
                    AddPatient();
                }
                else if (option == "3")
                {
                    SearchPatient();
                }
                else if (option == "4")
                {
                    DeletePatient();
                }
                else if (option == "5")
                {
                    break; 
                }
                else
                {
                    Console.WriteLine("INVALID OPTION!");
                    CommonUI.ContinueMenu();
                }
            }
        }

        private void ShowAllPatients()
        {
            CommonUI.MainHeader();
            CommonUI.AdminHeader();
            List<PatientModel> patients = _patientService.GetAllPatients();

            Console.WriteLine("NAME\tAGE\tDIAGNOSIS\tSCHEDULE\tFEE");
            foreach (PatientModel p in patients)
            {
                Console.WriteLine($"{p.GetName()}\t{p.GetAge()}\t{p.GetDiagnosis()}\t{p.GetSchedule()}\t{p.GetFee()}");
            }
            CommonUI.ContinueMenu();
        }

        private void AddPatient()
        {
            CommonUI.MainHeader();
            CommonUI.AdminHeader();
            Console.Write("ENTER NAME: ");
            string name = Console.ReadLine();

            Console.Write("ENTER AGE: ");
            int age = int.Parse(Console.ReadLine());

            if (age < 2 || age > 99)
            {
                Console.WriteLine("INVALID AGE! Must be 2-99.");
                CommonUI.ContinueMenu();
                return;
            }

            Console.Write("ENTER DIAGNOSIS: ");
            string diagnosis = Console.ReadLine();

            Console.Write("ENTER SCHEDULE (MONDAY-FRIDAY): ");
            string schedule = Console.ReadLine();

            _patientService.AddNewPatient(name, age, diagnosis, schedule);
            CommonUI.ContinueMenu();
        }

        private void SearchPatient()
        {
            CommonUI.MainHeader();
            CommonUI.AdminHeader();
            Console.Write("ENTER NAME TO SEARCH: ");
            string name = Console.ReadLine();

            PatientModel p = _patientService.FindPatientByName(name);
            if (p != null)
            {
                Console.WriteLine($"FOUND: {p.GetName()} | Age: {p.GetAge()} | Diag: {p.GetDiagnosis()} | Sched: {p.GetSchedule()} | Fee: {p.GetFee()}");
            }
            else
            {
                Console.WriteLine("PATIENT NOT FOUND.");
            }
            CommonUI.ContinueMenu();
        }

        private void DeletePatient()
        {
            CommonUI.MainHeader();
            CommonUI.AdminHeader();
            Console.Write("ENTER NAME TO DELETE: ");
            string name = Console.ReadLine();

            if (_patientService.DeletePatient(name))
            {
                Console.WriteLine("PATIENT DELETED.");
            }
            else
            {
                Console.WriteLine("PATIENT NOT FOUND.");
            }
            CommonUI.ContinueMenu();
        }
    }
}