using System;
using System.Collections.Generic;
using System.IO;
using MSPROJECT_V1_.Model;

namespace MSPROJECT_V1_.Repositories_DA_
{
    class PatientRepo
    {

        private readonly string _filePath = "D:\\UET\\SEMESTER 2\\OOP\\LAB\\PROJECT1\\AllPatientData.txt";


        //loading patient into list and we access list in program because its faster
        private List<PatientModel> LoadPatientFile()
        {
            List<PatientModel> _patients = new List<PatientModel>();
            if (File.Exists(_filePath))
            {

                using (StreamReader reader = new StreamReader(_filePath))
                {
                    string line;
                    while ((line = reader.ReadLine()) != null)
                    {

                        string[] parts = line.Split(',');

                        string name = parts[0];
                        int age = int.Parse(parts[1]);
                        string diagnosis = parts[2];
                        string schedule = parts[3];
                        int fee = int.Parse(parts[4]);


                        PatientModel patient = new PatientModel(name, age, diagnosis, schedule, fee);
                        _patients.Add(patient);

                    }
                }
            }
            return _patients;

        }


        //do i need to use if filepath exists again???
        public void SavePatientToFile(PatientModel p)
        {

            using (StreamWriter writer = new StreamWriter(_filePath))
            {
                writer.WriteLine(p.ToString());
            }
        }




        //return our current list of objects
        public List<PatientModel> GetAllPatients()
        {

            return LoadPatientFile();
        }


        private PatientModel FindByNameInList(List<PatientModel> list, string name)
        {
            foreach (PatientModel p in list)
            {
                if (p.GetName() == name)
                {
                    return p;
                }
            }
            return null;
        }

        public PatientModel FindByName(string name)
        {
            List<PatientModel> paitents = LoadPatientFile();
            return FindByNameInList(paitents, name);
        }


        public bool DeletebyName(string name)
        {
            List<PatientModel> paitents = LoadPatientFile();
            PatientModel patient = FindByNameInList(paitents, name);
            if (patient != null)
            {

                paitents.Remove(patient);

                return true;
            }
            return false;
        }

       
     
    }

}

