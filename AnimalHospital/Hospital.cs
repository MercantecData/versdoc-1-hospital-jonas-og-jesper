using System;
using System.Collections.Generic;
using System.Text;

namespace AnimalHospital
{
    class Hospital
    {
        public string name;

        public List<Patient> patients = new List<Patient>();
        public List<Doctor> doctors = new List<Doctor>();

        public Hospital(string name)
        {
            this.name = name;
        }

        public void AdmitPatient(Patient patient)
        {
            if(patients.Contains(patient))
            {
                Console.WriteLine("Patient already admitted to {0}.", name);
            } else
            {
                patients.Add(patient);
                Console.WriteLine("{0} was admitted to {1} successfully", patient.name, name);
            }
        }

        public void DischargePatient(Patient patient)
        {
            if(!patients.Contains(patient))
            {
                Console.WriteLine("Patient not in this hospital");
            } else
            {
                patients.Remove(patient);
            }
        }

        public Patient FindPatientByName(string name)
        {
            foreach(var p in patients)
            {
                if(p.name == name)
                {
                    return p;
                }
            }

            return null;
        }
    }
}
