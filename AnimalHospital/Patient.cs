using System;
using System.Collections.Generic;
using System.Text;

namespace AnimalHospital
{
    // Her bliver der oprettede et object som bliver brugt til Patienter
    class Patient
    {
        public string name;
        public int age;
        public Doctor doctor;

        public Patient(string name, int age)
        {
            this.name = name;
            this.age = age;
        }

     // Her bliver der lavet noget i forbindelse med oprettelsen af en Patient i porgram.cs
        public void AdmitTo(Hospital hospital)
        {
            hospital.AdmitPatient(this);
        }
    }
}
