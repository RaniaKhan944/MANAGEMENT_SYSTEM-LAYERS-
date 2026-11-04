using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MSPROJECT_V1_.Model; //patient modelclass
using MSPROJECT_V1_.Repositories_DA_; //patient repo

namespace PROJECT1.Service
{
    class PatientServices
    {
        //object to access repo
        private PatientRepo _patientRepo = new PatientRepo();

        public void AddNewPatient(string name, int age, string diagnosis, string schedule)
        {
            PatientModel newPatient = new PatientModel(name, age, diagnosis, schedule); //object of patient

            _patientRepo.SavePatientToFile(newPatient);
            Console.WriteLine("PATIENT ADDED!");
        }




    // to access repo when UI asks. 
        public List<PatientModel> GetAllPatients()
        {
            return _patientRepo.GetAllPatients();
        }

        public PatientModel FindPatientByName(string name)
        {
            return _patientRepo.FindByName(name);
        }

        public bool DeletePatient(string name)
        {
            return _patientRepo.DeletebyName(name);
        }
    }
}
