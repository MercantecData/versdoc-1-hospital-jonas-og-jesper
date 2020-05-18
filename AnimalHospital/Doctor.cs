using System;
using System.Collections.Generic;
using System.Text;

namespace AnimalHospital
{
    class Doctor
    {
        public string name;
        public string speciality;
        public List<Patient> assignedPatients = new List<Patient>();

        public Doctor(string name, string speciality)
        {
            this.name = name;
            this.speciality = speciality;
        }
    }
}
