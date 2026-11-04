using System;
using System.Collections.Generic;
using MSPROJECT_V1_.Model; //patientModel
using PROJECT1.Service; // access service

namespace PROJECT1.UI
{
    class TherapistUI
    {
        private PatientServices _patientService = new PatientServices();
        private TherapistServices _therapistService = new TherapistServices();

        public void TherapistMenu()
        {
            while (true)
            {
                CommonUI.MainHeader();
                CommonUI.TherapistHeader();

                Console.WriteLine("1. SHOW ALL PATIENTS");
                Console.WriteLine("2. SEARCH PATIENT");
                Console.WriteLine("3. CALCULATE SALARY");
                Console.WriteLine("4. LOGOUT");
                Console.Write("CHOOSE OPTION: ");

                string option = Console.ReadLine();

                if (option == "1")
                {
                    ShowAllPatients();
                }
                else if (option == "2")
                {
                    SearchPatient();
                }
                else if (option == "3")
                {
                    CalculateSalary();
                }
                else if (option == "4")
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

        //functions start
        private void ShowAllPatients()
        {
            CommonUI.MainHeader();
            CommonUI.TherapistHeader();

            List<PatientModel> patients = _patientService.GetAllPatients();
            Console.WriteLine("NAME\tAGE\tDIAGNOSIS\tSCHEDULE");

            foreach (PatientModel p in patients)
            {
                //no fee
                Console.WriteLine($"{p.GetName()}\t{p.GetAge()}\t{p.GetDiagnosis()}\t{p.GetSchedule()}");
            }
            CommonUI.ContinueMenu();
        }

        private void SearchPatient()
        {
            CommonUI.MainHeader();
            CommonUI.TherapistHeader();

            Console.Write("ENTER NAME TO SEARCH: ");
            string name = Console.ReadLine();

            PatientModel p = _patientService.FindPatientByName(name);

            if (p != null)
            {
                // no fee
                Console.WriteLine($"FOUND: {p.GetName()} | Age: {p.GetAge()} | Diag: {p.GetDiagnosis()} | Sched: {p.GetSchedule()}");
            }
            else
            {
                Console.WriteLine("PATIENT NOT FOUND.");
            }
            CommonUI.ContinueMenu();
        }

        private void CalculateSalary()
        {
            CommonUI.MainHeader();
            CommonUI.TherapistHeader();

            Console.Write("ENTER NUMBER OF SESSIONS CONDUCTED: ");
            int sessions = int.Parse(Console.ReadLine());

            int salary = _therapistService.CalculateTherapistSalary(sessions);
            Console.WriteLine($"SALARY AFTER TAXES IS: Rs. {salary}");
            CommonUI.ContinueMenu();
        }
    } 
} 