using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSPROJECT_V1_.Model
{
    class PatientModel
    {
        private string Name;
        private int Age;
        private string Diagnosis;
        private string Schedule;
        private int Fee;

        public PatientModel(string name, int age, string diagnosis, string schedule, int fee)
        {
            this.Name = name;
            this.Age = age;
            this.Diagnosis = diagnosis;
            this.Schedule = schedule;
            this.Fee = fee;
        }

        public PatientModel(string name, int age, string diagnosis, string schedule)
        {
            this.Name = name;
            this.Age = age;
            this.Diagnosis = diagnosis;
            this.Schedule = schedule;
            this.Fee = 0;
        }

        public string GetName() { return this.Name; }
        public int GetAge() { return this.Age; }
        public string GetDiagnosis() { return this.Diagnosis; }
        public string GetSchedule() { return this.Schedule; }
        public int GetFee() { return this.Fee; }
        


        public bool SetAge(int age)
        {
            if (age >= 2 && age <= 99)
            {
                return true;
                
            }
            else
            {
                return false;
            }
            
        }

        public override string ToString()
        {
            return $"{GetName()},{GetAge()},{GetDiagnosis()},{GetSchedule()},{GetFee()}";
        }
    }
}