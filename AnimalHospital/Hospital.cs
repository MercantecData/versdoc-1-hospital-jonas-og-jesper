using System;
using System.Collections.Generic;
using System.Text;

namespace AnimalHospital
{
    class Hospital
    {
        // definere en string med navnet name, som kan blive brugt i koden
        public string name;

        // laver to lister kaldet doctors og patients, som kan blive brugt til at indeholde personer og kan tilgåes alle steder da det er public.
        public List<Patient> patients = new List<Patient>();
        public List<Doctor> doctors = new List<Doctor>();
        

        // laver en public, som er en underdel af classen hospital
        public Hospital(string name)
        {
            this.name = name;
        }

        public void AdmitPatient(Patient patient)
        {
            // tjekker om patients listen indeholder noget værdi som patient indeholder
            if(patients.Contains(patient))
            {
                // skriver en linje i konsollen med navnet på patienten
                Console.WriteLine("Patient already admitted to {0}.", name);
            } else // this patient listen ikke indeholder navnet køres den her
            {
                // tilføjer patient du skrev til patients
                patients.Add(patient);
                // printer en linje i konsollen med navnet på patienten du skrev
                Console.WriteLine("{0} was admitted to {1} successfully", patient.name, name);
            }
        }

        // en public funcktion med Patient som værdi
        public void DischargePatient(Patient patient)
        {
            // this patient listen ikke indeholder navnet køres den her
            if (!patients.Contains(patient))
            {
                Console.WriteLine("Patient not in this hospital");
            }
            else // this patient listen indeholder navnet køres den her
            {
                patients.Remove(patient);
            }
        }

        public Patient FindPatientByName(string name)
        {
            // kører et loop med p som patients
            foreach(var p in patients)
            {
                // tjekker om p som er patients indeholder er det samme som name
                if(p.name == name)
                {
                    return p;
                }
            }
            // afgiver ingen værdi tilbage
            return null;
        }

    }
}
