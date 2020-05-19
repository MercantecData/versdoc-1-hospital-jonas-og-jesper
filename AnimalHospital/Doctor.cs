using System;
using System.Collections.Generic;
using System.Text;

namespace AnimalHospital
{
    // definere classen kaldet doctor med public strings og en liste som vil blive brugt andre steder. 
    class Doctor
    {
        public string name;
        public string speciality;
        public List<Patient> assignedPatients = new List<Patient>();

    // overskriver to af de værdierne vi definerede ovenover med nye værdier
        public Doctor(string name, string speciality)
        {
            this.name = name;
            this.speciality = speciality;
        }
    }
}
